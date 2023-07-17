using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practical
{
    class Program
    {
        static void Main(string[] args)
        {
            // Note: this file is in the template folder
            string filename = @"sentences.txt";
            // Open the file
            StreamReader infile = new StreamReader(filename);

            // Read sentences ...
            while (!infile.EndOfStream)
            {
                // Read a line from the file, as a whole string
                string line = infile.ReadLine();
                // Split string into 'words', separated by spaces
                string[] words = line.Split(' ');

                // Loop through each 'word' found
                for (int i = words.Length - 1; i > 0; i--)
                {
                    // check if not empty string
                    if (words[i] != "")
                    {
                        // Output current word
                        Console.Write(words[i]);

                        // Output a space between every word, except for the last one
                        if (i > 0)
                        {
                            Console.Write(" ");
                        }
                    }
                    

                }
                // Output a newline chatracter at the end of the sentence
                Console.WriteLine();
            }
            infile.Close(); // Be a tidy kiwi

            // Wait for user to have read the output
            Console.WriteLine();
            Console.Write("<Press enter to finish>");
            Console.ReadLine();
        }
    }
}
