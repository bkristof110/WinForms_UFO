using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spaceship_Game
{
    public partial class AsteroidForm : Form
    {
        Timer timer = new Timer();
        Point target;
        private int speed = 4;

        public AsteroidForm()
        {
            InitializeComponent();

            target = new Point(Form1.x, Form1.y);

            timer.Interval = 5;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(target.X - this.DesktopLocation.X) < speed)
            {
                this.SetDesktopLocation(target.X, this.DesktopLocation.Y);
            }
            else if (target.X < this.DesktopLocation.X)
            {
                this.SetDesktopLocation(this.DesktopLocation.X - speed, this.DesktopLocation.Y);
            }
            else if (target.X > this.DesktopLocation.X)
            {
                this.SetDesktopLocation(this.DesktopLocation.X + speed, this.DesktopLocation.Y);
            }


            if (Math.Abs(target.Y - this.DesktopLocation.Y) < speed)
            {
                this.SetDesktopLocation(this.DesktopLocation.X, target.Y);
            }
            else if (target.Y < this.DesktopLocation.Y)
            {
                this.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y - speed);
            }
            else if (target.Y > this.DesktopLocation.Y)
            {
                this.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y + speed);
            }
        }
    }
}
