using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Thief : Card
    {
        public Thief(CardType type) : base(type)
        {


        }

        public Thief(Card card) : base(card)
        {

        }


        public override string getResourceId()
        {

            return "thief";
        }
    }
}
