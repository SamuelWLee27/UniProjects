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
        //An array that stores rain fall values in mm
        int[] rainfallArray = new int[] { 10, 5, 30, 50, 0, 2, 0, 0, 8, 25, 15, 6, 0, 0, 22 };
        //The width of a bar in the graph
        const int BAR_WIDTH = 40;
        //The maximum amount of rainfall
        const int MAX_RAINFALL = 100;
        //The gap between the bars on the graph
        const int GAP = 5;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calculates the barheight for a rainfall value.
        /// </summary>
        /// <param name="value">The rainfall value to calculate the bar height for</param>
        /// <returns>The height of a bar in the graph for the rainfall value</returns>
        private int CalcBarHeight(int value)
        {
            int height = pictureBoxDisplay.Height * value / MAX_RAINFALL;
            return height;
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Clears the picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
        }
        /// <summary>
        /// Calculate number of days with zero rain once clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCalc_Click(object sender, EventArgs e)
        {
            //declear varible
            int counter = 0;
            //loop through array
            for(int i = 0; i < rainfallArray.Length; i++)
            {
                //check if amount of rain is equal to zero
                if (rainfallArray[i] == 0)
                {
                    //add one to counter
                    counter++;
                }
            }
            //display number of days with no rain
            MessageBox.Show(counter + " Days of rain");
        }
        /// <summary>
        /// Draw graph for amount of rain once clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDrawGraph_Click(object sender, EventArgs e)
        {
            //declear varibles
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            int height = 0;
            SolidBrush br = new SolidBrush(Color.LightBlue);
            int xPos = 0;
            int yPos = 0;
            //loop through array
            for(int i = 0;i < rainfallArray.Length; i++)
            {
                //get bar height
                height = CalcBarHeight(rainfallArray[i]);
                //set y so bar rises from bottom
                yPos = pictureBoxDisplay.Height - height;
                //Draw bar
                paper.FillRectangle(br, xPos, yPos, BAR_WIDTH, height);
                //Shift x position
                xPos += BAR_WIDTH + GAP;
            }

        }
    }
}
