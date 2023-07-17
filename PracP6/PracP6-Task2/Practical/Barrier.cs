using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Practical
{
    public class Barrier : GameObject
    {
        private const int _BarrierHeight = 60;

        private const int _BarrierWidth = 20;

        /// <summary>
        /// intialises objects
        /// </summary>
        /// <param name="x">x pos of barrier</param>
        /// <param name="y">y pos of barrier</param>
        public Barrier(int x, int y) : base (x, y)
        {
            _objectColor = Color.SaddleBrown;
        }
        /// <summary>
        /// draw barrier object
        /// </summary>
        /// <param name="paper"></param>
        public override void DrawObject(Graphics paper)
        {
            SolidBrush br = new SolidBrush(_objectColor);
            //check if selected
            if (_isSelected == false)
            {
                //draw in normal color
                br.Color = _objectColor;
                paper.FillRectangle(br, _xPos - _BarrierWidth / 2, _yPos - _BarrierHeight / 2, _BarrierWidth, _BarrierHeight);   
            }
            else if (_isSelected == true)
            {
                //draw in selected color
                br.Color = _selectedColor;
                paper.FillRectangle(br, _xPos - _BarrierWidth / 2, _yPos - _BarrierHeight / 2, _BarrierWidth, _BarrierHeight);
            }
        }
        /// <summary>
        /// check if clicked
        /// </summary>
        /// <param name="x">x pos of mouse click</param>
        /// <param name="y">y pos of mouse click</param>
        /// <returns>return if clicked or not</returns>
        public override bool IsClicked(int x, int y)
        {
            Rectangle bounds = new Rectangle(_xPos - _BarrierWidth / 2, _yPos - _BarrierHeight / 2, _BarrierWidth, _BarrierHeight);
            //check if clicked on barrier
            if(bounds.Contains(x, y))
            {
                _isSelected = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
