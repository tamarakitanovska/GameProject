using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public BallController BallController;
        private Timer timer;
        private int generateBall;
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.sky;
            BallController = new BallController();
            this.DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //BallController.addBall(this.Left, this.Width);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (generateBall % 10 == 0)
            {
                BallController.addBall(this.Left, this.Width);
            }
            ++generateBall;
            BallController.MoveBall(this.Height);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            BallController.Draw(e.Graphics);
        }
    }
}
