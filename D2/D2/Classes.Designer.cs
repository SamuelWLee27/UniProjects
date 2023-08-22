namespace D2
{
    partial class Classes
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
            this.buttonDisplayClasses = new System.Windows.Forms.Button();
            this.listBoxDisplay = new System.Windows.Forms.ListBox();
            this.radioButtonPast = new System.Windows.Forms.RadioButton();
            this.radioButtonPresent = new System.Windows.Forms.RadioButton();
            this.radioButtonFuture = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddClass = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDisplayClasses
            // 
            this.buttonDisplayClasses.Location = new System.Drawing.Point(12, 99);
            this.buttonDisplayClasses.Name = "buttonDisplayClasses";
            this.buttonDisplayClasses.Size = new System.Drawing.Size(154, 42);
            this.buttonDisplayClasses.TabIndex = 0;
            this.buttonDisplayClasses.Text = "Display Classes";
            this.buttonDisplayClasses.UseVisualStyleBackColor = true;
            this.buttonDisplayClasses.Click += new System.EventHandler(this.buttonDisplayClasses_Click);
            // 
            // listBoxDisplay
            // 
            this.listBoxDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDisplay.FormattingEnabled = true;
            this.listBoxDisplay.Location = new System.Drawing.Point(172, 99);
            this.listBoxDisplay.Name = "listBoxDisplay";
            this.listBoxDisplay.Size = new System.Drawing.Size(997, 381);
            this.listBoxDisplay.TabIndex = 4;
            // 
            // radioButtonPast
            // 
            this.radioButtonPast.AutoSize = true;
            this.radioButtonPast.Location = new System.Drawing.Point(13, 147);
            this.radioButtonPast.Name = "radioButtonPast";
            this.radioButtonPast.Size = new System.Drawing.Size(85, 17);
            this.radioButtonPast.TabIndex = 5;
            this.radioButtonPast.TabStop = true;
            this.radioButtonPast.Text = "Past Classes";
            this.radioButtonPast.UseVisualStyleBackColor = true;
            // 
            // radioButtonPresent
            // 
            this.radioButtonPresent.AutoSize = true;
            this.radioButtonPresent.Location = new System.Drawing.Point(13, 178);
            this.radioButtonPresent.Name = "radioButtonPresent";
            this.radioButtonPresent.Size = new System.Drawing.Size(100, 17);
            this.radioButtonPresent.TabIndex = 6;
            this.radioButtonPresent.TabStop = true;
            this.radioButtonPresent.Text = "Present Classes";
            this.radioButtonPresent.UseVisualStyleBackColor = true;
            // 
            // radioButtonFuture
            // 
            this.radioButtonFuture.AutoSize = true;
            this.radioButtonFuture.Location = new System.Drawing.Point(13, 209);
            this.radioButtonFuture.Name = "radioButtonFuture";
            this.radioButtonFuture.Size = new System.Drawing.Size(94, 17);
            this.radioButtonFuture.TabIndex = 7;
            this.radioButtonFuture.TabStop = true;
            this.radioButtonFuture.Text = "Future Classes";
            this.radioButtonFuture.UseVisualStyleBackColor = true;
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(13, 240);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(75, 17);
            this.radioButtonAll.TabIndex = 8;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All Classes";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(489, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search Classes";
            // 
            // buttonAddClass
            // 
            this.buttonAddClass.Location = new System.Drawing.Point(12, 263);
            this.buttonAddClass.Name = "buttonAddClass";
            this.buttonAddClass.Size = new System.Drawing.Size(154, 42);
            this.buttonAddClass.TabIndex = 11;
            this.buttonAddClass.Text = "Add Class";
            this.buttonAddClass.UseVisualStyleBackColor = true;
            this.buttonAddClass.Click += new System.EventHandler(this.buttonAddClass_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 437);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(154, 42);
            this.buttonBack.TabIndex = 12;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // Classes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 491);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAddClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonAll);
            this.Controls.Add(this.radioButtonFuture);
            this.Controls.Add(this.radioButtonPresent);
            this.Controls.Add(this.radioButtonPast);
            this.Controls.Add(this.listBoxDisplay);
            this.Controls.Add(this.buttonDisplayClasses);
            this.Name = "Classes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDisplayClasses;
        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.RadioButton radioButtonPast;
        private System.Windows.Forms.RadioButton radioButtonPresent;
        private System.Windows.Forms.RadioButton radioButtonFuture;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddClass;
        private System.Windows.Forms.Button buttonBack;
    }
}

