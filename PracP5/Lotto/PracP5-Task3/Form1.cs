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

namespace PracP5_Task3
{
    public partial class Form1 : Form
    {
        //filter for file
        const string FILTER = "CSV Files|*.csv|All Files|*.*";  
        //declears a list for lottolines
        List<LottoLine> lottoLineList = new List<LottoLine>();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// updates the listbox
        /// </summary>
        private void UpdateListBox()
        {
            //declear varible
            int count;
            //clear listbox
            listBoxLotto.Items.Clear();
            //loop through list
            foreach (LottoLine l in lottoLineList)
            {
                //add lottoline to listbox
                listBoxLotto.Items.Add(l);
                //get number of winning numbers
                count = l.CheckNumbers();
                //display how many winning numbers there are for the lottoline
                listBoxLotto.Items.Add(count + " numbers are correct");

            }
        }
        /// <summary>
        /// closes application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string line = "";
            StreamReader reader;
            string[] csvArray;
            
            //set filter for dialog control
            openFileDialog1.Filter = FILTER;
            //check if user selected file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open file
                reader = File.OpenText(openFileDialog1.FileName);
                //loop through file
                while (!reader.EndOfStream)
                {
                    try
                    {
                        line = reader.ReadLine();
                        csvArray = line.Split(',');
                        //check if right length
                        if (csvArray.Length == 6)
                        {
                            //add lotto line to list
                            lottoLineList.Add(new LottoLine(csvArray));
                        }
                        else if (csvArray.Length == 7)
                        {
                            //add powerball line to list
                            lottoLineList.Add(new PowerballLine(csvArray));
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
                //call UpdatelListBox method
                UpdateListBox();
            }
        }
    }
}
