using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Sandstorm : Card
    {
        public Sandstorm(CardType type) : base(type)
        {
            

        }

        public Sandstorm(Card card) : base(card)
        {
            
        }
        

        public override string getResourceId()
        {
            
        return "sandstorm";
        }
    }
}
