using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracP6
{
    /// <summary>
    /// A simple game of space invaders.
    /// </summary>
    public partial class SpaceInvaders : Form
    {
        //####################################################################
        //# Instance Variables
        /// <summary>
        /// List of all sprites.
        /// </summary>
        private List<Sprite> sprites_;
        /// <summary>
        /// The alien ship. It is also included in the list of sprites,
        /// but the separate variable helps to invoke the alien's special
        /// method to drop bombs.
        /// </summary>
        private AlienShip alien_;

        //####################################################################
        //# Constructor
        /// <summary>
        /// Initialise the Space Invaders game.
        /// </summary>
        public SpaceInvaders()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size;
            sprites_ = new List<Sprite>();
            alien_ = new AlienShip(pictureBox_.Width);
            sprites_.Add(new PlayerShip(15 , pictureBox_.Height- 35, 30, 15, pictureBox_.Width));
            sprites_.Add(alien_);
        }

        //####################################################################
        //# Event Handlers
        /// <summary>
        /// Tick handler of animation timer.
        /// This code is executed repeatedly at regular time intervals.
        /// </summary>
        private void animationTimer__Tick(object sender, EventArgs e)
        {
            // Move all sprites.
            foreach (Sprite sprite in sprites_)
            {
                sprite.Move();
            }
            // Check whether the alien wants to drop a bomb.
            AlienBomb bomb = alien_.LaunchBomb();
            if (bomb != null)
            {
                sprites_.Add(bomb);
            }
            // Make sure all changes are displayed.
            Refresh();
            // Check for collisions.
            foreach (Sprite sprite in sprites_)
            {
                if (sprite.HasCollidedWith(alien_))
                {
                    animationTimer_.Stop();
                    MessageBox.Show("The alien ship has been hit! Player wins.");
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Paint event handler. This is called when the form needs repainting,
        /// or in response to the Refresh() method call above. It simply displays
        /// all sprites in the correct graphics context.
        /// </summary>
       private void pictureBox__Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.Black);
            foreach (Sprite sprite in sprites_)
            {
                sprite.Draw(graphics);
            }
        }

        private void pictureBox__Click(object sender, EventArgs e)
        {

        }
    }
}
