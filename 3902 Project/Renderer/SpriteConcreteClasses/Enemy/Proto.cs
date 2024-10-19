using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class Proto : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _previousPosition = new Vector2(-1000, -1000);
        private Vector2 _currentPosition;
        private Renderer _enemy;

        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 100;
        private int _positionSpeed = 2;
        private Vector2 _updatePosition;
        private static Random random = new Random();


        // constructor for enemy
        public Proto(Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _enemy = new Renderer(Renderer._status.Animated, _spriteSheet, _previousPosition, 300, 194, 33, 16, 64, 64, 1, 2, 30);
        }


        // update the movement for enemy
        public void Update()
        {
            // update animation
            _enemy.Update();

            // update position and movement counter
            _currentPosition += _updatePosition;
            _moveCounter++;

            // Change direction periodically (random horizontal or vertical movement)
            if (_moveCounter >= _moveTotal)
            {
                // Randomly choose a direction: 0 = left, 1 = right, 2 = up, 3 = down
                switch (random.Next(4))
                {
                    case 0: // Move left
                        _updatePosition = new Vector2(-(Math.Abs(_positionSpeed)), 0);
                        break;
                    case 1: // Move right
                        _updatePosition = new Vector2(Math.Abs(_positionSpeed), 0);
                        break;
                    case 2: // Move up
                        _updatePosition = new Vector2(0, -(Math.Abs(_positionSpeed)));
                        break;
                    case 3: // Move down
                        _updatePosition = new Vector2(0, Math.Abs(_positionSpeed));
                        break;
                }
                _moveCounter = 0; // Reset the timer
            }
        }


        // draw the enemy
        public void Draw(SpriteBatch spriteBatch, Vector2 updatedPosition)
        {
            if (_previousPosition.Equals(new Vector2(-1000, -1000)))
            {
                _previousPosition = updatedPosition;
                _currentPosition = updatedPosition;
                _enemy.Draw(spriteBatch, _previousPosition);
            }
            else
            {
                _previousPosition = _currentPosition;
                _enemy.Draw(spriteBatch, _currentPosition);
            }
        }
    }
}
