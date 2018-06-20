using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public abstract class Ball
    {
        public Point Center { get; set; }
        public static int RADIUS = 25;
        public static int SPEED = 25;

        public bool ToBeDeleted { get; set; }
        public abstract void Draw(Graphics g);

        public abstract void Move();


        public bool IsHit(Point point)
        {
            var distance = Math.Abs(Center.X - point.X) + Math.Abs(Center.Y - point.Y);
            if (distance <= RADIUS * 2)
                return true;
            return false;
        }

        public abstract bool isOutOfFrame(int downline, int width, int left, int top);

        public abstract bool isFireBall();

        public abstract SubjectFactory.Subject getSubject();
    }
}
