using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracP6_Task3
{
    public partial class Form1 : Form
    {
        //list of postal items
        List<PostalItem> itemsList = new List<PostalItem>();
        public Form1()
        {
            InitializeComponent();
        }
        //add letter to list
        

        /// <summary>
        /// updates listbox
        /// </summary>
        public void UpdateListBox()
        {
            //clear list
            itemsList.Clear();
            //add to list
            itemsList.Add(new Letter("3 ihjod", "Bob",30,40, true));
            itemsList.Add(new Parcel("3 sdgnb", "eqwr", 30,50,100,20));
            itemsList.Add(new Postcard("3 jgijs", "Bob", 10, 10));

            listBoxPostalItems.Items.Clear();

            foreach (PostalItem item in itemsList)
            {
                listBoxPostalItems.Items.Add(item.ToString());
            }
        }

        /// <summary>
        /// calculates cost of items in list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCost_Click(object sender, EventArgs e)
        {
            decimal cost = 0;
            //gets cost of all items in list
            foreach(PostalItem i in itemsList)
            {
                cost += i.Cost();
            }
            //display cost
            textBoxCost.Text = "$" + cost.ToString();
        }

        /// <summary>
        /// Displays list to listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        
    }
}
