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
        private int number;
        private double[] Momentum = new double[2];//momentum[0] = x   ;   momentum[1] = y
        private bool isSpawned = false;
        public Fruit(Form1 fo, int Number)
        {
            InitializeComponent();
            form = fo;
            timer1.Interval = 1;
            this.BackColor = Color.FromArgb(randy.Next(1, 255), randy.Next(1, 255), randy.Next(1, 255));
            number = Number;
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
            testifMouseHovers();
        }

        //spawner && mover funcs
        private void spawn()
        {
            if (!isSpawned)
            {
                this.Location = new Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2))+randy.Next(-500, 501), Screen.PrimaryScreen.Bounds.Height + 100);
                if(this.Location.X < (Screen.PrimaryScreen.Bounds.Width / 2))
                {
                    Momentum[0] = randy.Next(10, 41);
                }
                else
                {
                    Momentum[0] = randy.Next(-40, -9);
                }
                
                Momentum[1] = randy.Next(70, 90);
                isSpawned = true;
            }
        }
        private void move()
        {
            this.Location = new Point(this.Location.X + (int)Momentum[0], this.Location.Y - (int)Momentum[1]);
            if(Momentum[1] > -100)
            {
                Momentum[1] -= 3;
                if(Momentum[0] > 0)
                {
                    Momentum[0] *= 0.97;
                }
                if (Momentum[0] < 0)
                {
                    Momentum[0] *= 0.97;
                }
            }
            if (this.Location.Y > 1500)
            {
                isSpawned = false;
            }
        }



        //slice funcs
        private void testifMouseHovers()
        {
            if (isSpawned)
            {
                if (form.Getmousestate())
                {
                    if (Cursor.Position.X >= this.Location.X && Cursor.Position.X <= this.Location.X + this.Width || Cursor.Position.Y >= this.Location.Y && Cursor.Position.Y <= this.Location.Y + this.Height)
                    {
                        slice();
                    }
                }
            }
        }
        private void slice()
        {
            this.Size = new Size(75,75);

        }
    }
}
