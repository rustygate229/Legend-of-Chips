using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class LinkWon : IColor
    {
        // variables for link in frame 1 of the moving link sprite animation
        private Rectangle _spriteFirstFrame = new(213, 11, 16, 16);
        private Rectangle _spriteThirdFrame = new(230, 11, 16, 16);

        private Vector2 _spriteRowAndColumn = new(1, 3);
        private int _frames = 18;
        private bool _flip = false;
        private int _counter = 0;
        private int _counterTotal = 20;

        // create a Renderer object
        private Renderer _link;
        private bool _isCentered = true;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkWon (Texture2D spriteSheet, float printScale)
        {
            // create different facing block sprites for the renderer list
            List<Rectangle> sourceRects = new List<Rectangle>() { _spriteFirstFrame, _spriteFirstFrame, _spriteThirdFrame };
            // create renderer list
            _link = new (spriteSheet, sourceRects, _spriteRowAndColumn, printScale, _frames);
            _link.AnimatedStatus = Renderer.STATUS.SeparatedAnimated;
            _link.IsCentered = _isCentered;
            // set correct direciton
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _link.DestinationRectangle; }
            set { _link.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _link.PositionOnWindow; }
            set { _link.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update() 
        { 
            _link.UpdateFrames();
            Vector2 jumpUpdatedPosition = new(0, 1);
            if (_flip)
            {
                _link.PositionOnWindow += jumpUpdatedPosition;
                if (_counter >= _counterTotal)
                {
                    _flip = !_flip;
                    _counter = 0;
                }
            }
            else if (!_flip)
            {
                _link.PositionOnWindow -= jumpUpdatedPosition;
                if (_counter >= _counterTotal)
                {
                    _flip = !_flip;
                    _counter = 0;
                }
            }
            _counter++;
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) 
        { 
            if (_link.CurrentFrame == 1) 
                _link.Draw(spriteBatch, Renderer.DrawFlips.Horizontal);
            else _link.Draw(spriteBatch);
        }

        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch, Color tint) { _link.Draw(spriteBatch, tint); }
    }
}