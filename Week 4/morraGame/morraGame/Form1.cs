using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace morraGame
{
    public partial class Form1 : Form
    {
        ///Create variables
        Random rand = new Random();
        int playerScore = 0;
        int compScore = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            ///Create variables
            int playerGuess = 0;
            int compGuess = 0;
            int compFingers = 0;
            int playerFingers = 0;
            
            try
            {
                ///Get values for guesses and fingers
                playerFingers = int.Parse(textBoxPlayerFingers.Text);
                playerGuess = int.Parse(textBoxPlayerGuess.Text);
                compGuess = rand.Next(0, 6);
                compFingers = rand.Next(0, 6);
                if ((playerGuess >= 0 && playerGuess <= 5) && (playerFingers >= 0 && playerFingers <= 5))
                {
                    ///Display number of fingers in graphics for player
                    if (playerFingers == 0)
                    {
                        pictureBoxPlayerDisplay.Image = Properties.Resources.Fist;
                    }
                    else if (playerFingers == 1)
                    {
                        pictureBoxPlayerDisplay.Image = Properties.Resources.oneFinger;
                    }
                    else if (playerFingers == 2)
                    {
                        pictureBoxPlayerDisplay.Image = Properties.Resources.twoFingers;
                    }
                    else if (playerFingers == 3)
                    {
                        pictureBoxPlayerDisplay.Image = Properties.Resources.threeFingers;
                    }
                    else if (playerFingers == 4)
                    {
                        pictureBoxPlayerDisplay.Image = Properties.Resources.fourFingers;
                    }
                    else
                    {
                        pictureBoxPlayerDisplay.Image = Properties.Resources.fiveFingers;
                    }
                    ///Display number of fingers in graphics for computer
                    if (compFingers == 0)
                    {
                        pictureBoxCompDisplay.Image = Properties.Resources.Fist;
                    }
                    else if (compFingers == 1)
                    {
                        pictureBoxCompDisplay.Image = Properties.Resources.oneFinger;
                    }
                    else if (compFingers == 2)
                    {
                        pictureBoxCompDisplay.Image = Properties.Resources.twoFingers;
                    }
                    else if (compFingers == 3)
                    {
                        pictureBoxCompDisplay.Image = Properties.Resources.threeFingers;
                    }
                    else if (compFingers == 4)
                    {
                        pictureBoxCompDisplay.Image = Properties.Resources.fourFingers;
                    }
                    else
                    {
                        pictureBoxCompDisplay.Image = Properties.Resources.fiveFingers;
                    }

                    ///if one of the guesses are right add a point
                    if (playerFingers == compGuess)
                    {
                        compScore++;
                    }
                    if (compFingers == playerGuess)
                    {
                        playerScore++;
                    }

                    ///Display scores
                    textBoxPlayerScore.Text = playerScore.ToString();
                    textBoxCompScore.Text = compScore.ToString();
                    ///Clear text boxs and and focus mouse on textBoxPlayerFingers
                    textBoxPlayerFingers.Clear();
                    textBoxPlayerGuess.Clear();
                    textBoxPlayerFingers.Focus();
                    if (playerScore == 5)
                    {
                        MessageBox.Show("You Win");
                    }
                    if (compScore == 5)
                    {
                        MessageBox.Show("You Lose");
                    }
                }
                else
                {
                    ///Display error message
                    MessageBox.Show("Please enter numbers with in 0 and 5");
                    ///Clear text boxs and and focus mouse on textBoxPlayerFingers
                    textBoxPlayerFingers.Clear();
                    textBoxPlayerGuess.Clear();
                    textBoxPlayerFingers.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBoxPlayerFingers.Clear();
                textBoxPlayerGuess.Clear();
                textBoxPlayerFingers.Focus();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
