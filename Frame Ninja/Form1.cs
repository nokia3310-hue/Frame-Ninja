using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frame_Ninja
{
    public partial class Form1 : Form
    {
        public static Fruit[] Mainfruit = new Fruit[20];
        public static CursorTrailNodes[] Cursortrail = new CursorTrailNodes[100];
        public Point[] mouseTrack = new Point[20];
        public Form1()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;

            for (int i = 0; i < Mainfruit.Length; i++)
            {
<<<<<<< HEAD
                Mainfruit[i] = new Fruit(this);
=======
                Mainfruit[i] = new Fruit(this, i);
>>>>>>> ff9fcc324f8d24c3b3cfce44604f9533b23ce02e
                Mainfruit[i].Show();
            }
            for (int i = 0; i < Cursortrail.Length; i++)
            {
                Cursortrail[i] = new CursorTrailNodes(this, i);
                Cursortrail[i].Show();
            }


            Thread vt = new Thread(new ThreadStart(velocitycycle));
            vt.Start();
        }

        private void velocitycycle()
        {
            while(true)
            {
                for(int i = mouseTrack.Length-1; i > 0; i--)
                {
                    
                    mouseTrack[i] = mouseTrack[i - 1];
                    mouseTrack[0] = Cursor.Position;

                    Mainfruit[i].Location = mouseTrack[i];
                }

                Thread.Sleep(100);
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
