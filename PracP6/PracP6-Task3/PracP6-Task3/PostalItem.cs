using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracP6_Task3
{
    public abstract class PostalItem
    {
        protected string _deliveryAddress;
        protected string _sendersName;
        protected int _height;
        protected int _length;
        protected bool _urgent;
        protected int _stamps;

        /// <summary>
        /// initialises object
        /// </summary>
        /// <param name="adress">adress of postal item</param>
        /// <param name="name">surname of postal items sender</param>
        /// <param name="height">height of postal item</param>
        /// <param name="length">length of postal item</param>
        public PostalItem(string adress, string name, int height, int length)
        {
            
        }
        public PostalItem(int height, int length)
        {
           
        }
        public PostalItem(string adress, string name, int height, int length, bool urgent)
        {

        }
        public virtual bool Urgent
        {
            get { return _urgent; }
            set { _urgent = value; }
        }

        public abstract decimal Cost();

        /// <summary>
        /// nicely padds item in sting format
        /// </summary>
        /// <returns>item in string format</returns>
        public override string ToString()
        {
            return _deliveryAddress.ToString().PadRight(15) + _sendersName.ToString().PadRight(15) + _height.ToString().PadRight(10) 
                + _length.ToString().PadRight(10);
        }
    }
}
