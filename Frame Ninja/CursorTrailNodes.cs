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
        private int counter;
        private int number;
        
        public CursorTrailNodes(Form1 fo, int num)
        {
            InitializeComponent();
            form = fo;
            number = num;
            this.Size = new Size(100, 100);
        }

        private void trailtimer_Tick(object sender, EventArgs e)
        {
            if (form.Getmousestate() || true)
            {
                /*double mouseposX = Cursor.Position.X / 10;
                mouseposX = Math.Round(mouseposX);
                mouseposX *= 10;
                mouseposX -= 5;
                double mouseposY = Cursor.Position.Y / 10;
                mouseposY = Math.Round(mouseposY);
                mouseposY *= 10;
                mouseposY -= 5;*/

                Point mouseposP = crappyfy(new Point(Cursor.Position.X-5, Cursor.Position.Y-5));


                if (Form1.visiblenodes > number)
                {
                    this.Opacity = 1;
                }
                else
                {
                    this.Opacity = 0;
                }

                int des = 10; // desired distance

                int crt = 20; // critical distance

                if (number == 0)
                {
                    /*last = Form1.Cursortrail[number - 1].Location;

                    if (pythagoras(last, this.Location) > 5)
                    {
                        
                        //this.Location = last;
                    }*/

                    if(pythagoras(mouseposP, this.Location) > des && form.Getmousestate())
                    {
                        this.Location = mouseposP; 
                    }
                    
                } else
                {
                    /* if (counter == number)
                     {
                          this.Location = new Point((int)mouseposX, (int)mouseposY);
                     }*/
                    Point last = Form1.Cursortrail[number - 1].Location;
                        
                    double dist = pythagoras(last, this.Location);
                    if (dist > des)
                    {
                        if(dist > crt)
                        {
                            Point shortened = crappyfy(disapointment(last, this.Location, crt));
                            
                            if(shortened != last)
                            {
                                this.Location = crappyfy(disapointment(last, this.Location, crt));
                            }
                            

                        } else
                        {
                            this.Location = last;
                        }
                        
                    }
                }
                
                
                counter++;
                if (counter == 100)
                {
                    counter = 0;
                }
            }
        }

        double pythagoras(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2)); ;
        }


        Point disapointment(Point a, Point b, double dl)
        {
            double length = pythagoras(a, b);
            double d1 = (b.X - a.X) / length;
            double d2 = (b.Y - a.Y) / length;
            return new Point((int)Math.Round(d1 * dl) + a.X, (int)Math.Round(d2 * dl) + a.Y);
        }

        Point crappyfy(Point a)
        {
            double aX = a.X / 10;
            aX = Math.Round(aX);
            aX *= 10;
            
            double aY = a.Y / 10;
            aY = Math.Round(aY);
            aY *= 10;
           
            //return new Point((int)aX, (int)aY);
            return a;
        }
    }
}
