using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracP6_Task3
{
    public class Postcard : PostalItem
    {

        /// <summary>
        /// initialises object
        /// </summary>
        /// <param name="adress">adress of postcard</param>
        /// <param name="name">name of sender</param>
        /// <param name="height">height of postcard</param>
        /// <param name="length">length of postcard</param>
        public Postcard(string adress, string name, int height, int length) : base(adress, name, height, length)
        {
            _deliveryAddress = adress;
            _sendersName = name;
            _height = height;
            _length = length;
            Urgent = true;
        }

        /// <summary>
        /// initialises object
        /// </summary>
        /// <param name="height">Height of postcard</param>
        /// <param name="length">length of postcard</param>
        public Postcard(int height, int length) : base(height, length)
        {
            _height = height;
            _length = length;
            Urgent = true;
        }

        /// <summary>
        /// overrides urgent properties
        /// </summary>
        public override bool Urgent 
        {
            get { return _urgent; } 
        
        }

        /// <summary>
        /// Cost of postcard
        /// </summary>
        /// <returns>cost of postcard</returns>
        public override decimal Cost()
        {
            _stamps = 2;
            return _stamps*2;
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
