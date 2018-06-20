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
        private Plane Plane;
        
        public Form1()
        {
            InitializeComponent();
            
            startNew();
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
            timer.Start();
        }

      
        private void timer_Tick(object sender, EventArgs e)
        {
            if (generateBall % 12 == 0)
            {
                BallController.addFallingBall();
            }
            ++generateBall;
            BallController.MoveBall(this.Height);
            askQuestion();
            Invalidate(true);
            checkGameOver();
        }
        public void checkGameOver()
        {
            if (BallController.ballsKilled < 0)
            {
                timer.Stop();
                if (MessageBox.Show("Do tou want new game?", "nova igra", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    startNew();
                    timer.Start();
                }
                else
                {
                    Application.Exit();
                }
            }
        }


        //Showing a question after every fallen ball
        private void askQuestion()
        {
            pause();
            for (int i=0;i< BallController.BallsForQuestion.Count;++i)
            {
                SubjectFactory.Subject subject = BallController.BallsForQuestion[i].getSubject();
                Dictionary<String,String> dictionary= subject.getQuestionAndAnswer();

                String question = dictionary.Keys.First();//the question string
                string answer = dictionary.Values.First();//the correct and wrong answers

                Question Question = new Question(question,answer);
               

                if(Question.ShowDialog()!=DialogResult.OK)
                {
                    if (subject.getName().Equals("Оперативни системи"))
                    {
                        BallController.ballsKilled -= 5;//decrementing the points due to wrong answer
                    }
                    else if (subject.getName().Equals("Архитектура и организација на копмјутери"))
                    {
                        BallController.ballsKilled -= 4;
                    }
                    else if (subject.getName().Equals("Софтверско инжинерство"))
                    {
                        BallController.ballsKilled -= 3;
                    }
                    else if (subject.getName().Equals("Струкрурно програмирање"))
                    {
                        BallController.ballsKilled -= 2;
                    }
                    else if (subject.getName().Equals("Маркетинг"))
                    {
                        BallController.ballsKilled -= 1;
                    }
                }
                else
                {
                    if (subject.getName().Equals("Оперативни системи"))
                    {
                        BallController.ballsKilled += 5;//decrementing the points due to wrong answer
                    }
                    else if (subject.getName().Equals("Архитектура и организација на копмјутери"))
                    {
                        BallController.ballsKilled += 4;
                    }
                    else if (subject.getName().Equals("Софтверско инжинерство"))
                    {
                        BallController.ballsKilled += 3;
                    }
                    else if (subject.getName().Equals("Струкрурно програмирање"))
                    {
                        BallController.ballsKilled += 2;
                    }
                    else if (subject.getName().Equals("Маркетинг"))
                    {
                        BallController.ballsKilled += 1;
                    }
                }
                BallController.BallsForQuestion[i].ToBeDeleted = true;
            }

            pause();
        }

        //when mouse is clicked fire ball is shooted
        private void mouse_click(object sender, MouseEventArgs e)
        {
            
             Plane.fireBallShoot();
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            BallController.Draw(e.Graphics);
        }
        private void saveFile()
        {
            //Excepiton handlers needed
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Balls doc file (*.bls)|*.bls";
                saveFileDialog.Title = "Save balls doc";
                
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
                        SaveObject saveObject = new SaveObject();
                        saveObject.BallController = BallController;
                        saveObject.Plane = Plane;
                        formatter.Serialize(fileStream, saveObject);
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
                        SaveObject saveObject = (SaveObject)formater.Deserialize(fileStream);
                        BallController = saveObject.BallController;
                        Plane = saveObject.Plane;
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

        private void startNew()
        {
            
            FileName = null;
            BackgroundImageLayout = ImageLayout.Stretch;
            BallController = new BallController(0, this.Width, this.Height);
            Plane = new Plane(BallController);
            this.BackgroundImage = Plane.getImage();
            this.DoubleBuffered = true;
            Paused = false;
            
            this.MouseClick += new MouseEventHandler(this.mouse_click);
            
        }

        //Start new Game
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            startNew();
            Invalidate(true);
        }


        //Open file
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            pause();
            openFile();
            pause();
        }



        private void pause()
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
        //Pause from menu
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            pause();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                //0 for left
                Plane.changeState(0);
                this.BackgroundImage = Plane.getImage();
                Invalidate();

            }
            else if (e.KeyCode == Keys.Right)
            {
                Plane.changeState(1);
                this.BackgroundImage = Plane.getImage();
                Invalidate();
            }

            else if (e.KeyCode == Keys.P)
                pause();



        }


        //save file
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            pause();
            saveFile();
            pause();
        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            pointsLabel.Text = BallController.ballsKilled.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
