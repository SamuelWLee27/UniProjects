using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week3_E1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttontriangle_Click(object sender, EventArgs e)
        {
            Graphics Paper = pictureBoxDisplay.CreateGraphics();
            //create pen
            Pen penTriangle = new Pen(Color.Blue, 5);
            //create points for triangle corners
            Point corner1 = new Point(20, 10);

            Point corner2 = new Point(30, 30);

            Point corner3 = new Point(10, 30);
            //Draw triangle
            Paper.DrawLine(penTriangle, corner1, corner2);

            Paper.DrawLine(penTriangle, corner2, corner3);

            Paper.DrawLine(penTriangle, corner3, corner1);
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            Graphics Paper = pictureBoxDisplay.CreateGraphics();
            //create pen
            Pen penSquare = new Pen(Color.Blue, 5);
            //declear x and y value
            int x = 100;
            int y = 50;
            //Draw square
            Paper.DrawRectangle(penSquare, x, y, 100, 50);
        }
    }
}
