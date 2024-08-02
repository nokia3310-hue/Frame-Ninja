﻿using System;
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
    public partial class Splitfruit : Form
    {
        Fruit frucht;
        private int fruchtX;
        private int fruchtY;
        private double[] Momentum = new double[2];
        Random randy = new Random();
        public Splitfruit(Fruit fr, int X, int Y, Color Farbe)
        {
            InitializeComponent();
            frucht = fr;
            fruchtX = X;
            fruchtY = Y;
            try
            {
                this.BackColor = Color.FromArgb(Farbe.R - 50, Farbe.G - 50, Farbe.B - 50);
            }
            catch
            {
                this.BackColor = Color.FromArgb(Farbe.R , Farbe.G , Farbe.B );
            }
            Momentum[0] = randy.Next(-25, 25);
            Momentum[1] = randy.Next(10, 40);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            move();
        }
        //initial spawner
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            this.Location = new Point(fruchtX, fruchtY);
            timer2.Enabled = false;
        }
        private void move()
        {
            if (Momentum[1] > -100)
            {
                Momentum[1] -= 3;
                if (Momentum[0] > 0)
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
                frucht.SplitFruitCloser();
            }
            this.Location = new Point(this.Location.X + (int)Momentum[0], this.Location.Y - (int)Momentum[1]);
        }
    }
}
