using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Server
{
    public partial class Server : Form
    {
        //server variables
        byte[] bt = new byte[] { 127, 0, 0, 1 };
        IPAddress address;
        TcpListener server;
        Socket connection;

        //players and rooms lists
        static List<Player> Allplayers = new List<Player>();
        static List<Room> allRooms = new List<Room>();


        //requests enum
        public enum request
        {
            receiveLoginInfo = 100,
            getPlayers = 210,
            getRooms = 220,
            createRoom = 310,
            joinRoom = 320,
            askToplay = 400,
            waitToPlay = 405,
            SendMove = 410,
            updateBoard = 420,
            gameEnded = 500,
            disconnectPlayer = 700
        }

        public Server()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //start server button and its task function
        private void Start_Button_Click(object sender, EventArgs e)
        {
            Task acceptingClients = new Task(NewClientListener);
            acceptingClients.Start();
        }
        public void NewClientListener()
        {
            address = new IPAddress(bt);
            server = new TcpListener(address, 2555);
            server.Start();

            MessageBox.Show("server started");

            while (true)
            {
                //start connection
                connection = server.AcceptSocket();
                //create new player
                Player tempPlayer = new Player();

                //assign the player member variables for stream
                tempPlayer.Nstream = new NetworkStream(connection);
                tempPlayer.Br = new BinaryReader(tempPlayer.Nstream);
                tempPlayer.Bw = new BinaryWriter(tempPlayer.Nstream);

                //assigning the cancellation token
                tempPlayer.ct = tempPlayer.tokenSource.Token;


                //launch the thread of the new player
                tempPlayer.PlayerThread = new Task(tempPlayer.playerHandling, tempPlayer.tokenSource.Token);
                tempPlayer.PlayerThread.Start();


            }
        }

        //login Name request
        public static void checkName(Player tempPlayer, string requestedName)
        {
            bool exists = false;
            foreach (Player p in Allplayers)
            {
                if (p.Name == requestedName)
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                tempPlayer.Name = requestedName;
                //adding the player to the players list
                Allplayers.Add(tempPlayer);
                tempPlayer.Bw.Write("100,1");
                foreach (var player in Allplayers)
                {
                    player.Bw.Write(getPlayer());
                }
            }
            else
            {
                tempPlayer.Bw.Write("100,0");
            }
        }

        //send the online players and rooms to the connected client
        //get players
        public static string getPlayer()
        {
            string lobbyinfo = "210";
            foreach (Player p in Allplayers)
            {
                lobbyinfo += "," + p.Name + "+" + p.IsPlaying;
            }
            return lobbyinfo;//210,name+status
        }
        //get rooms
        public static string getRooms()
        {
            string roomsData = "220";
            foreach (Room r in allRooms)
            {
                roomsData += "," + r.RoomName;//["220", "room1", "room2"...]
                foreach (Player p in r.RoomPlayers)
                {
                    roomsData += "+" + p.Name + "-" + p.IsPlaying + "-" + p.Color;
                }
            }
            return roomsData;
        }

        //create a room request
        public static void createRoom(Player roomOwner, string Color, string roomName, int row, int col)
        {
            Room tempRoom = new Room(roomOwner, roomName, row, col);
            roomOwner.MyRoom = tempRoom;
            roomOwner.Color = Color;
            allRooms.Add(tempRoom);

            foreach (var player in Allplayers)
            {
                player.Bw.Write(getRooms());
            }
            foreach (var player in Allplayers)
            {
                player.Bw.Write(getPlayer());
            }
        }

        //joining the room
        public static int joinRoom(Player askingPlayer, string roomName)
        {
            int retVal = -1;
            Room requestedRoom = null;
            bool isFound = false;
            for (var i = 0; i < allRooms.Count && !isFound; i++)
            {
                if (allRooms[i].RoomName == roomName)
                {
                    requestedRoom = allRooms[i];
                    isFound = true;
                }
            }
            //the requested room is found 
            if (isFound == true)
            {
                //check if the player is gonna be playing or watching
                if (requestedRoom.RoomPlayers.Count == 1)
                {
                    //the player has joined the room as a player
                    //the player will play
                    askingPlayer.IsPlaying = true;
                    requestedRoom.RoomPlayers.Add(askingPlayer);
                    askingPlayer.MyRoom = requestedRoom;
                    askingPlayer.Bw.Write("320,1");
                }
                else
                {
                    //the player will join as a spectator
                    requestedRoom.RoomPlayers.Add(askingPlayer);
                    askingPlayer.MyRoom = requestedRoom;
                    retVal = 2;
                    askingPlayer.Bw.Write($"320,2,{requestedRoom.RoomPlayers[0].Color},{requestedRoom.RoomPlayers[1].Color},{requestedRoom.Rows}+{requestedRoom.Cols}");
                }
                foreach (var player in Allplayers)
                {
                    player.Bw.Write(getRooms());
                }
                foreach (var player in Allplayers)
                {
                    player.Bw.Write(getPlayer());
                }
            }
            return retVal;
        }


        //ask the room owner to play
        public static void askToPlay(Player askingPlayer, string Color)
        {
            Room currentRoom = askingPlayer.MyRoom;
            Player roomOwner = currentRoom.RoomPlayers[0];
            askingPlayer.Color = Color;
            string askingstr = "400," + askingPlayer.Name + "+" + askingPlayer.Color;
            roomOwner.Bw.Write(askingstr);
        }
        //responding to the player asing to play
        public static int waitToPlay(Player roomOwner, int response)
        {
            Room currentRoom = roomOwner.MyRoom;
            Player askingPlayer = currentRoom.RoomPlayers[1];
            int retVal = -1;

            if (response == 1)
            {
                //if the room owner accepted
                askingPlayer.Bw.Write($"405,1,{currentRoom.Rows}+{currentRoom.Cols},{roomOwner.Color}");
                retVal = 1;
            }
            else
            {
                //the room owner refused 
                askingPlayer.Bw.Write("405,0,0,0");
                //remove the room refrence from the player
                askingPlayer.MyRoom = null;
                //restore the player's score to 0 and is playing to false
                askingPlayer.Score = 0;
                askingPlayer.IsPlaying = false;
                //remove this player from the room
                currentRoom.RoomPlayers.Remove(askingPlayer);
                //return the room turn to the owner if the challenger is kicked out
                currentRoom.PlayerTurn = 1;
                //remove all audience
                int roomPlayersCount = currentRoom.RoomPlayers.Count;
                for (int i = 1; i < roomPlayersCount; i++)
                {
                    currentRoom.RoomPlayers[i].MyRoom = null;
                }
                for (int i = 1; i < roomPlayersCount; i++)
                {
                    currentRoom.RoomPlayers.RemoveAt(1);
                }
                foreach (var player in Allplayers)
                {
                    player.Bw.Write(getRooms());
                }
                foreach (var player in Allplayers)
                {
                    player.Bw.Write(getPlayer());
                }
            }


            return retVal;
        }


        //send the move from one player to all the other in the room and check if this move win
        //send move
        public static void sendMove(Player moveSender, int x, int y)
        {
            Room currentRoom = moveSender.MyRoom;
            //change the room player turn & change the fill board according to the player turn
            currentRoom.Board[x, y] = (currentRoom.PlayerTurn == 1) ? 1 : 2;
            int winnerPlayer = currentRoom.checkWin(currentRoom.PlayerTurn);
            currentRoom.PlayerTurn = (currentRoom.PlayerTurn == 1) ? 2 : 1;
            //update the room board and send it to all the room players
            updateBoared(currentRoom);
            if (winnerPlayer == 1 || winnerPlayer == 2)
            {
                endGame(moveSender);
            }
            updateBoared(currentRoom);
        }
        //update the Board in all the room members
        public static void updateBoared(Room currentRoom)
        {
            //parse the room board and sent it to all the room players
            //410,2,0+1+0+2+0,0+1+0+2+0
            string updateStr = $"410,{currentRoom.PlayerTurn},";
            for (int row = 0; row < currentRoom.Rows; row++)
            {
                for (int col = 0; col < currentRoom.Cols; col++)
                {
                    if (col < currentRoom.Cols - 1)
                        updateStr += currentRoom.Board[row, col] + "+";
                    else
                        updateStr += currentRoom.Board[row, col];
                }
                if (row < currentRoom.Rows - 1)
                    updateStr += ",";
            }
            foreach (Player p in currentRoom.RoomPlayers)
            {
                p.Bw.Write(updateStr);
            }
        }
        //End game if a player has won in this move
        public static void endGame(Player winner)
        {
            Room currentRoom = winner.MyRoom;
            int winnerIndex = currentRoom.RoomPlayers.IndexOf(winner);
            Player loser;
            //assigning the loser player
            if (winnerIndex == 0)
            {
                loser = currentRoom.RoomPlayers[1];
            }
            else
            {
                loser = currentRoom.RoomPlayers[0];
            }
            //sending the end game response 
            for (var i = 0; i < currentRoom.RoomPlayers.Count; i++)
            {
                Player currentPlayer = currentRoom.RoomPlayers[i];
                if (currentPlayer.Name == winner.Name)
                {
                    currentPlayer.Bw.Write("500,1");
                    currentPlayer.Score++;
                }
                else if (currentPlayer.Name == loser.Name)
                {
                    currentPlayer.Bw.Write("500,0");
                }
                else
                {
                    currentPlayer.Bw.Write("500,-1," + winner.Name);
                }
            }
            //clearing the room board
            for (int i = 0; i < currentRoom.Board.GetLength(0); i++)
            {
                for (int j = 0; j < currentRoom.Board.GetLength(1); j++)
                {
                    currentRoom.Board[i, j] = 0;
                }
            }
            //return the turn to the winning player if they played again
            currentRoom.PlayerTurn = (currentRoom.PlayerTurn == 1) ? 2 : 1;
        }


        //play again after one has win or lose and save the score to the server text file
        public static void playAgain(Player moveSender, int PlayAgain)
        {
            //600,1 sending player wants to play again
            Room currentRoom = moveSender.MyRoom;
            if (currentRoom.GameEnded == 0)//the other player havn't responded yet
            {
                //check the response of the move sender
                currentRoom.GameEnded++;
                if (PlayAgain == 1)
                {
                    moveSender.PlayAgain = true;
                }
            }
            else //the other player has already sent the response
            {
                if (PlayAgain == 1)
                {
                    moveSender.PlayAgain = true;
                }
                if (currentRoom.RoomPlayers[0].Name == moveSender.Name)//the move sender is the room owner
                {
                    Player guestPlayer = currentRoom.RoomPlayers[1];
                    if (moveSender.PlayAgain)//the room owner wants to play again
                    {
                        //check the guest
                        if (guestPlayer.PlayAgain)//the guest wants to play also
                        {
                            Server.updateBoared(currentRoom);
                        }
                        else//the guest doesn't want to play so kick him out
                        {
                            currentRoom.RoomPlayers[1].PlayAgain = false;
                            saveGameToFile(currentRoom);
                            waitToPlay(moveSender, 0);
                        }
                    }
                    else//the room owner doesn't want to play again
                    {
                        currentRoom.RoomPlayers[1].PlayAgain = false;
                        saveGameToFile(currentRoom);
                        waitToPlay(moveSender, 0);
                    }

                }
                else //the second responder is the guest
                {
                    Player roomOwner = currentRoom.RoomPlayers[0];
                    if (moveSender.PlayAgain)//the guest wants to play again
                    {
                        //check the guest
                        if (roomOwner.PlayAgain)//the room owner wants to play also
                        {
                            Server.updateBoared(currentRoom);
                        }
                        else//the room owner doesn't want to play so kick the guest out
                        {
                            currentRoom.RoomPlayers[1].PlayAgain = false;
                            saveGameToFile(currentRoom);
                            waitToPlay(moveSender, 0);
                        }
                    }
                    else
                    {
                        currentRoom.RoomPlayers[1].PlayAgain = false;
                        saveGameToFile(currentRoom);
                        waitToPlay(moveSender, 0);
                    }
                }
                //restore the default settings
                currentRoom.GameEnded = 0;
                currentRoom.RoomPlayers[0].PlayAgain = false;
                currentRoom.Board = new int[currentRoom.Rows, currentRoom.Cols];
            }
        }
        public static void saveGameToFile(Room room)
        {
            //Player2 name “value”, Player2 name “value” date of the game

            DirectoryInfo dir = new DirectoryInfo(".");
            string path = @dir.FullName + "\\scoreSheet.txt";
            StreamWriter Sw = File.AppendText(path);
            Sw.WriteLine($"player1: {room.RoomPlayers[0].Name}, Score: {room.RoomPlayers[0].Score}, player2: {room.RoomPlayers[1].Name}, score: {room.RoomPlayers[1].Score}, Date: {DateTime.Now.ToString()}");
            Sw.Close();
        }

        //if the room owner wants to leave the room and go to the lobby again
        public static void leaveRoom(Player player)
        {
            if (player.MyRoom != null && player.MyRoom.RoomPlayers.Count < 2)
            {
                if (player.MyRoom.RoomPlayers[0].Name == player.Name)
                {
                    Room currentRoom = player.MyRoom;
                    player.MyRoom = null;
                    player.Score = 0;
                    player.IsPlaying = false;
                    currentRoom.RoomPlayers.Remove(player);
                    allRooms.Remove(currentRoom);
                    foreach (var p in Allplayers)
                    {
                        p.Bw.Write(getRooms());
                    }
                    foreach (var p in Allplayers)
                    {
                        p.Bw.Write(getPlayer());
                    }
                }
            }
        }
        //when the player wants to logout of the game
        public static void disconnectPlayer(Player player)
        {
            //close all the player's streams, writer and reader
            player.Br.Close();
            player.Bw.Close();
            player.Nstream.Close();
            //dispose the player's thread
            player.tokenSource.Cancel();
            //remove the player from the players list 
            Allplayers.Remove(player);
            foreach (var p in Allplayers)
            {
                p.Bw.Write(getPlayer());
            }
        }


        //updating the roomList in the server GUI
        public void UpdateList()
        {
            Rooms_ListBox.Items.Clear();
            for (int i = 0; i < allRooms.Count; i++)
            {
                //if there are players in the room
                if (allRooms[i].RoomPlayers.Count != 0)
                {
                    Rooms_ListBox.Items.Add(allRooms[i].RoomName);
                    foreach (Player p in allRooms[i].RoomPlayers)
                    {
                        Rooms_ListBox.Items.Add("    " + p.Name);
                    }
                }
                else
                {
                    Rooms_ListBox.Items.Remove(allRooms[i]);
                }
            }
            Players_ListBox.Items.Clear();
            foreach (Player p in Allplayers)
            {
                Players_ListBox.Items.Add(p.Name + " Online");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
