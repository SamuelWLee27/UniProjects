using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace D2
{
    public partial class Classes : Form
    {
        public Classes()
        {
            InitializeComponent();
        }
      
        /// <summary>
        /// when button is pressed display all classes and their info to the
        /// listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisplayClasses_Click(object sender, EventArgs e)
        {
            string courseID = "", startTime = "", query = "", 
                endTime = "", location = "", fname = "", sname = "";
            int classID = 0;

            //check if needed to filter
            if (radioButtonPast.Checked)
            {
                //query to get past classes info
                query = "select C.ClassID, C.CourseID, C.startTime, C.endTime, C.location, I.fname as 'Instructor fname', I.sname as 'Instructor sname' " +
                        "from Instructor I, Teaches T, Class C where I.email = T.iEmail and C.ClassID = T.ClassID and endTime < getdate() order by C.ClassID";
            }
            else if (radioButtonPresent.Checked)
            {
                //query to get present classes info
                query = "select C.ClassID, C.CourseID, C.startTime, C.endTime, C.location, I.fname as 'Instructor fname', I.sname as 'Instructor sname' " +
                    "from Instructor I, Teaches T, Class C where I.email = T.iEmail and C.ClassID = T.ClassID and getdate() between startTime and endTime order by C.ClassID";
            }
            else if (radioButtonFuture.Checked)
            {
                //query to get future classes info
                query = "select C.ClassID, C.CourseID, C.startTime, C.endTime, C.location, I.fname as 'Instructor fname', I.sname as 'Instructor sname' " +
                    "from Instructor I, Teaches T, Class C where I.email = T.iEmail and C.ClassID = T.ClassID and startTime > getdate() order by C.ClassID";
            }
            else
            {
                //query to get all class info
                query = "select C.ClassID, C.CourseID, C.startTime, C.endTime, C.location, I.fname as 'Instructor fname', I.sname as 'Instructor sname' " +
                        "from Instructor I, Teaches T, Class C where I.email = T.iEmail and C.ClassID = T.ClassID order by C.ClassID";
            }
            //excute sql statement
            SQL.selectQuery(query);
            //clear listBox
            listBoxDisplay.Items.Clear();
            try
            {
                
                //Check that data has been returned
                //Then loop through each row, printing the data to the list box
                //Check that there is something to write into list box
                if (SQL.read.HasRows)
                {
                    listBoxDisplay.Items.Add("Classes");
                    //loop through each table row from the database
                    while (SQL.read.Read())
                    {
                        //get the data values and store them in variables
                        classID = int.Parse(SQL.read[0].ToString());
                        courseID = SQL.read[1].ToString();
                        startTime = SQL.read[2].ToString();
                        endTime= SQL.read[3].ToString();
                        location = SQL.read[4].ToString();
                        fname = SQL.read[5].ToString();
                        sname = SQL.read[6].ToString();
                        //display each of the rows in a nice way
                        listBoxDisplay.Items.Add("ClassID: " + classID.ToString() 
                            + ", CourseID: " + courseID
                            + ", Start Time: " + startTime
                            + ", End Time: " + endTime 
                            + ", Location: " + location
                            + ", Intsructor Fname: " + fname
                            + ", Intsructor Sname: " + sname);
                    }
                }
                else //where it doesnt have any successful searches
                {
                    listBoxDisplay.Items.Add("No Classes found.");
                }

            }
            catch
            {
                //If an error happens here, it means error in locating data
                MessageBox.Show("Error in querying database.  Please check that the database is connected.");
            }
        }

        /// <summary>
        /// Go to newClasses page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddClass_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a NewClasses Page object to change to
            NewClasses newClasses = new NewClasses();
            //show the newClasses page
            newClasses.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// goes back to start page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            //Hides current page form from user
            this.Hide();
            //Create a Start Page object to change to
            StartForm start = new StartForm();
            //show the Start page
            start.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }
    }
}
