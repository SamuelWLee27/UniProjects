using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Archeology
{
    //enum of card types
    public enum CardType { Coin = 1, Cup, Map, Mask, Shard, Scrap, Talisman, Sandstorm, Thief, Pyramid }

    /// <summary>
    /// Making a card
    /// </summary>
    public abstract class Card
    {
        //declear varibles
        private ResourceManager resource_manager = Properties.Resources.ResourceManager;
        protected CardType _type;
        protected Image _image;
        private const int CARD_GAP = 10;
        private Image _frontImage;
        private bool flipped;
        private bool _selected;
        private Rectangle _rectangle;

        //initailiase empty card
        private Card()
        { }

        //intailise card it's varibles
        public Card(CardType type)
        {

            _type = type;

            string resource_id = getResourceId();

            _image = (Bitmap)resource_manager.GetObject(resource_id);
            _frontImage = _image;

            flipped = false;
        }

        //intailise card and it's varibles
        public Card(Card card)
        {

            _type = card._type;
            _image = card._image;
            _frontImage = _image;
        }

        /// <summary>
        /// what type of card the card is
        /// </summary>
        public CardType Type { get { return _type; } }
        /// <summary>
        /// trade value of card
        /// </summary>
        public virtual int TradeValue { get { return 0; } }

        /// <summary>
        /// Gets and sets whether gate is selected or not 
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        /// <summary>
        /// gets list of treasure values
        /// </summary>
        /// <returns>list of treasure values</returns>
        public virtual List<int> TreasureValues()
        {
            List<int> newTreasureValuesList = new List<int>();

            return newTreasureValuesList;
        }

        /// <summary>
        /// draws cards
        /// </summary>
        /// <param name="paper">Graphic to draw on</param>
        /// <param name="pictureBox">pictureBox drawing in</param>
        /// <param name="cardPos">Position of card in deck</param>
        /// <param name="deckSize">Size of deck card is in</param>
        public void DrawCard(Graphics paper, PictureBox pictureBox, int cardPos, int deckSize)
        {
            //stor size of picture box
            int display_x_dim = pictureBox.Width;
            int display_y_dim = pictureBox.Height;
            double ddisplay_x_dim = (double)display_x_dim;
            double ddisplay_y_dim = (double)display_y_dim;

            //store size of image
            double dcard_x_dim = (double)_image.Width;
            double dcard_y_dim = (double)_image.Height;

            //rescale image
            double x_scale = ddisplay_x_dim / ((dcard_x_dim + CARD_GAP) * (deckSize + 2));
            double y_scale = ddisplay_y_dim / (dcard_y_dim);

            //check scales make sure x is less then y
            double scale = (x_scale < y_scale) ? x_scale : y_scale;
            //get width and height for card
            int scaled_card_x_dim = (int)Math.Round(dcard_x_dim * scale);
            int scaled_card_y_dim = (int)Math.Round(dcard_y_dim * scale);
            //get x and y position
            int card_x_org = CARD_GAP + cardPos * (scaled_card_x_dim + CARD_GAP);
            int card_y_org = (display_y_dim - scaled_card_y_dim) / 2;
            //create boundry for card to check if clicked
            _rectangle = new Rectangle(card_x_org, card_y_org, scaled_card_x_dim, scaled_card_y_dim);
            //check if selected
            if (_selected)
            {
                //draw selected card
                paper.FillRectangle(new SolidBrush(Color.Purple), card_x_org - 5, card_y_org - 5, scaled_card_x_dim + 10, scaled_card_y_dim + 10);
                paper.DrawImage(_image, card_x_org, card_y_org, scaled_card_x_dim, scaled_card_y_dim);
            }
            else
            {
                //draw normal card
                paper.DrawImage(_image, card_x_org, card_y_org, scaled_card_x_dim, scaled_card_y_dim);
            }
                
        }

        /// <summary>
        /// draw card
        /// </summary>
        /// <param name="paper">graphics to draw on</param>
        /// <param name="x">x pos of card</param>
        /// <param name="y">y pos of card</param>
        /// <param name="width">width of card</param>
        /// <param name="height">height of card</param>
        public void DrawCard(Graphics paper, int x, int y, int width, int height)
        {
            paper.DrawImage(_image, x, y, width, height);
        }

        /// <summary>
        /// Flip card from back to front vice virsa
        /// </summary>
        public void FlipCard()
        {
            //check if not flipped
            if(flipped == false)
            {
                //set image to back of card
                _image = (Bitmap)resource_manager.GetObject("cardback");
            }//check if flipped
            else if (flipped == true)
            {
                //set image back to front of card
                _image = _frontImage;
            }

            //switch flipped to the opposite of flipped
            flipped = !flipped;
        }

        /// <summary>
        /// check if card is clicked on
        /// </summary>
        /// <param name="x">x of mouse click</param>
        /// <param name="y">y of mouse click</param>
        /// <returns>if clicked on or not</returns>
        public bool IsMouseOn(int x, int y)
        {
            //check if clicked on card
            if (_rectangle.Contains(x, y))
            {
                //switch selected to the opposite of flipped
                _selected = !_selected;
                //return clicked
                return true;
            }
            else //return not clicked
                return false;
        }



        /// <summary>
        /// get resource id for image
        /// </summary>
        /// <returns>resource id for image</returns>
        public abstract string getResourceId();
    }
}
