using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Pyramid : Card
    {
        public Pyramid(CardType type) : base(type)
        {


        }

        public Pyramid(Card card) : base(card)
        {

        }

        public override string getResourceId()
        {

            return "pyramid";
        }
    }
}
