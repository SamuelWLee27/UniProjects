namespace PracTest1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.displayAllRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayByTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayByYearAndLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayTotalNumberOfTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayBestPassRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayTotalTestsPerLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBoxData = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTestType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.displayToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1152, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFileToolStripMenuItem.Text = "Open File...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testingToolStripMenuItem,
            this.toolStripMenuItem2,
            this.displayAllRecordsToolStripMenuItem,
            this.displayByTypeToolStripMenuItem,
            this.displayByYearAndLocationToolStripMenuItem,
            this.displayTotalNumberOfTestsToolStripMenuItem,
            this.displayBestPassRateToolStripMenuItem,
            this.displayTotalTestsPerLocationToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.testingToolStripMenuItem.Text = "Testing";
            this.testingToolStripMenuItem.Click += new System.EventHandler(this.testingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(281, 6);
            // 
            // displayAllRecordsToolStripMenuItem
            // 
            this.displayAllRecordsToolStripMenuItem.Name = "displayAllRecordsToolStripMenuItem";
            this.displayAllRecordsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.displayAllRecordsToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.displayAllRecordsToolStripMenuItem.Text = "Display All Records";
            this.displayAllRecordsToolStripMenuItem.Click += new System.EventHandler(this.displayAllRecordsToolStripMenuItem_Click);
            // 
            // displayByTypeToolStripMenuItem
            // 
            this.displayByTypeToolStripMenuItem.Name = "displayByTypeToolStripMenuItem";
            this.displayByTypeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.displayByTypeToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.displayByTypeToolStripMenuItem.Text = "Display by Test Type";
            this.displayByTypeToolStripMenuItem.Click += new System.EventHandler(this.displayByTypeToolStripMenuItem_Click);
            // 
            // displayByYearAndLocationToolStripMenuItem
            // 
            this.displayByYearAndLocationToolStripMenuItem.Name = "displayByYearAndLocationToolStripMenuItem";
            this.displayByYearAndLocationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.displayByYearAndLocationToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.displayByYearAndLocationToolStripMenuItem.Text = "Display by Test Type and Year";
            this.displayByYearAndLocationToolStripMenuItem.Click += new System.EventHandler(this.displayByYearAndLocationToolStripMenuItem_Click);
            // 
            // displayTotalNumberOfTestsToolStripMenuItem
            // 
            this.displayTotalNumberOfTestsToolStripMenuItem.Name = "displayTotalNumberOfTestsToolStripMenuItem";
            this.displayTotalNumberOfTestsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.displayTotalNumberOfTestsToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.displayTotalNumberOfTestsToolStripMenuItem.Text = "Display Total Number of Failures";
            this.displayTotalNumberOfTestsToolStripMenuItem.Click += new System.EventHandler(this.displayTotalNumberOfTestsToolStripMenuItem_Click);
            // 
            // displayBestPassRateToolStripMenuItem
            // 
            this.displayBestPassRateToolStripMenuItem.Name = "displayBestPassRateToolStripMenuItem";
            this.displayBestPassRateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.displayBestPassRateToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.displayBestPassRateToolStripMenuItem.Text = "Display Worst Fail rate";
            this.displayBestPassRateToolStripMenuItem.Click += new System.EventHandler(this.displayBestPassRateToolStripMenuItem_Click);
            // 
            // displayTotalTestsPerLocationToolStripMenuItem
            // 
            this.displayTotalTestsPerLocationToolStripMenuItem.Name = "displayTotalTestsPerLocationToolStripMenuItem";
            this.displayTotalTestsPerLocationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.displayTotalTestsPerLocationToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.displayTotalTestsPerLocationToolStripMenuItem.Text = "Display Total Tests per Year";
            this.displayTotalTestsPerLocationToolStripMenuItem.Click += new System.EventHandler(this.displayTotalTestsPerLocationToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBoxData
            // 
            this.listBoxData.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxData.FormattingEnabled = true;
            this.listBoxData.ItemHeight = 18;
            this.listBoxData.Location = new System.Drawing.Point(12, 27);
            this.listBoxData.Name = "listBoxData";
            this.listBoxData.Size = new System.Drawing.Size(972, 544);
            this.listBoxData.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(989, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Year:";
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(1046, 53);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(100, 20);
            this.textBoxYear.TabIndex = 3;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(1046, 79);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(100, 20);
            this.textBoxLocation.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(989, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Location:";
            // 
            // textBoxTestType
            // 
            this.textBoxTestType.Location = new System.Drawing.Point(1046, 27);
            this.textBoxTestType.Name = "textBoxTestType";
            this.textBoxTestType.Size = new System.Drawing.Size(100, 20);
            this.textBoxTestType.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(989, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Test Type:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 586);
            this.Controls.Add(this.textBoxTestType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBoxData;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayAllRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayByTypeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.ToolStripMenuItem displayByYearAndLocationToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem displayBestPassRateToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxTestType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem displayTotalNumberOfTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayTotalTestsPerLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

