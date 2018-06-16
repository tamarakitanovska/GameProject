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
        public List<FireBall> FireBalls { get; set; }      
        public int Width { get; set; }
        public int Left { get; set; }
        public int DownLine { get; set; }

        public static  Random Random = new Random();

        public BallController(int Left, int Width,int h)
        {
            FireBalls = new List<FireBall>();
            this.Left = Left;
            this.Width = Width;
            this.DownLine = h;
            Balls = new List<Ball>();
        }


        public void addFireBall()
        {
            //create the FireBall with Center and angle for moving depending on the state of the plane
            FireBall fireBall = new FireBall(Plane.getCenter(), Plane.getAngle());
            FireBalls.Add(fireBall);
        }
        public void addBall()
        {
            //to be implemented 
            //choose what type of ball
            //x coordinate of the center
            int x = Random.Next(Left + Ball.RADIUS, Width - Ball.RADIUS*2);
            //y coordinate of the center
            int y = -Ball.RADIUS * 2;        
            
            Ball newBall = new Ball(new Point(x, y));
            Balls.Add(newBall);

        }
        public void Draw(Graphics g)
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                    Balls[i].Draw(g);
            }

            for (int i = 0; i < FireBalls.Count; i++)
            {
                FireBalls[i].Draw(g);
            }
        }

        //Validating the existing balls
        //Removing the balls that are not in valid state


        private void ValidateBalls(int DownLine)
        {

            for (int i = 0; i < Balls.Count; i++)
            {
                for (int j = 0; j < FireBalls.Count; j++)
                {
                    if(Balls[i].IsHit(FireBalls[j].Center))
                    {
                        Balls[i].toBeDeleted = true;
                        FireBalls[j].toBeDeleted = true;
                    }

                }
            }

            for (int i = 0; i < Balls.Count; i++)
            {
                if (Balls[i].TheBallHasFallen(DownLine) || Balls[i].toBeDeleted)
                {
                    Balls.Remove(Balls[i]);
                }
            }

            for (int i = 0; i < FireBalls.Count; i++)
            {
                if (FireBalls[i].toBeDeleted || FireBalls[i].isOutOfFrame(Width,0,0))
                {
                    FireBalls.Remove(FireBalls[i]);
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

            foreach (var ball in FireBalls)
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
