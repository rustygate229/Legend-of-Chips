using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class Darknut : IColor
    {
        // variables to change based on where your block is and what to print out
        private Rectangle _spriteDownPosition = new (1, 90, 32, 16);
        private Vector2 _spriteDownRowAndColumns = new (1, 2);

        private Rectangle _spriteUpPosition = new (36, 90, 16, 16);
        private Vector2 _spriteUpRowAndColumns = new (1, 1);

        private Rectangle _spriteRightLeftPosition = new (52, 90, 32, 16);
        private Vector2 _spriteRightLeftRowAndColumns = new (1, 2);

        private RendererLists _rendererList;
        private bool _isCentered = true;

        // variables for moving the enemy
        private int _moveCounter;
        private int _moveTotal = 100;
        private int _frameRate = 12;
        private float _positionSpeed = 2f;


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.); takes the Enemy Spritesheet
        /// </summary>
        /// <param name="spriteSheet"></param>
        public Darknut(Texture2D spriteSheet, float printScale)
        {
            // create our renderer list
            Renderer[] rendererListArray = // positions in array correlate to above positions, usually: DOWN, UP, RIGHT, LEFT
            {
                new (spriteSheet, _spriteDownPosition, _spriteDownRowAndColumns, printScale, _frameRate),
                new (spriteSheet, _spriteUpPosition, _spriteUpRowAndColumns, printScale, _frameRate),
                new (spriteSheet, _spriteRightLeftPosition, _spriteRightLeftRowAndColumns, printScale, _frameRate)
            };
            rendererListArray[0].AnimatedStatus = Renderer.STATUS.RowAndColumnAnimated;
            rendererListArray[1].AnimatedStatus = Renderer.STATUS.SingleAnimated;
            rendererListArray[2].AnimatedStatus = Renderer.STATUS.RowAndColumnAnimated;
            // create and assign what type of renderer list it is, and if it is centered
            _rendererList = new RendererLists(rendererListArray, RendererLists.RendOrder.Size3RightLeft);
            _rendererList.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _rendererList.DestinationRectangle; }
            set { _rendererList.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _rendererList.PositionOnWindow; }
            set { _rendererList.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            if (_moveCounter == 0) _rendererList.SetRandomDirection(); Vector2 updatePosition = _rendererList.GetUpdatePosition(_positionSpeed);
            _moveCounter++;
            if (_moveCounter == _moveTotal) { _moveCounter = 0; }

            // update position and animation
            _rendererList.PositionOnWindow = PositionOnWindow + updatePosition;
            _rendererList.UpdateFrames();
        }

        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.Draw(spriteBatch); }

        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="tint"></param>
        public void Draw(SpriteBatch spriteBatch, Color tint) { _rendererList.Draw(spriteBatch, tint); }
    }
}
