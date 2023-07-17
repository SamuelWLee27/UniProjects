using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Practical
{
    public partial class Form1 : Form
    {

        //The width of a bar in the bar graph
        const int BAR_WIDTH = 25;

        //the gap between bars in the bar graph
        const int GAP = 5;

        //the factor to scale the the graph by to make it fit nicely in the the picturebox
        const int SCALE_FACTOR = 15;

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// calculate steps per metre
        /// </summary>
        /// <param name="numSteps"> get total steps</param>
        /// <param name="distance"> Get distance walked</param>
        /// <returns></returns>
        private double calculateStepsPerMetre(int numSteps, double distance)
        {
            //calculate steps per metre
            double stepsPerMetre = (double)numSteps / ((double)distance * 1000);
            //return calculation
            return stepsPerMetre;
        }

        /// <summary>
        /// Draws a vertical bar that is part of a bar graph.
        /// i.e. It fills a rectangle at position (x,y) with the specified colour.
        /// Then draws a black outline for the rectangle.
        /// Uses the BAR_WIDTH constant for the size of the rectangle.
        /// </summary>
        /// <param name="paper">The Graphics object to draw on.</param>
        /// <param name="x">The x position of the top left corner of the rectangle.</param>
        /// <param name="y">The y position of the top left corner of the rectangle.</param>
        /// <param name="colour">The colour to fill the background of the rectangle with.</param>
        private void DrawABar(Graphics paper, int x, int y, int length, Color colour)
        {
            //create a brush of specified colour and fill background with this colour 
            SolidBrush brush = new SolidBrush(colour);
            paper.FillRectangle(brush, x, y, BAR_WIDTH, length);

            //draw outline in black
            paper.DrawRectangle(Pens.Black, x, y, BAR_WIDTH, length);
        }
        /// <summary>
        /// exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// clear listbox and first picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear listbox and first picturebox
            listBoxOutput.Items.Clear();
            pictureBoxTop.Refresh();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear reader
            StreamReader reader;


            //filter for files
            const string FILTER = "CSV Files|*.csv|All Files|*.*";
            //Set filter for dialog control
            openFileDialog1.Filter = FILTER;
            //check if user selected file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //declear variables
                string date = "";
                int caloriesBurned = 0;
                int steps = 0;
                double distance = 0;
                int minInactive = 0;
                int minLight = 0;
                int minFairly = 0;
                int minVery = 0;
                int activityCal = 0;
                int totalSteps = 0;
                int x = 0;
                int y = 0;
                Graphics paper = pictureBoxTop.CreateGraphics();

                //Open selected file
                reader = File.OpenText(openFileDialog1.FileName);

                //dvlear string varible
                string line = "";
                //loop until reached end of file
                while (!reader.EndOfStream)
                {
                    try
                    {
                        //read a line of file into varible
                        line = reader.ReadLine();
                        //split text by commas
                        string[] table = line.Split(',');
                        //if it is the right number of data
                        if (table.Length == 9)
                        {
                            //put the data from file into varibles
                            date = (table[0]);
                            caloriesBurned = int.Parse(table[1]);
                            steps = int.Parse(table[2]);
                            distance = double.Parse(table[3]);
                            minInactive = int.Parse(table[4]);
                            minLight = int.Parse(table[5]);
                            minFairly = int.Parse(table[6]);
                            minVery = int.Parse(table[7]);
                            activityCal = int.Parse(table[8]);
                            //calculate steps per metre from method
                            double stepsPerMetre = calculateStepsPerMetre(totalSteps, distance);
                            //display data in list box
                            string list = date.ToString().PadRight(15) + caloriesBurned.ToString().PadRight(10) + steps.ToString().PadRight(8) + distance.ToString().PadRight(13)
                                + minInactive.ToString().PadRight(10) + minLight.ToString().PadRight(8) + minFairly.ToString().PadRight(8) + minVery.ToString().PadRight(8)
                                + activityCal.ToString().PadRight(8) + stepsPerMetre.ToString("n3");
                            listBoxOutput.Items.Add(list);
                            //caculate total steps
                            totalSteps += steps;
                            //calculate height of bar
                            int height = (int)distance * SCALE_FACTOR;
                            //find y so bars rise
                            y = pictureBoxTop.Height - height;
                            //call draw bar method
                            DrawABar(paper, x, y, height, Color.LightBlue);
                            //shift x pos
                            x += BAR_WIDTH;
                        }
                        else
                        {
                            //error
                            Console.WriteLine("Error: " + line);
                        }

                    }
                    catch (Exception ex)
                    {
                        //error
                        Console.WriteLine("Error: " + line);
                    }

                }
                //show total steps
                MessageBox.Show("number of steps taken this month " + totalSteps);
                //close reader
                reader.Close();
            }
        }

        private void listBoxOutput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    

