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
        //Samuel Lee
        //ID: 1595395

        //Direction values
        const int NORTH = 0;
        const int EAST = 90;
        const int SOUTH = 180;
        const int WEST = 270;

        //Amount to move the turtle 1 step
        const int STEP_AMOUNT = 50;

        //Amount to add to direction when turning
        const int TURN_AMOUNT = EAST;

        //Set direction of turtle to East
        int direction = 90;
        //Status of the tail
        bool isTailUp = true;
        //Current x and y position of the turtle
        Point turtlePos = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialises the application to it's initial state.
        /// </summary>
        private void Initialise()
        {
            pictureBoxDisplay.Refresh();
            direction = 90;
            isTailUp = true;
            turtlePos = new Point(0, 0);
        }

        /// <summary>
        /// Turns the direction of the turtle 90 degrees to the left.
        /// </summary>
        private void TurnLeft()
        {
            //If direction is north then set to west, otherwise just subtract 
            //the turn amount from the current direction
            if (direction == NORTH)
            {
                direction = WEST;
            }
            else
            {
                direction -= TURN_AMOUNT;
            }
        }

        /// <summary>
        /// Turns the direction of the turtle 90 degrees to the right
        /// </summary>
        private void TurnRight()
        {
            //If direction is west then set to north, otherwise just add 
            //the turn amount to the current direction
            if (direction == WEST)
            {
                direction = NORTH;
            }
            else
            {
                direction += TURN_AMOUNT;
            }
        }

        /// <summary>
        /// Toggles the state of the tail.
        /// </summary>
        private void Tail()
        {
            isTailUp = !isTailUp;
        }

        /// <summary>
        /// Works out the new position of the turtle when doing a step
        /// based on the current direction of the turtle.
        /// </summary>
        /// <returns>The new position of the turtle after doing a step</returns>
        private Point NewTurtlePos()
        {
            //Create the new position at the current turtle position
            Point newPos = new Point(turtlePos.X, turtlePos.Y);

            //Change the x or y position based on the direction
            if (direction == NORTH)
            {
                newPos.Y -= STEP_AMOUNT;
            }
            else if (direction == SOUTH)
            {
                newPos.Y += STEP_AMOUNT;
            }
            else if (direction == WEST)
            {
                newPos.X -= STEP_AMOUNT;
            }
            else
            {
                newPos.X += STEP_AMOUNT;
            }

            return newPos;
        }

        /// <summary>
        /// Make the turtle move by 1 step in the current direction.
        /// </summary>
        /// <param name="paper">Where to draw the graphics</param>
        private void Step(Graphics paper)
        {
            Pen pen1 = new Pen(Color.Black, 5);

            //Get the new position of the turtle after doing the step
            Point newPos = NewTurtlePos();

            if (isTailUp == true)
            {
                //If the tail is up then just move the turtle to the new position
                turtlePos = newPos;
            }
            else
            {
                //If the tail is down then draw a line to the new position and then
                //move the turtle to the new position.
                paper.DrawLine(pen1, turtlePos, newPos);
                turtlePos = newPos;
            }
        }
        /// <summary>
        /// Exit program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Clear pictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
        }
        /// <summary>
        /// When clicked open file and draw based on commands from file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openLogoProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declare varibles
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            StreamReader reader;
            //filter for files
            const string FILTER = "Text Files|*.txt|All Files|*.*";
            //Set filter for dialog control
            openFileDialog1.Filter = FILTER;
            //Check if user has selected a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Open selected file
                    reader = File.OpenText(openFileDialog1.FileName);
                    //Loop till it reaches the end of the file
                    while (!reader.EndOfStream)
                    {
                        
                            //Read a line from text file
                            string command = reader.ReadLine();
                            //Check what command is entered
                        if (command == "Left")
                        {
                            //call TurnLeft method
                            TurnLeft();
                        }
                        else if (command == "Right")
                        {
                            //call TurnRight method
                            TurnRight();
                        }
                        else if (command == "Tail")
                        {
                            //call Tail method
                            Tail();
                        }
                        else if (command == "Step")
                        {
                            //Call Step method
                            Step(paper);
                        }
                        else
                        {
                            //show error
                            Console.WriteLine("Error: " + command);
                        }
                      
                    }
                    //Close reader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    //show error
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
