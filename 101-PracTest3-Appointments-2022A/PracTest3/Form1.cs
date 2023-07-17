using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PracTest3
{
    public partial class Form1 : Form
    {
        //Name: Samuel Lee
        //ID: 1595395

        //The number of days in the calendar, 1 is Monday and 5 is Friday
        const int NUM_DAYS = 5;
        //The number of hours to display for each day
        const int NUM_HOURS = 10;
        //The starting hour for the calendar (9am)
        const int START_HOUR = 9;
        //The amount of gap between the text and outline of an appointment
        const int OFFSET = 2;
        //The width of an appointment
        const int APP_WIDTH = 100;
        //The height of an appointment
        const int APP_HEIGHT = 60;
        //Create lists
        List<string> dayList = new List<string>();
        List<int> hoursList = new List<int>();
        List<string> appTypeList = new List<string>();
        List<string> textList = new List<string>();

        //Colour variables for the different appointments
        Color WORK_COLOUR = Color.Gold;
        Color PERSONAL_COLOUR = Color.LightBlue;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Draws the given text at the specified x and y coordinates
        /// </summary>
        /// <param name="paper">Where to draw the text</param>
        /// <param name="hour">The hour of the appointment</param>
        /// <param name="text">The text of the appointment</param>
        /// <param name="x">The x position of the appointment</param>
        /// <param name="y">The y position of the appointment</param>
        private void DrawText(Graphics paper, int hour, string text, int x, int y)
        {
            paper.DrawString(hour.ToString() + ".00: " + text, new Font("Arial", 8),
                Brushes.Black, x + OFFSET, y + OFFSET);

        }

        /// <summary>
        /// Draws an appointment in the given color.
        /// </summary>
        /// <param name="paper">Where to draw the appointment</param>
        /// <param name="x">The x position of the appointment</param>
        /// <param name="y">The y position of the appointment</param>
        /// <param name="backColor">The background color of the appointment</param>
        private void DrawAppointment(Graphics paper, int x, int y, Color backColor)
        {
            SolidBrush br = new SolidBrush(backColor);
            Pen pen1 = new Pen(Color.Black, 1);

            paper.FillRectangle(br, x, y, APP_WIDTH, APP_HEIGHT);
            paper.DrawRectangle(pen1, x, y, APP_WIDTH, APP_HEIGHT);
        }

        /// <summary>
        /// Draws an empty calendar.
        /// </summary>
        /// <param name="paper">Where to draw the calendar</param>
        private void DrawEmptyCalendar(Graphics paper)
        {
            //The x position of the current appointment
            int x = 0;
            //The y position of the current appointment
            int y = 0;

            //Clear the drawing area
            pictureBoxCalendar.Refresh();

            //Loop for each day in the calendar
            for (int hour = 1; hour <= NUM_HOURS; hour++)
            {
                //Loop for each hour in the calendar
                for (int day = 1; day <= NUM_DAYS; day++)
                {
                    //Draw the appointment and then move to the next position
                    DrawAppointment(paper, x, y, Color.White);
                    x += APP_WIDTH;
                }

                //Move down to the next row and move back to beginning of the row
                y += APP_HEIGHT;
                x = 0;
            }
        }

        /// <summary>
        /// Calculate the x position of an appointment.
        /// </summary>
        /// <param name="day">The day of the appointment</param>
        /// <returns>The x position of the appointment based on the given day</returns>
        private int CalculateX(string day)
        {
            //Stores all the days to display on the calendar
            string[] dayArray = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri" };
            //The x position of the appointment
            int x = 0;
            //The number for a day, Mon = 0, Fri = 4
            int dayNum = 0;

            //Look through the array for the given day
            for (int i = 0; i < dayArray.Length; i++)
            {
                //Check if the current day matches the given day
                if (dayArray[i] == day)
                {
                    //Store the day number for the given day
                    dayNum = i;
                }
            }

            //Calculate the x position of the appointment depending on the day
            x = dayNum * APP_WIDTH;

            return x;
        }
        /// <summary>
        /// calculatr y position
        /// </summary>
        /// <param name="hour">Hour of the appointment</param>
        /// <returns></returns>
        private int CalculateY(int hour)
        {
            //declear varible
            int y = 0;
            //caculate y
            y = (hour - START_HOUR) * APP_HEIGHT;
            //return y
            return y;
        }
        /// <summary>
        /// when selected draw red appointment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //create graphics paper
            Graphics paper = pictureBoxCalendar.CreateGraphics();
            //declear index clicked
            int index = listBoxCalendar.SelectedIndex;
            //declear varibles
            string day = dayList[index];
            int hour = hoursList[index];
            string text = textList[index];
            
            //call Calculate x method
            int xPos = CalculateX(day);
            //call callculate y method
            int yPos = CalculateY(hour);
            //call draw app menthod
            DrawAppointment(paper, xPos, yPos, Color.Red);
            //call draw text method
            DrawText(paper, hour, text, xPos, yPos);

        }
        /// <summary>
        /// count number of appointments that have the same type as in the textBox then display in textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear varible
            int numApps = 0;
            //get user input from text
            string userAppType = textBoxCount.Text;
            //search list
            for (int i = 0; i < appTypeList.Count; i++)
            {
                //check if string at i position is the same as user input
                if (appTypeList[i] == userAppType)
                {
                    //add one to counter
                    numApps++;
                }
            }
            //diplay how many appointment with same type as userinput there are
            MessageBox.Show("Number of appointment with " + userAppType + " type: " + numApps.ToString());
        }
        /// <summary>
        /// Exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// open csv file and read then display info 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear varibles
            string line = "";
            string day = "";
            int hour = 0;
            string appointmentType = "";
            string textToDisplay = "";
            int xPos = 0;
            int yPos = 0;
            int app = 0;
            //declear reader
            StreamReader reader;
            //create picturebox
            Graphics paper = pictureBoxCalendar.CreateGraphics();
            //filter for files
            const string FILTER = "CSV Files|*.csv|All Files|*.*";
            //Set filter for dialog control
            openFileDialog1.Filter = FILTER;
            //check if user selected file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //call drawEmptyCalender method
                DrawEmptyCalendar(paper);
                //open file
                reader = File.OpenText(openFileDialog1.FileName);
                //loop until end of file
                while (!reader.EndOfStream)
                {
                    try
                    {
                        //read line to varible
                        line = reader.ReadLine();
                        //split line by , into an array
                        string[] CSVarray = line.Split(',');
                        //check if array is right length
                        if (CSVarray.Length == 4)
                        {
                            //put data in varibles
                            day = CSVarray[0];
                            hour = int.Parse(CSVarray[1]);
                            appointmentType = CSVarray[2];
                            textToDisplay = CSVarray[3];
                            //display in listBox
                            listBoxCalendar.Items.Add(day.PadRight(8) + hour.ToString().PadRight(8) + appointmentType.PadRight(10) + textToDisplay);
                            dayList.Add(day);
                            hoursList.Add(hour);
                            appTypeList.Add(appointmentType);
                            textList.Add(textToDisplay);
                            //call Calculate x method
                            xPos = CalculateX(day);
                            //call callculate y method
                            yPos = CalculateY(hour);
                            //check type of appointment
                            if (appointmentType == "Work")
                            {
                                //call draw appointment with work colour
                                DrawAppointment(paper, xPos, yPos, WORK_COLOUR);
                            }
                            else if (appointmentType == "Personal")
                            {
                                //call drawAppointment method using personal colour
                                DrawAppointment(paper, xPos, yPos, PERSONAL_COLOUR);
                            }
                            //call draw text method
                            DrawText(paper, hour, textToDisplay, xPos, yPos);
                            //add one to the number of appointments
                            app++;
                        }
                        else
                        {
                            //display error message
                            Console.WriteLine("Error: " + line);
                        }
                    }
                    catch 
                    {
                        //display error message
                        Console.WriteLine("Error: " + line);
                    }
                }
                //close file
                reader.Close();
                //display number of appointments
                MessageBox.Show("Number of appointments: " + app);
            }
        }
    }
}
