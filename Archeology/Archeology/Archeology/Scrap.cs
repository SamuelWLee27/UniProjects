using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Scrap : Card
    {
        //declear list
        private List<int> scrapValueList;

        public Scrap(CardType type) : base(type)
        {
            scrapValueList = TreasureValues();

        }

        public Scrap(Card card) : base(card)
        {
            if (card is Scrap)
            {
                scrapValueList = TreasureValues();

            }
        }

        public override int TradeValue { get { return scrapValueList[0]; } }

        public override List<int> TreasureValues()
        {
            List<int> newTreasureValuesList = new List<int>();

            newTreasureValuesList.Add(1);
            newTreasureValuesList.Add(2);
            newTreasureValuesList.Add(3);
            newTreasureValuesList.Add(10);

            return newTreasureValuesList;
        }

        public override string getResourceId()
        {
            return "scrap";
        }
    }
}
