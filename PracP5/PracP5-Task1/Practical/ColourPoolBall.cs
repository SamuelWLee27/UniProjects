using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Practical
{
    public class ColourPoolBall : PoolBall
    {
        private Color _color;
        /// <summary>
        /// initialises color
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="colour">colour of ball</param>
        public ColourPoolBall(int x, int y, int dx, int dy, Color colour) : base(x, y, dx, dy)
        {
            _color = colour;
        }
        /// <summary>
        /// overrides Display method to add colour to the balls
        /// </summary>
        /// <param name="paper"></param>
        public override void Display(Graphics paper)
        {
            SolidBrush br = new SolidBrush(_color);
            paper.FillEllipse(br, xCoord, yCoord, size, size);
            paper.DrawEllipse(pen, xCoord, yCoord, size, size);
        }


    }
}
