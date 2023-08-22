using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace D2
{
    /// <summary>
    /// form that adds students certification information
    /// </summary>
    public partial class Certification : Form
    {
        public Certification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// searches for student using email displays their details in listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearchEmail_Click(object sender, EventArgs e)
        {
            string email = "", sEmail = "", fname = "", sname = "", phone = "";
            //clear listBox
            listBoxDisplayStudent.Items.Clear();
            try
            {
                email = textBoxSearchStudent.Text;

                SQL.findStudent(email);

                //Check that data has been returned
                //Then loop through each row, printing the data to the list box
                //Check that there is something to write into list box
                if (SQL.read.HasRows)
                {
                    //loop through each table row from the database
                    while (SQL.read.Read())
                    {
                        //get the data values and store them in variables
                        sEmail = SQL.read[0].ToString();
                        fname = SQL.read[1].ToString();
                        sname = SQL.read[2].ToString();
                        phone = SQL.read[3].ToString();

                        //display each of the rows in a nice way
                        listBoxDisplayStudent.Items.Add("Student Email: " + sEmail.ToString()
                            + ", fname: " + fname
                            + ", sname: " + sname
                            + ", phone: " + phone);
                    }
                }
                else //where it doesnt have any successful searches
                {
                    listBoxDisplayStudent.Items.Add("No Students found.");
                }
            }
            catch
            {
                //If an error happens here, it means error in locating data
                MessageBox.Show("Error in querying database.  Please check that the database is connected.");
            }
        }

        /// <summary>
        /// adds student to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            string email = "", fname = "", sname = "", phone = "";

            try 
            { 
                email = textBoxSearchStudent.Text;
                fname = textBoxFname.Text;
                sname = textBoxSname.Text;
                phone = textBoxPhone.Text;
                SQL.addStudent(email, fname, sname, phone);
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }
        }

        /// <summary>
        /// adds attendance to database and checks if certified
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAttendance_Click(object sender, EventArgs e)
        {
            string email = "";
            int classID =  0, mark = 0;
            try
            {
                email = textBoxSearchStudent.Text;
                classID = int.Parse(textBoxClassID.Text);
                mark = int.Parse(textBoxMark.Text);

                //check if valid mark
                if (mark <= 100 && mark >= 0)
                {
                    SQL.addAttendance(email, classID, mark);
                    //check if student is now certified
                    if (mark >= 50)
                    {
                        //cant add student to qualified table as has to be instuctor so this is the only way to show it
                        MessageBox.Show("attendence added student is certified");
                    }//if not certified
                    else 
                    {
                        MessageBox.Show("attendence added but student is not certified");
                    }
                }
                else 
                {
                    MessageBox.Show("Mark must be between 0 and 100 inclusive");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// go back to start page
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
