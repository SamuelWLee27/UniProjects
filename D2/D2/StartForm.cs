using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Goes to classes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClasses_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Classes Page object to change to
            Classes classes = new Classes();
            //show the Classes page
            classes.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Goes to certification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCertification_Click(object sender, EventArgs e)
        {
            //Hides current page form from user
            this.Hide();
            //Create a Certification Page object to change to
            Certification cert = new Certification();
            //show the Certification page
            cert.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Goes to summary report page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSummaryReport_Click(object sender, EventArgs e)
        {
            //Hides current page form from user
            this.Hide();
            //Create a SummaryReport Page object to change to
            SummaryReport summary = new SummaryReport();
            //show the SummaryReport page
            summary.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }
    }
}
