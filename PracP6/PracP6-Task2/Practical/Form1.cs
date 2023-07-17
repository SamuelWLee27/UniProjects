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
        //The currently selected game object.  Will be null if no object is selected
        //Uncomment this when you are ready to test your code
        GameObject selectedObject = null;

        //A list of the game objects in the current level of the game
        //Uncomment this when you are ready to test your code
        List<GameObject> objectList = new List<GameObject>();

        List<GameObject> cannonList = new List<GameObject>();
        public Form1()
        {
            InitializeComponent();
            //Start the time that will automatically redraw the graphics
            timer1.Enabled = true;
        }


        
        /// <summary>
        /// This will clear out the picturebox and then draw all the obejcts in the current level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxDisplay_Paint(object sender, PaintEventArgs e)
        {
            //Clear the picturebox to green
            e.Graphics.Clear(Color.LightGreen);
            //Write the code to draw all the objects in the level here
            foreach(GameObject g in objectList)
            {
                g.DrawObject(e.Graphics);
            }
        }

        /// <summary>
        /// The method will select an object if none has been selected.  If an object has been selected
        /// then it will move the object to the mouse position and then deselect the object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //check if there is a selected object
                if (selectedObject != null)
                {
                    //move object to mouse pos
                    selectedObject.MoveObject(e.X, e.Y);
                    //deselect object and set to null
                    selectedObject.DeselectedObject();
                    selectedObject = null;
                }
                else
                {
                    //loop through object list
                    foreach (GameObject g in objectList)
                    {
                        //chec if objcet is clicked
                        if (g.IsClicked(e.X, e.Y))
                        {
                            //set selected object to current object
                            selectedObject = g;
                        }
                    }
                    //check if object is selected
                    if (selectedObject == null)
                    {
                        //check if raido button is clicked
                        if (radioButtonCannon.Checked)
                        {
                            LoveCannon love = new LoveCannon(e.X, e.Y, int.Parse(textBoxRange.Text));

                            cannonList.Add(love);
                            //add new cannon where clicked
                            objectList.Add(love);

                            
                        }
                        else if (radioButtonBarrier.Checked)
                        {
                            //add barrier object where clicked
                            objectList.Add(new Barrier(e.X, e.Y));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This method will refresh the picturebox to re-draw the graphics.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
        }

        /// <summary>
        /// This method will end the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This method will make all the cannons in the level upgrade.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upgradeCannonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //upgrade each cannon in list
            foreach(LoveCannon g in cannonList)
            {
                g.UpgradeCannon();
            }
        }

        /// <summary>
        /// This method will load all the game objects for the current level from the csv file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
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
                //while not at end of stream
                while (!reader.EndOfStream)
                {
                    try
                    {
                        //read line from file
                        line = reader.ReadLine();
                        //split line into csvarray
                        csvArray = line.Split(',');
                        //check if cannon or barrier
                        if(csvArray.Length == 3)
                        {
                            LoveCannon love = new LoveCannon(int.Parse(csvArray[0]), int.Parse(csvArray[1]), int.Parse(csvArray[2]));

                            //add cannon to list
                            objectList.Add(love);

                            cannonList.Add(love);
                        }
                        else if(csvArray.Length == 2)
                        {
                            //add barrier to list
                            objectList.Add(new Barrier(int.Parse(csvArray[0]), int.Parse(csvArray[1])));
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
            }
        }
    }
}
