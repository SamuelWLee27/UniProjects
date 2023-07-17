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

namespace PracP1_Task3
{
    public partial class Form1 : Form
    {
        //Declear lists
        List<int> votesList = new List<int>();
        List<string> partyList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// open file and calculate total votes and number of seat for each party
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //filter for files
            const string FILTER = "CSV Files|*.csv|All Files|*.*";
            //declear veriables
            StreamReader reader;
            string line = "";
            string[] csvArray;
            string party = "";
            int votes = 0;
            int totalVotes = 0;
            int seats = 0;
            int seatsPerParty = 0;
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
                        //split line into array
                        csvArray = line.Split(',');
                        //check if array is right length
                        if(csvArray.Length == 2)
                        {
                            //store data in varibles
                            party = csvArray[0];
                            votes = int.Parse(csvArray[1]);
                            //Get total votes
                            totalVotes += votes;
                            //add datat to lists
                            partyList.Add(party);
                            votesList.Add(votes);
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
                //close file
                reader.Close();
                //Display total number of votes
                Console.WriteLine(totalVotes + " total votes");
                //get number of seats
                seats = totalVotes / 120;
                //loop through lists
                for(int i = 0; i < votesList.Count; i++)
                {
                    //calculate seats for each party
                    seatsPerParty = votesList[i]/seats;
                    //Dispaly seat for each party to the console
                    Console.WriteLine(partyList[i] + " has " + seatsPerParty + " seats.");
                }

            }
        }
    }
}
