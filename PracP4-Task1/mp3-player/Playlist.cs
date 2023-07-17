using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp3_player
{
    /// <summary>
    /// A playlist class that stores a playlist of songs
    /// </summary>
    public class Playlist
    {
        //Creates a list to store each song in the playlist
        public List<Song> SongList = new List<Song>();

        /// <summary>
        /// Returns the next valid song ID. Naively one more than the playlist length
        /// </summary>
        public int NextId
        {
            get
            {
                return SongList.Count + 1; //Gets next ID number to use 
            }
        }
        /// <summary>
        /// Adds a song to the playlist. Provided here for information hiding in case the SongList is not public
        /// </summary>
        /// <param name=""></param>
        public void AddSong(Song newsong)
        {
            SongList.Add(newsong);
        }
    }
}
