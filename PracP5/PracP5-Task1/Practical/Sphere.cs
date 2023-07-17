using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Practical
{
    public class Sphere
    {
        //The x and y position of the top left hand corner of the sphere
        protected int xCoord, yCoord;
        //The size of the sphere
        protected const int size = 10;
        //Outline colour of the sphere
        protected Pen pen = new Pen(Color.Black);

        /// <summary>
        /// Initialies the x and y position to the values passed in
        /// </summary>
        /// <param name="x">The initial x position of the ball</param>
        /// <param name="y">The initial y position of the ball</param>
        public Sphere(int x, int y)
        {
            xCoord = x;
            yCoord = y;
        }

        /// <summary>
        /// Gets the x potisition of the top left hand corner
        /// </summary>
        public int X
        {
            get { return xCoord; }
        }

        /// <summary>
        /// Gets the y position of the top left hand corner
        /// </summary>
        public int Y
        {
            get { return yCoord; }
        }

        /// <summary>
        /// Displays the sphere 
        /// </summary>
        /// <param name="paper">The Graphics object to use for the drawing</param>
        public virtual void Display(Graphics paper)
        {
            
            paper.DrawEllipse(pen, xCoord, yCoord, size, size);
            
        }
    }
}
