using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Mask : Card
    {
        //declear list
        private List<int> maskValueList;

        public Mask(CardType type) : base(type)
        {
            maskValueList = TreasureValues();

        }

        public Mask(Card card) : base(card)
        {
            if (card is Talismans)
            {
                maskValueList = TreasureValues();

            }
        }

        public override int TradeValue { get { return maskValueList[0]; } }

        public override List<int> TreasureValues()
        {
            List<int> newTreasureValuesList = new List<int>();

            newTreasureValuesList.Add(4);
            newTreasureValuesList.Add(12);
            newTreasureValuesList.Add(26);
            newTreasureValuesList.Add(50);

            return newTreasureValuesList;
        }

        public override string getResourceId()
        {
            return "mask";
        }
    }
}
