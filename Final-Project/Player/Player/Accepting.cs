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
    public partial class Accepting : Form
    {
        string challengerMsg;
        public string challenger
        {

            set { 
                challengerMsg= value;
                label2.Text = challengerMsg;
            }
        }
        public Accepting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
