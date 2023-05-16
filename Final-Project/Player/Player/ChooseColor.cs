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
    public partial class ChooseColor : Form
    {
        public Color Selected_color { get; set; }
        public ChooseColor()
        {
            InitializeComponent();
        }

        private void Red_Button_Click(object sender, EventArgs e)
        {
            Selected_color = Color.Red;
            Color_Panel.BackColor = Selected_color;


        }

        private void Yellow_Button_Click(object sender, EventArgs e)
        {
            Selected_color = Color.Yellow;
            Color_Panel.BackColor = Selected_color;
        }

        private void Blue_Button_Click(object sender, EventArgs e)
        {
            Selected_color = Color.Indigo;
            Color_Panel.BackColor = Selected_color;
        }

        private void Green_Button_Click(object sender, EventArgs e)
        {
            Selected_color = Color.Green;
            Color_Panel.BackColor = Selected_color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameManger.UpdatePlayer(Selected_color);
            this.DialogResult = DialogResult.OK;
        }


    }
}
