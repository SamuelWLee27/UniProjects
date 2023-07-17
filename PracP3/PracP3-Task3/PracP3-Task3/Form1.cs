using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracP3_Task3
{
    public partial class Form1 : Form
    {
        //list
        List<Tree> treesList = new List<Tree>();
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //clear picture box
            e.Graphics.Clear(Color.LightGray);
            //add tree to list
       
            //loop through tree list and draw trees
                foreach (Tree tree in treesList)
                {
                    tree.DrawTree(e.Graphics);
                }
         
        }
        /// <summary>
        /// timer refresh picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Adds tree where clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try 
            { 

                //add tree to list where clicked
                treesList.Add(new Tree(e.X, e.Y, int.Parse(textBoxFoliage.Text)));

            }
            catch (Exception ex)
            {
                //error
                MessageBox.Show(ex.Message);
            }
}
    }
}
