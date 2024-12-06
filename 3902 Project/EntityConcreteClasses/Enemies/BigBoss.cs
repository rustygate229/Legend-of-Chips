using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class BigBoss : IColor
    {
        // variables to change based on where your block is and what to print out
        private Rectangle _spritePosition = new(40, 154, 165, 32);
        private Vector2 _rowAndColumns = new(1, 5);
        private int frames = 25;
        private float _printScale;

        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 15;
        private float _positionSpeed = 1F;

      

        // create enemy renderer
        private Renderer _enemy;
        private bool _isCentered = true;


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.)
        /// </summary>
        /// <param name="spriteSheet"></param>
        public BigBoss(Texture2D spriteSheet, float printScale)
        {
            _printScale = printScale;
           
            _enemy = new(spriteSheet, _spritePosition, _rowAndColumns, printScale, frames);
            _enemy.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _enemy.DestinationRectangle; }
            set { _enemy.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _enemy.PositionOnWindow; }
            set { _enemy.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            if (_moveCounter == 0) _enemy.SetRandomMovement(); Vector2 updatePosition = _enemy.GetUpdatePosition(_positionSpeed);
           
            _moveCounter++;
            if (_moveCounter == _moveTotal) { _moveCounter = 0; }

            // update position and animation
            _enemy.PositionOnWindow = PositionOnWindow + updatePosition;
            _enemy.UpdateFrames();
        }


        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _enemy.Draw(spriteBatch); }

        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="tint"></param>
        public void Draw(SpriteBatch spriteBatch, Color tint) { _enemy.Draw(spriteBatch, tint); }
    }
}