using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PracP3_Task3
{
    public class Shrub : Tree
    {
        
        /// <summary>
        /// Intialises the object to the values passed in
        /// </summary>
        /// <param name="x">x position of shrub</param>
        /// <param name="y">y position of shrub</param>
        /// <param name="size">size of shrub</param>
        public Shrub(int x, int y, int size) : base(x, y, size)
        {
            _xPos = x;
            _yPos = y;

            if (size > 30)
            {
                _size = 30;
            }
            else if (size < 10)
            {
                _size = 10;
            }
            else
            {
                _size = size;
            }
        }
        /// <summary>
        /// overrides DrawTree to draw a shrub
        /// </summary>
        /// <param name="paper">Graphic to draw shrub on</param>
        public override void DrawTree(Graphics paper)
        {
            //brush for shrub
            Brush brShrub = new SolidBrush(Color.Green);
            //Draw shrub
            paper.FillEllipse(brShrub, _xPos - _size / 2, _yPos - _size / 2, _size, _size);
        }
       
        /// <summary>
        /// returns a string in csv format
        /// </summary>
        /// <returns></returns>
        public override string ToCsvString()
        {
            return "Shrub" + "," + _xPos + "," + _yPos + "," + _size;
        }
        /// <summary>
        /// overrides to string method 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Shrub at position " + _xPos + ", " + _yPos;
        }
    }
}
