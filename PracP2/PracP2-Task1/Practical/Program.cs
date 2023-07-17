using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //declear varibles
                string c;
                int numChars = 0;

                //ask user for number of characters
                Console.WriteLine("Enter number of characters");
                //Get user input and put it in varible
                numChars = int.Parse(Console.ReadLine());

                //ask user for character to draw
                Console.WriteLine("Enter character to draw");
                //put user character into varible
                c = Console.ReadLine();

                //Call varible
                DrawChars(numChars, c);


                // Wait for user to have read the output
                Console.WriteLine();
                Console.Write("<Press enter to finish>");
                Console.ReadLine();
            }
            catch (Exception ex)
            { 
                //error message
                Console.WriteLine(ex.ToString()); 
            }
        }

        /// <summary>
        /// Draws a line of characters
        /// </summary>
        /// <param name="n">Number of characters to draw</param>
        /// <param name="s">Character to draw n times</param>
        static void DrawChars(int n, string s)
        {
            int num = 0;
            //loop for rows
            for (int j = 0; j < n; j++)
            {
                //loop for coloumns
                for (int i = 0; i < n; i++)
                {
                    //check for if coloumn is same as row
                    if (i == j)
                    {
                        //get number of row so stays as a one digit number
                        num = (i+1) % 10;
                        //write number of row
                        Console.Write(num);
                    }
                    else
                    {
                        //write character
                        Console.Write(s);
                    }
                }
                //move to next line
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
