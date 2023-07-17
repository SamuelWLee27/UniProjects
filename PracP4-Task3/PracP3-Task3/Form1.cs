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
        //filter for files
        const string FILTER = "CSV Files|*.csv|All Files|*.*";
        ////list
        //List<Tree> treesList = new List<Tree>();
        Forest forest = new Forest();
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //clear picture box
            e.Graphics.Clear(Color.LightGray);

            //draw trees
            forest.DrawTrees(e.Graphics);


            ////loop through tree list and draw trees
            //    foreach (Tree tree in treesList)
            //    {
            //        tree.DrawTree(e.Graphics);
            //    }
         
        }
        /// <summary>
        /// timer refresh picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            forest.GrowForest(2);
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
                forest.AddTree(e.X, e.Y, int.Parse(textBoxFoliage.Text));
                ////add tree to list where clicked
                //treesList.Add(new Tree(e.X, e.Y, int.Parse(textBoxFoliage.Text)));

            }
            catch (Exception ex)
            {
                //error
                MessageBox.Show(ex.Message);
            }
}
        /// <summary>
        /// exits program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// open file with trees and draw them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set filter for dialog control
            openFileDialog1.Filter = FILTER;
            //check if user selected file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                forest.OpenFile(filename);
            }
        }
        /// <summary>
        /// saves trees to file in csv formate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set filter for dialog control
            saveFileDialog1.Filter = FILTER;
            //check if user selected file
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                forest.SaveFile(filename);
            }
        }
    }
}
