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
    public partial class CursorTrailNodes : Form
    {
        Form1 form;
        private int number;
        private bool vis = false;
        private int nodesize = 10;

        public CursorTrailNodes(Form1 fo, int num)
        {
            InitializeComponent();
            form = fo;
            number = num;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(-100, -100);

            this.MaximumSize = new Size(nodesize, nodesize);

        }



        private void trailtimer_Tick(object sender, EventArgs e)
        {
            
    
            Point mouseposP = new Point(Cursor.Position.X-(nodesize/2), Cursor.Position.Y-(nodesize/2));


            if (form.getVisiblenodes() > number)
            {
             
                if (vis == false)
                {
                        
                    this.Location = mouseposP;
                }
                vis = true;
                this.Show();
                    
            }
            else
            {
                this.Hide();
                this.Location = mouseposP;
                vis = false;
                //this.Location = new Point(-100, -100);
            }

            int des = 7; // desired distance

            int crt = 15; // critical distance

            if (number == 0)
            {

                if(pythagoras(mouseposP, this.Location) > des && form.Getmousestate())
                {
                    this.Location = mouseposP; 
                }
                    
            } 
            else if (vis)
            {
   
                Point last = form.getCursortrail()[number - 1].Location;
                        
                double dist = pythagoras(last, this.Location);
                if (dist > des)
                {
                    if(dist > crt)
                    {
                        Point shortened = disapointment(last, this.Location, crt);
                            
                        if(shortened != last)
                        {
                            this.Location = disapointment(last, this.Location, crt);
                        }

                    } else
                    {
                        this.Location = last;
                    }
                        
                }
            }
            
            if(form.getVisiblenodes() <= 0)
            {
                double s1 = 2*nodesize - 1.5*(Math.Abs((number + 1) - (form.getVisiblenodes() / 2f)));

                this.Size = new Size((int)s1, (int)s1);
            }
           
            
        }

        private double pythagoras(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2)); ;
        }


        private Point disapointment(Point a, Point b, double dl) //dl  = desiredlength
        {
            double length = pythagoras(a, b);
            double d1 = (b.X - a.X) / length;
            double d2 = (b.Y - a.Y) / length;
            return new Point((int)Math.Round(d1 * dl) + a.X, (int)Math.Round(d2 * dl) + a.Y);
        }
    }
}
