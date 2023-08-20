using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Archeology
{
    public partial class Form1 : Form
    {
        //Declear varibles
        protected ResourceManager resource_manager;
        List<Card> cardsList = new List<Card>();
        Random random = new Random();

        int playersTurn;
        int passed = 0;
        int numberOfSelectedCards = 0;
        int p1Money = 0;
        int p2Money = 0;
        int numOfCardsSoldP1 = 0;
        int numOfCardsSoldP2 = 0;

        bool gameStarted = false;
        bool actionTaken = false;
        bool digSiteEmpty = false;
        bool gameEnd = false;
        bool forceSell = false;
        bool cardStolen = false;
        bool thiefCard = false;
        bool cardSold = false;

        //initailise each deck
        Deck deck = new Deck();
        PlayerHand p1Hand = new PlayerHand();
        PlayerHand p2Hand = new PlayerHand();
        MarketPlaceDeck market = new MarketPlaceDeck();
        DigSiteDeck digSite = new DigSiteDeck();
        PyramidDeck pyramidDeck = new PyramidDeck();


        public Form1()
        {

            InitializeComponent();

            resource_manager = Properties.Resources.ResourceManager;

            //disable all buttons when app is started
            DisablePlayer1Buttons();

            DisablePlayer2Buttons();
        }

        /// <summary>
        /// Disable player one buttons
        /// </summary>
        private void DisablePlayer1Buttons()
        {
            buttonDigP1.Enabled = false;
            buttonDoneP1.Enabled = false;
            buttonExploreP1.Enabled = false;
            buttonSellP1.Enabled = false;
            buttonStealP1.Enabled = false;
            buttonTradeP1.Enabled = false;
        }

        /// <summary>
        /// Disable player two buttons
        /// </summary>
        private void DisablePlayer2Buttons()
        {
            buttonDigP2.Enabled = false;
            buttonDoneP2.Enabled = false;
            buttonExploreP2.Enabled = false;
            buttonSellP2.Enabled = false;
            buttonStealP2.Enabled = false;
            buttonTradeP2.Enabled = false;
        }

        /// <summary>
        /// starts player 1's turn
        /// </summary>
        private void P1StartTurn()
        {
            //check if digsite is not empty
            if(!digSiteEmpty)
                buttonDigP1.Enabled = true;//enable button
            else
            {   //start turn without dig
                buttonDigP1.Enabled = false;
                buttonExploreP1.Enabled = true;
                buttonSellP1.Enabled = true;
                buttonTradeP1.Enabled = true;
                buttonDoneP1.Enabled = true;
            }
            
            //flipcards so face up
            foreach (Card card in p2Hand.CardsList)
            {
                card.FlipCard();
            }
            //deselect selected cards
            DeselectCards();
        }

        /// <summary>
        /// Starts player 2's turn
        /// </summary>
        private void P2StartTurn()
        {
            //check if cards in dig site
            if (!digSiteEmpty)
                buttonDigP2.Enabled = true;//enable button
            else
            { //start turn without dig
                buttonDigP2.Enabled = false;
                buttonExploreP2.Enabled = true;
                buttonSellP2.Enabled = true;
                buttonTradeP2.Enabled = true;
                buttonDoneP2.Enabled = true;
            }
                //flipcards so face up
                foreach (Card card in p1Hand.CardsList)
            {
                card.FlipCard();
            }
            //deselect selected cards
            DeselectCards();
        }

        /// <summary>
        /// refreshs each picture box
        /// </summary>
        private void RefreshGraphics()
        {
            pictureBoxPlayer2.Refresh();
            pictureBoxPlayer1.Refresh();
            pictureBoxInDeck.Refresh();
            pictureBoxMarket.Refresh();
            pictureBoxPyramid.Refresh();
        }


        /// <summary>
        /// check if turn is passed once dig deck is empty
        /// </summary>
        private void CheckIfPassed()
        {
            //check if turn passed and deck is empty
            if (actionTaken == false && digSiteEmpty == true)
                passed++; //add one to passed value
            else if (actionTaken == true && digSiteEmpty == true)
                passed = 0; //sets equal to 0

            if (passed >= 4) // if passed is four or greater start sequence for end of game
            {
                gameEnd = true;
            }
        }

        /// <summary>
        /// Deslect player and market cards
        /// </summary>
        private void DeselectCards()
        {
            //deselect cards in player 1 hand
            foreach(Card c in p1Hand.CardsList)
            {
                c.Selected = false;
            }
            //deselect cards in player 2 hand
            foreach(Card c in p2Hand.CardsList)
            {
                c.Selected = false;
            }
            //deselect cards in market
            foreach (Card c in market.CardsList)
            {
                c.Selected = false;
            }
        }

        /// <summary>
        /// sells the cards passed int
        /// </summary>
        /// <param name="selectedCards">List of selected cards</param>
        /// <param name="sameCards"> bool to check if cards selected are the same cards</param>
        /// <param name="numCardsSold"> number of cards sold for player 1 or 2 </param>
        /// <returns>Money form cards sold</returns>
        private int SellCards(List<Card> selectedCards, bool sameCards, int numCardsSold)
        {
            //checks if cards are the same
            if (sameCards)
            {
                //Gets position in selle value list
                numberOfSelectedCards = selectedCards.Count - 1;
                //makes sure numOfSelected cards isn't less then 0
                if (numberOfSelectedCards >= 0)
                {
                    //get list for card of the values
                    List<int> sellValuesList = selectedCards[0].TreasureValues();
                    //makes sure not out of array
                    if (sellValuesList.Count - 1 >= numberOfSelectedCards)
                    {
                        //gets sell value of cards
                        int sellValue = sellValuesList[numberOfSelectedCards];
                        //adds to number of cards sold
                        numCardsSold += selectedCards.Count;
                        //card is sold
                        cardSold = true;
                        //return sell value
                        return sellValue;
                    }
                    else
                    {
                        //error
                        MessageBox.Show("Too many cards of this type selected");
                    }
                }
                else
                {
                    //error
                    MessageBox.Show("No cards selected in your hand");
                }
            }
            else
            {
                //error
                MessageBox.Show("Select the same type of cards");
            }
            //return 0 as error has occured
            return 0;
        }

        /// <summary>
        /// removes selected cards from hand
        /// </summary>
        /// <param name="hand">pass in player hand</param>
        /// <param name="selectedCards"> get list of selected cards</param>
        private void RemoveSelecedCards(PlayerHand hand, List<Card> selectedCards)
        {
            //loop through selected cards
            for (int i = 0; i < selectedCards.Count; i++)
            {
                //loop through hand
                for (int j = 0; j < hand.CardsList.Count; j++)
                {
                    //remove selected cards in hand
                    if (hand.CardsList[j].Equals(selectedCards[i]))
                    {
                        hand.CardsList.RemoveAt(j);
                        hand.HandSize = hand.HandSize - 1;
                    }
                }
            }
        }

        /// <summary>
        /// digs a card from deck
        /// </summary>
        /// <param name="hand1">Current player's hand</param>
        /// <param name="hand2">Other player's hand</param>
        /// <param name="stealButton">current player steal button</param>
        public void Dig(PlayerHand hand1, PlayerHand hand2, Button stealButton)
        {
            //check if deck is not empty
            if (digSite.CardsList.Count > 0)
            {
                //draw card from deck
                Card card = digSite.DrawCard();
                if (card is Sandstorm) //check if sandstorm
                {
                    //tell player its a sandstorm
                    MessageBox.Show("Sandstorm both players lose half there hand");
                    //remove hale of each deck at random
                    hand2.Sandstorm();
                    hand1.Sandstorm();

                }
                else if (card is Thief) //check if thief card
                {
                    //tell player its a thief card
                    MessageBox.Show("Steal one card from the other player");
                    //enable steal button
                    stealButton.Enabled = true;
                    //thief card has popped up
                    thiefCard = true;

                    //loop though and flip other player hand so you can see the cards you can steal
                    foreach (Card c in hand2.CardsList)
                    {
                        c.FlipCard();
                    }
                }
                else
                {
                    //add card to hand
                    hand1.CardsList.Add(card);
                    //add one to hand size
                    hand1.HandSize = hand1.HandSize + 1;
                }
            }
            else
            {
                //tell user deck is empty
                MessageBox.Show("Deck is empty");
                //set empty to true
                digSiteEmpty = true;
            }
        }

        /// <summary>
        /// trade selected cards in hand with selected cards in market
        /// </summary>
        /// <param name="hand">hand of current player</param>
        public void TradeCards(PlayerHand hand)
        {
            //declear varibles
            int tradeValueHand = 0;
            int tradeValueMarket = 0;
            //get selected cards from hand and market
            List<Card> selectedCardsHand = hand.SelectedCards(hand.CardsList);
            List<Card> selectedCardsMarket = market.SelectedCards(market.CardsList);
            //loop though selected cards in hand and get trade value
            foreach (Card card in selectedCardsHand)
            {
                tradeValueHand += card.TradeValue;
            }
            //loop though selected cards in market and get trade value
            foreach (Card card in selectedCardsMarket)
            {
                tradeValueMarket += card.TradeValue;
            }
            //check if trade value in hand is equal or greater then trade value of market cards
            if (tradeValueHand >= tradeValueMarket)
            {
                //loop through hand lists and move selected cards to market 
                for (int i = 0; i < hand.CardsList.Count; i++)
                {
                    foreach (Card c in selectedCardsHand)
                    {
                        if (hand.CardsList[i].Equals(c))
                        {
                            market.CardsList.Add(hand.CardsList[i]);
                            hand.CardsList.RemoveAt(i);
                            hand.HandSize--;

                        }
                    }

                }
                //loop through market lists and move selected cards to hand
                for (int i = 0; i < market.CardsList.Count; i++)
                {
                    foreach (Card c in selectedCardsMarket)
                    {
                        if (market.CardsList[i].Equals(c))
                        {
                            hand.CardsList.Add(market.CardsList[i]);
                            market.CardsList.RemoveAt(i);
                            hand.HandSize++;
                        }
                    }
                }
            }
            else
            {
                //error
                MessageBox.Show("Trade value of cards selected in hand is less then trade value" +
                    " of cards selected on market");
            }
            //deselect all cards
            DeselectCards();
        }

        /// <summary>
        /// add a pyramid deck to players hand
        /// </summary>
        /// <param name="hand">current players hand</param>
        public void Explore(PlayerHand hand)
        {
            //set map clicked to false
            bool mapCardClicked = false;
            //loop though hand list
            for (int i = 0; i < hand.CardsList.Count; i++)
            {
                //check if card = map is selected
                if (hand.CardsList[i].Selected && hand.CardsList[i] is Map)
                {
                    
                    //check if any pyramids  and if hasn't already found a selected map
                    if (pyramidDeck.NumPyramids != 0 && !mapCardClicked)
                    {
                        //set map clicked to true
                        mapCardClicked = true;
                        //remove card from card list
                        hand.CardsList.RemoveAt(i);
                        // -1 from hand size
                        hand.HandSize--;
                    }

                }
            }//check if map clicked
            if (mapCardClicked)
                //add pyramid card to deck
                hand.CardsList = pyramidDeck.ExploreAPyramid(hand);
            else
            {
                //error
                MessageBox.Show("Must select a map card");
            }

        }

        /// <summary>
        /// steals card selected from other player
        /// </summary>
        /// <param name="hand1">other players hand</param>
        /// <param name="hand2">current players hand</param>
        /// <param name="button">steal button</param>
        public void Steal(PlayerHand hand1, PlayerHand hand2 , Button button)
        {
            
            //initialise varible
            Card card;
            //get list of selected cards
            List<Card> selectedCards = hand1.SelectedCards(hand1.CardsList);
            //check if only one card is selected
            if (selectedCards.Count == 1)
            {
                //loop through list
                for (int i = 0; i < hand1.CardsList.Count; i++)
                {
                    //check if selected
                    if (hand1.CardsList[i].Selected)
                    {
                        //steal card from player and add to current player hand
                        card = hand1.CardsList[i];
                        hand1.CardsList.RemoveAt(i);
                        hand1.HandSize--;
                        hand2.CardsList.Add(card);
                        hand2.HandSize++;
                    }
                }
                //loop through other players cards
                foreach (Card c in hand1.CardsList)
                {
                    //and flipp cards back
                    c.FlipCard();
                }
                button.Enabled = false;
                cardStolen = true;
            }
            else
            {
                //error
                MessageBox.Show("Must select one card");
            }
        }

        /// <summary>
        /// Ends the game and gives winner
        /// </summary>
        public void EndGame()
        {
            //disable buttons
            DisablePlayer1Buttons();
            DisablePlayer2Buttons();
            //check if player 1s money is greater then player 2s
            if(p1Money > p2Money)
            {
                //display winner
                MessageBox.Show("Player 1 wins");
            }//check if money equal
            else if(p1Money == p2Money)
            {   //check if player 1s num cards sold is greater then player 2s
                if (numOfCardsSoldP1 > numOfCardsSoldP2)
                {
                    // display winner
                    MessageBox.Show("Player 1 wins");
                }//check if num cards sold equal
                else if(numOfCardsSoldP1 == numOfCardsSoldP2)
                {
                    // display draw
                    MessageBox.Show("It's a draw");
                }
                else
                {
                    // display winner
                    MessageBox.Show("Player 2 wins");
                }
            }
            else
            {
                //display winner
                MessageBox.Show("Player 2 wins");
            }
        }



       
        /// <summary>
        /// When button is clicked draw card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDigP2_Click(object sender, EventArgs e)
        {
            //call dig method
            Dig(p2Hand, p1Hand, buttonStealP2);
            //refresh graphics
            RefreshGraphics();
            //enable and disable buttons
            buttonDigP2.Enabled = false;
            buttonExploreP2.Enabled = true;
            buttonSellP2.Enabled = true;
            buttonTradeP2.Enabled = true;
            buttonDoneP2.Enabled = true;
            //display number of cards in deck
            textBoxNumCardsInDeck.Text = digSite.CardsInDeck.ToString();
        }

        /// <summary>
        /// When button is clicked draw card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDigP1_Click(object sender, EventArgs e)
        {
            //call dig method
            Dig(p1Hand, p2Hand, buttonStealP1);
            //refresh graphics
            RefreshGraphics();
            //enable and disable buttons
            buttonDigP1.Enabled = false;
            buttonExploreP1.Enabled = true;
            buttonSellP1.Enabled = true;
            buttonTradeP1.Enabled = true;
            buttonDoneP1.Enabled = true;
            //display number of cards in deck
            textBoxNumCardsInDeck.Text = digSite.CardsInDeck.ToString();
        }

        /// <summary>
        /// when clicked starts the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if game has already been started
            if (!gameStarted)
            {
                //create decks
                cardsList = deck.SartingDeck(cardsList);
                cardsList = deck.ShuffleDeck(cardsList);
                cardsList = p1Hand.SartingDeck(cardsList);
                cardsList = p2Hand.SartingDeck(cardsList);
                cardsList = market.SartingDeck(cardsList);
                cardsList = pyramidDeck.SartingDeck(cardsList);
                cardsList = digSite.SartingDeck(cardsList);
                digSite.ShuffleDeck();//shuffle deck
            }

            //get players turn
            playersTurn = random.Next(0, 2);
            if (playersTurn == 0 && gameStarted == false)
            {
                P1StartTurn();
            }
            else if (playersTurn == 1 && gameStarted == false)
            {
                P2StartTurn();
            }
            RefreshGraphics();
            gameStarted = true;
            //display num of cards in deck
            textBoxNumCardsInDeck.Text = digSite.CardsInDeck.ToString();

        }

        /// <summary>
        /// draw player two's hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPlayer2_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < p2Hand.CardsList.Count; i++)
            {
                p2Hand.CardsList[i].DrawCard(e.Graphics, pictureBoxPlayer2, i, p2Hand.HandSize);
            }
        }

        /// <summary>
        /// Draw player one's hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPlayer1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < p1Hand.CardsList.Count; i++)
            {
                p1Hand.CardsList[i].DrawCard(e.Graphics, pictureBoxPlayer1, i, p1Hand.HandSize);
            }
        }

        /// <summary>
        /// Draws top card on draw pile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxInDeck_Paint(object sender, PaintEventArgs e)
        {
            if (digSite.CardsList != null && digSite.CardsList.Count > 0)
                digSite.CardsList[0].DrawCard(e.Graphics, pictureBoxInDeck, 0, 0);
        }

        /// <summary>
        /// draws market deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxMarket_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < market.CardsList.Count; i++)
            {
                market.CardsList[i].DrawCard(e.Graphics, pictureBoxMarket, i, market.CardsList.Count);
            }
        }
        /// <summary>
        /// draw pyramid decks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPyramid_Paint(object sender, PaintEventArgs e)
        {
            if (pyramidDeck.Pyramid1List.Count > 0)
                pyramidDeck.Pyramid1List[0].DrawCard(e.Graphics, 95, 20, 46, 80);
            if (pyramidDeck.Pyramid2List.Count > 0)
                pyramidDeck.Pyramid2List[0].DrawCard(e.Graphics, 47, 0, 47, 80);
            if (pyramidDeck.Pyramid3List.Count > 0)
                pyramidDeck.Pyramid3List[0].DrawCard(e.Graphics, 0, 20, 46, 80);
            Pyramid pyramid = new Pyramid(CardType.Pyramid);
            pyramid.DrawCard(e.Graphics, 47, 105, 47, 83);
        }

        /// <summary>
        /// check if clicked on card in pictureBoxPlayer2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPlayer2_MouseClick(object sender, MouseEventArgs e)
        {
            //declear varibles
            int x = e.X;
            int y = e.Y;
            // check if card clicked
            bool cardClicked = p2Hand.CardInDeckClicked(x, y, p2Hand.CardsList);

            //if card clicked refresh graphics
            if (cardClicked)
                pictureBoxPlayer2.Refresh();
        }

        /// <summary>
        /// check if clicked on card in pictureBoxPlayer1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPlayer1_MouseClick(object sender, MouseEventArgs e)
        {
            //declear varibles
            int x = e.X;
            int y = e.Y;
            // check if card clicked
            bool cardClicked = p1Hand.CardInDeckClicked(x, y, p1Hand.CardsList);
            //if card clicked refresh graphics
            if (cardClicked)
                pictureBoxPlayer1.Refresh();
        }

        /// <summary>
        /// check if clicked on card in pictureBoxMarket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxMarket_MouseClick(object sender, MouseEventArgs e)
        {
            //declear varibles
            int x = e.X;
            int y = e.Y;
            // check if card clicked
            bool cardClicked = market.CardInDeckClicked(x, y, market.CardsList);
            //if card clicked refresh graphics
            if (cardClicked)
                pictureBoxMarket.Refresh();
        }

        /// <summary>
        /// once clicked switch turns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDoneP2_Click(object sender, EventArgs e)
        {
            //call method
            CheckIfPassed();
            //set to initial value
            actionTaken = false;
            
            //check if card is stolen or thief card has not popped up
            if (cardStolen || !thiefCard)
            {
                //flip cards in hand
                foreach (Card card in p1Hand.CardsList)
                {
                    card.FlipCard();
                }
            }
            //set to intial value
            cardStolen = false;
            thiefCard = false;
            //call methods
            DisablePlayer2Buttons();
            P1StartTurn();
            RefreshGraphics();
            //if end of game force next player to sell 
            if (gameEnd && p1Hand.CardsList.Count != 0 && !forceSell)
            {
                buttonExploreP1.Enabled = false;
                buttonTradeP1.Enabled = false;
                buttonDoneP1.Enabled = false;
            }
            else if (gameEnd || forceSell) //check if end of game
            {

                EndGame();
            }
        }
        // <summary>
        /// once clicked switch turns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDoneP1_Click(object sender, EventArgs e)
        {
            //call method
            CheckIfPassed();
            //set to inital value
            actionTaken = false;
            //check if card is stolen or thief card has not popped up
            if (cardStolen || !thiefCard)
            {
                //flip cards in hand
                foreach (Card card in p2Hand.CardsList)
                {
                    card.FlipCard();
                }
            }
            //set to intial value
            cardStolen = false;
            thiefCard = false;
            //call methods
            DisablePlayer1Buttons();
            P2StartTurn();
            RefreshGraphics();
            //if end of game force next player to sell
            if (gameEnd && p2Hand.CardsList.Count != 0 && !forceSell)
            {
                buttonExploreP2.Enabled = false;
                buttonTradeP2.Enabled = false;
                buttonDoneP2.Enabled = false;
            }
            else if (gameEnd || forceSell) //check if end of game
            {
                EndGame();
            }
        }

        /// <summary>
        /// if clicked sell cards selected in hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSellP2_Click(object sender, EventArgs e)
        {
            //set to true
            actionTaken = true;
            //get list of selected cards
            List<Card> selectedCards = p2Hand.SelectedCards(p2Hand.CardsList);
            //check if cards are the same
            bool sameCards = p2Hand.SameSelectedCards(selectedCards);
            //get value of cards sold
            int value = SellCards(selectedCards, sameCards, numOfCardsSoldP2);
            //add value to money
            p2Money += value;
            //check if cards were sold
            if (sameCards && value != 0)
            {
                //remove selected cards from hand
                RemoveSelecedCards(p2Hand, selectedCards);
            }
            //refresh picturebox
            pictureBoxPlayer2.Refresh();
            //update amount of money
            textBoxMoneyP2.Text = p2Money.ToString();
            //check if game end
            if (gameEnd && cardSold)
            {
                //set up for end of game
                buttonDoneP2.Enabled = true;
                forceSell = true;
            }
            cardSold = false;
        }

        /// <summary>
        /// if clicked sell cards selected in hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSellP1_Click(object sender, EventArgs e)
        {
            //set to true
            actionTaken = true;
            //get list of selected cards
            List<Card> selectedCards = p1Hand.SelectedCards(p1Hand.CardsList);
            //check if cards are the same
            bool sameCards = p1Hand.SameSelectedCards(selectedCards);
            //get value of cards sold
            int value = SellCards(selectedCards, sameCards, numOfCardsSoldP1);
            //add value to money
            p1Money += value;
            //check if cards were sold
            if (sameCards && value != 0)
            {
                //remove selected cards from hand
                RemoveSelecedCards(p1Hand, selectedCards);
            }
            //refresh picturebox
            pictureBoxPlayer1.Refresh();
            //update amount of money
            textBoxMoneyP1.Text = p1Money.ToString();
            //check if game end
            if (gameEnd && cardSold)
            {
                //set up for end of game
                buttonDoneP1.Enabled = true;
                forceSell = true;
            }
            cardSold = false;
        }

        /// <summary>
        /// trade selected cards in hand and market
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTradeP2_Click(object sender, EventArgs e)
        {
            //set to true
            actionTaken = true;
            //call methods
            TradeCards(p2Hand);
            RefreshGraphics();
        }

        /// <summary>
        /// trade selected cards in hand and market
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTradeP1_Click(object sender, EventArgs e)
        {
            //set to true
            actionTaken = true;
            //call methods
            TradeCards(p1Hand);
            RefreshGraphics();
        }
        
        /// <summary>
        /// explore pyramid and add cards to hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExploreP2_Click(object sender, EventArgs e)
        {
            //set to true
            actionTaken = true;
            //call methods
            Explore(p2Hand);
            RefreshGraphics();
        }

        /// <summary>
        /// explore pyramid and add cards to hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExploreP1_Click(object sender, EventArgs e)
        {
            //set true
            actionTaken = true;
            //call methods
            Explore(p1Hand);
            RefreshGraphics();
        }

        /// <summary>
        /// when clicked steal selected card from opponent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStealP2_Click(object sender, EventArgs e)
        {
            //set true
            actionTaken = true;
            //call methods
            Steal(p1Hand, p2Hand, buttonStealP2);
            RefreshGraphics();
        }

        /// <summary>
        /// when clicked steal selected card from opponent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStealP1_Click(object sender, EventArgs e)
        {
            //set true
            actionTaken = true;
            //call methods
            Steal(p2Hand, p1Hand, buttonStealP1);
            RefreshGraphics();
        }

        /// <summary>
        /// Exits application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
