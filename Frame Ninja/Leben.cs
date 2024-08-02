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
    public partial class Leben : Form
    {
        Form1 form;
        private int nummer;
        public Leben(Form1 fo, int number)
        {
            InitializeComponent();
            form = fo;
            nummer = number+1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void setuptimer_Tick(object sender, EventArgs e)
        {
                this.Location = new Point((this.Width/2)*nummer-(this.Width/2)+10, 10);
                setuptimer.Enabled = false;
        }
    }
}
