using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Week10_Ex2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //make list for bookmarks
        List<string> bookMarksList = new List<string>();
        //filter for files
        const string FILTER = "Text Files|*.txt|All Files|*.*";
        /// <summary>
        /// method to update bookmarks to listbox
        /// </summary>
        private void UpdateListBox()
        {
            //clear listbox
            listBoxBookmark.Items.Clear();
            //loop through list
            for(int i = 0; i <= bookMarksList.Count-1; i++)
            {
                //add items from list to listbox
                listBoxBookmark.Items.Add(bookMarksList[i]);
            }
        }

        /// <summary>
        /// clear textbox, list and listbox
        /// </summary>
        private void Initialise()
        {
            //clear textbox
            textBoxURL.Clear();
            //clear listbox
            listBoxBookmark.Items.Clear();
            //clear list
            bookMarksList.Clear();
        }

        /// <summary>
        /// search for url
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBoxURL.Text);
        }
        /// <summary>
        /// Go forward a page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
        /// <summary>
        /// Go back a page on web browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            textBoxStatus.Text = "Loading...";
        }
        /// <summary>
        /// when finished loading clear status textbox and set url textbox to url then change form tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //clear status textbox
            textBoxStatus.Clear();
            //set url text box to url navigated to
            textBoxURL.Text = webBrowser1.Document.Url.ToString();
            //set titlebar to title of webpage
            this.Text = webBrowser1.DocumentTitle.ToString();
        }

        /// <summary>
        /// reset application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBookmarkFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call initialise method
            Initialise();
        }
        /// <summary>
        /// Add bookmark to listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if url is empty
            if (!(textBoxURL.Text == ""))
            {
                //add url to list
                bookMarksList.Add(textBoxURL.Text);
                //call update listbox method
                UpdateListBox();
            }
        }
        /// <summary>
        /// search selected listbox index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxBookmark_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get index clicked
            int index = listBoxBookmark.SelectedIndex;
            //change text to url from textbox
            textBoxURL.Text = bookMarksList[index];
            //Go to webpage
            webBrowser1.Navigate(textBoxURL.Text);
        }
        /// <summary>
        /// Exit applicaton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// save bookmarks to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBookmarkFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear varible
            StreamWriter writer;
            //Set filter for dialog control
            saveFileDialog1.Filter = FILTER;
            //check if user selected file
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //create file
                writer = File.CreateText(saveFileDialog1.FileName);
                //loop for each url in list
                for (int i = 0; i < bookMarksList.Count; i++)
                {
                    //write to file url
                    writer.WriteLine(bookMarksList[i]);
                }
                //close file
                writer.Close();
            }
            
        }

        /// <summary>
        ///open file and save bookmark urls to listbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadBookmarkFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear veriables
            StreamReader reader;
            string bookmark = "";
            //set filter for dialog control
            openFileDialog1.Filter = FILTER;
            //check if user selected file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open file
                reader = File.OpenText(openFileDialog1.FileName);
                //call initialise metho
                Initialise();
                //loop to end of stream
                while (!reader.EndOfStream)
                {
                    try
                    {
                        //read line to varible
                        bookmark = reader.ReadLine();
                        //add data to listbox
                        bookMarksList.Add(bookmark);
                    }
                    catch(Exception ex)
                    {
                        //error
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                //close file
                reader.Close();
                //call update listbox method
                UpdateListBox();
            }

        }
        /// <summary>
        /// delete bookmark at selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //declear index varible
            int index = listBoxBookmark.SelectedIndex; 
            //clear data at selected index
            bookMarksList.RemoveAt(index);
            //call update listbox method
            UpdateListBox();
        }
    }
}
