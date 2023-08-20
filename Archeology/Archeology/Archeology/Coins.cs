using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Coins : Card
    {
        //declear list
        private List<int> coinValueList;

        public Coins(CardType type) : base(type)
        {
            coinValueList = TreasureValues();

        }

        public override int TradeValue { get { return coinValueList[0]; } }

        public Coins(Card card) : base(card)
        {
            if (card is Coins)
            {
                coinValueList = TreasureValues();

            }
        }
        public override List<int> TreasureValues()
        {
            List<int> newTreasureValuesList = new List<int>();

            newTreasureValuesList.Add(2);
            newTreasureValuesList.Add(5);
            newTreasureValuesList.Add(10);
            newTreasureValuesList.Add(18);
            newTreasureValuesList.Add(30);

            return newTreasureValuesList;
        }

        public override string getResourceId()
        {
            return "coin";
        }
    }
}
