using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace D2
{
    /// <summary>
    /// Shows summary report and stats
    /// </summary>
    public partial class SummaryReport : Form
    {
        public SummaryReport()
        {
            InitializeComponent();
            initChart();
        }

        /// <summary>
        /// display summary report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displaySummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int classCount = 0, attendCount = 0;
            double avgMark = 0;

            string courseId = "";

            try 
            {
                //clear the listbox previous data
                listBoxDisplay.Items.Clear();

                //SQL for number of classes run for each course
                SQL.selectQuery("select count(ClassID) as 'Number of Classes' from Class");

                //put result in list box
                if (SQL.read.HasRows)
                {
                    listBoxDisplay.Items.Add("Number of Classes:");
                    //get count in table
                    SQL.read.Read();
                    
                    //get the data values and store them in variables
                    classCount = int.Parse(SQL.read[0].ToString());
                    //display each of the rows in a nice way
                    listBoxDisplay.Items.Add(classCount);
                    
                }
                else //where it doesnt have any successful searches
                {
                    listBoxDisplay.Items.Add("No classes");
                }

                //query for number of students who attend each course
                SQL.selectQuery("select CourseID, count(distinct cEmail) from Attends A, Class C where A.ClassID = C.ClassID group by CourseID");
                //display query to listBox
                if (SQL.read.HasRows)
                {
                    listBoxDisplay.Items.Add("Number of students who attend each course:");
                    //loop through each table row from the database
                    while (SQL.read.Read())
                    {
                        //get the data values and store them in variables
                        courseId = SQL.read[0].ToString();
                        attendCount = int.Parse(SQL.read[1].ToString());
                        //display each of the rows in a nice way
                        listBoxDisplay.Items.Add("CourseID: " + courseId
                         + ", Number of Students: " + attendCount);
                    }
                }
                else //where it doesnt have any successful searches
                {
                    listBoxDisplay.Items.Add("No students attended any courses.");
                }

                //query for each courses avg mark
                SQL.selectQuery("select CourseID, avg(mark) from Attends A, Class C where A.ClassID = C.ClassID group by CourseID");
                //display query to listBox
                if (SQL.read.HasRows)
                {
                    listBoxDisplay.Items.Add("Average marks for each course:");
                    //loop through each table row from the database
                    while (SQL.read.Read())
                    {
                        //get the data values and store them in variables
                        courseId = SQL.read[0].ToString();
                        avgMark = double.Parse(SQL.read[1].ToString());
                        //display each of the rows in a nice way
                        listBoxDisplay.Items.Add("CourseID: " + courseId
                         + ", Average Mark: " + avgMark);
                    }
                }
                else //where it doesnt have any successful searches
                {
                    listBoxDisplay.Items.Add("No marks for any course.");
                }



            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// creates chart
        /// </summary>
        public void initChart() 
        {
            //get selected state from combo box
            string chart_type_strng = (string)((ComboBox)this.Controls["comboBoxChart"]).SelectedItem;
            if (chart_type_strng == null)
            {
                chart_type_strng = "Where Class Took Place";
            }
            //initailise bar graph
            SeriesChartType chartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), "Bar");

            Chart chart = (Chart)this.Controls["chartGraph"];


            chart.Series.Clear();
            chart.Titles.Clear();

            chart.Titles.Add("Class/Course attendance Data");
            chart.ChartAreas["ChartArea"].AxisX.Interval = 1;
            chart.ChartAreas["ChartArea"].AxisX.MajorGrid.LineWidth = 0;
            //chart.ChartAreas["ChartArea"].AxisY.MajorGrid.LineWidth = 0;

            //check what data is being displayed
            if (chart_type_strng == "Where Class Took Place")
            {
                //create graph Where Class Took Place
                Series series1 = new Series("Location");
                series1.ChartType = chartType;

                string location = "";
                int count = 0;

                //query for Where Class Took Place graph
                SQL.selectQuery("select location, count(*) from Class group by location");

                //check if sql table is not empty
                if (SQL.read.HasRows)
                {
                    //loop through each table row from the database
                    while (SQL.read.Read())
                    {
                        //add points to graph
                        location = SQL.read[0].ToString().TrimEnd();
                        count = int.Parse(SQL.read[1].ToString());
                        series1.Points.AddXY(location, count);
                    }
                }
                //add data to graph
                chart.Series.Add(series1);

            }
            else if (chart_type_strng == "When Class Took Place")
            {
                //create graph When Class Took Place
                Series series1 = new Series("Weekday");
                series1.ChartType = chartType;
                string weekday = "";
                string time = "";
                string weekdayTime = "";
                int count = 0;

                //query for When Class Took Place graph
                SQL.selectQuery("select DATENAME(WEEKDAY, startTime), cast(startTime as time), count(*)  from Class group by DATENAME(WEEKDAY, startTime), cast(startTime as time) order by DATENAME(WEEKDAY, startTime)");

                //check if sql table is not empty
                if (SQL.read.HasRows)
                {
                    //loop through each table row from the database
                    while (SQL.read.Read())
                    {
                        //add points to graph
                        weekday = SQL.read[0].ToString();
                        time = SQL.read[1].ToString();
                        weekdayTime = weekday + " " + time;
                        count = int.Parse(SQL.read[2].ToString());
                        series1.Points.AddXY(weekdayTime, count);
                    }
                }
                //add data to graph
                chart.Series.Add(series1);
            }
            else if (chart_type_strng == "Instructor Assigned To Course") 
            {
                //create graph Instructor Assigned To Course
                Series series1 = new Series("Instructor");
                series1.ChartType = chartType;

                string Instructor = "";
                int count = 0;

                //query for Instructor Assigned To Course graph
                SQL.selectQuery("select I.email, count(*) from Instructor I, Class C, Teaches T where I.email = T.iEmail and C.ClassID = T.ClassID group by I.email");

                //check if sql table is not empty
                if (SQL.read.HasRows)
                {
                    //loop through each table row from the database
                    while (SQL.read.Read())
                    {
                        //add points to graph
                        Instructor = SQL.read[0].ToString().TrimEnd();
                        count = int.Parse(SQL.read[1].ToString());
                        series1.Points.AddXY(Instructor, count);
                    }
                }
                //add data to graph
                chart.Series.Add(series1);
            }

        }

        /// <summary>
        /// initialise chart on index change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            initChart();
        }

        /// <summary>
        /// goes back to start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
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
