namespace mouseMoveGraphics
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
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.buttonSetColour = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.Location = new System.Drawing.Point(-1, -1);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(989, 564);
            this.pictureBoxDisplay.TabIndex = 0;
            this.pictureBoxDisplay.TabStop = false;
            this.pictureBoxDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDisplay_MouseMove);
            // 
            // buttonSetColour
            // 
            this.buttonSetColour.Location = new System.Drawing.Point(51, 50);
            this.buttonSetColour.Name = "buttonSetColour";
            this.buttonSetColour.Size = new System.Drawing.Size(75, 23);
            this.buttonSetColour.TabIndex = 1;
            this.buttonSetColour.Text = "Set Colour";
            this.buttonSetColour.UseVisualStyleBackColor = true;
            this.buttonSetColour.Click += new System.EventHandler(this.buttonSetColour_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.Red;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 566);
            this.Controls.Add(this.buttonSetColour);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.Button buttonSetColour;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

