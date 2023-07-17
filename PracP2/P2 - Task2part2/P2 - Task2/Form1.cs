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

namespace P2___Task2
{
    public partial class Form1 : Form
    {
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
            char[] csvArray;
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int wordValue = 0;
            string word = "";

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
                        // save word for writeline
                        word = line;

                        //make line upper case
                        line = line.ToUpper();
            
                        //split line into array
                        csvArray = line.ToCharArray();

                        //set value of word to zero
                        wordValue = 0;

                        //loop through word
                        for (int i = 0; i < csvArray.Length; i++)
                        {
                          //loop through alphabet
                            for(int j = 0; j < alphabet.Length; j++)
                            {
                               //check if letter and place in alphabet
                                if (csvArray[i] == alphabet[j])
                                {
                                    //add letter value to word
                                    wordValue = wordValue + j + 1;
                                }
                            }
                            
                        }
                        //check if word value is between 110 and 90
                        if (wordValue < 110 && wordValue > 90 && wordValue != 100)
                        {
                            //write word and value in console
                            Console.WriteLine(word + " = $" + wordValue.ToString());
                        }
                        // if equal to 100
                        else if (wordValue == 100)
                        {
                            //write word and value in console and jackpot
                            Console.WriteLine(word + " = Jackpot $" + wordValue.ToString());
                        }

                    }
                    catch (Exception ex)
                    {
                        //error
                        Console.WriteLine("Error :" + line);
                    }
                }
                //close file
                reader.Close();
            }
        }
    }
}
