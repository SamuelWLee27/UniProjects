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
        //Filter for csv files and all files
        const string FILTER = "CSV files|*.csv|All Files|*.*";
        //Maximum number of student data
        const int MAX_STUDENTS = 100;
        //An array to store all id numbers
        string[] idArray = new string[MAX_STUDENTS];
        //An array to store all the exam marks
        int[] markArray = new int[MAX_STUDENTS];
        //The number of students read from the file
        int numStudents = 0;

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// return letter grade
        /// </summary>
        /// <param name="mark"> get mark </param>
        /// <returns></returns>
        private string CalcLetterGrade(int mark)
        {
            //check mark and return appropiate letter grade
            if (mark >= 80 && mark <= 100)
            {
                return "A";
            }
            else if (mark >= 65 && mark <= 79)
            {
                return "B";
            }
            else if (mark >= 50 && mark <= 64)
            {
                return "C";
            }
            else if (mark >= 35 && mark <= 49)
            {
                return "D";
            }
            else
            {
                return "E";
            }
        }
        /// <summary>
        /// calculate height of bar
        /// </summary>
        /// <param name="mark">get mark</param>
        /// <returns></returns>
        private int CalculateBarHeight(int mark)
        {
            //calculate height of bar
            int height = (pictureBoxDisplay.Height * mark) / 100;
            //return height of bar
            return height;
        }

        /// <summary>
        /// Will load a csv file of marks and store the data in appropriate arrays.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadMarkFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader reader;
            string line = "";
            string[] csvArray;
            string id = "";
            int mark = 0;

            //Set filter for dialog control
            openFileDialog1.Filter = FILTER;
            //Check if the user has selected a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the selected file
                reader = File.OpenText(openFileDialog1.FileName);
                //Repeat while it is not the end of the file
                while (!reader.EndOfStream)
                {
                    try
                    {
                        //Read a line from the file
                        line = reader.ReadLine();
                        //Split the line using an array
                        csvArray = line.Split(',');
                        //Check if the array has the correct number of elements
                        if (csvArray.Length == 2)
                        {
                            //Extract the values into separate variables
                            id = csvArray[0];
                            mark = int.Parse(csvArray[1]);
                            //Display the data in the listbox
                            listBoxData.Items.Add(id.PadRight(10) + mark);
                            //Store the values into the array using numStudents
                            //for the index position
                            idArray[numStudents] = id;
                            markArray[numStudents] = mark;
                            //Increase the number of students
                            numStudents++;
                        }
                        else
                        {
                            //error
                            Console.WriteLine("Error: " + line);
                        }
                    }
                    catch
                    {
                        //error
                        Console.WriteLine("Error: " + line);
                    }
                }
                //Close the file

                reader.Close();
            }
        }
        /// <summary>
        /// clear graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();

        }
        /// <summary>
        /// exit app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// draw graph when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear varibles
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            Pen pen1 = new Pen(Color.Black, 2);
            SolidBrush br = new SolidBrush(Color.LightBlue);
            int xPos = 0;
            int barWidth = pictureBoxDisplay.Width / numStudents;
            //loop for number of students
            for (int i = 0; i < numStudents; i++)
            {
                //call calculate height method 
                int height = CalculateBarHeight(markArray[i]);
                //get ypos so bar rises
                int yPos = pictureBoxDisplay.Height - height;
                //draw bars
                paper.FillRectangle(br, xPos, yPos, barWidth, height);
                paper.DrawRectangle(pen1, xPos, yPos, barWidth, height);
                //shift x pos
                xPos += barWidth;
            }
        }
        /// <summary>
        /// Write report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear writer
            StreamWriter writer;
            //filter for files
            const string FILTER = "Text Files|*.txt|All Files|*.*";
            //Set filter for dialog control
            saveFileDialog1.Filter = FILTER;
            //Check if user has selected a file to save to
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Save to selected file
                writer = File.CreateText(saveFileDialog1.FileName);
                //loop for number of students
                for (int i = 0;i < numStudents; i++)
                {
                    //Call letter grade
                    string letterGrade = CalcLetterGrade(markArray[i]);
                    //write out data to text file
                    writer.WriteLine(idArray[i].PadRight(10) + markArray[i].ToString().PadRight(10) + letterGrade);
                }
                //close writer
                writer.Close();
            }
        }
    }
}
