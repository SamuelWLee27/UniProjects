using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class DigSiteDeck : Deck
    {
        //declearlist for cards in deck
        private List<Card> _digCardList;
        //number of cards in deck
        private int _numCardsInDeck;

        public DigSiteDeck() : base()
        {
            
        }

        public override List<Card> CardsList { get { return _digCardList; } set { _digCardList = value; } }

        /// <summary>
        /// number of cards in dig site deck
        /// </summary>
        public int CardsInDeck { get { return _numCardsInDeck; } }


        public override List<Card> SartingDeck(List<Card> digCardList)
        {
            _digCardList = digCardList;
            for (int i = 0; i < 6; i++)
            {
                Map map = new Map(CardType.Map);
                map.FlipCard();
                _digCardList.Add(map);
            }
            for (int i = 0; i < 6; i++)
            {
                Sandstorm sandstorm = new Sandstorm(CardType.Sandstorm);
                sandstorm.FlipCard();
                _digCardList.Add(sandstorm);
            }
            for (int i = 0; i < 8; i++)
            {
                Thief thief = new Thief(CardType.Thief);
                thief.FlipCard();
                _digCardList.Add(thief);
            }
            _numCardsInDeck = _digCardList.Count;

            return digCardList;
        }

        /// <summary>
        /// Draws card from dig site deck
        /// </summary>
        /// <returns>Drawn Card</returns>
        public Card DrawCard()
        {
            Card card = _digCardList[0];
            card.FlipCard();
            _digCardList.RemoveAt(0);
            _numCardsInDeck = _digCardList.Count;
            return card;
        }

        /// <summary>
        /// shuffles dig car deck
        /// </summary>
        public void ShuffleDeck()
        {
            Card num;
            Card num2;
            //loop 500 times
            for (int i = 0; i <= 500; i++)
            {
                //get random index from list
                int index1 = _random.Next(0, _digCardList.Count - 1);
                int index2 = _random.Next(0, _digCardList.Count - 1);
                //switch them aroud
                num = _digCardList[index1];
                num2 = _digCardList[index2];
                _digCardList[index1] = num2;
                _digCardList[index2] = num;


            }
            
        }
    }
}
