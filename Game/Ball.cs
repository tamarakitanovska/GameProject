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
        public Color Color { get; set; }
        public static readonly int RADIUS = 40;
        public static readonly int SPEED = 10;
        public Ball(Point Center, Color Color)
        {
            Center = new Point();
            this.Color = Color;
            
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }
        public void Move()
        {
            Center = new Point(Center.X+SPEED, Center.Y);
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
