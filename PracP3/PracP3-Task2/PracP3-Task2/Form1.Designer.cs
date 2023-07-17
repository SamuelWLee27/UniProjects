namespace PracP3_Task2
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
            this.listBoxStudents = new System.Windows.Forms.ListBox();
            this.buttonNewStudent = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxHasPaid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxStudents
            // 
            this.listBoxStudents.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxStudents.FormattingEnabled = true;
            this.listBoxStudents.ItemHeight = 14;
            this.listBoxStudents.Location = new System.Drawing.Point(34, 147);
            this.listBoxStudents.Name = "listBoxStudents";
            this.listBoxStudents.Size = new System.Drawing.Size(459, 284);
            this.listBoxStudents.TabIndex = 0;
            // 
            // buttonNewStudent
            // 
            this.buttonNewStudent.Location = new System.Drawing.Point(155, 100);
            this.buttonNewStudent.Name = "buttonNewStudent";
            this.buttonNewStudent.Size = new System.Drawing.Size(171, 41);
            this.buttonNewStudent.TabIndex = 1;
            this.buttonNewStudent.Text = "New student";
            this.buttonNewStudent.UseVisualStyleBackColor = true;
            this.buttonNewStudent.Click += new System.EventHandler(this.buttonNewStudent_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(34, 66);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(174, 66);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 3;
            // 
            // textBoxHasPaid
            // 
            this.textBoxHasPaid.Location = new System.Drawing.Point(319, 66);
            this.textBoxHasPaid.Name = "textBoxHasPaid";
            this.textBoxHasPaid.Size = new System.Drawing.Size(100, 20);
            this.textBoxHasPaid.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Has Paid (true/false)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHasPaid);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonNewStudent);
            this.Controls.Add(this.listBoxStudents);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxStudents;
        private System.Windows.Forms.Button buttonNewStudent;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxHasPaid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

