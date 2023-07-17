using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Practical
{
    public abstract class GameObject
    {
        protected int _xPos;

        protected int _yPos;

        protected bool _isSelected;

        protected Color _objectColor;

        protected Color _selectedColor;

        /// <summary>
        /// intialises the object
        /// </summary>
        /// <param name="x">x position of object</param>
        /// <param name="y">y position of object</param>
        public GameObject(int x, int y)
        {
            _xPos = x;
            _yPos = y;
            _isSelected = false;
            _selectedColor = Color.Red;
        }

        /// <summary>
        /// intialises draw object
        /// </summary>
        public abstract void DrawObject(Graphics paper);

        /// <summary>
        /// intialises iis clicked
        /// </summary>
        public abstract bool IsClicked(int x, int y);

        /// <summary>
        /// deselect object
        /// </summary>
        public void DeselectedObject()
        {
            _isSelected = false;
        }

        /// <summary>
        /// Move object to x and y pos
        /// </summary>
        /// <param name="x">object move to X pos</param>
        /// <param name="y">object move to Y pos</param>
        public void MoveObject(int x, int y)
        {
            _xPos = x;

            _yPos = y;
        }
    }
}
