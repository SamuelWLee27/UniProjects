using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracP3_Task2
{
    public partial class Form1 : Form
    {
        //list for students
        List<Student> studentsLists = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// clears and updates listbox
        /// </summary>
        /// <param name="student">new student</param>
        private void UpdateListBox()
        {
            //clear listbox
            listBoxStudents.Items.Clear();
            listBoxStudents.Items.Add("Name".PadRight(15) + "Id".PadRight(15) + "Has Paid");
            //loop through lists and add students to listbox
            foreach (Student s in studentsLists)
            {
                listBoxStudents.Items.Add(s);
            }
        }

        /// <summary>
        /// Adds student to list and displays in listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewStudent_Click(object sender, EventArgs e)
        {
            try
            {
                //add textbox info to student
                Student s1 = new Student(textBoxName.Text, int.Parse(textBoxID.Text), Convert.ToBoolean(textBoxHasPaid.Text));
                //add student to list
                studentsLists.Add(s1);
                //call method
                UpdateListBox();

            }
            catch (Exception ex)
            {
                //error
                MessageBox.Show(ex.Message);
            }
        }
    }
}
