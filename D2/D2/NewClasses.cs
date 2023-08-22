using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace D2
{

    /// <summary>
    /// add new classes to the database
    /// </summary>
    public partial class NewClasses : Form
    {
        public NewClasses()
        {
            InitializeComponent();
        }

        /// <summary>
        /// add a new classs to classes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddClass_Click(object sender, EventArgs e)
        {
            string location = "", startTime = "", endTime = "", courseID = "", iEmail = "";
            string[] strings;
            try 
            { 
                location = textBoxLocation.Text;
                startTime = textBoxStartTime.Text;
                endTime = textBoxEndTime.Text;
                courseID = textBoxCourseID.Text;

                strings = comboBoxInstructor.Text.Trim().Split(' ');

                iEmail = strings[2].Trim();

                SQL.newClass(location, startTime, endTime, courseID, iEmail);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        /// <summary>
        /// goes back to classes page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            //Hides current page form from user
            this.Hide();
            //Create a Classes Page object to change to
            Classes classes = new Classes();
            //show the Classes page
            classes.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }
        
        /// <summary>
        /// assuming you only want to assign instructors to new classes
        /// add 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInstructor_Click(object sender, EventArgs e)
        {
            
            try
            {
                string courseID = textBoxCourseID.Text;

                SQL.findInstructor(courseID);

                comboBoxInstructor.Text = "";
                comboBoxInstructor.Items.Clear();
                // this will print whatever is in the database to the combobox
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                    {
                        comboBoxInstructor.Items.Add(SQL.read[0].ToString() + " " + SQL.read[1].ToString() + " " + SQL.read[2].ToString());
                    }
                }
            }//error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
    }
}
