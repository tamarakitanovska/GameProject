using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        private String FileName;
        private bool Paused;
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.sky_airplane;
            BackgroundImageLayout = ImageLayout.Stretch;
            BallController = new BallController();
            this.DoubleBuffered = true;
            Paused = false;
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
        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Balls doc file (*.bls)|*.bls";
                saveFileDialog.Title = "Save balls doc";
                saveFileDialog.FileName = FileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }
            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, BallController);
                }
            }
        }
        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Balls doc file (*.bls)|*.bls";
            openFileDialog.Title = "Open balls doc file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        BallController = (BallController)formater.Deserialize(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read file: " + FileName);
                    FileName = null;
                    return;
                }
                Invalidate(true);
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Paused = !Paused;
            if (Paused)
            {
                timer.Stop();
                toolStripLabel1.Text = "Continue";
            }
            else
            {
                timer.Start();
                toolStripLabel1.Text = "Pause";
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
