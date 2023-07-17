using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracP6_Task3
{
    public class Letter : PostalItem
    {
        /// <summary>
        /// initialises object
        /// </summary>
        /// <param name="adress">adress of letter</param>
        /// <param name="name">surname of sender</param>
        /// <param name="height">height of box</param>
        /// <param name="length">length of box</param>
        public Letter(string adress, string name, int height, int length) : base(adress, name, height, length)
        {
            _deliveryAddress = adress;
            _sendersName = name;
            _height = height;
            _length = length;
            Urgent = false;
        }
        /// <summary>
        /// initialises object when no adress of name is defined
        /// </summary>
        /// <param name="height">height of Letter</param>
        /// <param name="length">length of Letter</param>
        public Letter(string adress, string name, int height, int length, bool urgent) : base(adress, name, height, length, urgent)
        {
            _deliveryAddress = adress;
            _sendersName = name;
            _height = height;
            _length = length;
            Urgent = urgent;
        }


        /// <summary>
        /// gets cost of Letter
        /// </summary>
        /// <returns>returns cost of Letter</returns>
        public override decimal Cost()
        {
            //checks height and length of box
            if (_height <= 130 && _length <= 235)
            {
                _stamps = 1;
            }
            else if (_height <= 165 && _length <= 235)
            {
                _stamps = 2;
            }
            else if (_height <= 230 && _length <= 325)
            {
                _stamps = 3;
            }
            else
            {
                _stamps = 4;
            }
            //check if urgent
            if (_urgent == true)
            {
                _stamps += 1;
            }
            //return cost
            return (decimal)(_stamps * 0.70);
        }
        /// <summary>
        /// nicely padds item in sting format
        /// </summary>
        /// <returns>item in string format</returns>
        public override string ToString()
        {
            return base.ToString() + Urgent.ToString().PadRight(7) + "$" + Cost().ToString();
        }
    }
}
