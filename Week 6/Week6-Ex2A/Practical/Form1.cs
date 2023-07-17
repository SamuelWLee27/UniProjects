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
        //The number of squares in each row
        const int NUM_COLUMNS = 10;
        //The minimum number of rows to draw
        const int MIN_ROWS = 5;
        //The maximum number of rows to draw
        const int MAX_ROWS = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        /// code for clearing textbox
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ///Clear textboxs and picturebox also focus textbox
            textBoxNumRows.Clear();
            pictureBoxBoard.Refresh();
            textBoxNumRows.Focus();
        }
        /// code for exiting the program
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// Code for when you click the button
        private void buttonDrawBoard_Click(object sender, EventArgs e)
        {
            ///declear varible and create picture box and brush
            Graphics paper = pictureBoxBoard.CreateGraphics();
            int rows = 1;
            int columns = 1;
            int x = 0;
            int y = 0;
            SolidBrush brush = new SolidBrush(Color.LightGreen);
            Pen pen1 = new Pen(Color.Black);
            try
            {
                ///declear variables
                int numRows = int.Parse(textBoxNumRows.Text);
                int widthSquare = pictureBoxBoard.Width / NUM_COLUMNS;
                int heightSquare = pictureBoxBoard.Height / numRows;
                if (numRows <= MAX_ROWS && numRows >= MIN_ROWS)
                {
                    ///Make loops
                    while (rows <= numRows)
                    {
                        while (columns <= NUM_COLUMNS)
                        {
                            ///Pick colour of square
                            if (columns == 1 || columns == NUM_COLUMNS)
                            {
                                brush.Color = Color.LightPink;
                            }
                            else if (columns == 5 || columns == 6)
                            {
                                brush.Color = Color.LightBlue;
                            }
                            else
                            {
                                brush.Color = Color.LightGreen;
                            }
                            ///Draw square
                            paper.FillRectangle(brush, x, y, widthSquare, heightSquare);
                            paper.DrawRectangle(pen1, x, y, widthSquare, heightSquare);
                            ///Shift x and add one to counter
                            x += widthSquare;
                            columns++;
                        }
                        ///Shift y and and reset x add one to counter and reset counter for columns
                        x = 0;
                        columns = 1;
                        y += heightSquare;
                        rows++;
                    }
                }
                else
                {
                    ///Clear textboxs and picturebox also focus textbox
                    textBoxNumRows.Clear();
                    pictureBoxBoard.Refresh();
                    textBoxNumRows.Focus();
                    ///error message
                    MessageBox.Show("Number of rows must be between 5 and 10");
                }
            }
            catch (Exception ex)
            {
                ///Show error message
                MessageBox.Show(ex.Message);
                ///Clear textboxs and picturebox also focus textbox
                textBoxNumRows.Clear();
                pictureBoxBoard.Refresh();
                textBoxNumRows.Focus();
            }
        }
    }
}
