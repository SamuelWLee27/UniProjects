using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Practical
{
    public class LoveCannon : GameObject
    {
        private int _range;

        private int _cannonWidth;

        private int _cannonHeight;

        public LoveCannon(int x , int y, int range) : base (x, y)
        {
            _range = range;

            _objectColor = Color.Blue;

            _cannonWidth = 50;

            _cannonHeight = 10;

        }
        /// <summary>
        /// draws love cannon in correct colour centered around x and y pos
        /// </summary>
        /// <param name="paper"></param>
        public override void DrawObject(Graphics paper)
        {
            //declear varibles
            SolidBrush br = new SolidBrush(_objectColor);
            Pen pen = new Pen(_objectColor, 2);
            //check if selected
            if (_isSelected == false)
            {
                //draw love cannon in normal colour
                br.Color = _objectColor;

                paper.FillRectangle(br, _xPos - _cannonWidth/2, _yPos - _cannonHeight/2, _cannonWidth, _cannonHeight);
            }
            else if (_isSelected == true)
            {
                //draw love cannon in selected colour and show range
                br.Color = _selectedColor;
                paper.FillRectangle(br, _xPos - _cannonWidth/2, _yPos - _cannonHeight/2, _cannonWidth, _cannonHeight);
            }
            //draw cannon range
            paper.DrawEllipse(pen, _xPos - _range / 2, _yPos - _range / 2, _range, _range);
        }
        /// <summary>
        /// check if love cannon is clicked
        /// </summary>
        /// <param name="x">x pos of click</param>
        /// <param name="y">y pos of click</param>
        /// <returns>returns true if clicked false if not clicked</returns>
        public override bool IsClicked(int x, int y)
        {
            //get bounds of shape
            Rectangle bounds = new Rectangle(_xPos - _cannonWidth/2, _yPos - _cannonHeight/2, _cannonWidth, _cannonHeight);
            //check if rectangle has x and y in it
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
        /// <summary>
        /// upgrades range of cannon
        /// </summary>
        public void UpgradeCannon()
        {
            //increases range by 10
            _range += 10;
        }
    }
}
