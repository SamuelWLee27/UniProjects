using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace mp3_player
{
    /// <summary>
    /// Stores the information retrieved from the ID3 tags of an MP3 file
    /// Genre should probably be an enum, or a list lookup
    /// </summary>
    public class ID3
    {
        public char[] Tag = new char[3];
        public char[] Title = new char[30];
        public char[] Artist = new char[30];
        public char[] Album = new char[30];
        public char[] Year = new char[4];
        public char[] Comment = new char[30];
        public byte Genre;

        public ID3()
        {
            //create a blank tag
        }

        public ID3(string filename)
        {
            //create an ID3 based on info from file in filename
            BinaryReader binfile;
            try
            {
                binfile = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read));
                if (binfile != null)
                {
                    long length = binfile.BaseStream.Length;
                    binfile.BaseStream.Seek((length - 128), 0);
                    Tag = binfile.ReadChars(3);
                    Title = binfile.ReadChars(30);
                    Artist = binfile.ReadChars(30);
                    Album = binfile.ReadChars(30);
                    Year = binfile.ReadChars(4);
                    Comment = binfile.ReadChars(30);
                    Genre = binfile.ReadByte();

                    binfile.Close();
                }
            }
            catch (IOException error)
            {
                //do nothing and return a blank tag
                Console.WriteLine("tag reading error: " + error);
            }
        }

        public override string ToString()
        {
            string line = "unknown song";
            if (HasTag())
            {
                line = Stringify(Title, 30) + "," + Stringify(Artist, 30) + "," + Stringify(Album, 30) + "," + Genre.ToString();
            }
            return line ;
        }
        public bool HasTag()
        {
            return ((Tag[0] == 'T' || Tag[0] == 't') &&
                (Tag[1] == 'A' || Tag[1] == 'a') &&
                (Tag[2] == 'G' || Tag[2] == 'g'));
        }
        /// <summary>
        /// method to turn arrays of chars into strings.
        /// should probably be static.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string Stringify(char[] s, int length)
        {
            int i = 0;
            string line = "";
            for (i = 0; i < length; i++)
            {
                if ((s[i] != 0 || s[i] != ' '))

                    line += s[i];
            }
            return line;
        }
    }
}
