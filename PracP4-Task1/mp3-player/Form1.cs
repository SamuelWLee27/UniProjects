using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace mp3_player
{
    /// <summary>
    /// Mp3 player, using a playlist object containing a list of song objects.
    /// The assistance of Grace Ng and Sophie Hutton in creating this project is greatly appreciated.
    /// </summary>
    public partial class Form1 : Form
    {
        const string TITLE = " - MP3 Player"; //constant to simplify form title
        const string PLAY = "&Play"; //constant of 'Play' button text
        const string PAUSE = "&Pause"; //constant of 'Pause' button text
        const string RESUME = "&Resume"; //constant of 'Resume' button text

        Playlist playlist; //class level Playlist variable so all methods can access current playlist 

        //player object created to make use of the csCompactMusicLibrary
        csCompactMusicLibrary.csCompactMusicLibrary player = new csCompactMusicLibrary.csCompactMusicLibrary();

        /// <summary>
        /// Sets the ID label to the next ID number to use, clears the filename and path label 
        /// and clears the rating control.
        /// </summary>
        private void ClearControls()
        {
            int ID = playlist.NextId; //Gets next ID number to use and stores into integer variable
            labelID.Text = ID.ToString(); //Sets ID label to next ID number to use
            labelFilename.Text = ""; //Clear filename label
            labelPath.Text = ""; // Clears path label
            labelTags.Text = ""; // Clears tags label
            txtRating.Clear(); //Clears the rating textbox
        }

        /// <summary>
        /// Updates listbox with current playlist
        /// </summary>
        private void UpdateListBox()
        {
            lstSongs.Items.Clear(); //Clears listbox

            foreach (Song song in playlist.SongList) //Goes through each song in the current playlist
            {
                lstSongs.Items.Add(song.Songname); //Adds song name to listbox
            }
        }

        public Form1()
        {
            InitializeComponent();
            newPlaylistToolStripMenuItem.PerformClick(); //'clicks' on the new playlist menu item automatically
        }


        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //Closes the application
        }



        private void button1_Click(object sender, EventArgs e)
        {
            uieOpenFileDialog.Filter = "MP3 Files|*.mp3|All Files|*.*";
            uieOpenFileDialog.ShowDialog();

            player.fileToPlay = uieOpenFileDialog.FileName;
            player.playMusic();
            MessageBox.Show((uieOpenFileDialog.FileName));

        }

        /// <summary>
        /// Allows user to browse files to select a song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectSong_Click(object sender, EventArgs e)
        {
            ClearControls(); //Clears controls on form
            uieOpenFileDialog.Filter = "MP3 Files|*.mp3|All Files|*.*"; //Sets open dialog filter
            if (uieOpenFileDialog.ShowDialog() == DialogResult.OK) //Checks to see that user has given a filename
            {
                labelPath.Text = uieOpenFileDialog.FileName; //Updates path label with song path and filename
                labelFilename.Text = uieOpenFileDialog.SafeFileName; // Updates filename label with just the filename, i.e. the 'song name'
            }
            txtRating.Focus(); //the next thing the user will want to do is set the rating level
        }

        /// <summary>
        /// Plays, pauses and resumes currently selected song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (labelPath.Text != "") //Checks to see if a song is selected
            {
                if (btnPlay.Text == PLAY) //Checks to see if the button is currently a 'play' button
                {
                    player.fileToPlay = labelPath.Text; //Gives player the path of the currently selected song
                    player.playMusic(); //Plays the song
                    btnPlay.Text = PAUSE; //Changes text of button to "&Pause"
                }

                else if (btnPlay.Text == PAUSE)//Checks to see if the button is currently a 'pause' button
                {
                    player.pausePlay(); //Pauses song
                    btnPlay.Text = RESUME; //Changes text of button to "&Resume"
                }
                else if (btnPlay.Text == RESUME)//Checks to see if the button is currently a 'resume' button
                {
                    player.resumePlay(); //Resumes playing the song
                    btnPlay.Text = PAUSE; //Changes text of button to "&Pause"
                }
            }
        }

        /// <summary>
        /// Stops currently selected song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            player.stopPlay(); //Stops song
            player.changePositionTo(0); //Changes player position of song to zero
            btnPlay.Text = PLAY; //Changes text of play button to "&Play"
        }

        /// <summary>
        /// Allows user to change the volume using the volume trackbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            player.volumeLevel = trackBarVolume.Value; //Changes volume to current position in volume trackbar
        }

        /// <summary>
        /// Allows user to change position in song via the position trackbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarPosition_Scroll(object sender, EventArgs e)
        {
            player.changePositionTo(trackBarPosition.Value); //Changes song position to position in song-position trackbar

            if (btnPlay.Text == RESUME) //Checks to see if song is currently paused
            { //Following two lines is used to allow player to use resume button to resume song from the new position
                player.playMusic(); //Plays song
                player.pausePlay(); //Pauses play
            }
        }

        /// <summary>
        /// Creates a new blank playlist and clears controls on form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playlist = new Playlist(); //Clears current playlist
            UpdateListBox(); //Updates listbox
            ClearControls(); //Clears controls
            this.Text = "New Playlist" + TITLE;  //Changes form title    
        }

        private void openPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //read in a playlist from a file and create a playlist from it
            playlist = new Playlist();
            uieOpenFileDialog.Filter = "CSV Files|*.csv|All Files|*.*"; //Sets open file dialog filter
            if (uieOpenFileDialog.ShowDialog() == DialogResult.OK) //Checks to see that user has chosen a filename
            {
                StreamReader reader = File.OpenText(uieOpenFileDialog.FileName); //Attaches filename to streamreader object

                while (!reader.EndOfStream) //Loops until end of textfile is reached
                {
                    string line = reader.ReadLine(); //Inserts first line of file into a string variable
                    string[] csvArray = line.Split(','); //Splits line using comma as seperators
                    int id = Convert.ToInt32(csvArray[0]); //Inserts song id into song structure
                    string path = csvArray[1]; //Inserts path of song into song structure
                    int rating = Convert.ToInt32(csvArray[2]);//Inserts song rating into song structure
                    Song song = new Song(id, path, rating); //Creates a song object
                    playlist.AddSong(song); //Adds song to playlist
                }
                reader.Close(); //Closes streamreader object
                this.Text = uieOpenFileDialog.FileName + TITLE; //Changes title of form
                UpdateListBox(); //Updates listbox
                ClearControls(); //Clears controls
            }
        }

        /// <summary>
        /// Allows user to update information for an existing song or adds a new song to the playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtRating.Text != "") //Checks to see if rating textbox is empty
            {
                int id = int.Parse(labelID.Text); //Gets song id  
                int rating = int.Parse(txtRating.Text); //Gets song rating level
                if (rating > 5 || rating < 1) //Checks to see that the rating is an appropriate value
                {
                    MessageBox.Show("Please enter an appropriate rating for the song between 1 and 5 inclusive", "Error"); //Shows error message  
                }
                else //Code is executed if rating in rating textbox is an inappropriate value
                {
                    Song song = new Song(id, labelPath.Text, rating); //Creates a song object

                    if (song.id > playlist.SongList.Count) //Checks to see if the song id is not one that is currently in the playlist
                    {
                        playlist.AddSong(song); //Adds song to playlist
                        UpdateListBox(); //Updates listbox
                    }
                    else //Code executed if song is one that is currently in the playlist
                        playlist.SongList[song.id - 1] = song; //Updates existing song in playlist                   
                }
            }
            else //Code is executed if rating textbox is empty
            {
                MessageBox.Show("Please enter a rating for the song", "Error"); //Shows error message
            }
        }

        /// <summary>
        /// Clears song information on form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearControls(); //Clears controls on form
        }

        /// <summary>
        /// Timer object which keeps track of duration and elapsed time of currently selected song and updates song position trackbar
        /// as appropriate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerHalfSecs_Tick(object sender, EventArgs e)
        {
            labelElapsedTime.Text = player.formatPosition; //Shows elapsed time of current song in elapsed time label
            labelDuration.Text = player.formatDuration; //Shows duration of song in duration time label
            trackBarPosition.Value = player.positionInSec; //Updates the position of the song position trackbar
            trackBarPosition.Maximum = player.durationInSec; //Sets the maximum of the song position trackbar to the duration of the song
            trackBarPosition.TickFrequency = player.durationInSec / 20; //Changes the tick frequency to an appropriate value
            if (player.durationInMS == player.positionInMS) // Checks to see if song has ended
            {
                player.stopPlay(); //stops the song
                player.changePositionTo(0); //changes player position of song to zero
                btnPlay.Text = PLAY; //Changes play/pause button text to 'play'
                //now trigger the next song
                int currentSong = lstSongs.SelectedIndex;
                if (currentSong >= 0 && currentSong < lstSongs.Items.Count - 1) //if a song is selected and songs left to play
                {
                    lstSongs.SetSelected(currentSong + 1, true); //Select the next song
                    btnPlay.PerformClick(); //click the play button
                }
            }
        }

        /// <summary>
        /// Used to show information of the currently selected song in listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstSongs.SelectedIndex; //Gets the index of selected song
            Song currentSong = playlist.SongList[index];

            labelID.Text = currentSong.id.ToString(); //Updates ID label with song ID
            labelFilename.Text = currentSong.Songname; //Updates filename label with song name
            labelPath.Text = currentSong.path; //Updates path label with song path
            txtRating.Text = currentSong.rating.ToString(); //Updates rating textbox with song rating
            labelTags.Text = currentSong.tags.ToString(); //Updates tags from mp3 song tags

            //Following two lines are to prevent errors if user has selected a new song in the listbox while playing/pausing a song
            btnPlay.Text = PLAY; //Changes play/pause  button text to 'play'
            player.fileToPlay = labelPath.Text; //Changes file to play of player to currently selected song
        }
        /// <summary>
        /// saves playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declear writer
            StreamWriter writer;


            //filter for files
            string FILTER = "CSV Files|*.csv|All Files|*.*";
            //Set filter for dialog control
            saveFileDialog1.Filter = FILTER;
            //check if user selected file
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //create file to save to
                writer = File.CreateText(saveFileDialog1.FileName);
                
                //loop through each song in playlist
                foreach(Song song in playlist.SongList)
                {
                    //writes songs in playlist to csvfile
                    writer.WriteLine(song.ToCsvString());
                }



                //close file
                writer.Close();
            }
        }
    }
}
