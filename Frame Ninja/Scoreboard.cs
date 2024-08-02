using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frame_Ninja
{
    public partial class Scoreboard : Form
    {
        Form1 form;
        
        public Scoreboard(Form1 fo)
        {
            InitializeComponent();
            form = fo;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Score: " + form.getScore();
        }

        private void StartupTimer_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(10,70);
            StartupTimer.Enabled = false;
        }
    }
}
