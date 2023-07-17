using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical
{
    public partial class Form1 : Form
    {
        //The minimum number of hours to display
        const int MIN_HOURS = 1;
        //The maximum number of hours to display
        const int MAX_HOURS = 24;
        //The number of days to display
        const int NUM_DAYS = 7;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Draw square
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="sColor"></param>
        private void DrawSquare(Graphics canvas, int x, int y, int width, int height, Color sColor)
        {
            //create pen
            Pen pen1 = new Pen(Color.Black, 2);
            //create brush
            SolidBrush br = new SolidBrush(sColor);
            //draw square then outline for square
            canvas.FillRectangle(br, x, y, width, height);
            canvas.DrawRectangle(pen1, x, y, width, height);
        }

        /// <summary>
        /// Draw row of squares
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DrawRow(Graphics canvas, int y, int width, int height)
        {
            //declear x varible
            int x = 0;
            //loop to draw a row
            for (int day = 1; day <= NUM_DAYS; day++)
            {
                //check if weekend
                if (day >= 6)
                {
                    //if weekend draw a light blue square
                    DrawSquare(canvas, x, y, width, height, Color.LightBlue);
                }
                else
                {
                    //if weekday draw white square 
                    DrawSquare(canvas, x, y, width, height, Color.White);
                }
                //shift x by width of square
                x += width;
            }
        }

        /// <summary>
        /// Exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Clear textbox, clear picturebox and focus textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear textbox
            textBoxHours.Clear();
            //set focus to textbox
            textBoxHours.Focus();
            //Clear picturebox
            pictureBoxDisplay.Refresh();
        }
        /// <summary>
        /// draw event planner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawPlannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create graphic for picturebox
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            //DrawSquare(paper, 0, 0, 50, 50, Color.Blue);
            //DrawRow(paper, 0, 50, 50);
            //
            //declear varibles
            int y = 0;
            int width = pictureBoxDisplay.Width / NUM_DAYS;
            try
            {
                //get input varible
                int hours = int.Parse(textBoxHours.Text);
                //Get height of squares
                int height = pictureBoxDisplay.Height / hours;
                //check if hours is valid
                if (hours >= MIN_HOURS && hours <= MAX_HOURS)
                {
                    //loop for each row for how many hours that is input
                    for (int row = 1; row <= hours; row++)
                    {
                        //call draw row method
                        DrawRow(paper, y, width, height);
                        //shift y height of square
                        y += height;
                    }
                }
                else
                {
                    //error message
                    MessageBox.Show("Hours must be within 24 hours");
                    //Clear textbox
                    textBoxHours.Clear();
                    //set focus to textbox
                    textBoxHours.Focus();
                    //Clear picturebox
                    pictureBoxDisplay.Refresh();
                }

            }
            catch (Exception ex)
            {
                //error message
                MessageBox.Show(ex.Message);
                //Clear textbox
                textBoxHours.Clear();
                //set focus to textbox
                textBoxHours.Focus();
                //Clear picturebox
                pictureBoxDisplay.Refresh();
            }
        }
    }
}
