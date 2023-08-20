namespace Circuits
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOR = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLamp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEval = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClone = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEndGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAnd,
            this.toolStripButtonOR,
            this.toolStripButtonNot,
            this.toolStripButtonInput,
            this.toolStripButtonLamp,
            this.toolStripButtonEval,
            this.toolStripButtonClone,
            this.toolStripButtonStartGroup,
            this.toolStripButtonEndGroup});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1416, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAnd
            // 
            this.toolStripButtonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnd.Image = global::Circuits.Properties.Resources.AndIcon;
            this.toolStripButtonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnd.Name = "toolStripButtonAnd";
            this.toolStripButtonAnd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAnd.Text = "toolStripButton1";
            this.toolStripButtonAnd.Click += new System.EventHandler(this.toolStripButtonAnd_Click);
            // 
            // toolStripButtonOR
            // 
            this.toolStripButtonOR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOR.Image = global::Circuits.Properties.Resources.OrIcon;
            this.toolStripButtonOR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOR.Name = "toolStripButtonOR";
            this.toolStripButtonOR.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOR.Text = "toolStripButton1";
            this.toolStripButtonOR.Click += new System.EventHandler(this.toolStripButtonOR_Click);
            // 
            // toolStripButtonNot
            // 
            this.toolStripButtonNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNot.Image = global::Circuits.Properties.Resources.NotIcon;
            this.toolStripButtonNot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNot.Name = "toolStripButtonNot";
            this.toolStripButtonNot.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNot.Text = "toolStripButton";
            this.toolStripButtonNot.ToolTipText = "toolStripButtonNot";
            this.toolStripButtonNot.Click += new System.EventHandler(this.toolStripButtonNot_Click);
            // 
            // toolStripButtonInput
            // 
            this.toolStripButtonInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInput.Image = global::Circuits.Properties.Resources.InputIcon;
            this.toolStripButtonInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInput.Name = "toolStripButtonInput";
            this.toolStripButtonInput.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonInput.Text = "toolStripButton1";
            this.toolStripButtonInput.Click += new System.EventHandler(this.toolStripButtonInput_Click);
            // 
            // toolStripButtonLamp
            // 
            this.toolStripButtonLamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLamp.Image = global::Circuits.Properties.Resources.OutputIcon;
            this.toolStripButtonLamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLamp.Name = "toolStripButtonLamp";
            this.toolStripButtonLamp.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLamp.Text = "toolStripButton1";
            this.toolStripButtonLamp.Click += new System.EventHandler(this.toolStripButtonLamp_Click);
            // 
            // toolStripButtonEval
            // 
            this.toolStripButtonEval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEval.Image = global::Circuits.Properties.Resources.EvaluateIcon;
            this.toolStripButtonEval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEval.Name = "toolStripButtonEval";
            this.toolStripButtonEval.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEval.Text = "toolStripButton1";
            this.toolStripButtonEval.Click += new System.EventHandler(this.toolStripButtonEval_Click);
            // 
            // toolStripButtonClone
            // 
            this.toolStripButtonClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClone.Image = global::Circuits.Properties.Resources.CopyIcon;
            this.toolStripButtonClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClone.Name = "toolStripButtonClone";
            this.toolStripButtonClone.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClone.Text = "toolStripButton1";
            this.toolStripButtonClone.Click += new System.EventHandler(this.toolStripButtonClone_Click);
            // 
            // toolStripButtonStartGroup
            // 
            this.toolStripButtonStartGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStartGroup.Image = global::Circuits.Properties.Resources.StartCompoundIcon;
            this.toolStripButtonStartGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartGroup.Name = "toolStripButtonStartGroup";
            this.toolStripButtonStartGroup.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStartGroup.Text = "toolStripButton1";
            this.toolStripButtonStartGroup.Click += new System.EventHandler(this.toolStripButtonStartGroup_Click);
            // 
            // toolStripButtonEndGroup
            // 
            this.toolStripButtonEndGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEndGroup.Image = global::Circuits.Properties.Resources.EndCompoundIcon;
            this.toolStripButtonEndGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEndGroup.Name = "toolStripButtonEndGroup";
            this.toolStripButtonEndGroup.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEndGroup.Text = "toolStripButton1";
            this.toolStripButtonEndGroup.Click += new System.EventHandler(this.toolStripButtonEndGroup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1416, 729);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnd;
        private System.Windows.Forms.ToolStripButton toolStripButtonOR;
        private System.Windows.Forms.ToolStripButton toolStripButtonNot;
        private System.Windows.Forms.ToolStripButton toolStripButtonInput;
        private System.Windows.Forms.ToolStripButton toolStripButtonLamp;
        private System.Windows.Forms.ToolStripButton toolStripButtonEval;
        private System.Windows.Forms.ToolStripButton toolStripButtonClone;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartGroup;
        private System.Windows.Forms.ToolStripButton toolStripButtonEndGroup;
    }
}

