using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class PSprite_SmallExplosion : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private Rectangle _spriteExplode = new (53, 189, 8, 8);
        private Vector2 _spriteRowAndColumn = new (1, 1);
        private int _frames = 6;

        // create Renderer objects
        private Renderer _explode;
        private bool _isCentered = true;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_SmallExplosion(Texture2D spriteSheet, float printScale)
        {
            // create renders of the small explosion projectile
            _explode = new (spriteSheet, _spriteExplode, _spriteRowAndColumn, printScale, _frames);
            _explode.AnimatedStatus = Renderer.STATUS.SingleAnimated;
            _explode.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _explode.DestinationRectangle; }
            set { _explode.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _explode.PositionOnWindow; }
            set { _explode.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the projectile (movement, animation, etc.)
        /// </summary>
        public void Update() { _explode.UpdateFrames(); }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _explode.Draw(spriteBatch); }
    }
}