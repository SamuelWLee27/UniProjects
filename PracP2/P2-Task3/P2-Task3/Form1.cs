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

namespace P2_Task3
{
    public partial class Form1 : Form
    {
        //Declear lists
        List<string> namesList = new List<string>();
        List<string> uniqueNamesList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //filter for files
            const string FILTER = "Text Files|*.txt|All Files|*.*";

            //declear veriables
            StreamReader reader;
            string line = "";
            bool repeatingName = false;
            int count = 0;

            //set filter for dialog control
            openFileDialog1.Filter = FILTER;
            //check if user selected file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open file
                reader = File.OpenText(openFileDialog1.FileName);
                //loop through to end of file
                while (!reader.EndOfStream)
                {
                    try
                    {
                        //read line to varible
                        line = reader.ReadLine();
                        
                        //add name to lists
                        namesList.Add(line);

                        //reset newName to false
                        repeatingName = false;
                        //loop through the list
                        for(int i = 0; i < uniqueNamesList.Count; i++)
                        {
                            //check if its in list already
                            if (uniqueNamesList[i] == line)
                            {
                                //if name is in list change to true
                                repeatingName = true;
                            }
                        }// check if names in list
                        if (repeatingName == false)
                        {
                            //if name is not in list add to list
                            uniqueNamesList.Add(line);
                        }
                    }
                    catch (Exception ex)
                    {
                        //error
                        Console.WriteLine("Error: " + line);
                    }
                }
                //close file
                reader.Close();
                //write header for name and count to console
                Console.WriteLine("Name".PadRight(15) + "Count");
                //loop through unique names list
                for (int i = 0; i < uniqueNamesList.Count; i++)
                {
                    //reset count to zero
                    count = 0;
                    //loop through names list
                    for (int j = 0; j < namesList.Count; j++)
                    {
                        //if name appears in list
                        if(uniqueNamesList[i] == namesList[j])
                        {
                            //add one to count
                            count++;
                        }
                    }
                    //display to console name and it's count
                    Console.WriteLine(uniqueNamesList[i].ToString().PadRight(15) + count);
                }
            }
        }
    }
}
