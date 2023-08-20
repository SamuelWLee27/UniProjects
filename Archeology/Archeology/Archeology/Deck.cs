using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Deck
    {
        private List<Card> cardsList;
        protected Random _random;

        protected int _NumOfCards;

        /// <summary>
        /// initialises deck
        /// </summary>
        public Deck()
        {
            cardsList = new List<Card>();
            _random = new Random();

            
        }

        /// <summary>
        /// get and set _cardList
        /// </summary>
        public virtual List<Card> CardsList
        {
            get { return cardsList; }
            set { cardsList = value; }
        }

        /// <summary>
        /// creates starting deck in prep for the game
        /// </summary>
        /// <param name="cardsList">cardList for game</param>
        public virtual List<Card> SartingDeck(List<Card> cardsList)
        {
            //add treasure cards to deck
            for (int i = 1; i <= 18; i++)
            {
                PotShard potShard = new PotShard(CardType.Shard);
                potShard.FlipCard();
                cardsList.Add(potShard);
            }
            for (int i = 1; i <= 16; i++)
            {
                Scrap scrap = new Scrap(CardType.Scrap);
                scrap.FlipCard();
                cardsList.Add(scrap);
            }
            for (int i = 1; i <= 14; i++)
            {
                Coins coin = new Coins(CardType.Coin);
                coin.FlipCard();
                cardsList.Add(coin);
            }
            for (int i = 1; i <= 8; i++)
            {
                Talismans talisman = new Talismans(CardType.Talisman);
                talisman.FlipCard();
                cardsList.Add(talisman);
            }
            for (int i = 1; i <= 6; i++)
            {
                Cup cup = new Cup(CardType.Cup);
                cup.FlipCard();
                cardsList.Add(cup);
            }
            for (int i = 1; i <= 4; i++)
            {
                Mask mask = new Mask(CardType.Mask);
                mask.FlipCard();
                cardsList.Add(mask);
            }
            return cardsList;

            
        }

        /// <summary>
        /// Shuffles deck
        /// </summary>
        public List<Card> ShuffleDeck(List<Card> cardsList)
        {
            Card num;
            Card num2;
            //loop 500 times
            for (int i = 0; i <= 500; i++)
            {
                //get random index from list
                int index1 = _random.Next(0, cardsList.Count - 1);
                int index2 = _random.Next(0, cardsList.Count - 1);
                //switch them aroud
                num = cardsList[index1];
                num2 = cardsList[index2];
                cardsList[index1] = num2;
                cardsList[index2] = num;

                
            }
            return cardsList;
        }
        /// <summary>
        /// remove card at index
        /// </summary>
        /// <param name="cardsList"></param>
        /// <param name="index"></param>
        /// <returns>return list with removed card</returns>
        public List<Card> RemoveCard(List<Card> cardsList, int index)
        {
            cardsList.RemoveAt(index);
            return cardsList;
        }

        /// <summary>
        /// check if card in deck is clicked on
        /// </summary>
        /// <param name="x">x of mouse click</param>
        /// <param name="y">y of mouse click</param>
        /// <param name="deckList">list of deck being checked</param>
        /// <returns>if card in deck is clicked on</returns>
        public bool CardInDeckClicked(int x, int y , List<Card> deckList)
        {
            //set clicked to false
            bool clicked = false;
            //loop though list and get check if a card has been clicked on
            foreach(Card c in deckList)
            {
                if(!clicked)
                    clicked = c.IsMouseOn(x, y);
            }
            return clicked;
        }

        /// <summary>
        /// get a list of selected cards
        /// </summary>
        /// <param name="cardList">list thatis being check for selected cards</param>
        /// <returns>list of selected cards</returns>
        public List<Card> SelectedCards(List<Card> cardList)
        {
            //declear list
            List<Card> selectedList = new List<Card>();
            //loop through list and add selected cards to selected list
            foreach (Card c in cardList)
            {
                if (c.Selected)
                {
                    selectedList.Add(c);
                }
            }
            // List of selected cards
            return selectedList;

        }

        /// <summary>
        /// check if seleced cards are the same
        /// </summary>
        /// <param name="selectedList"></param>
        /// <returns>if cards in list are the same of not</returns>
        public bool SameSelectedCards(List<Card> selectedList)
        {
            //declear value
            int firstCardType = -1;
            //loop through list and check if cards are the same
            foreach(Card c in selectedList)
            {
                if (c.Selected)
                {
                    if (firstCardType == -1)
                    {
                        firstCardType = (int)c.Type;
                    }
                    else
                    {   //if not the same return false
                        if (firstCardType != (int)c.Type)
                            return false;
                    }
                }
            }
            //if the same return true
            return true;

        }

    }
}
