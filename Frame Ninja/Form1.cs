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
    public partial class Form1 : Form
    {
        private Fruit[] Mainfruit = new Fruit[20];
        private CursorTrailNodes[] Cursortrail = new CursorTrailNodes[100];
        public Form1()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;

            for (int i = 0; i < Mainfruit.Length; i++)
            {
                Mainfruit[i] = new Fruit(this, i);
                Mainfruit[i].Show();
            }
            for (int i = 0; i < Cursortrail.Length; i++)
            {
                Cursortrail[i] = new CursorTrailNodes(this, i);
                Cursortrail[i].Show();
            }
        }
        private bool mouseisdown;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseisdown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseisdown = false;
        }
        public bool Getmousestate()
        {
            return mouseisdown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
