namespace PracP6_Task3
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
            this.buttonCost = new System.Windows.Forms.Button();
            this.listBoxPostalItems = new System.Windows.Forms.ListBox();
            this.buttonDisplay = new System.Windows.Forms.Button();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCost
            // 
            this.buttonCost.Location = new System.Drawing.Point(671, 217);
            this.buttonCost.Name = "buttonCost";
            this.buttonCost.Size = new System.Drawing.Size(75, 23);
            this.buttonCost.TabIndex = 0;
            this.buttonCost.Text = "Cost";
            this.buttonCost.UseVisualStyleBackColor = true;
            this.buttonCost.Click += new System.EventHandler(this.buttonCost_Click);
            // 
            // listBoxPostalItems
            // 
            this.listBoxPostalItems.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPostalItems.FormattingEnabled = true;
            this.listBoxPostalItems.ItemHeight = 14;
            this.listBoxPostalItems.Location = new System.Drawing.Point(12, 12);
            this.listBoxPostalItems.Name = "listBoxPostalItems";
            this.listBoxPostalItems.Size = new System.Drawing.Size(653, 368);
            this.listBoxPostalItems.TabIndex = 1;
            // 
            // buttonDisplay
            // 
            this.buttonDisplay.Location = new System.Drawing.Point(689, 39);
            this.buttonDisplay.Name = "buttonDisplay";
            this.buttonDisplay.Size = new System.Drawing.Size(75, 23);
            this.buttonDisplay.TabIndex = 2;
            this.buttonDisplay.Text = "Display list";
            this.buttonDisplay.UseVisualStyleBackColor = true;
            this.buttonDisplay.Click += new System.EventHandler(this.buttonDisplay_Click);
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(671, 303);
            this.textBoxCost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.ReadOnly = true;
            this.textBoxCost.Size = new System.Drawing.Size(76, 20);
            this.textBoxCost.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.buttonDisplay);
            this.Controls.Add(this.listBoxPostalItems);
            this.Controls.Add(this.buttonCost);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCost;
        private System.Windows.Forms.ListBox listBoxPostalItems;
        private System.Windows.Forms.Button buttonDisplay;
        private System.Windows.Forms.TextBox textBoxCost;
    }
}

