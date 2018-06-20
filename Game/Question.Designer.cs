namespace Game
{
    partial class Question
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Question1 = new System.Windows.Forms.Label();
            this.Answer1 = new System.Windows.Forms.Button();
            this.Answer2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Question1
            // 
            this.Question1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Question1.Location = new System.Drawing.Point(0, 0);
            this.Question1.Name = "Question1";
            this.Question1.Size = new System.Drawing.Size(437, 225);
            this.Question1.TabIndex = 0;
            this.Question1.Text = "Question1";
            this.Question1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Question1.Click += new System.EventHandler(this.Question1_Click);
            // 
            // Answer1
            // 
            this.Answer1.Location = new System.Drawing.Point(36, 141);
            this.Answer1.Name = "Answer1";
            this.Answer1.Size = new System.Drawing.Size(152, 39);
            this.Answer1.TabIndex = 1;
            this.Answer1.Text = "Answer1";
            this.Answer1.UseVisualStyleBackColor = true;
            this.Answer1.Click += new System.EventHandler(this.Answer1_Click);
            // 
            // Answer2
            // 
            this.Answer2.Location = new System.Drawing.Point(250, 141);
            this.Answer2.Name = "Answer2";
            this.Answer2.Size = new System.Drawing.Size(156, 39);
            this.Answer2.TabIndex = 2;
            this.Answer2.Text = "Answer2";
            this.Answer2.UseVisualStyleBackColor = true;
            this.Answer2.Click += new System.EventHandler(this.Answer2_Click);
            // 
            // Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 225);
            this.Controls.Add(this.Answer2);
            this.Controls.Add(this.Answer1);
            this.Controls.Add(this.Question1);
            this.Name = "Question";
            this.Text = "Question";
            this.Load += new System.EventHandler(this.Question_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Question1;
        private System.Windows.Forms.Button Answer1;
        private System.Windows.Forms.Button Answer2;
    }
}