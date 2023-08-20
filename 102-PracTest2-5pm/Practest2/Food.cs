using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practest2
{
    public class Food : Consumed
    {
        private double _weight;

        public Food(string name, double weight, double time) : base(name, time)
        {
            this._weight = weight;
        }

        /// <summary>
        /// weight of food in grams
        /// </summary>
        public double Weight 
        { 
            get { return _weight; }
            set { _weight = value; }
        }



        public override double StandardDrinks()
        {
            //weight to remove one standard drink
            double weightOfStandardDrink = 500.0;
            //drinks removed
            int drinksRemoved = 0;
            //get how many drinks removed
            while(_weight >= weightOfStandardDrink)
            {
                drinksRemoved--;
                weightOfStandardDrink += 500;
            }
            //return the number
            return drinksRemoved;
        }



        
        public override string ToCSV()
        {
            return name + "," +
                _weight.ToString() + "," +
                time.ToString();
        }

        /// <summary>
        /// Returns a string summarising this drink, neatly padded into columns
        /// </summary>
        /// <returns>String describing this food</returns>
        public override string ToString()
        {
            return name.PadRight(20) + " " +
                _weight.ToString().PadLeft(5) + "g " +
                time.ToString().PadLeft(5) + " hours";
        }
    }
}
