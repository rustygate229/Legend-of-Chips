using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class StartScreen : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _startScreenFrame1 = new(258, 11, 256, 224);
        private Rectangle _startScreenFrame2 = new(515, 11, 256, 224);
        private Rectangle _destinationRectangle = new(0, 0, 1024, 900);
        private Vector2 _spriteRowAndColumns = new(1, 2);
        private int _frames = 12;

        // create timers, movement and speed variables
        private Renderer _startScreen;
        private bool _isCentered = false;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public StartScreen(Texture2D spriteSheet)
        {
            List<Rectangle> SRs = new List<Rectangle>() { _startScreenFrame1, _startScreenFrame2 };
            _startScreen = new(spriteSheet, SRs, _spriteRowAndColumns, 4.1f, _frames);
            _startScreen.PositionOnWindow = new(_destinationRectangle.X, _destinationRectangle.Y);
            _startScreen.DestinationRectangle = _destinationRectangle;
            _startScreen.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _startScreen.DestinationRectangle; }
            set { _startScreen.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _startScreen.PositionOnWindow; }
            set { _startScreen.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            _startScreen.UpdateFrames();
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _startScreen.Draw(spriteBatch);}

        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="tint"></param>
        public void Draw(SpriteBatch spriteBatch, Color tint) { _startScreen.Draw(spriteBatch, tint);}
    }
}
