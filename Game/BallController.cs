using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BallController
    {
        //Gi cuvame topcinjata sto vo momentot postojat
        public List<Ball> Balls { get; set; }


        public int Widht { get; set; }
        public int Left { get; set; }
        public int DownLine { get; set; }
        
        public Random Random { get; set; }

        public BallController()
        {
            Balls = new List<Ball>();
            
        }

        public void addBall()
        {

            //to be implemented 
            //choose what type of ball
            //x coordinate of the center
            int x = Random.Next(Left+Ball.RADIUS*2, Widht-Ball.RADIUS*2);
            //y coordinate of the center
            int y = -Ball.RADIUS * 2;

            Ball newBall = new Ball(new Point(x, y));
            Balls.Add(newBall);

        }

        //Validating the existing balls
        //Removing the balls that are not in valid state

        
        private void ValidateBalls()
        {

            for (int i = 0; i < Balls.Count; i++)
            {
                if (Balls[i].TheBallHasFallen(DownLine))
                {
                    Balls.Remove(Balls[i]);
                }
            }
        }
        public void MoveBall()
        {
            foreach (var ball in Balls)
            {
                //moving each ball
                ball.Move();
            }

            //delete the balls that had fallen(crossed the downline)
            ValidateBalls();
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
