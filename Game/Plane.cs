using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    class Plane
    {
        //the plane may be in 5 different states
        //0 for full left
        //1 for half-left
        //2 for straight
        //3 for half right
        //4 for full right
        public static int State { get; set; }
        public static Point CenterPlane = new Point(454,456);
        public static Point LeftPlane = new Point(375,467);
        public static Point LeftLeftPlane = new Point(363,492);
        public static Point RightPlane = new Point(540,458);
        public static Point RightRightPlane = new Point(571,482);

        public static Point []CenterArray = {LeftLeftPlane, LeftPlane, CenterPlane, RightPlane, RightRightPlane };
        public BallController BallController { get; set; }
        //the whole image with a single position of the plane
        //in every picture the plane has a different possition
        public static List<Bitmap> Images { get; set; }
        
        
        public Plane(BallController ballController )
        {

            //At the beginnig the state is straight
            State = 2;
            Images = new List<Bitmap>();
            Images.Add(Game.Properties.Resources.leftleftplane);
            Images.Add(Game.Properties.Resources.leftplane);
            Images.Add(Game.Properties.Resources.plane);
            Images.Add(Game.Properties.Resources.rightplane);
            Images.Add(Game.Properties.Resources.rightrightplane);

            BallController = ballController;
        }

        public Bitmap getImage()
        {
            //dependin on the state it returns the image
            return Images.ElementAt(State);
        }

        private void changeLeft()
        {
            //go more left only if it is possible
            if (State > 0)
                State = State - 1;
        }

        private void changeRight()
        {
            if (State < 4)
                State = State + 1;
        }


        //the value of side shows if the plane is going left or right
        public void changeState(int side)
        {
            //0 for left
            if (side == 0)
                changeLeft();
            else
                changeRight();
        }

        public static int getAngle()
        {
            if (State == 0)
                return 148;
            if (State == 1)
                return 135;
            else if (State == 2)
                return 90;
            else if (State == 3)
            {
                return 50;
            }
            else
                return 35;
        }
        public static Point getCenter()
        {
            return CenterArray[State];
        }
        public void fireBallShoot()
        {
            BallController.addFireBall();
        }
    }
}
