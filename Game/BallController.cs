using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class BallController
    {
        //Gi cuvame topcinjata sto vo momentot postojat
        public List<Ball> Balls { get; set; }
        public List<Ball> BallsForQuestion { get; set; }
        public int Width { get; set; }
        public int Left { get; set; }
        public int DownLine { get; set; }
        public  int ballsKilled { get; set;  }

        public static  Random Random = new Random();

        public BallController(int Left, int Width,int h)
        {
            ballsKilled = 0;
            Balls = new List<Ball>();
            this.Left = Left;
            this.Width = Width;
            this.DownLine = h;
            BallsForQuestion = new List<Ball>();
        }


        public void addFireBall()
        {
            //create the FireBall with Center and angle for moving depending on the state of the plane
            FireBall fireBall = new FireBall(Plane.getCenter(), Plane.getAngle());
            Balls.Add(fireBall);
        }

        public void addFallingBall()
        {
            //to be implemented 
            //choose what type of ball
            //x coordinate of the center
            int x = Random.Next(Left + Ball.RADIUS, Width - Ball.RADIUS*2);
            //y coordinate of the center
            int y = -Ball.RADIUS * 2;        
            
            Ball newBall = new FallingBall(new Point(x, y));
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
                for (int j = i+1; j < Balls.Count; j++)
                {
                    if(Balls[i].IsHit(Balls[j].Center))
                    {
                        if (Balls[i].isFireBall() && Balls[j].isFireBall())
                            continue;
                        Balls[i].ToBeDeleted = true;
                        Balls[j].ToBeDeleted = true;
                        ballsKilled++;
                    }

                }
            }

            for(int i=0;i<BallsForQuestion.Count;++i)
            {
                if (BallsForQuestion[i].ToBeDeleted)
                    BallsForQuestion.RemoveAt(i);
            }
            
            for (int i = 0; i < Balls.Count; i++)
            {
                if(!Balls[i].isFireBall() && Balls[i].isOutOfFrame(DownLine, Width, 0, 0))
                {
                    BallsForQuestion.Add(Balls[i]);
                    Balls.Remove(Balls[i]);
                }
                if (Balls[i].ToBeDeleted )
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
