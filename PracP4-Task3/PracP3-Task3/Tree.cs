using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PracP3_Task3
{
    public class Tree
    {
        /// <summary>
        /// x position for tree
        /// </summary>
        private int _xPos;
        /// <summary>
        /// y position for tree
        /// </summary>
        private int _yPos;
        /// <summary>
        /// size of tree
        /// </summary>
        private int _size;
        /// <summary>
        /// tree height
        /// </summary>
        private const int HEIGHT = 80;
        /// <summary>
        /// tree width
        /// </summary>
        private const int WIDTH = 6;

        /// <summary>
        /// Initialies the object to the values passed in.
        /// also makes sure size it between 30 and 10 inclusive
        /// </summary>
        /// <param name="x">x position of tree</param>
        /// <param name="y">y position of tree</param>
        /// <param name="size">size of tree</param>
        public Tree(int x, int y, int size)
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
        /// Draws trees
        /// </summary>
        /// <param name="paper">graphics paper to draw on</param>
        public void DrawTree(Graphics paper)
        {
            //declear varibles
            Brush brTrunk = new SolidBrush(Color.Brown);
            Brush brFoliage = new SolidBrush(Color.Green);
            //draw tree
            paper.FillRectangle(brTrunk, _xPos - WIDTH/2, _yPos, WIDTH, HEIGHT);
            paper.FillEllipse(brFoliage, _xPos - _size / 2, _yPos - _size / 2, _size, _size);
        }
        /// <summary>
        /// returns a string in csv format
        /// </summary>
        /// <returns></returns>
        public string ToCsvString()
        {
            return _xPos + "," + _yPos + "," + _size;
        } 
        /// <summary>
        /// add a growth amount to size of foliage
        /// </summary>
        /// <param name="growth">how much tree will grow</param>
        public void GrowTree(int growth)
        {
            _size += growth;
            if (_size > 50)
            {
                _size = 50;
            }
        }
    }
}
