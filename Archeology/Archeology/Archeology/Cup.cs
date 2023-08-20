using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Cup : Card
    {
        //declear list
        private List<int> cupValueList;

        public Cup(CardType type) : base(type)
        {
            cupValueList = TreasureValues();

        }

        public Cup(Card card) : base(card)
        {
            if (card is Cup)
            {
                cupValueList = TreasureValues();

            }
        }

        public override int TradeValue { get { return cupValueList[0]; } }

        public override List<int> TreasureValues()
        {
            List<int> newTreasureValuesList = new List<int>();

            newTreasureValuesList.Add(2);
            newTreasureValuesList.Add(15);

            return newTreasureValuesList;
        }

        public override string getResourceId()
        {
            return "cup";
        }
    }
}
