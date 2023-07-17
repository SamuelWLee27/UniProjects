using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    public class MovingBall : Ball
    {
        //The speed in the x direction of the ball
        private int xSpeed;
        //The speed in the y direction of the ball
        private int ySpeed;

        /// <summary>
        /// Gets and sets the speed in the x direction.
        /// </summary>
        public int XSpeed
        {
            get { return xSpeed; }
            set { xSpeed = value; }
        }

        /// <summary>
        /// Gets and sets the speed in the y direction.
        /// </summary>
        public int YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value; }
        }

        /// <summary>
        /// Initalises the fields to the values passed in.
        /// </summary>
        /// <param name="x">The x position of the ball</param>
        /// <param name="y">The y position of the ball</param>
        /// <param name="dx">The speed in the x direction of the ball</param>
        /// <param name="dy">The speed in the y direction of the ball</param>
        public MovingBall(int x, int y, int dx, int dy) : base(x, y)
        {
            //The base constructor will initialise the x and y position so just
            //need to initialise the speed fields
            xSpeed = dx;
            ySpeed = dy;
        }

        /// <summary>
        /// Make the ball move horizontally and vertically.
        /// </summary>
        public void Move()
        {
            MoveHorizontal(xSpeed);
            MoveVertical(ySpeed);
        }

        /// <summary>
        /// Checks to ass if the ball collides with the ball passed in.
        /// </summary>
        /// <param name="anotherBall"></param>
        /// <returns>True if a collision has occurred</returns>
        public bool CollidesWith(MovingBall anotherBall)
        {
            // Get differences of coords
            int dx = xCoord - anotherBall.xCoord;
            int dy = yCoord - anotherBall.yCoord;

            // Euclidean Distance between the balls
            double dist = Math.Sqrt((double)(dx * dx) + (double)(dy * dy));

            // If distance is less than the diameter, the balls are touching
            return (dist < (double)size);
        }

        /// <summary>
        /// Checks to see if the ball is touching another ball and if it is then
        /// move in opposite direction.
        /// </summary>
        /// <param name="anotherBall"></param>
        public void Touching(MovingBall anotherBall)
        {
            while (CollidesWith(anotherBall))
            {
                if (X < anotherBall.X)
                    MoveHorizontal(-1);
                else
                    MoveHorizontal(+1);
                if (Y < anotherBall.Y)
                    MoveVertical(-1);
                else
                    MoveVertical(+1);
            }
        }

        /// <summary>
        /// Make the current ball and the ball passed in bounce off each other.
        /// </summary>
        /// <param name="anotherBall"></param>
        public void Bounce(MovingBall anotherBall)
        {
            // Get differences of coords
            int dx = xCoord - anotherBall.xCoord;
            int dy = yCoord - anotherBall.yCoord;

            //bounce both balls - this is not very accurate :-(
            XSpeed *= -1;
            YSpeed *= -1;

            anotherBall.XSpeed *= -1;
            anotherBall.YSpeed *= -1;

        }
    }
}
