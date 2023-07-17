using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mouseMoveGraphics
{
    public partial class Form1 : Form
    {

        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonSetColour_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
        /// <summary>
        /// Draw coloure dots as mouse moves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            ///Declear varibles
            int circle = 0;
            int size = 0;
            int red = 0;
            int green = 0;
            int blue = 0;
            int xPos = 0;
            int yPos = 0;

            /// check if left mouse button is click while the mouse is moving
            if (e.Button == MouseButtons.Left)
            {
                ///random number of circles around mouse when moves
                circle = rand.Next(5, 11);
                int counter = 1;
                /// While loop for multiple circles
                while (counter <= circle) 
                {
                   ///Create random colours
                    size = rand.Next(2, 11);
                    red = rand.Next(0, 256);
                    green = rand.Next(0, 256);
                    blue = rand.Next(0, 256);
                    ///Random positions for circles around the mouse
                    xPos = e.X + rand.Next(-10, 11);
                    yPos = e.Y + rand.Next(-10, 11);
                    /// Create graphics paper
                    Graphics paper = pictureBoxDisplay.CreateGraphics();
                    /// create pen
                    Pen pen1 = new Pen(Color.Black, 2);
                    ///create brush
                    SolidBrush br = new SolidBrush(Color.Orange);
                    /// paper.DrawLine(pen1, pictureBoxDisplay.Width / 2, pictureBoxDisplay.Height / 2, e.X, e.Y);
                    ///paper.DrawLine(pen1, rand.Next(pictureBoxDisplay.Width+1), rand.Next(pictureBoxDisplay.Height+1), e.X, e.Y);
                    ///change brush colour to random
                    br.Color = Color.FromArgb(red, green, blue);
                    ///create circles
                    paper.FillEllipse(br, xPos, yPos, size, size);
                    paper.DrawEllipse(pen1, xPos, yPos, size, size);
                    ///add to counter
                    counter ++;
                }
                
            }
        }
    }
}
