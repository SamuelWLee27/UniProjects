namespace D2
{
    partial class SummaryReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.displaySummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxDisplay = new System.Windows.Forms.ListBox();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxChart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displaySummaryReportToolStripMenuItem,
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // displaySummaryReportToolStripMenuItem
            // 
            this.displaySummaryReportToolStripMenuItem.Name = "displaySummaryReportToolStripMenuItem";
            this.displaySummaryReportToolStripMenuItem.Size = new System.Drawing.Size(149, 20);
            this.displaySummaryReportToolStripMenuItem.Text = "Display Summary Report";
            this.displaySummaryReportToolStripMenuItem.Click += new System.EventHandler(this.displaySummaryReportToolStripMenuItem_Click);
            // 
            // listBoxDisplay
            // 
            this.listBoxDisplay.FormattingEnabled = true;
            this.listBoxDisplay.Location = new System.Drawing.Point(12, 27);
            this.listBoxDisplay.Name = "listBoxDisplay";
            this.listBoxDisplay.Size = new System.Drawing.Size(238, 407);
            this.listBoxDisplay.TabIndex = 1;
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // chartGraph
            // 
            chartArea4.Name = "ChartArea";
            this.chartGraph.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartGraph.Legends.Add(legend4);
            this.chartGraph.Location = new System.Drawing.Point(283, 81);
            this.chartGraph.Name = "chartGraph";
            series4.ChartArea = "ChartArea";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartGraph.Series.Add(series4);
            this.chartGraph.Size = new System.Drawing.Size(487, 353);
            this.chartGraph.TabIndex = 2;
            this.chartGraph.Text = "chart";
            // 
            // comboBoxChart
            // 
            this.comboBoxChart.FormattingEnabled = true;
            this.comboBoxChart.Items.AddRange(new object[] {
            "Where Class Took Place",
            "When Class Took Place",
            "Instructor Assigned To Course"});
            this.comboBoxChart.Location = new System.Drawing.Point(436, 43);
            this.comboBoxChart.Name = "comboBoxChart";
            this.comboBoxChart.Size = new System.Drawing.Size(198, 21);
            this.comboBoxChart.TabIndex = 3;
            this.comboBoxChart.SelectedIndexChanged += new System.EventHandler(this.comboBoxChart_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chart Type:";
            // 
            // SummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxChart);
            this.Controls.Add(this.chartGraph);
            this.Controls.Add(this.listBoxDisplay);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SummaryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SummaryReport";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem displaySummaryReportToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGraph;
        private System.Windows.Forms.ComboBox comboBoxChart;
        private System.Windows.Forms.Label label1;
    }
}