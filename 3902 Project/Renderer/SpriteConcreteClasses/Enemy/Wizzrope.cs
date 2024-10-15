using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class Wizzrope : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer _enemy;

        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 10;
        private int _positionSpeed = 2;
        private Vector2 _updatedPosition;
        private static Random random = new Random();


        // constructor for enemy
        public Wizzrope(Texture2D spriteSheet, Vector2 startPosition)
        {
            _spriteSheet = spriteSheet;
            _position = startPosition;
            _enemy = new Renderer(Renderer._status.Animated, _spriteSheet, _position, 127, 90, 32, 33, 64, 64, 2, 2, 30);
        }


        // update the movement for enemy
        public void Update()
        {
            // update animation
            _enemy.Update();

            // update position and movement counter
            _position += _updatedPosition;
            _moveCounter++;

            // Change direction periodically (random horizontal or vertical movement)
            if (_moveCounter >= _moveTotal)
            {
                // Randomly choose a direction: 0 = left, 1 = right, 2 = up, 3 = down
                switch (random.Next(4))
                {
                    case 0: // Move left
                        _updatedPosition = new Vector2(-(Math.Abs(_positionSpeed)), 0);
                        break;
                    case 1: // Move right
                        _updatedPosition = new Vector2(Math.Abs(_positionSpeed), 0);
                        break;
                    case 2: // Move up
                        _updatedPosition = new Vector2(0, -(Math.Abs(_positionSpeed)));
                        break;
                    case 3: // Move down
                        _updatedPosition = new Vector2(0, Math.Abs(_positionSpeed));
                        break;
                }
                _moveCounter = 0; // Reset the timer
            }

        }


        // draw the enemy
        public void Draw(SpriteBatch spriteBatch)
        {
            _enemy.Draw(spriteBatch);
        }
    }
}
