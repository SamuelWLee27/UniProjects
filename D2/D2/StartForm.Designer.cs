namespace D2
{
    partial class StartForm
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
            this.buttonClasses = new System.Windows.Forms.Button();
            this.buttonSummaryReport = new System.Windows.Forms.Button();
            this.buttonCertification = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PrapareAware";
            // 
            // buttonClasses
            // 
            this.buttonClasses.Location = new System.Drawing.Point(41, 59);
            this.buttonClasses.Name = "buttonClasses";
            this.buttonClasses.Size = new System.Drawing.Size(255, 40);
            this.buttonClasses.TabIndex = 1;
            this.buttonClasses.Text = "Classes";
            this.buttonClasses.UseVisualStyleBackColor = true;
            this.buttonClasses.Click += new System.EventHandler(this.buttonClasses_Click);
            // 
            // buttonSummaryReport
            // 
            this.buttonSummaryReport.Location = new System.Drawing.Point(41, 217);
            this.buttonSummaryReport.Name = "buttonSummaryReport";
            this.buttonSummaryReport.Size = new System.Drawing.Size(255, 40);
            this.buttonSummaryReport.TabIndex = 2;
            this.buttonSummaryReport.Text = "SummaryReport";
            this.buttonSummaryReport.UseVisualStyleBackColor = true;
            this.buttonSummaryReport.Click += new System.EventHandler(this.buttonSummaryReport_Click);
            // 
            // buttonCertification
            // 
            this.buttonCertification.Location = new System.Drawing.Point(41, 134);
            this.buttonCertification.Name = "buttonCertification";
            this.buttonCertification.Size = new System.Drawing.Size(255, 40);
            this.buttonCertification.TabIndex = 3;
            this.buttonCertification.Text = "Certification";
            this.buttonCertification.UseVisualStyleBackColor = true;
            this.buttonCertification.Click += new System.EventHandler(this.buttonCertification_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 316);
            this.Controls.Add(this.buttonCertification);
            this.Controls.Add(this.buttonSummaryReport);
            this.Controls.Add(this.buttonClasses);
            this.Controls.Add(this.label1);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClasses;
        private System.Windows.Forms.Button buttonSummaryReport;
        private System.Windows.Forms.Button buttonCertification;
    }
}