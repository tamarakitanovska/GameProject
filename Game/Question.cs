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
    public partial class Question : Form
    {
        public String question { get; set; }
        public String answer { get; set; }
        public Question(String q,String a)
        {
            InitializeComponent();
            Question1.Text = q;
            String[] parts = a.Split(';');
            Answer1.Text = parts[0];
            Answer2.Text = parts[1];
        }

        private void Answer1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Answer2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Question_Load(object sender, EventArgs e)
        {
        }

        private void Question1_Click(object sender, EventArgs e)
        {
        }
    }
}
