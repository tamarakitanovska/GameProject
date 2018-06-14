using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BallController
    {
        //Gi cuvame topcinjata sto vo momentot postojat
        public List<Ball> Balls { get; set; }

        public Color Color { get; set; }

        public int state { get; set; }

        public int Width { get; set; }
        public int Left { get; set; }
        public int DownLine { get; set; }

        public Random Random = new Random();

        public BallController()
        {
            Balls = new List<Ball>();
        }

        public void addBall(int Left, int Width)
        {
            this.Left = Left;
            this.Width = Width;
            //to be implemented 
            //choose what type of ball
            //x coordinate of the center
            int x = Random.Next(Left+Ball.RADIUS*2, Width-Ball.RADIUS*2);
            //y coordinate of the center
            int y = -Ball.RADIUS * 2;

            state = Random.Next(4);
            if (state == 0)
            {
                //Marketing
                Color = Color.Yellow;
            }
            else if (state == 1)
            {
                //Strukturno
                Color = Color.Green;
            }
            else if (state == 2)
            {
                //Softversko
                Color = Color.Red;
            }
            else if (state == 3)
            {
                //AOK
                Color = Color.Blue;
            }
            else if (state == 4)
            {
                //Operativni
                Color = Color.Black;
            }
            Ball newBall = new Ball(new Point(x, y),Color);
            Balls.Add(newBall);

        }
        public void Draw(Graphics g)
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                    Balls[i].Draw(g);
            }
        }

        //Validating the existing balls
        //Removing the balls that are not in valid state


        private void ValidateBalls(int DownLine)
        {

            for (int i = 0; i < Balls.Count; i++)
            {
                if (Balls[i].TheBallHasFallen(DownLine))
                {
                    Balls.Remove(Balls[i]);
                }
            }
        }
        public void MoveBall(int DownLine)
        {
            foreach (var ball in Balls)
            {
                //moving each ball
                ball.Move();
            }

            //delete the balls that had fallen(crossed the downline)
            ValidateBalls(DownLine);
        }

        public void Hit(int x, int y)
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                if (Balls[i].IsHit(new Point(x, y)))
                    Balls.RemoveAt(i);
            }
        }
    }
}
