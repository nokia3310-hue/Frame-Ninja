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
        public static Fruit[] Mainfruit = new Fruit[20];
//<<<<<<< HEAD
        
        public static CursorTrailNodes[] Cursortrail = new CursorTrailNodes[10];
        public static Point[] mouseTrack = new Point[20];
        public static Fruit[] Mainfred = new Fruit[5];
        public static int visiblenodes = 100;


        public static System.Timers.Timer _delayTimer;
//=======
        //public static CursorTrailNodes[] Cursortrail = new CursorTrailNodes[10];
        //public Point[] mouseTrack = new Point[20];
//>>>>>>> 0364cb2aa2877f2ceb106796b067529ed070ec85
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

            _delayTimer = new System.Timers.Timer(); // was auch immer das macht
            _delayTimer.Interval = 10; 
            _delayTimer.Elapsed += ExecuteFunction; 
            _delayTimer.AutoReset = true; 

//<<<<<<< HEAD
           
            _delayTimer.Start();
            
        }

        public static double velocity = 0;

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

            Console.WriteLine("vel " + vel);
            double n = velocity / 10;
            visiblenodes = (int)(n > Cursortrail.Length-1 ? Cursortrail.Length-1 : n);



//=======
            /*Thread vt = new Thread(new ThreadStart(velocitycycle));
            vt.Start();*/
//>>>>>>> 0364cb2aa2877f2ceb106796b067529ed070ec85
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
        
    }
}
