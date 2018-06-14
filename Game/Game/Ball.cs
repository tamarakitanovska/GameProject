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
        public Color Color { get; set; }
        public static Random random = new Random();
        public int state { get; set; }
        public static readonly int RADIUS = 40;
        public static readonly int SPEED = 10;
        public Ball(Point Center)
        {
            Center = new Point();
            state = random.Next(4);
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
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 20);
            b.Dispose();
        }
        public void Move()
        {
            Center = new Point(Center.X, Center.Y + SPEED);
        }
    }
}
