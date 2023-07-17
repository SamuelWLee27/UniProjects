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

namespace PracTest1
{
    public partial class Form1 : Form
    {
        //Name: Samuel Lee
        //ID: 1595395

        //class scope list for storing test record objects
        List<TestRecord> recordsList = new List<TestRecord>();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// updates the listbox from list
        /// </summary>
        private void UpdateListbox()
        {
            //clear items in listbox
            listBoxData.Items.Clear();
            //loop through list
            foreach (TestRecord record in recordsList)
            {
                //add item to listbox
                listBoxData.Items.Add(record);
            }
        }
       /// <summary>
       /// filters listbox by test type
       /// </summary>
       /// <param name="test"></param>
        private void FilterByTestType(string test)
        {
            //clear listbox
            listBoxData.Items.Clear();
            //loop through listbox
            foreach(TestRecord record in recordsList)
            {
                //check if test type matches
                if (record.TestType == test)
                {
                    //adds item to list
                    listBoxData.Items.Add(record);
                }
            }
        }
        /// <summary>
        /// filter listbox by test type and year
        /// </summary>
        /// <param name="type"></param>
        /// <param name="year"></param>
        private void FilterByTestTypeAndYear(string type, int year)
        {
            //clear listbox
            listBoxData.Items.Clear();
            //loop through listbox
            foreach (TestRecord record in recordsList)
            {
                //check if test type and year matches
                if (record.TestType == type && record.TestYear == year)
                {
                    //adds item to list
                    listBoxData.Items.Add(record);
                }
            }
        }
        /// <summary>
        /// gets total number of fails in a location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private int CalcTotalFailuresForLocation(string location)
        {
            //declear varibles
            int count = 0;
           

            //loop though list
            foreach(TestRecord record in recordsList)
            {
                //check if location matches
                if(record.Location == location)
                {
                    //add one to counter
                    count += record.TotalFailed;
                }
            }
            //return total number of fails
            return count;
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This will allow testing of the TestRecord class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Create an object and then display it's data
                //TestRecord r1 = new TestRecord(2017, "Auckland", "RESTRICTED", "25 - 29 years", 5363, 2634);
                //Console.WriteLine(r1);

                //Change the values in the object and re-display it's data
                //r1.Location = "Hamilton";
                //r1.TestType = "FULL";
                //r1.TotalTests = 10;
                //r1.TotalFailed = 5;
                //r1.AgeGroup = "16 - 24 years";
                //Console.WriteLine(r1);

                //Test the error checking code in the object
                
                //r1.Location = "";
                //r1.TestType = "";
                //r1.AgeGroup = "";
                //r1.TotalTests = 0;
                //r1.TotalFailed = -5;
                //TestRecord r2 = new TestRecord(2017, "Bay of Plenty", "", "40 and over", 777, 101);
                // r2 = new TestRecord(2017, "", "Full", "40 and over", 777, 101);
                //TestRecord r2 = new TestRecord(2017, "Bay of Plenty", "Full", "", 777, 101);
                //TestRecord r2 = new TestRecord(2017, "Bay of Plenty", "Full", "40 and over", 0, 101);
                //TestRecord r2 = new TestRecord(2017, "Bay of Plenty", "Full", "40 and over", 777, -5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// opens file and reads in data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear varibles
            StreamReader reader;
            string line = "";
            string[] csvArray;

            //set filter for dialog
            openFileDialog1.Filter = "CSV File|*.csv|All Files|*.*";
            //check if user selected a file and press ok
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open file
                reader = File.OpenText(openFileDialog1.FileName);
                //clear records in list
                recordsList.Clear();
                //while not at end of stream
                while (!reader.EndOfStream)
                {
                    try
                    {
                        //read a line from file
                        line = reader.ReadLine();
                        //split line into csvArray
                        csvArray = line.Split(',');
                        //check length of array
                        if (csvArray.Length == 6)
                        {
                            //add record to records list
                            recordsList.Add(new TestRecord(int.Parse(csvArray[0]), csvArray[1],
                                csvArray[2], csvArray[3], int.Parse(csvArray[4]), int.Parse(csvArray[5])));

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
                //close file
                reader.Close();
                //updatelistbox
                UpdateListbox();
            }
        }
        /// <summary>
        /// displays records in list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayAllRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //updatelistbox
            UpdateListbox();

        }
        /// <summary>
        /// filters listbox by test type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayByTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //gets test type from textbox
                string type = textBoxTestType.Text.ToUpper();
                //call filter method
                FilterByTestType(type);
            }
            catch (Exception ex)
            {
                //error
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// filter listbox by year and test type 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayByYearAndLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //gets test type from textbox
                string type = textBoxTestType.Text.ToUpper();
                //gets year from texbox
                int year = int.Parse(textBoxYear.Text);
                //call method
                FilterByTestTypeAndYear(type, year);
            }
            catch(Exception ex) 
            {
                //error
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// gets number of fails in a location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayTotalNumberOfTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get location from text box
            string location = textBoxLocation.Text;
            //call method
            int number = CalcTotalFailuresForLocation(location);
            //display number of fails in location
            MessageBox.Show("Number of fails in location: " + number);

        }
        /// <summary>
        /// displays worst fail rate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayBestPassRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get fail rate of first in list
            double worstFailRate = recordsList[0].CalcFailRate();
            //declear varible
            int index = 0;
            //loop through list
            for(int i = 0; i < recordsList.Count; i++)
            { 
                //compare fail rates
                if (recordsList[i].CalcFailRate() < worstFailRate)
                {
                    //if worse fail rate set to worstfailrate 
                    worstFailRate = recordsList[i].CalcFailRate();
                    //get index of failrate
                    index = i;
                }
            }
            //display worst fail rate
            MessageBox.Show(recordsList[index].ToString());
        }
        /// <summary>
        /// displays total number of test for each year in list box
        /// then the year with the highest total in a message window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayTotalTestsPerLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //list for years and count
            List<int> yearList = new List<int>();
            List<int> numberList = new List<int>();
            //loop through list and add years and count
            for (int i = 0; i < recordsList.Count; i++)
            {
                for (int j = 0; j < yearList.Count; j++)
                {


                    if (recordsList[i].TestYear == yearList[j])
                    {
                        numberList[j]++;
                    }
                    else
                    {
                        yearList.Add(recordsList[i].TestYear);
                    }
                        
                }
            }
        }
    }
}
