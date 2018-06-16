using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Ball
    {
        public Point Center { get; set; }
        public static Random random = new Random();
        public SubjectFactory.Subject Subject;
        public static readonly int RADIUS = 25;
        public static readonly int SPEED = 25;
        public bool toBeDeleted { get; set; }
        public Ball(Point Center)
        {
            Subject = SubjectFactory.GetSubject();
            this.Center = Center;
            
            
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Subject.Color);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }
        public void Move()
        {
            Center = new Point(Center.X, Center.Y + SPEED);
        }



        public bool TheBallHasFallen(int downLine)
        {
            if(Center.Y-RADIUS>=downLine)
            {
                return true;
            }
            return false;
        }
        public bool IsHit(Point point)
        {
            var distance = Math.Abs(Center.X - point.X) + Math.Abs(Center.Y - point.Y);
            if (distance <= RADIUS * 2)
                return true;
            return false;
        }
    }
}
