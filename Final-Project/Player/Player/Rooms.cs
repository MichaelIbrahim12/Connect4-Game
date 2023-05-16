using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public partial class Rooms : Form
    {
        public static Rooms lobby;
        //create room data 
        public string Roomname_new;
        public int board_hight;
        public int board_width;
        public  Game boardGame;
        public static Game seegamebaord;
        public static Room currentroom;
        public static string newRoom_Name;
        public Color hostColor;
        public static Waiting wait;
        public Spectator Watcher;
        public int selectedCount=0;
        ChooseColor joinGame;



        public string ListBox1Names
        {
            set { Players_ListBox.Items.Add(value); }
        }
        public Rooms()
        {
            InitializeComponent();
            lobby = this;
        }
        public void showplayer()
        {
            Players_ListBox.Items.Clear();
            Player[] playerlist = new Player[GameManger.playerslist.Count];

            for (int i = 0; i < playerlist.Length; i++)
            {
                playerlist[i] = new Player(GameManger.playerslist[i].Name);
                Players_ListBox.Items.Add(playerlist[i].Name);
            }
    
        }


        public void showroom()
        {
            Rooms_ListBox.Items.Clear();

            Room[] roomlist = new Room[GameManger.Rommslist.Count];
            for (int i = 0; i < roomlist.Length; i++)
            {
                roomlist[i] = new Room(GameManger.Rommslist[i].Name, GameManger.Rommslist[i].Host);

                Rooms_ListBox.Items.Add(roomlist[i].Name);

            }
        }

        private void Play_Button_Click(object sender, EventArgs e)
        {
            try
            {
                currentroom = GameManger.Rommslist[Rooms_ListBox.SelectedIndex];
                if (selectedCount == 0) //no room selected
                {
                    MessageBox.Show("Please Select Room First");
                }
                
                else
                {
                    if (GameManger.Rommslist[Rooms_ListBox.SelectedIndex].challenger == null)//&& !GameManger.Rommslist[selected.ElementAt(0)].occupied  
                    {
                        GameManger.SendServerRequest(Flag.joinRoom, GameManger.Rommslist[Rooms_ListBox.SelectedIndex].Name);
                        joinGame = new ChooseColor();
                        var dg = joinGame.ShowDialog();
                        if (dg == DialogResult.OK)
                        {
                            GameManger.SendServerRequest(Flag.asktoplay, GameManger.CurrentPlayer.Name, GameManger.CurrentPlayer.PlayerColor.ToArgb().ToString());
                            wait = new Waiting();
                            wait.Show();

                        }
                    }
                    else
                    {

                        Watcher = new Spectator();
                        var dg = Watcher.ShowDialog();

                        if (dg == DialogResult.OK)
                        {
                            GameManger.SendServerRequest(Flag.joinRoom, GameManger.Rommslist[Rooms_ListBox.SelectedIndex].Name);

                        }
                    }



                }
            }
            catch
            {

                MessageBox.Show("please select a room before \n joining");
            }
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            Create askUser = new Create();
            DialogResult c_Result;
            c_Result = askUser.ShowDialog();
            if(c_Result == DialogResult.OK)
            {               
                board_width = askUser.Cols;
                board_hight = askUser.Rows;
                hostColor = askUser.Selected_color;
                newRoom_Name = askUser.RoomName;
                Rooms_ListBox.Items.Add(newRoom_Name);


                GameManger.SendServerRequest(Flag.createRoom,
                GameManger.CurrentPlayer.Name + "+" + GameManger.CurrentPlayer.PlayerColor.ToArgb().ToString(),
                newRoom_Name, board_width.ToString() + "+" + board_hight.ToString()
    );

                Game.rows = board_width;
                Game.cols = board_hight;
                Game.HostColor =hostColor ;
                Game.ChallangerColor = Color.Purple;
                Game.turn = 1;
                Game.playerTurn = 1;
                currentroom = new Room(Roomname_new, GameManger.CurrentPlayer);
                boardGame = new Game();
                wait = new Waiting();
                wait.Show();



            }
        }

        private void Rooms_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCount++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            showplayer();
            showroom();
        }
    }
}
