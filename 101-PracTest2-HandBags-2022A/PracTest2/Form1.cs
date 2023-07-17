using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracTest2
{
    public partial class Form1 : Form
    {
        //Name:Samuel Lee
        //ID:1595395

        //Width of a hand bag
        const int BAG_WIDTH = 50;
        //Height of a hand bag
        const int BAG_HEIGHT = 50;
        //The number of columns of hand bags to draw
        const int NUM_COLUMNS = 10;
        //The gap between rows and columns
        const int GAP = 10;
        //Number of columns
        const int COL = 10;
        //max hand bags
        const int MAX_HAND_BAGS = 10;
        //min hand bags
        const int MIN_HAND_BAGS = 2;


        public Form1()
        {
            InitializeComponent();
        }
        private void ClearTextBox()
        {
            //Clear textBox
            textBoxDraw.Clear();
            //focus textbox
            textBoxDraw.Focus();
        }
        /// <summary>
        /// Draw hand bags
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDrawBags_Click(object sender, EventArgs e)
        {
            //Declear starting x and y pos
            int x = 0;
            int y = 0;
            //Create graphics paper
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            //Make pen
            Pen pen1 = new Pen(Color.Black, 2);
            //Make Brush
            SolidBrush br = new SolidBrush(Color.Red);
            try
            {
                //get user input
                int handBags = int.Parse(textBoxDraw.Text);
                //Check if number of handbags is valid
                if (handBags >= MIN_HAND_BAGS && handBags <= MAX_HAND_BAGS)
                {
                    //loop for rows needed
                    for (int rows = 1; rows <= handBags; rows++)
                    {
                        //loop for columns
                        for (int numCol = 1; numCol <= COL; numCol++)
                        {
                            //Check if colunm number is a multiple of 3
                            if (numCol % 3 == 0)
                            {
                                //Change square to purple
                                br.Color = Color.Purple;
                            }
                            //if not multiple of 3
                            else
                            {
                                //Change square to red
                                br.Color = Color.Red;
                            }
                            //Draw square at current x and y
                            paper.FillRectangle(br, x, y, BAG_WIDTH, BAG_HEIGHT);
                            paper.DrawRectangle(pen1, x, y, BAG_WIDTH, BAG_HEIGHT);
                            //shift x by bag width and gap
                            x += BAG_WIDTH + GAP;
                        }
                        //Set x to orignal place
                        x = 0;
                        //shift y by bag height and gap
                        y += BAG_HEIGHT + GAP;
                    }
                }
                else
                {
                    //Error message
                    MessageBox.Show("Number of bags must be between 2 and 10 inclusive");
                    //Clear textBox
                    //textBoxDraw.Clear();
                    //Clear picturebox
                    pictureBoxDisplay.Refresh();
                    //focus textbox
                    //textBoxDraw.Focus();
                    //call clear textbox method
                    ClearTextBox();
                }
            }
            catch (Exception ex)
            {
                //Error message
                MessageBox.Show(ex.Message);
                //Clear textBox
                //textBoxDraw.Clear();
                //Clear picturebox
                pictureBoxDisplay.Refresh();
                //focus textbox
                //textBoxDraw.Focus();
                //call clear textbox method
                ClearTextBox();
            }
        }

        /// <summary>
        /// Clear textbox and picture box and focus textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            //Clear textBox
            //textBoxDraw.Clear();
            //Clear picturebox
            pictureBoxDisplay.Refresh();
            //focus textbox
            //textBoxDraw.Focus();
            //call clear textbox method
            ClearTextBox();
        }

        /// <summary>
        /// Exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
