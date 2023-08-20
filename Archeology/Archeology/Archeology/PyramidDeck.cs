using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archeology
{
    public class PyramidDeck : Deck
    {
        //Declare lists
        private List<Card> _pyramid1List;
        private List<Card> _pyramid2List;
        private List<Card> _pyramid3List;
        //number of pyramids left
        private int _numPyramids;
        

        public PyramidDeck() : base()
        {
            _pyramid1List = new List<Card>();
            _pyramid2List = new List<Card>();
            _pyramid3List = new List<Card>();
            _numPyramids = 3;
    }

        /// <summary>
        /// list of cards in pyramid 1
        /// </summary>
        public List<Card> Pyramid1List { get { return _pyramid1List; } }

        /// <summary>
        /// list of cards in pyramid 2
        /// </summary>
        public List<Card> Pyramid2List { get { return _pyramid2List; } }

        /// <summary>
        /// list of cards in pyramid 3
        /// </summary>
        public List<Card> Pyramid3List { get { return _pyramid3List; } }

        /// <summary>
        /// Number of pyramids left to explore
        /// </summary>
        public int NumPyramids { get { return _numPyramids; } }

        public override List<Card> SartingDeck(List<Card> cardsList)
        {
            for (int i = 0; i < 3; i++)
            {

                Card card = cardsList[0];
                _pyramid1List.Add(card);
                cardsList.RemoveAt(0);

            }
            for (int i = 0; i < 5; i++)
            {

                Card card = cardsList[0];
                _pyramid2List.Add(card);
                cardsList.RemoveAt(0);
            }
            for (int i = 0; i < 7; i++)
            {

                Card card = cardsList[0];
                _pyramid3List.Add(card);
                cardsList.RemoveAt(0);
            }
            return cardsList;
        }

        /// <summary>
        /// adds pyramid list to hand
        /// </summary>
        /// <param name="hand">current player hand</param>
        /// <returns>New hand list</returns>
        public List<Card> ExploreAPyramid(PlayerHand hand)
        {
            //declear list
            List<Card> pyramidList = new List<Card>();
            //get random index between 0 inclusive and 3 exclusive
            int index = _random.Next(0, 3);
            //check if there are pyramids to explore
            if (_numPyramids > 0)
            {
                //get pyramid list
                pyramidList = AddPyramidToList(pyramidList, index);

                //loop through pyramid list and add cards to hand
                foreach (Card c in pyramidList)
                {
                    c.FlipCard();
                    hand.CardsList.Add(c);
                    hand.HandSize++;
                }
                // number of pyramids -1 
                _numPyramids--;
            }
            else
            {   //error
                MessageBox.Show("There are no pyramids left to explore");
            }
            //return new hand list
            return hand.CardsList;
            
        }

        /// <summary>
        /// get the which pyramid was explored randomly
        /// </summary>
        /// <param name="pyramidList">list to add pyramid cards too</param>
        /// <param name="index">random number for when pyramid is explored</param>
        /// <returns>list of cards in pryamid choosen</returns>
        public List<Card> AddPyramidToList(List<Card> pyramidList, int index)
        {
           //loop untill pyramid list isn't empty
            while (pyramidList.Count <= 0 && pyramidList != null)
            {
                //check index = 0 and _pyramid1List is not empty
                if (index == 0 && _pyramid1List.Count != 0)
                {   //add pyramid to pyramidlist then clear pyramid
                    foreach (Card c in _pyramid1List)
                        pyramidList.Add(c);
                    
                    _pyramid1List.Clear();
                }
                else if (index == 0)// if index = 0 and _pyramid1List is empty
                {   //add one to index
                    index++;
                }
                //check index = 1 and _pyramid2List is not empty
                if (index == 1 && _pyramid2List.Count != 0)
                {   //add pyramid to pyramidlist then clear pyramid
                    foreach (Card c in _pyramid2List)
                        pyramidList.Add(c);

                    _pyramid2List.Clear();

                }
                else if (index == 1)// if index = 1 and _pyramid2List is empty
                { //add one to index
                    index++;
                }

                if (index == 2 && _pyramid3List.Count != 0)//check if index = 2 and _pyramid3List is not empty
                {   //add pyramid to pyramidlist then clear pyramid
                    foreach (Card c in _pyramid3List)
                        pyramidList.Add(c);

                    _pyramid3List.Clear();

                }
                else if (index == 2)// if index = 2 and _pyramid3List is empty
                {   //set index to 0
                    index = 0;
                }

                
            }
            //return pyramid list
            return pyramidList;
        }
    }
}
