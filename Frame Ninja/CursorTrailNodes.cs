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
            if (form.Getmousestate())
            {
                double mouseposX = Cursor.Position.X / 10;
                mouseposX = Math.Round(mouseposX);
                mouseposX *= 10;
                mouseposX -= 5;
                double mouseposY = Cursor.Position.Y / 10;
                mouseposY = Math.Round(mouseposY);
                mouseposY *= 10;
                mouseposY -= 5;


                if (counter == number)
                {
                    this.Location = new Point((int)mouseposX, (int)mouseposY);
                }
                counter++;
                if (counter == 100)
                {
                    counter = 0;
                }
            }
        }
    }
}
