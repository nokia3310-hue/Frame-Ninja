using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Frame_Ninja
{
    public partial class Form1 : Form
    {
        private static Fruit[] Mainfruit = new Fruit[20];
        private static CursorTrailNodes[] Cursortrail = new CursorTrailNodes[10];
        private static Point[] mouseTrack = new Point[20];
        private static int visiblenodes = 100;
        private static double velocity = 0;

        private static System.Timers.Timer _delayTimer;

        public Form1()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

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

            _delayTimer = new System.Timers.Timer(); // was auch immer das macht
            _delayTimer.Interval = 10; 
            _delayTimer.Elapsed += ExecuteFunction; 
            _delayTimer.AutoReset = true; 
           
            _delayTimer.Start();
            
        }

        

        private static void ExecuteFunction(object sender, ElapsedEventArgs e)
        {
            double vel = 0;
            
            for(int i = mouseTrack.Length-1; i > 0; i--)
            {
                    
                mouseTrack[i] = mouseTrack[i - 1];
                if(mouseisdown)
                {
                    mouseTrack[0] = Cursor.Position;
                }

            }

            for(int i = 0; i < mouseTrack.Length-2; i++)
            {
                vel += Math.Sqrt(Math.Pow(mouseTrack[i+1].X - mouseTrack[i].X, 2) + Math.Pow(mouseTrack[i+1].Y - mouseTrack[i].Y, 2));
            }

            velocity = vel;

            double n = velocity / 10;
            visiblenodes = (int)(n > Cursortrail.Length-1 ? Cursortrail.Length-1 : n);
        }

        private static bool mouseisdown;
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

        public CursorTrailNodes[] getCursortrail()
        {
            return Cursortrail;
        }

        public int getVisiblenodes()
        {
            return visiblenodes;
        }

    }
}
