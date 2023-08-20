using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Practest2
{
    /// <summary>
    /// Stores a drinks volume and alcoholic content, to calculate how many standard drinks
    /// </summary>
    public class Drink : Consumed
    {
        
        private double volume;  //volume of liquid, in ml
        private double alcohol; //percentage of alcohol in drink
        

        /// <summary>
        /// Stores a drink consumed in a nights entertainment
        /// </summary>
        /// <param name="name">name or type of the drink</param>
        /// <param name="volume">volume of liquid, in ml</param>
        /// <param name="alcohol">percentage of alcohol in drink</param>
        /// <param name="time">time when drink was consumed, in hours since start of evening</param>
        public Drink(string name, double volume, double alcohol, double time) :
            base(name, time)
        {
          
            this.volume = volume;
            this.alcohol = alcohol;
            
        }

        
        /// <summary>
        /// Volume property holds volume of liquid in drink in millilitres, as a double
        /// For example: 500 means half a litre of drink
        /// </summary>
        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        /// <summary>
        /// Alcohol property holds percentage of alcohol in drink, as a double
        /// For example: 37 means a drink that is 37% alcohol, such as a spirit
        /// </summary>
        public double Alcohol
        {
            get { return alcohol; }
            set { alcohol = value; }
        }
        

        
        public override double StandardDrinks()
        {
            double sd = volume/1000.0 * alcohol * 0.789;
            return sd;
        }

        
        public override string ToCSV()
        {
            return name + "," +
                volume.ToString() + "," +
                alcohol.ToString() + "," +
                time.ToString();
        }

        /// <summary>
        /// Returns a string summarising this drink, neatly padded into columns
        /// </summary>
        /// <returns>String describing this drink</returns>
        public override string ToString()
        {
            return name.PadRight(20)+" "+
                volume.ToString().PadLeft(5) + "ml " +
                alcohol.ToString().PadLeft(5) + "% at " + 
                time.ToString().PadLeft(5) + " hours"; 
        }
    }
}
