using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2_Ex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            Graphics Paper = pictureBoxDisplay.CreateGraphics();
            Pen pen1 = new Pen(Color.Blue, 5);

            Paper.DrawLine(pen1, 10, 10, 100, 100);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDrawSquare_Click(object sender, EventArgs e)
        {
            Graphics Paper = pictureBoxDisplay.CreateGraphics();
            Pen penSquare = new Pen(Color.Pink,5);

            Paper.DrawLine(penSquare, 10, 10, 10, 40);

            penSquare.Color = Color.Yellow;
            penSquare.Width = 7;

            Paper.DrawLine(penSquare, 10, 10, 40, 10);

            penSquare.Color = Color.OrangeRed;
            penSquare.Width = 3;

            Paper.DrawLine(penSquare, 40, 10, 40, 40);

            penSquare.Color = Color.Violet;
            penSquare.Width = 4;

            Paper.DrawLine(penSquare, 40, 40, 10, 40);
        }
    }
}
