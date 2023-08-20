using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Map : Card
    {
        //declear list
        private List<int> mapValueList;

        public Map(CardType type) : base(type)
        {
            mapValueList = TreasureValues();

        }

        public Map(Card card) : base(card)
        {
            if (card is Map)
            {
                mapValueList = TreasureValues();

            }
        }

        public override int TradeValue { get { return mapValueList[0]; } }

        public override List<int> TreasureValues()
        {
            List<int> newTreasureValuesList = new List<int>();

            newTreasureValuesList.Add(3);
           

            return newTreasureValuesList;
        }

        public override string getResourceId()
        {
            return "map";
        }
    }
}
