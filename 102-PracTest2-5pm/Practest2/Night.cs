using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Practest2
{
    /// <summary>
    /// Stores a record of drinks consumed in a nights entertainment.
    /// It contains a list of drinks.
    /// </summary>
    public class Night
    {
        public List<Consumed> consumedList;

        /// <summary>
        /// Creates a night of drinking.
        /// It contains a list of drinks
        /// </summary>
        public Night()
        {
            consumedList = new List<Consumed>();
        }

        /// <summary>
        /// Adds a drink to the nights list of drinks 
        /// </summary>
        /// <param name="drink">drink to add</param>
        public void AddDrink(Consumed c)
        {
            consumedList.Add(c);
        }

        /// <summary>
        /// Selects a drink, assuming the position in the listbox is the same as the position in the list of drinks
        /// </summary>
        /// <param name="pos">position of the drink in the list</param>
        /// <returns></returns>
        public Consumed SelectDrink(int pos)
        {
            if (pos >= 0 && consumedList.Count > pos)
            {
                return consumedList[pos];
            }

            return null;
        }

        /// <summary>
        /// calculates the total number of standard drinks in the nights entertainment
        /// </summary>
        /// <returns>total number of standard drinks</returns>
        public double TotalDrinks()
        {
            double total = 0;
            foreach (Consumed c in consumedList)
            {
                total += c.StandardDrinks();
            }
            return total;
        }
        /// <summary>
        /// Calculates how many hours till sober.
        /// Assumes the body can process one standard drink per hour.
        /// Assumes the time to sober starts at the consumption of the last drink in the list
        /// </summary>
        /// <returns></returns>
        public double HoursTillSober()
        {
            double time = 0;
            double total = 0;
            foreach (Consumed c in consumedList)
            {
                //sober up for time since last drink
                total -= c.Time - time;
                if (total < 0) total = 0; //can't get less than sober
                //now add new drink
                total += c.StandardDrinks();
                time = c.Time; //set start time for gap to next drink
            }
            return total; //number of standard drinks = number of hours to sober up
        }

        /// <summary>
        /// Returns a string summarising this nights entertainment
        /// </summary>
        /// <returns>String describing this nights entertainment</returns>
        public override string ToString()
        {
            return "Tonight has " + consumedList.Count.ToString() + " drinks.";
        }
    }
}
