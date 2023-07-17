using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    public class PoolBall : MovingBall
    {
    
        public PoolBall(int x, int y, int dx, int dy) : base(x, y, dx, dy)
        {
         
        }
        /// <summary>
        /// makes it so the ball cant go past the the cushions
        /// </summary>
        /// <param name="x"></param>
        /// <param name="dx"></param>
        /// <returns></returns>
        public int CushionsSides(int x, int dx)
        {
            if (x < 0 || x > 223)
            {
                return -dx;
            }
            
            return dx;
        }
        /// <summary>
        /// makes it so the ball cant go past the the cushions
        /// </summary>
        /// <param name="y"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        public int CushionsyTopBottom(int y, int dy)
        {
            if ((y < 0) || (y > 107))
            {
                return -dy;
            }
            return dy;
        }
    }
}
