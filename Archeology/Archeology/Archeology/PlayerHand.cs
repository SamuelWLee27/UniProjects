using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class PlayerHand : Deck
    {
        //varible for handsize
        private int _handSize;
        //declear list for cards in deck
        private List<Card> _handList;
        

        public PlayerHand() : base()
        {
            
            _handList = new List<Card>();

        }
        /// <summary>
        /// property for the size of a hand
        /// </summary>
        public int HandSize { get { return _handSize; } set { _handSize = value; } }
        public override List<Card> CardsList { get { return _handList; } }

        public override List<Card> SartingDeck(List<Card> cardsList)
        {
            for (int i = 0; i < 4; i++)
            {
                Card card = cardsList[0];
                card.FlipCard();
                _handList.Add(card);
                cardsList = RemoveCard(cardsList, 0);
            }
            _handSize = 4;
            return cardsList;
        }

        /// <summary>
        /// removes half the cards in the hand
        /// </summary>
        public void Sandstorm()
        {
            //get hand size
            int handSize = _handSize;
            //set to 0
            int index = 0;
            //if hand is not empty
            if (_handList != null)
            {
                //remove half hand at random by looping though half of the deck
                for (int i = 0; i < handSize / 2; i++)
                {
                    //check if count is greater then one
                    if (_handList.Count > 1) 
                        index = _random.Next(0, _handList.Count - 1); //get random index based on count
                    else
                        index = 0; //set index to zero
                    //remove card from hand at index
                    _handList.RemoveAt(index);
                    // -1 from hand size
                    _handSize--;
                }
            }
        }

        
        
    }
}
