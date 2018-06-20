using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class FallingBall :Ball
    {
        
        public static Random random = new Random();
        
        public SubjectFactory.Subject Subject;
        public static int Radius { get; set; } = 25;
        public static int Speed { get; set; } = 15;
        public bool toBeDeleted { get; set; }
        public FallingBall(Point Center)
        {

            Subject = SubjectFactory.GetSubject();
            this.Center = Center;
            
            
        }
        public override  void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Subject.Color);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }
        public override void  Move()
        {
            Center = new Point(Center.X, Center.Y + SPEED);
        }



        public override bool isOutOfFrame(int downLine, int width, int left, int top)
        {
            if(Center.Y-RADIUS>=downLine)
            {
                return true;
            }
            return false;
        }

        public override bool isFireBall()
        {
            return false;
        }

        public override SubjectFactory.Subject getSubject()
        {
            return Subject;
        }
    }
}
