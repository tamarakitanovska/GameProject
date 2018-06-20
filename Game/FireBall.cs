using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class FireBall :Ball
    {
        

        public static int Radius { get; set; } = 11;
        public static int Speed { get; set; } = 19;

        public int VelcovityX { get; set; }
        public int VelcovityY { get; set; }

        public bool toBeDeleted { get; set; }
        public FireBall(Point c,double angle)
        {
            Center = c;

            double angleInRadians = (angle /180)*Math.PI;
            VelcovityX = (int)(Math.Cos(angleInRadians)*Speed);
            VelcovityY= (int)(Math.Sin(angleInRadians)*Speed);
        }

        public override void Move()
        {
            Center = new Point(Center.X + VelcovityX, Center.Y - VelcovityY);
        }

        public override void Draw(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.Red);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            b.Dispose();
        }

        public override bool isOutOfFrame(int downline, int width, int left, int top)
        {
            if (Center.X + Radius <= left || Center.X - Radius >= width)
                return true;
            if (Center.Y + Radius <= top)
                return true;
            return false;
        }

        public override bool isFireBall()
        {
            return true;
        }

        public override SubjectFactory.Subject getSubject()
        {
            throw new NotImplementedException();
        }
    }
}
