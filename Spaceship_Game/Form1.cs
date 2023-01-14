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
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        Timer moveTimer = new Timer();
        int speed = 5;

        public static int x, y;
        Queue<AsteroidForm> asteroids = new Queue<AsteroidForm>();

        public Form1()
        {
            InitializeComponent();

            moveTimer.Interval = 5;
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();

            StartGame();
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            MoveUFO();
            CheckCollision();
        }

        private void CheckCollision()
        {
            foreach (var item in asteroids)
            {
                if (Rectangle.Intersect(this.Bounds, item.Bounds) != Rectangle.Empty)
                {
                    timer.Stop();
                    moveTimer.Stop();
                    this.BackgroundImage = Spaceship_Game.Properties.Resources.explosion;
                    MessageBox.Show("Game Over!");
                    Application.Exit();
                    return;
                }
            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {           

            if (asteroids.Count != 0)
            {
                asteroids.Peek().Close();
                asteroids.Dequeue();
            }

            AsteroidForm asteroid = new AsteroidForm();
            asteroid.Show();
            asteroid.SetDesktopLocation(0, 0);
            AsteroidForm asteroid2 = new AsteroidForm();
            asteroid2.Show();
            asteroid2.SetDesktopLocation(Screen.PrimaryScreen.Bounds.Right, Screen.PrimaryScreen.Bounds.Bottom);
            
            asteroids.Enqueue(asteroid2);
            asteroids.Enqueue(asteroid);
            
        }

        public Point GetMousePos()
        {
            return Cursor.Position;
        }

        public void MoveUFO()
        {
            Point mPos = GetMousePos();
            mPos.X += 10;
            mPos.Y += 10;

            if (Math.Abs(mPos.Y - this.DesktopLocation.Y) < speed && Math.Abs(mPos.X - this.DesktopLocation.X) < speed)
            {
                this.SetDesktopLocation(mPos.X, mPos.Y);
                return;
            }
            else

            if (Math.Abs(mPos.X - this.DesktopLocation.X) < speed)
            {
                this.SetDesktopLocation(mPos.X, this.DesktopLocation.Y);
            }
            else if (mPos.X < this.DesktopLocation.X)
            {
                this.SetDesktopLocation(this.DesktopLocation.X - speed, this.DesktopLocation.Y);
            }
            else if (mPos.X > this.DesktopLocation.X)
            {
                this.SetDesktopLocation(this.DesktopLocation.X + speed, this.DesktopLocation.Y);
            }


            if (Math.Abs(mPos.Y - this.DesktopLocation.Y) < speed)
            {
                this.SetDesktopLocation(this.DesktopLocation.X, mPos.Y);
            }
            else if (mPos.Y < this.DesktopLocation.Y)
            {
                this.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y - speed);
            }
            else if (mPos.Y > this.DesktopLocation.Y)
            {
                this.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y + speed);
            }

            x = this.DesktopLocation.X;
            y = this.DesktopLocation.Y;
        }

        private void StartGame()
        {
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        
    }
}
