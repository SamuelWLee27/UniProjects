using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracP6
{
    public class PlayerShip : Sprite
    {

        private int _pixels;

        private int _width;
        /// <summary>
        /// intailises object by varibles passed in. 
        /// </summary>
        /// <param name="x">x pos of ship</param>
        /// <param name="y">y pos of ship</param>
        /// <param name="width">width of ship</param>
        /// <param name="height">height of ship</param>
        /// <param name="screenWidth">width of picture box</param>
        public PlayerShip(int x, int y, int width, int height, int screenWidth) : base (x, y, width, height)
        {
            _width = screenWidth;

            _pixels = 4;
        }
        /// <summary>
        /// Moves player ship by pixels with in the screen
        /// </summary>
        public override void Move()
        {
            if (X <= 0 || X >= _width - 50)
            {
                _pixels = -_pixels;
            }
            X += _pixels;
            
        }
        /// <summary>
        /// draw player ship at x and y pos
        /// </summary>
        /// <param name="graphics">graphics ship is drawn on</param>
        public override void Draw(Graphics graphics)
        {
            SolidBrush br = new SolidBrush(Color.Green);
            graphics.FillRectangle(br, X, Y, Width, Height);
            graphics.FillRectangle(br, X + Width/2 - 2, Y - 10, 4, 10);
        }
    }
}
