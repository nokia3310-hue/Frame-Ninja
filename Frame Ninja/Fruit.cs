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
    public partial class Fruit : Form
    {
        //setup
        Form1 form;
        Random randy = new Random();
        private int counterms;
        private int countersek;
        private int MovementSlowness = 2;
        private int number;
        private double[] Momentum = new double[2];//momentum[0] = x   ;   momentum[1] = y
        private bool isSpawned = false;
        private Splitfruit[] splittie= new Splitfruit[1];
        private Splitfruit[] Bombensplittie = new Splitfruit[4];

        public Fruit(Form1 fo, int Number)
        {
            InitializeComponent();
            form = fo;
            timer1.Interval = 2;
            this.BackColor = Color.FromArgb(randy.Next(70, 255), randy.Next(70, 255), randy.Next(70, 255));
            number = Number;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height + 100);
        }
        //initial spawner
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2), Screen.PrimaryScreen.Bounds.Height + 100);
            timer2.Enabled = false;
        }

        //Gameloop
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (countersek == number)
            {
                spawn();
            }
            if (countersek >= 20)
            {
                countersek = 0;
            }
            if (counterms >= randy.Next(100,500))
            {
                counterms = 0;
                countersek++;
            }
            counterms++;
            move();
            if (isBomb)
            {
                blinken();
            }
            testifMouseHovers();
        }

        //spawner && mover funcs
        private bool isBomb;
        private void spawn()
        {
            if (!isSpawned && form.GetLive())
            {
                isBomb = false;
                if (randy.Next(0,40)<8)
                {
                    this.Size = new Size(200, 200);
                    this.Location = new Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2)) + randy.Next(-500, 501), Screen.PrimaryScreen.Bounds.Height + 100);
                    this.BackColor = Color.FromArgb(0,0,0);
                    isBomb = true;
                }
                else
                {
                    this.Size = new Size(150, 150);
                    this.Location = new Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2)) + randy.Next(-500, 501), Screen.PrimaryScreen.Bounds.Height + 100);
                    this.BackColor = Color.FromArgb(randy.Next(70, 255), randy.Next(70, 255), randy.Next(70, 255));
                }
                if (this.Location.X < (Screen.PrimaryScreen.Bounds.Width / 2))
                {
                    Momentum[0] = randy.Next(10, 41);
                }
                else
                {
                    Momentum[0] = randy.Next(-40, -9);
                }
                
                Momentum[1] = randy.Next(70/MovementSlowness, 90/MovementSlowness);
                isSpawned = true;
            }
        }
        private int BlinkCounter = 0;
        private void blinken()
        {
            if (BlinkCounter < 10)
            {
                this.BackColor = Color.FromArgb(0, 0, 0);
            }
            if (BlinkCounter >10 && BlinkCounter<20)
            {
                this.BackColor = Color.FromArgb(255, 0, 0);
            }
            if (BlinkCounter > 20)
            {
                BlinkCounter = 0;
            }
            BlinkCounter++;
        }
        private void move()
        {
            if(Momentum[1] > -100)
            {
                Momentum[1] -= (3 / MovementSlowness);
                if(Momentum[0] > 0)
                {
                    Momentum[0] *= 0.97;
                }
                if (Momentum[0] < 0)
                {
                    Momentum[0] *= 0.97;
                }
            }
            if (this.Location.Y > Screen.PrimaryScreen.Bounds.Height + 200)
            {
                if (isSpawned && !issliced && !isBomb)
                {
                    form.Lowerlives();
                }
                isSpawned = false;
                issliced = false;
            }
            if (isSpawned)
            {
                this.Location = new Point(this.Location.X + (int)Momentum[0], this.Location.Y - (int)Momentum[1]);
            }
        }



        //slice funcs
        private void testifMouseHovers()
        {
            if (isSpawned)
            {
                if (form.Getmousestate())
                {
                    if (Cursor.Position.X >= this.Location.X && Cursor.Position.X <= this.Location.X + this.Width && Cursor.Position.Y >= this.Location.Y && Cursor.Position.Y <= this.Location.Y + this.Height)
                    {
                        slice();
                    }
                }
            }
        }
        private bool issliced = false;
        private void slice()
        {
            if (!issliced)
            {
                if (isBomb)
                {
                    this.Size = new Size(125, 125);
                    for (int i = 0; i < 4; i++)
                    {
                        Bombensplittie[i] = new Splitfruit(this, this.Location.X, this.Location.Y, this.BackColor, isBomb, i);
                        Bombensplittie[i].Show();
                    }
                    
                    Momentum[0] = randy.Next(-80, 80);
                    Momentum[1] = randy.Next(-80, 80);
                    form.Lowerlives();
                    form.Addscore(-250);
                }
                else
                {
                    this.Size = new Size(75, 75);
                    splittie[0] = new Splitfruit(this, this.Location.X, this.Location.Y, this.BackColor, isBomb, 0);
                    splittie[0].Show();
                    Momentum[0] = randy.Next(-25, 25);
                    Momentum[1] = randy.Next(10, 40);
                    form.Addscore(100);
                }
                issliced = true;
                try
                {
                    this.BackColor = Color.FromArgb(this.BackColor.R - 50, this.BackColor.G - 50, this.BackColor.B - 50);
                }
                catch
                {

                }
            }
        }
        public void SplitFruitCloser()
        {
            if (splittie[0] != null)
            {
                splittie[0].Close();
                splittie[0] = null;
            }
        }
        public void SplitBombCloser(int number)
        {
            if (Bombensplittie[number] != null)
            {
                Bombensplittie[number].Close();
                Bombensplittie[number] = null;
            }
        }
        public int getMovementSlowness()
        {
            return MovementSlowness;
        }
    }
}
