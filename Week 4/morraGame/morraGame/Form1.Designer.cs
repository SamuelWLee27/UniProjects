namespace morraGame
{
    partial class Form1
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
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxPlayerFingers = new System.Windows.Forms.TextBox();
            this.textBoxPlayerGuess = new System.Windows.Forms.TextBox();
            this.textBoxPlayerScore = new System.Windows.Forms.TextBox();
            this.textBoxCompScore = new System.Windows.Forms.TextBox();
            this.pictureBoxPlayerDisplay = new System.Windows.Forms.PictureBox();
            this.pictureBoxCompDisplay = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(68, 397);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(544, 491);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(137, 23);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxPlayerFingers
            // 
            this.textBoxPlayerFingers.Location = new System.Drawing.Point(68, 346);
            this.textBoxPlayerFingers.Name = "textBoxPlayerFingers";
            this.textBoxPlayerFingers.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayerFingers.TabIndex = 2;
            // 
            // textBoxPlayerGuess
            // 
            this.textBoxPlayerGuess.Location = new System.Drawing.Point(477, 346);
            this.textBoxPlayerGuess.Name = "textBoxPlayerGuess";
            this.textBoxPlayerGuess.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayerGuess.TabIndex = 3;
            // 
            // textBoxPlayerScore
            // 
            this.textBoxPlayerScore.Location = new System.Drawing.Point(68, 66);
            this.textBoxPlayerScore.Name = "textBoxPlayerScore";
            this.textBoxPlayerScore.ReadOnly = true;
            this.textBoxPlayerScore.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayerScore.TabIndex = 4;
            // 
            // textBoxCompScore
            // 
            this.textBoxCompScore.Location = new System.Drawing.Point(477, 66);
            this.textBoxCompScore.Name = "textBoxCompScore";
            this.textBoxCompScore.ReadOnly = true;
            this.textBoxCompScore.Size = new System.Drawing.Size(100, 20);
            this.textBoxCompScore.TabIndex = 5;
            // 
            // pictureBoxPlayerDisplay
            // 
            this.pictureBoxPlayerDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPlayerDisplay.Location = new System.Drawing.Point(68, 118);
            this.pictureBoxPlayerDisplay.Name = "pictureBoxPlayerDisplay";
            this.pictureBoxPlayerDisplay.Size = new System.Drawing.Size(216, 181);
            this.pictureBoxPlayerDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlayerDisplay.TabIndex = 6;
            this.pictureBoxPlayerDisplay.TabStop = false;
            // 
            // pictureBoxCompDisplay
            // 
            this.pictureBoxCompDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCompDisplay.Location = new System.Drawing.Point(477, 118);
            this.pictureBoxCompDisplay.Name = "pictureBoxCompDisplay";
            this.pictureBoxCompDisplay.Size = new System.Drawing.Size(216, 181);
            this.pictureBoxCompDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCompDisplay.TabIndex = 7;
            this.pictureBoxCompDisplay.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Player score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Computer score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of fingers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Guess computers number of fingers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 550);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxCompDisplay);
            this.Controls.Add(this.pictureBoxPlayerDisplay);
            this.Controls.Add(this.textBoxCompScore);
            this.Controls.Add(this.textBoxPlayerScore);
            this.Controls.Add(this.textBoxPlayerGuess);
            this.Controls.Add(this.textBoxPlayerFingers);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPlay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxPlayerFingers;
        private System.Windows.Forms.TextBox textBoxPlayerGuess;
        private System.Windows.Forms.TextBox textBoxPlayerScore;
        private System.Windows.Forms.TextBox textBoxCompScore;
        private System.Windows.Forms.PictureBox pictureBoxPlayerDisplay;
        private System.Windows.Forms.PictureBox pictureBoxCompDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

