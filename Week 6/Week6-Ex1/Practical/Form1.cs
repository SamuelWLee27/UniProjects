using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical
{
    public partial class Form1 : Form
    {
        //size of a lotto ball
        const int BALL_SIZE = 40;
        //size of the gap between lotto balls
        const int GAP_SIZE = 10;
        // the coordinates of the top, left corner of the display of the phone
        const int DISPLAY_LEFT = 40;
        const int DISPLAY_TOP = 140;
        //the width and height of the display area of the phone
        const int DISPLAY_WIDTH = 320;
        const int DISPLAY_HEIGHT = 460;

        //NOTE: If the display looks wrong in your screen resolution, 
        //please check that the picture box is 400 x 730 pixels in size
        //and adjust the form to be slightly larger than that.
        //Stupid Visual Studio changes the form size based on your screen resolution - gah!
        
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Draws an image of a phone in the picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDrawPhone_Click(object sender, EventArgs e)
        {
            //set the background image of the picture box to display the phone
            pictureBoxDisplay.BackgroundImage = Properties.Resources.iPhone;

            
        }

        private void buttonBalls_Click(object sender, EventArgs e)
        {
            ///Declear varibles
            Random rand = new Random();
            int counter = 1;
            int col = 1;
            int rows = DISPLAY_HEIGHT / (BALL_SIZE + GAP_SIZE);
            
            int x = DISPLAY_LEFT;
            int y = DISPLAY_TOP;
            int num = 0;
            
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            try
            {
            int colBalls = int.Parse(textBoxNumBalls.Text);
                ///Making sure the number ther user entered isn't to high
                ///or low

                if ((((BALL_SIZE + GAP_SIZE) * colBalls) < DISPLAY_WIDTH) && colBalls >= 1)
                {
                    ///Create loops
                    while (rows >= counter)
                    {
                        while (colBalls >= col)
                        {
                            SolidBrush br = new SolidBrush(Color.Blue);
                            num = rand.Next(0, 41);
                            ///draw balls
                            if (num >= 9 && num <= 1)
                            { 
                                br.Color = Color.Blue;
                            }                         
                            else if (num >= 10 && num <= 19)
                            {
                                br.Color = Color.Orange;
                            }
                            else if (num >= 20 && num <= 29)
                            {
                                br.Color = Color.Green;
                            }
                            else if (num >= 30 && num <= 39)
                            {
                                br.Color = Color.Red;
                            }
                            else
                            {
                                br.Color = Color.Purple;
                            }
                            ///Draw circle
                            paper.FillEllipse(br, x, y, BALL_SIZE, BALL_SIZE);
                            ///Shift x
                            x += BALL_SIZE + GAP_SIZE;
                            ///add one to counter

                            col++;
                        }
                        ///reset col counter
                        col = 1;
                        ///Shift y
                        y += BALL_SIZE + GAP_SIZE;
                        ///Set x back to original state
                        x = DISPLAY_LEFT;
                        ///add one to counter
                        counter++;
                    }
                }
                else
                {
                    ///Show error
                    MessageBox.Show("number of balls is to high and has to be one or greater");
                    ///Clear picturebox and textbox
                    pictureBoxDisplay.Refresh();
                    textBoxNumBalls.Clear();
                    ///Focus textbox
                    textBoxNumBalls.Focus();
                }
            }
            catch (Exception ex)
            {
                ///Show error
                MessageBox.Show(ex.Message);
                ///Clear picturebox and textbox
                pictureBoxDisplay.Refresh();
                textBoxNumBalls.Clear();
                ///Focus textbox
                textBoxNumBalls.Focus();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ///Clear picturebox and textbox
            pictureBoxDisplay.Refresh();
            textBoxNumBalls.Clear();
            ///Focus textbox
            textBoxNumBalls.Focus();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            ///Exit program
            Application.Exit();
        }
    }
}
