using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace D2
{
    public class SQL
    {
        //generates the connection to the database       
        //Make sure that in the Database connection you put your Database connection here:
        public static SqlConnection con = new SqlConnection(@"Data Source=cairo.cms.waikato.ac.nz;Database=sl408_D2;Integrated Security=True");
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataReader read;

        /// <summary>
        /// This excecutres the query, used mainly for 
        /// insert/delete/update statements etc. where we don't need
        /// to read from what we are doing.
        /// </summary>
        /// <param name="query"></param>
        public static void executeQuery(string query)
        {
            //try catch to catch any unforseen errors gracefully
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //put a message box in here if you are recieving errors and see if you can find out why?
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Generates an SQL query based on the input
        /// query e.g. "SELECT * FROM staff"
        /// </summary>
        /// <param name="query"></param>
        public static void selectQuery(string query)
        {
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                read = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                //put a message box in here if you are recieving errors and see if you can find out why?
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Prints out the ID  based on the query givin into a combo box
        /// </summary>
        /// <param name="comboBox">A control to be used to write existing names to</param>
        /// <param name="query">An SQL query to generate from</param>
        public static void editComboBoxItems(ComboBox comboBox, string query)
        {
            bool clear = true;

            //gets data from database
            SQL.selectQuery(query);
            //Check that there is something to write 
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    if (comboBox.Text == SQL.read[0].ToString())
                    {
                        clear = false;
                    }
                }
            }

            //gets data from database
            SQL.selectQuery(query);
            //if nothing in the comboBox then we need to clear it
            if (clear)
            {
                comboBox.Text = "";
                comboBox.Items.Clear();

            }

            // this will print whatever is in the database to the combobox
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    comboBox.Items.Add(SQL.read[0].ToString() + " " + SQL.read[1].ToString() + " " + SQL.read[2].ToString());
                }
            }
        }

        /// <summary>
        /// writes sql query to add a class to the database
        /// </summary>
        /// <param name="location">location of class</param>
        /// <param name="startTime">start date and time for class</param>
        /// <param name="endTime">end time and date for class</param>
        /// <param name="courseId">what course the class runs</param>
        public static void newClass(string location, string startTime, string endTime, string courseId, string iEmail)
        { 
            try
            {   //insert using parameters
                SqlCommand newClass = new SqlCommand("insert into Class values(@location, @startTime, @endTime, @courseID)");
                con.Close();
                newClass.Connection = con;
                con.Open();
                SqlParameter prm = new SqlParameter("@location", SqlDbType.VarChar, 100);
                prm.Value = location;
                newClass.Parameters.Add(prm);
                prm = new SqlParameter("@startTime", SqlDbType.DateTime, 19);
                prm.Value = startTime;
                newClass.Parameters.Add(prm);
                prm = new SqlParameter("@endTime", SqlDbType.Char, 19);
                prm.Value = endTime;
                newClass.Parameters.Add(prm);
                prm = new SqlParameter("@courseID", SqlDbType.Char, 5);
                prm.Value = courseId;
                newClass.Parameters.Add(prm);
                newClass.ExecuteNonQuery();
                //select using parameters
                SqlCommand findClassID = new SqlCommand("select ClassID from Class where Location = @location and StartTime = @startTime and" +
                                                        " EndTime = @endTime and CourseID = @courseID");
                con.Close();
                findClassID.Connection = con;
                con.Open();
                prm = new SqlParameter("@location", SqlDbType.VarChar, 100);
                prm.Value = location;
                findClassID.Parameters.Add(prm);
                prm = new SqlParameter("@startTime", SqlDbType.DateTime, 19);
                prm.Value = startTime;
                findClassID.Parameters.Add(prm);
                prm = new SqlParameter("@endTime", SqlDbType.Char, 19);
                prm.Value = endTime;
                findClassID.Parameters.Add(prm);
                prm = new SqlParameter("@courseID", SqlDbType.Char, 5);
                prm.Value = courseId;
                findClassID.Parameters.Add(prm);
                read = findClassID.ExecuteReader();
                

                //using found classID and iEmail insert to teaches
                SQL.read.Read();
                string classID = read[0].ToString().TrimEnd();
                SQL.executeQuery("insert into Teaches (iEmail, ClassID) values ('" + iEmail + "', " + classID + ")");

                MessageBox.Show("Class added");
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// selects students using email
        /// </summary>
        /// <param name="email">student email</param>
        public static void findStudent(string email) 
        {
            try
            {
                SqlCommand findStudent = new SqlCommand("select * from Customer where email = @email");

                con.Close();
                findStudent.Connection = con;
                con.Open();
                SqlParameter prm = new SqlParameter("@email", SqlDbType.VarChar, 255);
                prm.Value = email;
                findStudent.Parameters.Add(prm);
                read = findStudent.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// adds student to database
        /// </summary>
        /// <param name="email">student email</param>
        /// <param name="fname">student first name</param>
        /// <param name="sname">student surname</param>
        /// <param name="phone">student phone number</param>
        public static void addStudent(string email, string fname, string sname, string phone)
        {
            try
            {
                //insert using parameters
                SqlCommand newStudent = new SqlCommand("insert into Customer (email, fname, sname, phone) values(@email, @fname, @sname, @phone)");
                con.Close();
                newStudent.Connection = con;
                con.Open();
                SqlParameter prm = new SqlParameter("@email", SqlDbType.VarChar, 255);
                prm.Value = email;
                newStudent.Parameters.Add(prm);
                prm = new SqlParameter("@fname", SqlDbType.VarChar, 50);
                prm.Value = fname;
                newStudent.Parameters.Add(prm);
                prm = new SqlParameter("@sname", SqlDbType.VarChar, 50);
                prm.Value = sname;
                newStudent.Parameters.Add(prm);
                prm = new SqlParameter("@phone", SqlDbType.VarChar, 20);
                prm.Value = phone;
                newStudent.Parameters.Add(prm);
                newStudent.ExecuteNonQuery();

                MessageBox.Show("Student added");
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// adds attendance to database and checks if certified
        /// </summary>
        /// <param name="email">student email</param>
        /// <param name="classID">classId of class student attended</param>
        /// <param name="mark">mark student got in that class</param>
        public static void addAttendance(string email, int classID, int mark) 
        {
            //insert using parameters
            SqlCommand attended = new SqlCommand("insert into Attends (cEmail, ClassID, mark) values(@email, @classID, @mark)");
            con.Close();
            attended.Connection = con;
            con.Open();
            SqlParameter prm = new SqlParameter("@email", SqlDbType.VarChar, 255);
            prm.Value = email;
            attended.Parameters.Add(prm);
            prm = new SqlParameter("@classID", SqlDbType.Int);
            prm.Value = classID;
            attended.Parameters.Add(prm);
            prm = new SqlParameter("@mark", SqlDbType.Decimal);
            prm.Value = mark;
            attended.Parameters.Add(prm);
            attended.ExecuteNonQuery();
        }

        /// <summary>
        /// finds qualifed instructor
        /// </summary>
        /// <param name="courseID"></param>
        public static void findInstructor(string courseID) 
        {
            SqlCommand findInstructor = new SqlCommand("select I.fname as 'Instructor fname', I.sname as 'Instructor sname', I.email " +
                                            "from Instructor I, Course C, Qualified Q " +                        
                                            "where C.CourseID = Q.CourseID and Q.iEmail = I.email and C.CourseID = @courseID");

            con.Close();
            findInstructor.Connection = con;
            con.Open();
            SqlParameter prm = new SqlParameter("@courseID", SqlDbType.Char, 5);
            prm.Value = courseID;
            findInstructor.Parameters.Add(prm);
            read = findInstructor.ExecuteReader();
        }
    }
}
