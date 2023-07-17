namespace Practical
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
            this.pictureBoxBoard = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumRows = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDrawBoard = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBoard
            // 
            this.pictureBoxBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBoard.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxBoard.Name = "pictureBoxBoard";
            this.pictureBoxBoard.Size = new System.Drawing.Size(852, 561);
            this.pictureBoxBoard.TabIndex = 1;
            this.pictureBoxBoard.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 586);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of rows";
            // 
            // textBoxNumRows
            // 
            this.textBoxNumRows.Location = new System.Drawing.Point(45, 606);
            this.textBoxNumRows.Name = "textBoxNumRows";
            this.textBoxNumRows.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumRows.TabIndex = 3;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(374, 603);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDrawBoard
            // 
            this.buttonDrawBoard.Location = new System.Drawing.Point(233, 603);
            this.buttonDrawBoard.Name = "buttonDrawBoard";
            this.buttonDrawBoard.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawBoard.TabIndex = 5;
            this.buttonDrawBoard.Text = "Draw board";
            this.buttonDrawBoard.UseVisualStyleBackColor = true;
            this.buttonDrawBoard.Click += new System.EventHandler(this.buttonDrawBoard_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(491, 603);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 638);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDrawBoard);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxNumRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumRows;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDrawBoard;
        private System.Windows.Forms.Button buttonExit;
    }
}

