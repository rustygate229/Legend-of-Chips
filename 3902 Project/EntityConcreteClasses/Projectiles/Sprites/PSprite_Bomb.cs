using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class PSprite_Bomb : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteBomb = new (129, 185, 8, 14);

        // create Renderer objects
        private Renderer _bomb;
        private bool _isCentered = true;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_Bomb(Texture2D spriteSheet, float printScale)
        {
            // create renders of the bomb projectile
            _bomb = new (spriteSheet, _spriteBomb, printScale);
            _bomb.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _bomb.DestinationRectangle; }
            set { _bomb.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _bomb.PositionOnWindow; }
            set { _bomb.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the projectile (movement, animation, etc.)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _bomb.Draw(spriteBatch); }
    }
}