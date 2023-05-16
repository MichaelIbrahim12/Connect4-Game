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
    public partial class Start : Form
    {
        Rooms rooms;
        string playerName;
        private bool firstLogin=true;
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (Name_TextBox.Text=="")
            {
                MessageBox.Show("please Enter Your Name ");

            }
            else
            {
                playerName= Name_TextBox.Text;
                try
                {
                    if (firstLogin)
                    {
                        GameManger.Login(playerName);
                        firstLogin= false;

                        try
                        {
                            if (GameManger.isloginSuc(playerName))
                            {
                                MessageBox.Show("connected with server");
                                rooms = new Rooms();
                                rooms.ListBox1Names = playerName;
                                GameManger.recieve = new Task(GameManger.ReceiveServerRequest);
                                GameManger.recieve.Start();

                                GameManger.SendServerRequest(Flag.getPlayers);
                                GameManger.SendServerRequest(Flag.getRooms);
                                rooms.Show();
                                this.Hide();
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                }
                catch ( Exception ex)
                {
                    MessageBox.Show("Server is Offline");
                }
            }    

        }
    }
}
