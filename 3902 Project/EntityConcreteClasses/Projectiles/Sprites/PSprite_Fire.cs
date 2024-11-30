using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class PSprite_Fire : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteFire = new (191, 185, 16, 16);
        private Vector2 _spriteRowAndColumn = new Vector2(1, 1);
        private int _fireFrames = 30;

        private Renderer _fire;
        private bool _isCentered = true;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_Fire(Texture2D spriteSheet, float printScale)
        {
            _fire = new (spriteSheet, _spriteFire, _spriteRowAndColumn, printScale, _fireFrames);
            _fire.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _fire.DestinationRectangle; }
            set { _fire.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _fire.PositionOnWindow; }
            set { _fire.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the projectile (movement, animation, etc.)
        /// </summary>
        public void Update() { _fire.UpdateFrames(); }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _fire.Draw(spriteBatch); }
    }
}