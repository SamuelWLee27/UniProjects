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

namespace RunLengthCoding
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //filter for files
        const string FILTER = "CSV Files|*.csv|All Files|*.*";
        //create list for run length code
        List<int> runLengthList = new List<int>();

        /// <summary>
        /// When clicked open file and print run length coding image to console
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear veriables
            StreamReader reader;
            string line = "";
            //set filter for dialog control
            openFileDialog1.Filter = FILTER;

            //check if user selected file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open file
                reader = File.OpenText(openFileDialog1.FileName);
                //Read a line
                line = reader.ReadLine();
                //split line into array
                string[] sizeArray = line.Split(',');
                //Check if first line is image width and height
                if (sizeArray.Length == 2)
                {
                    //Declear varibles
                    int width = int.Parse(sizeArray[0]);
                    int height = int.Parse(sizeArray[1]);
                    while (!reader.EndOfStream)
                    {
                        try
                        {
                            //read line
                            line = reader.ReadLine();
                            //slipt line into array
                            string[] runLengthArray = line.Split(',');
                            //loop until end of array
                            for (int i = 0; i < runLengthArray.Length; i++)
                            {
                               //Loop untill j equal number of run length number
                                for (int j = 0; j < int.Parse(runLengthArray[i]); j++)
                                {
                                    //Check if need space or #
                                    if(i % 2 == 0)
                                    {
                                        //write a space to console
                                        Console.Write(" ");
                                    }
                                    else 
                                    {
                                        //write # to console
                                        Console.Write("#");
                                    }
                                }
                            }
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {
                            //error
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
                else
                {
                    //error
                    Console.WriteLine("The first line should be width,hieght in numbers of pixels");
                }
                //close file
                reader.Close();
            }
        }
        /// <summary>
        /// Exit Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
