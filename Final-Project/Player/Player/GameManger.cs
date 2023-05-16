using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public static class GameManger
    {
        static byte[] ip;
        static int port;
        public static bool connStatues;
        static string UserName;
        static IPAddress ServerIP;
        static TcpClient server;
        static NetworkStream ConnectionStream;
        static BinaryReader br;
        static BinaryWriter bwr;
        public static Task recieve;

        public static List<Player> playerslist;
        public static List<Room> Rommslist;

        public static Player CurrentPlayer;
        public static Room CurrentRoom;

     static GameManger()
        {
            ip =new byte[] {127,0,0,1};
            port = 2555;
            connStatues = false;
            ServerIP = new IPAddress(ip);
            playerslist = new List<Player>();
            Rommslist = new List<Room>();
        }
        public static void Login(string userName)
        {

            try
            {
                TcpClient server = new TcpClient();
                server.Connect(ServerIP, port);
                ConnectionStream = server.GetStream();
                br = new BinaryReader(ConnectionStream);
                bwr = new BinaryWriter(ConnectionStream);

                SendServerRequest(Flag.sendLoginInfo, userName);
                UserName = userName;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void SendServerRequest(Flag flag, params string[] data)
        {
            var f = (int)flag;//310
            string msg = f.ToString();//"310"

            if (data.Length > 0)
            {
                foreach (var item in data)
                {
                    msg += "," + item;
                }
            }

            bwr.Write(msg);//"310,playerName+color+height+width"

        }
        public static bool isloginSuc(string userName)
        {

            var msg = br.ReadString();//100,1
            var msgArray = msg.Split(',');//["100","1"]
            Flag flag = (Flag)int.Parse(msgArray[0]);
            var data = msgArray.ToList();
            data.RemoveAt(0);//["1"]
            if (data.ElementAt(0) == "1")
            {
                UserName = userName;
                connStatues = true;
                return true;
            }
            else
            {
                MessageBox.Show("Name already taken");

                return false;
            }
        }
        public static List<Player> Getplayers(List<string> data)//["name+status"]
        {
            var players = new List<Player>();

            foreach (var item in data)
            {
                var name = item.Split('+')[0];//["name","status"]
                bool isplaying = bool.Parse(item.Split('+')[1]);
                players.Add(new Player(name, isplaying));
            }
            return players;
        }
        public static List<Room> GetRooms(List<string> data)
        {
            var rooms = new List<Room>();

            foreach (var item in data)
            {
                var rom = item.Split('+');
                var roomName = rom[0];
                var host = rom[1].Split('-');
                var addedRoom = new Room(roomName, new Player(host[0]));
                if (rom.Length == 3)
                {
                    addedRoom.challenger = new Player(rom[2].Split('-')[0]);
                }
                rooms.Add(addedRoom);
            }
            return rooms;
        }
        public static void UpdatePlayer(Color colorName)
        {
            var currPlayer = new Player(UserName);

            currPlayer.PlayerColor = colorName;

            CurrentPlayer = currPlayer;
        }
        public static Room UpdateRoom(List<string> data)
        {
            var currroom = new Room(data[0], new Player(data[1]));

            return currroom;
        }
        public static void ReceiveServerRequest()
        {
            var msg = br.ReadString();

            var msgArray = msg.Split(',');
            Flag flag = (Flag)int.Parse(msgArray[0]);
            var data = msgArray.ToList();
            data.RemoveAt(0);

            switch (flag)
            {
                case Flag.getPlayers:
                    playerslist = Getplayers(data);
                    Rooms.lobby.Invoke(new MethodInvoker(delegate ()
                    {
                        Rooms.lobby.showplayer();
                    }));
                    break;

                case Flag.getRooms:
                    Rommslist = GetRooms(data);
                    Rooms.lobby.Invoke(new MethodInvoker(delegate ()
                    {
                        Rooms.lobby.showroom();
                    }));
                    break;

                case Flag.waittopaly:
                    //care if the owner refused he return 405,0 so it throws exception 
                    playgame(data.ElementAt(0), data.ElementAt(1), data.ElementAt(2)); // if 405,1: hide or open gamebaord     else 405,0:close choose color host didnt accpet
                    break;
                case Flag.createRoom:
                    break;
                case Flag.joinRoom:
                    if (data.ElementAt(0) == "2")
                    {
                        joinASspectator(data.ElementAt(1), data.ElementAt(2), data.ElementAt(3));
                    }

                    break;
                case Flag.SendMove:
                    Game.turn = int.Parse(data.ElementAt(0));
                    data.RemoveAt(0);
                    updateBoard(data);
                    break;
                case Flag.updateBoard:
                    break;
                case Flag.asktoplay:
                    //"400, askingPlayer.Name + askingPlayer.Color"
                    acceptTheChallenger(data[0]);
                    Game.ChallangerColor = Color.FromArgb(Int32.Parse(data[0].Split('+')[1]));
                    Game.ChallangerBrush = new SolidBrush(Game.ChallangerColor);
                    break;
                case Flag.gameResult:
                    showWinningMesg(data);
                    break;
                default:
                    break;
            }
            ReceiveServerRequest();

        }
        private static void updateBoard(List<string> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                var rowstring = data.ElementAt(i);
                var row = rowstring.Split('+');
                for (int j = 0; j < row.Length; j++)
                {

                    Game.currntGameboard.board[i, j] = int.Parse(row[j]);

                }

            }
            if (Game.currntGameboard.Visible)
            {
                Game.currntGameboard.BeginInvoke(new MethodInvoker(delegate () {

                    Game.currntGameboard.repaintBord();
                }));

            }


        }
        private static void acceptTheChallenger(string data)
        {
            //pop up a menu asking the room owner if he wants the challenger to play or not

            Accepting dlg = new Accepting();
            string[] arr = data.Split('+');
            dlg.challenger = $"{arr[0]} Wants To Challange You ";
            DialogResult ownerResponse = dlg.ShowDialog();
            //if the owner accepts
            if (ownerResponse == DialogResult.OK)
            {
                SendServerRequest(Flag.waittopaly, "1");
                Rooms.lobby.Invoke(new MethodInvoker(delegate ()
                {
                    MessageBox.Show($"  You are currently playing against: {arr[0]}");
                    Rooms.wait.Close();
                    Rooms.lobby.boardGame.Show();

                }));
            }
            else
            {
                SendServerRequest(Flag.waittopaly, "0");
            }
        }
        private static void showWinningMesg(List<string> data)
        {

            switch (data[0])
            {
                case "0":
                    Game.currntGameboard.Invoke(new MethodInvoker(delegate ()
                    {
                        GameResult.result = 0;
                        Game.winOrLose= new GameResult ();
                        Game.winOrLose.ShowDialog();


                    }));
                    break;
                case "1":
                    Game.currntGameboard.Invoke(new MethodInvoker(delegate ()
                    {
                        GameResult.result = 1;
                        Game.winOrLose = new GameResult ();
                        Game.winOrLose.ShowDialog();

                    }));
                    break;
                case "-1":
                    Game.currntGameboard.Invoke(new MethodInvoker(delegate ()
                    {
                        GameResult.result = -1;
                        GameResult.winner = data[1];
                        Game.winOrLose= new GameResult();
                        Game.winOrLose.ShowDialog();

                    }));
                    break;
                default:
                    break;
            }
        }
        private static void joinASspectator(string hostColor, string ChallngerColor, string size)
        {
            var sizear = size.Split('+');
            Rooms.lobby.Invoke(new MethodInvoker(delegate ()
            {

                MessageBox.Show("You are Now Watching The Game");
                Game.cols = int.Parse(sizear[1]);
                Game.rows = int.Parse(sizear[0]);
                Game.HostColor = Color.FromArgb(Int32.Parse(hostColor));
                Game.ChallangerColor = Color.FromArgb(Int32.Parse(ChallngerColor));
                Game.turn = 0;
                Game.playerTurn = 3;

                Rooms.seegamebaord = new Game();
                Rooms.seegamebaord.Show();
            }));
        }
        private static void playgame(string response, string size, string hostcolor)
        {
            if (int.Parse(response) == 1)
            {
                var sizear = size.Split('+');
                Rooms.lobby.Invoke(new MethodInvoker(delegate ()
                {
                    Rooms.wait.Close();
                    MessageBox.Show("the owner has accepted you!");
                    Game.cols = int.Parse(sizear[1]);
                    Game.rows = int.Parse(sizear[0]);
                    Game.HostColor = Color.FromArgb(Int32.Parse(hostcolor));
                    Game.ChallangerColor = CurrentPlayer.PlayerColor;
                    Game.turn = 1;
                    Game.playerTurn = 2;


                    Rooms.seegamebaord = new Game();
                    Rooms.seegamebaord.Show();
                }));



            }

            else
            {
                Rooms.lobby.Invoke(new MethodInvoker(delegate ()
                {
                    MessageBox.Show("the owner has rejected you!");
                    Rooms.currentroom = null;


                    Rooms.seegamebaord.Close();
                }));

            }
        }


    }
    

    public class Player
    {
        public string Name { get; set; }
        public bool isplaying { get; set; }
        public Color PlayerColor { get; set; }

        public Player(string name, bool isPlaying)
        {
            Name = name;
            this.isplaying = isPlaying;
        }
        public Player(string name)
        {
            Name = name;
            this.isplaying = isplaying;
        }
    }
    public class Room
    {
        public string Name { get; set; }
        public Player Host { get; set; }

        public Player challenger { get; set; }
        public Player[] inspectors { get; set; }
        public bool occupied = false;

        public Room(string name, Player host)
        {
            Name = name;
            Host = host;
        }
    }
        public enum Flag
        {
            sendLoginInfo = 100,
            getPlayers = 210,
            getRooms = 220,
            createRoom = 310,
            joinRoom = 320,
            asktoplay = 400,
            waittopaly = 405,
            SendMove = 410,
            updateBoard = 420,
            gameResult = 500,
            playAgain = 600,
            leaveRoom = 650,
            disconnect = 700
        }
}

