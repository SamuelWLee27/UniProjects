using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracP5_Task3
{
    public class PowerballLine : LottoLine
    {
        private int _powerballNum;
        /// <summary>
        /// Initialises object from passed in varibles
        /// </summary>
        /// <param name="csvArray">csv array of numbers from file</param>
        public PowerballLine(string[] csvArray) : base(csvArray)
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
                //add powerball number to field
                _powerballNum = int.Parse(csvArray[6]);
            }
        
        }
        /// <summary>
        /// neatly padded string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + _powerballNum;
        }
        /// <summary>
        /// overrides checknumbers method to include count of powerball
        /// </summary>
        /// <returns></returns>
        public override int CheckNumbers()
        {
            //declear winning numbers array
            int[] winningNumsArray = new int[] {29, 10, 12, 8, 32, 27, 18};
            //call base method add value to count
            int count = base.CheckNumbers();
            //check if powerball is equal to winning powerball
            if (_powerballNum == winningNumsArray[6])
            {
                count++;
            }
            return count;
        }
    }
}
