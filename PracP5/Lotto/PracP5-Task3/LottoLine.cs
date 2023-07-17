using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracP5_Task3
{
    public class LottoLine
    {
        protected int[] _numbersArray;
        
       
        /// <summary>
        /// Intialises the objects from stuff passed in
        /// </summary>
        /// <param name="csvArray">csvArray from file</param>
        public LottoLine(string[] csvArray)
        {
            _numbersArray = new int[csvArray.Length];
            //check if array is empty
            if (csvArray != null)
            {
                //loop though array
                for (int i = 0; i < 6; i++)
                {
                    //add csvArray to numbersArray
                    _numbersArray[i] = int.Parse(csvArray[i]);
                }
            }
        }
        /// <summary>
        /// neatly padded string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _numbersArray[0].ToString().PadRight(5) + _numbersArray[1].ToString().PadRight(5)
                + _numbersArray[2].ToString().PadRight(5) + _numbersArray[3].ToString().PadRight(5) 
                + _numbersArray[4].ToString().PadRight(5) + _numbersArray[5].ToString().PadRight(5);
        }
        /// <summary>
        /// checks how many winning numbers there are
        /// </summary>
        /// <returns>count of winning numbers</returns>
        public virtual int CheckNumbers()
        {
            //winning numbers array
            int[] winNumsArray = new int[] { 29, 10, 12, 8, 32, 27, 18 };
            //declear variable
            int count = 0;
            //loop through both arrays
            for(int i = 0; i < 6;i++) 
            {
                for(int j = 0; j < 6; j++)
                {
                    //check if has a winning number
                    if (winNumsArray[i] == _numbersArray[j])
                    {
                        //add one to count
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
