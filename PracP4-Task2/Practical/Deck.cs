using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    public class Deck
    {
        private Random random; //generates a random number
        private int nextCard; //int varble for next card
        private List<Card> cardList; //list for deck of cards
        private Card deckCard; //card for deck

        /// <summary>
        /// Initialies the deck of cards
        /// </summary>
        public Deck()
        {
             
            cardList = new List<Card>();
            nextCard = 0;
            random = new Random();
            for(int i = 1; i <= 52; i++)
            {
                deckCard = new Card(i);
                cardList.Add(deckCard);
            }
        }
        /// <summary>
        /// displays each card in console window
        /// </summary>
        public void DisplayDeck()
        {
            //loop through each card in cardlist
            foreach(Card card in cardList)
            {
                Console.WriteLine(card);
            }
        }
        /// <summary>
        /// Shuffles deck
        /// </summary>
        public void ShuffleDeck()
        {
            //declear varibles
            Card num;
            Card num2;
            bool suffled = false;
            if (suffled == false)
            {
                //loop 500 times
                for (int i = 0; i <= 500; i++)
                {
                    //get random indexs from list
                    int index1 = random.Next(0, cardList.Count - 1);
                    int index2 = random.Next(0, cardList.Count - 1);
                    //switch them around
                    num = cardList[index1];
                    num2 = cardList[index2];
                    cardList[index1] = num2;
                    cardList[index2] = num;

                }
                suffled = true;
            }
        }
        /// <summary>
        /// deals card
        /// </summary>
        /// <returns>returns card dealt</returns>
        public Card DealCard()
        {
            //get next card
            Card card = cardList[nextCard];
            //add one to next card
            nextCard++;
            return card;
        }
    }
}
