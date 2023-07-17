using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical
{
    public partial class Form1 : Form
    {
        //#############################################################################################
        //# Instance variables
        /// <summary>
        /// Random number generator, used to generate cards.
        /// </summary>
        private Random randomGenerator = new Random();

        //private Card playerCard1;
        //private Card playerCard2;

        //private Card dealerCard1;
        //private Card dealerCard2;
        //###############################################################################
        //list for players cards and dealer and varible
        //private List<Card> playerCardsList = new List<Card>();
        //private List<Card> dealerCardsList = new List<Card>();
        
        //Initialies new deck
        private Deck deck = new Deck();
        //Initialies hand
        private Hand playerHand = new Hand();
        private Hand dealerHand = new Hand();
        //#############################################################################################
        //# Constants
        /// <summary>
        /// Total number of cards
        /// </summary>
        private const int NUM_CARDS = 52;
        /// <summary>
        /// Maximum points allowed before going bust
        /// </summary>
        private const int BLACKJACK = 21;
        /// <summary>
        /// Initial amount of money available to the player (to implement betting).
        /// </summary>
        private const int START_MONEY = 100;

        //#############################################################################################
        //# Constructor
        public Form1()
        {
            InitializeComponent();
            // Prevent the user from resising the form
            MinimumSize = MaximumSize = Size;
        }

        //#############################################################################################
        //# Event Handlers
        //private void buttonDealFirstCard__Click(object sender, EventArgs e)
        //{
        //    // Generate 4 new random cards
        //    playerCard1 = new Card(randomGenerator.Next(NUM_CARDS));
        //    playerCard2 = new Card(randomGenerator.Next(NUM_CARDS));
        //    dealerCard1 = new Card(randomGenerator.Next(NUM_CARDS));
        //    dealerCard2 = new Card(randomGenerator.Next(NUM_CARDS));

        //    // Display the first card to player and dealer
        //    textBoxPlayerCard1_.Text = playerCard1.ToString();
        //    textBoxDealerCard1_.Text = dealerCard1.ToString();

        //    // Clear the second card and totals
        //    textBoxPlayerCard2_.Text = "";
        //    textBoxPlayerTotal_.Text = "";
        //    textBoxDealerCard2_.Text = "";
        //    textBoxDealerTotal_.Text = "";
        //}

        //private void buttonDealSecondCard__Click(object sender, EventArgs e)
        //{
        //    //display second two cards and total
        //    textBoxPlayerCard2_.Text = playerCard2.ToString();
        //    textBoxDealerCard2_.Text = dealerCard2.ToString();

        //    int playerTotal = playerCard1.Points + playerCard2.Points;
        //    int dealerTotal = dealerCard1.Points + dealerCard2.Points;

        //    textBoxPlayerTotal_.Text = playerTotal.ToString();
        //    textBoxDealerTotal_.Text = dealerTotal.ToString();

        //    if (playerTotal > BLACKJACK)
        //    { // Player bust: loses even if dealer bust.
        //        LoseGame();
        //    }
        //    else if (dealerTotal > BLACKJACK || playerTotal > dealerTotal)
        //    {
        //        MessageBox.Show("You win!");
        //    }
        //    else if (playerTotal == dealerTotal)
        //    {
        //        MessageBox.Show("You tie!");
        //    }
        //    else
        //    { // Player total less than dealer, and dealer did not bust.
        //        LoseGame();
        //    }
        //}

        /// <summary>
        /// This method will end the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuit__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //#############################################################################################
        //# Private Methods
        private void LoseGame()
        {
            MessageBox.Show("You lose!");
        }
        
        private void buttonDeal_Click(object sender, EventArgs e)
        {
            
            
            deck.ShuffleDeck();
            
            deck.DisplayDeck();

            //add card to dealer and 
            playerHand.AddCard(deck.DealCard()); 
            dealerHand.AddCard(deck.DealCard());

            //clear list box
            listBoxDealersCards.Items.Clear();
            listBoxPlayersCards.Items.Clear();

            //clear total points
            textBoxPlayerTotal_.Text = "";
            textBoxDealerTotal_.Text = "";

            //get hand values
            int playerPoints = playerHand.Total();
            int dealerPoints = dealerHand.Total();

            //show player points and cards
            textBoxPlayerTotal_.Text = playerPoints.ToString();
            playerHand.DisplayHand(listBoxPlayersCards);

            //show dealer points and cards
            textBoxDealerTotal_.Text = dealerPoints.ToString();
            dealerHand.DisplayHand(listBoxDealersCards);

            if (playerPoints > BLACKJACK)
            { // Player bust: loses even if dealer bust.
                LoseGame();
            }
            else if (dealerPoints > BLACKJACK)
            {
                MessageBox.Show("You win!");
            }
            ////set player and dealer points to 0
            //int playerPoints = 0;
            //int dealerPoints = 0;
            ////clear list box
            //listBoxDealersCards.Items.Clear();
            //listBoxPlayersCards.Items.Clear();

            ////deal cards for player and computer
            //playerCard1 = new Card(randomGenerator.Next(NUM_CARDS));

            //dealerCard1 = new Card(randomGenerator.Next(NUM_CARDS));
            ////add card to list
            //dealerCardsList.Add(dealerCard1);

            ////add cards to list
            //playerCardsList.Add(playerCard1);

            ////clear total points
            //textBoxPlayerTotal_.Text = "";
            //textBoxDealerTotal_.Text = "";
            ////loop for player cards
            //for(int i = 0; i < playerCardsList.Count; i++)
            //{
            //    //add card to listbox
            //    listBoxPlayersCards.Items.Add(playerCardsList[i]);
            //    playerPoints += playerCardsList[i].Points;
            //}
            ////show player points
            //textBoxPlayerTotal_.Text = playerPoints.ToString();
            ////loop for dealer cards
            //foreach(Card c in dealerCardsList)
            //{
            //    listBoxDealersCards.Items.Add(c);
            //    dealerPoints += c.Points;
            //}
            ////show dealer points
            //textBoxDealerTotal_.Text = dealerPoints.ToString();
            //if (playerPoints > BLACKJACK)
            //{ // Player bust: loses even if dealer bust.
            //    LoseGame();
            //}
            //else if (dealerPoints > BLACKJACK)
            //{
            //    MessageBox.Show("You win!");
            //}


        }


    }
   
}

