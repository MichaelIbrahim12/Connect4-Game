using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public partial class GameResult : Form
    {
        public static int result;
        public static string winner;
        public GameResult()
        {
            InitializeComponent();
            ShowWinner();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void ShowWinner()
        {
            if (result == 1)
            {
                label1.Text = "Congratulations you Won the Game";
            }
            else if (result == 0)
            {
                label1.Text = "   Game Over you Lose the Game";

            }

            else if (result == -1)
            {
                 label1.Text = $"Game Over and {winner} was the Winner";

                  button1.Text = "Watch Next Game";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (result == -1)
            {
                this.Close();
 
            }
            else
            {
                GameManger.SendServerRequest(Flag.playAgain, "1");
                DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (result == -1)
            {
                //if the player is spectator
                Game.currntGameboard.Close();
                DialogResult = DialogResult.Cancel;

            }
            else
            {

                // is host or challanger

                if (Rooms.currentroom.Host.Name != GameManger.CurrentPlayer.Name)//if the challanger closed the game
                {
                    GameManger.SendServerRequest(Flag.playAgain, "0");
                    Game.currntGameboard.Close();
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    Rooms.wait = new Waiting();
                    Rooms.wait.Show();
                    GameManger.SendServerRequest(Flag.playAgain, "0");
                    DialogResult = DialogResult.Cancel;
                }

            }
        }
    }
}
