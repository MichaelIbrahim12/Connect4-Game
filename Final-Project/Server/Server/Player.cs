using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Player
    {
        string name;
        string color;
        bool isPlaying = false;
        bool playAgain = false;
        int score = 0;
        Room myRoom = null;
        //player network and streams
        NetworkStream nstream;
        BinaryReader br;
        BinaryWriter bw;
        //player specific task to handle each player requests
        Task playerThread;

        //assign a cancellation token for the task
        public CancellationTokenSource tokenSource = new CancellationTokenSource();
        public CancellationToken ct; //this.tokenSource.Token;


        //class getters and setters
        public string Name { get { return name; } set { name = value; } }
        public string Color { get { return color; } set { color = value; } }
        public bool IsPlaying { get { return isPlaying; } set { isPlaying = value; } }
        public bool PlayAgain { get { return playAgain; } set { playAgain = value; } }
        public int Score { get { return score; } set { score = value; } }
        public Room MyRoom { get { return myRoom; } set { myRoom = value; } }
        public NetworkStream Nstream { get { return nstream; } set { nstream = value; } }
        public BinaryReader Br { get { return br; } set { br = value; } }
        public BinaryWriter Bw { get { return bw; } set { bw = value; } }
        public Task PlayerThread { get { return playerThread; } set { playerThread = value; } }

        public void playerHandling()
        {
            while (true && !ct.IsCancellationRequested)
            {
                string clientRequest = this.br.ReadString();//"310,playerName+color+h+w"
                //parsing the incoming request
                string[] arr = ReadFromClient(clientRequest);//["310", "playerName", "color", "h", "w"]

                string request = arr[0];//"310"
                string color;

                switch (request)
                {
                    case "100":
                        string name = arr[1];
                        Server.checkName(this, name);
                        break;
                    case "210":
                        string lobbyinfo = Server.getPlayer();//210,name+status
                        bw.Write(lobbyinfo);//210,name+status
                        break;
                    case "220":
                        string s = Server.getRooms();
                        this.bw.Write(s);
                        break;
                    case "310":
                        int row, col;
                        string roomName = arr[3];
                        color = arr[2];
                        row = int.Parse(arr[4]);
                        col = int.Parse(arr[5]);
                        Server.createRoom(this, color, roomName, row, col);
                        break;
                    case "320":
                        //320,roomname
                        string RoomName = arr[1];
                        int isJoined = Server.joinRoom(this, RoomName);
                        if (isJoined == -1)
                        {
                            //the player hasn't joined the room
                            bw.Write("320,-1");
                        }
                        break;
                    case "400":
                        color = arr[2];
                        Server.askToPlay(this, color);
                        break;
                    case "405":
                        int responseToPlay = int.Parse(arr[1]);
                        int response = Server.waitToPlay(this, responseToPlay);
                        break;
                    case "410":
                        Server.sendMove(this, int.Parse(arr[1]), int.Parse(arr[2]));
                        break;
                    case "600":
                        int playAgain = int.Parse(arr[1]);
                        Server.playAgain(this, playAgain);
                        break;
                    case "650":
                        Server.leaveRoom(this);
                        break;
                    case "700":
                        Server.disconnectPlayer(this);
                        break;
                }

            }
        }

        public string[] ReadFromClient(string request)
        {
            //when the flag sytax is assigned
            string[] sArr = request.Split(',', '+');//["310", "playerName", "color", "h", "w"]
            return sArr;
        }
    }
}
