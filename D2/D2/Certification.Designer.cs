namespace D2
{
    partial class Certification
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearchEmail = new System.Windows.Forms.Button();
            this.textBoxSearchStudent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxDisplayStudent = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAddStudent = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxClassID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxMark = new System.Windows.Forms.TextBox();
            this.buttonAttendance = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Email:";
            // 
            // buttonSearchEmail
            // 
            this.buttonSearchEmail.Location = new System.Drawing.Point(55, 92);
            this.buttonSearchEmail.Name = "buttonSearchEmail";
            this.buttonSearchEmail.Size = new System.Drawing.Size(137, 23);
            this.buttonSearchEmail.TabIndex = 1;
            this.buttonSearchEmail.Text = "Search For Student";
            this.buttonSearchEmail.UseVisualStyleBackColor = true;
            this.buttonSearchEmail.Click += new System.EventHandler(this.buttonSearchEmail_Click);
            // 
            // textBoxSearchStudent
            // 
            this.textBoxSearchStudent.Location = new System.Drawing.Point(55, 66);
            this.textBoxSearchStudent.Name = "textBoxSearchStudent";
            this.textBoxSearchStudent.Size = new System.Drawing.Size(213, 20);
            this.textBoxSearchStudent.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Student Certification";
            // 
            // listBoxDisplayStudent
            // 
            this.listBoxDisplayStudent.FormattingEnabled = true;
            this.listBoxDisplayStudent.Location = new System.Drawing.Point(55, 121);
            this.listBoxDisplayStudent.Name = "listBoxDisplayStudent";
            this.listBoxDisplayStudent.Size = new System.Drawing.Size(579, 30);
            this.listBoxDisplayStudent.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "If no students found after search add new student with email above";
            // 
            // textBoxFname
            // 
            this.textBoxFname.Location = new System.Drawing.Point(55, 209);
            this.textBoxFname.Name = "textBoxFname";
            this.textBoxFname.Size = new System.Drawing.Size(134, 20);
            this.textBoxFname.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "New Student Infomation:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "First Name:";
            // 
            // textBoxSname
            // 
            this.textBoxSname.Location = new System.Drawing.Point(208, 209);
            this.textBoxSname.Name = "textBoxSname";
            this.textBoxSname.Size = new System.Drawing.Size(136, 20);
            this.textBoxSname.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Last Name:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(363, 209);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(181, 20);
            this.textBoxPhone.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Phone Number:";
            // 
            // buttonAddStudent
            // 
            this.buttonAddStudent.Location = new System.Drawing.Point(55, 235);
            this.buttonAddStudent.Name = "buttonAddStudent";
            this.buttonAddStudent.Size = new System.Drawing.Size(134, 23);
            this.buttonAddStudent.TabIndex = 13;
            this.buttonAddStudent.Text = "Add Student";
            this.buttonAddStudent.UseVisualStyleBackColor = true;
            this.buttonAddStudent.Click += new System.EventHandler(this.buttonAddStudent_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Add Class Attendence For Student Above";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "ClassID:";
            // 
            // textBoxClassID
            // 
            this.textBoxClassID.Location = new System.Drawing.Point(55, 299);
            this.textBoxClassID.Name = "textBoxClassID";
            this.textBoxClassID.Size = new System.Drawing.Size(100, 20);
            this.textBoxClassID.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(187, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Mark: (0-100)";
            // 
            // textBoxMark
            // 
            this.textBoxMark.Location = new System.Drawing.Point(188, 299);
            this.textBoxMark.Name = "textBoxMark";
            this.textBoxMark.Size = new System.Drawing.Size(100, 20);
            this.textBoxMark.TabIndex = 18;
            // 
            // buttonAttendance
            // 
            this.buttonAttendance.Location = new System.Drawing.Point(55, 325);
            this.buttonAttendance.Name = "buttonAttendance";
            this.buttonAttendance.Size = new System.Drawing.Size(134, 23);
            this.buttonAttendance.TabIndex = 19;
            this.buttonAttendance.Text = "Add Attendance";
            this.buttonAttendance.UseVisualStyleBackColor = true;
            this.buttonAttendance.Click += new System.EventHandler(this.buttonAttendance_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(497, 396);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(179, 42);
            this.buttonBack.TabIndex = 20;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // Certification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 450);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAttendance);
            this.Controls.Add(this.textBoxMark);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxClassID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonAddStudent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxSname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxDisplayStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSearchStudent);
            this.Controls.Add(this.buttonSearchEmail);
            this.Controls.Add(this.label1);
            this.Name = "Certification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearchEmail;
        private System.Windows.Forms.TextBox textBoxSearchStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxDisplayStudent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAddStudent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxClassID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxMark;
        private System.Windows.Forms.Button buttonAttendance;
        private System.Windows.Forms.Button buttonBack;
    }
}