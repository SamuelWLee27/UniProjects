using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical
{
    public class Hand
    {
        private List<Card> _handList;
        public Hand()
        {
            _handList = new List<Card>();
        }
        /// <summary>
        /// get total points of hand
        /// </summary>
        /// <returns></returns>
        public int Total()
        {
            int points = 0;
            foreach (Card hand in _handList)
            {
                points += hand.Points;
            }
            return points;
        }
        /// <summary>
        /// add card to hand
        /// </summary>
        /// <param name="c"></param>
        public void AddCard(Card c)
        {
            _handList.Add(c);
        }
        /// <summary>
        /// Display hand to listbox
        /// </summary>
        public void DisplayHand(ListBox listBox1)
        {
            //clear listbox
            listBox1.Items.Clear();
            //add cards in hand to listbox
            foreach(Card hand in _handList)
            {
                listBox1.Items.Add(hand);
            }
        }
    }
}
