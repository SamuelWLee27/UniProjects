using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practest2
{
    abstract public class Consumed
    {
        protected string name;    //name or type of the drink or food
        protected double time;    //time when drink or food was consumed, in hours since start of evening


        /// <summary>
        /// Stores a drink or food consumed in a nights entertainment
        /// </summary>
        /// <param name="name">name or type of the drink</param>
        /// <param name="time">time when drink or food was consumed, in hours since start of evening</param>
        public Consumed(string name, double time)
        {
            this.name = name;
            this.time = time;
        }


        /// <summary>
        /// Name property holds name or type of drink or food, as a string
        /// For example: "Martini" or "lager" 
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Time property holds time that drink was consumed, measured in hours since beginning of night, as a double
        /// For example, 0.75 means 3/4 of an hour after start of nights entertainment
        /// </summary>
        public double Time
        {
            get { return time; }
            set { time = value; }
        }

        /// <summary>
        /// calculates the number of standard drinks
        /// formula is volume in litres * percentage of alcohol * 0.789 (density of alcohol)
        /// </summary>
        /// <returns></returns>
        public abstract double StandardDrinks();
        


        /// <summary>
        /// Returns a comma separated values i.e. CSV string summarising this drink
        /// format is "name,volume,alcohol,time" or for food
        /// it's "name,weight,timw"
        /// </summary>
        /// <returns>String describing this drink or food</returns>
        public abstract string ToCSV();
       

       
    }
}
