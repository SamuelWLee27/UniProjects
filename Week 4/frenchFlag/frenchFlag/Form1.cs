using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frenchFlag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDrawFlag_Click(object sender, EventArgs e)
        {
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            int x = 0;
            int y = 0;

            Brush br = new SolidBrush(Color.Blue);
            paper.FillRectangle(br, x, y, pictureBoxDisplay.Width/3, pictureBoxDisplay.Height);
            br = new SolidBrush(Color.White);
            x = pictureBoxDisplay.Width / 3;
            paper.FillRectangle(br, x,y, pictureBoxDisplay.Width/3, pictureBoxDisplay.Height);
            br = new SolidBrush(Color.Red);
            x = pictureBoxDisplay.Width/3*2;
            paper.FillRectangle(br, x, y, pictureBoxDisplay.Width/3*2, pictureBoxDisplay.Height);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
