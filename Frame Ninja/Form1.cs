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
        private static Leben[] leben = new Leben[5];
        private static CursorTrailNodes[] Cursortrail = new CursorTrailNodes[10];
        private static Point[] mouseTrack = new Point[20];
        private static int visiblenodes = 100;
        private static double velocity = 0;

        private static System.Timers.Timer _delayTimer;

      
        
        public Form1()
        {
            InitializeComponent();

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
        private int Lives = 5;
        private bool alive = true;
        public void Lowerlives()
        {
            Lives--;
            for (int i = 0; i < leben.Length; i++)
            {
                if (leben[i] != null)
                {
                    leben[i].Hide();
                    leben[i] = null;
                }
            }
            for (int i = 0; i < Lives; i++)
            {
                leben[i] = new Leben(this, i);
                leben[i].Show();
            }
            if(Lives == 0)
            {
                alive = false;
                MessageBox.Show("Du hast Verloren");
                System.Windows.Forms.Application.Exit();
            }
        }
        public bool GetLive()
        {
            return alive;
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


        private int startcounter = 399;
        private void StartTimer_Tick(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width / 4;
            this.Height = Screen.PrimaryScreen.Bounds.Height / 4;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width/2-(this.Width/2), Screen.PrimaryScreen.Bounds.Height / 2 - (this.Height / 2)) ;
            label1.Text = "" + startcounter/100;
            if (startcounter == 0)
            {
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
                for (int i = 0; i < leben.Length; i++)
                {
                    leben[i] = new Leben(this, i);
                    leben[i].Show();
                }
                Scoreboard score = new Scoreboard(this);
                score.Show();
                _delayTimer = new System.Timers.Timer(); // was auch immer das macht
                _delayTimer.Interval = 10;
                _delayTimer.Elapsed += ExecuteFunction;
                _delayTimer.AutoReset = true;

                _delayTimer.Start();
                
            }
            if(startcounter < -20)
            {
                this.Opacity = .01;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
                this.Location = new Point(0, 0);
                StartTimer.Enabled = false;
            }
            startcounter--;
        }
        private int score;
        public void Addscore(int amount)
        {
            score += amount;
        }
        public int getScore()
        {
            return score;
        }

    }
}
