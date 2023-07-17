using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracP6_Task3
{
    public class Parcel : PostalItem
    {
        private int _thickness;
        private int _weight;
        /// <summary>
        /// intialises the object
        /// </summary>
        /// <param name="adress">adress of parcel</param>
        /// <param name="name">surname of sender</param>
        /// <param name="height">height of parcel</param>
        /// <param name="length">length of parcel</param>
        /// <param name="thickness">thickness of parcel</param>
        /// <param name="weight">weight of parcel</param>
        public Parcel(string adress, string name, int height, int length, int thickness, int weight) : base(adress, name, height, length)
        {
            _deliveryAddress = adress;
            _sendersName = name;
            _height = height;
            _length = length;
            _thickness = thickness;
            _weight = weight;
            Urgent = false;
        }
        /// <summary>
        /// initialises objects
        /// </summary>
        /// <param name="height">height of parcel</param>
        /// <param name="length">length of parcel</param>
        /// <param name="thickness">thickness of parcel</param>
        /// <param name="weight">weight of parcel</param>
        public Parcel(int height, int length, int thickness, int weight) : base(height, length)
        {
            _height = height;
            _length = length;
            _thickness = thickness;
            _weight = weight;
            Urgent = false;
        }
        public Parcel(string adress, string name, int height, int length, int thickness, int weight, bool urgent) : base(adress, name, height, length, urgent)
        {
            _deliveryAddress = adress;
            _sendersName = name;
            _height = height;
            _length = length;
            _thickness = thickness;
            _weight = weight;
            Urgent = urgent;
        }

        /// <summary>
        /// get cost of parcel
        /// </summary>
        /// <returns>returns cost of parcel</returns>
        public override decimal Cost()
        {
            //get size of parcel
            int size = _height * _length * _thickness;
            //check size of parcel
            if(size <= 2000000)
            {
                _stamps = 2 * _weight;
            }
            else if(size <= 3000000)
            {
                _stamps = 3 * _weight;
            }
            else if(size <= 6000000)
            {
                _stamps = 4 * _weight;
            }
            else
            {
                _stamps = 5 * _weight;
            }
            if (_urgent == true)
            {
                _stamps += _weight;
            }
            return (decimal)(_stamps * 0.70);
        }

        /// <summary>
        /// nicely padds item in sting format
        /// </summary>
        /// <returns>item in string format</returns>
        public override string ToString()
        {
            return base.ToString() + _thickness.ToString().PadRight(10) + _weight.ToString().PadRight(10) + Urgent.ToString().PadRight(7) + "$" + Cost().ToString();
        }
    }
}
