using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Talismans : Card
    {
        //declear list
        private List<int> talismanValueList;

        public Talismans(CardType type) : base(type)
        {
            talismanValueList = TreasureValues();

        }

        public Talismans(Card card) : base(card)
        {
            if (card is Talismans)
            {
                talismanValueList = TreasureValues();

            }
        }

        public override int TradeValue { get { return talismanValueList[0]; } }

        public override List<int> TreasureValues()
        {
            List<int> newTreasureValuesList = new List<int>();

            newTreasureValuesList.Add(3);
            newTreasureValuesList.Add(7);
            newTreasureValuesList.Add(14);
            newTreasureValuesList.Add(24);
            newTreasureValuesList.Add(40);

            return newTreasureValuesList;
        }

        public override string getResourceId()
        {
            return "talisman";
        }
    }
}
