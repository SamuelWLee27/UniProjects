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

namespace Week8_Ex2A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Select file then write info to console and file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProcessFile_Click(object sender, EventArgs e)
        {
            //declear variable
            int total = 0;
            //declear reader and writer
            StreamReader reader;
            StreamWriter writer;
            //filter for files
            const string FILTER = "Text Files|*.txt|All Files|*.*";
            //Set filter for dialog control
            openFileDialog1.Filter = FILTER;
            saveFileDialog1.Filter = FILTER;
            //Check if user has selected a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Open selected file
                        reader = File.OpenText(openFileDialog1.FileName);
                        //Save to selected file
                        writer = File.CreateText(saveFileDialog1.FileName);
                        //write weapon info titles to file
                        writer.WriteLine("Weapon Name".PadRight(30)
                            + "Weapon Type".PadRight(15)
                            + "Damage".PadRight(8)
                            + "Speed".PadRight(8)
                            + "DPS");
                        //write weapon info titles to console
                        Console.WriteLine("Weapon Name".PadRight(30)
                            + "Weapon Type".PadRight(15)
                            + "Damage".PadRight(8)
                            + "Speed".PadRight(8)
                            + "DPS");
                        //Loop till it reaches the end of the file
                        while (!reader.EndOfStream)
                        {
                           //Get weapon name
                            string weaponName = reader.ReadLine();
                            //Get weapon tupe
                            string weaponType = reader.ReadLine();
                            //Get weapon damage
                            int weaponDamage = int.Parse(reader.ReadLine());
                            //Get weapon speed
                            double weaponSpeed = double.Parse(reader.ReadLine());
                            //Get weapon dps
                            double weaponDPS = (double)weaponDamage / weaponSpeed;
                            //write weapon info to console
                            Console.WriteLine(weaponName.PadRight(30)
                                + weaponType.PadRight(15)
                                + weaponDamage.ToString().PadRight(8)
                                + weaponSpeed.ToString().PadRight(8)
                                + weaponDPS.ToString("n3"));
                            //write weapon info to file
                            writer.WriteLine(weaponName.PadRight(30)
                                + weaponType.PadRight(15)
                                + weaponDamage.ToString().PadRight(8)
                                + weaponSpeed.ToString().PadRight(8)
                                + weaponDPS.ToString("n3"));
                            //add one to total
                            total++;
                        }
                        //Write numner of weapons processed to file
                        writer.WriteLine("Number of weapens processed: " + total);
                        writer.Close();
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        //error
                        Console.WriteLine(ex.Message);
                    }
                }
            }        
        }
        /// <summary>
        /// Exit program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
