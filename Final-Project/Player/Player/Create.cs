using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Player
{
    public partial class Create : Form
    {
         int cols;
         int rows;
        public Color Selected_color { get; set; }

        public int Cols
        {
            get
            {
                if (R_5x6.Checked == true)
                {
                    cols = 6;

                }
                else if (R_6x7.Checked == true)
                {
                    cols = 7;
                }
                else if (R_7x8.Checked == true)
                {
                    cols = 8;
                }
                return cols;
            }
            set
            {
                cols = value;
                if (cols == 6)
                {
                    R_5x6.Checked = true;
                }
                else if (cols == 7)
                {
                    R_6x7.Checked = true;
                }
                else if (cols == 8)
                {
                    R_7x8.Checked = true;
                }
            }
        }
        public int Rows
        {
            get
            {
                if (R_5x6.Checked == true)
                {
                    rows = 5;

                }
                else if (R_6x7.Checked == true)
                {
                    rows = 6;
                }
                else if (R_7x8.Checked == true)
                {
                    rows = 7;
                }
                return cols;
            }
            set
            {
                rows=value;
                if (rows == 5)
                {
                    R_5x6.Checked = true;
                }
                else if (rows == 6)
                {
                    R_6x7.Checked = true;
                }
                else if (rows == 7)
                {
                    R_7x8.Checked = true;
                }
            }
            
    }
        public string RoomName
        {

            get { return textBox1.Text; }
            
        }
  
        public Create()
        {
            InitializeComponent();
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (RoomName == "")
            {
                MessageBox.Show("Please Enter Room Name");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                GameManger.UpdatePlayer(Selected_color);
                this.Close();
                
            }

           
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Red_Button_Click(object sender, EventArgs e)
        {
            Selected_color = Color.Red;
            Color_Panel.BackColor= Selected_color;
            
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
    }
}
