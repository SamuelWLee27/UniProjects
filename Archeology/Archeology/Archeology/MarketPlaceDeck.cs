using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class MarketPlaceDeck : Deck
    {
        //declearlist for cards in deck
        private List<Card> _marketPlaceCardList;

        public MarketPlaceDeck() : base()
        {
            _marketPlaceCardList = new List<Card>();
        }

        public override List<Card> CardsList { get { return _marketPlaceCardList; } }



        public override List<Card> SartingDeck(List<Card> cardsList)
        {
            for (int i = 1; i <= 5; i++)
            {
                //get random card index
                Card card = cardsList[0];
                card.FlipCard();
                _marketPlaceCardList.Add(card);
                cardsList = RemoveCard(cardsList, 0);
            }
            return cardsList;
        }
    }
}
