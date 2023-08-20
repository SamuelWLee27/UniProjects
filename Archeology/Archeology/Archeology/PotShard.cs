using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class PotShard : Card
    {
        //declear list
        private List<int> shardValueList;

        public PotShard(CardType type) : base(type)
        {
            shardValueList = TreasureValues();

        }

        public PotShard(Card card) : base(card)
        {
            if (card is PotShard)
            {
                shardValueList = TreasureValues();

            }
        }

        public override int TradeValue { get { return shardValueList[0]; } }

        public override List<int> TreasureValues()
        {
            List<int> newTreasureValuesList = new List<int>();

            newTreasureValuesList.Add(1);
            newTreasureValuesList.Add(2);
            newTreasureValuesList.Add(3);
            newTreasureValuesList.Add(4);
            newTreasureValuesList.Add(15);

            return newTreasureValuesList;
        }

        public override string getResourceId()
        {
            return "shard";
        }
    }
}
