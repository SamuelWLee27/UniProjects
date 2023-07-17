namespace PracP6
{
   
    public partial class SpaceInvaders
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox_ = new System.Windows.Forms.PictureBox();
            this.animationTimer_ = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_
            // 
            this.pictureBox_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_.Name = "pictureBox_";
            this.pictureBox_.Size = new System.Drawing.Size(469, 304);
            this.pictureBox_.TabIndex = 1;
            this.pictureBox_.TabStop = false;
            this.pictureBox_.Click += new System.EventHandler(this.pictureBox__Click);
            this.pictureBox_.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox__Paint);
            // 
            // animationTimer_
            // 
            this.animationTimer_.Enabled = true;
            this.animationTimer_.Interval = 20;
            this.animationTimer_.Tick += new System.EventHandler(this.animationTimer__Tick);
            // 
            // SpaceInvaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(469, 304);
            this.Controls.Add(this.pictureBox_);
            this.Name = "SpaceInvaders";
            this.Text = "Space Invaders";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_;
        private System.Windows.Forms.Timer animationTimer_;
    }
}

