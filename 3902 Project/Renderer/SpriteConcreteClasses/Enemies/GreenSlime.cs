using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class GreenSlime : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer _enemy;

        // variables to change based on where your block is and what to print out
        private Vector2 _spritePosition = new Vector2(79, 11);
        private Vector2 _spriteDimensions = new Vector2(30, 16);
        private Vector2 _spritePrintDimensions = new Vector2(64, 64);
        private Vector2 _rowAndColumns = new Vector2(1, 2);

        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 10;
        private int _positionSpeed = 2;
        private Vector2 _updatePosition;
        private static Random random = new Random();


        // constructor for enemy
        public GreenSlime(Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _enemy = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _position, _spritePosition, _spriteDimensions, _spritePrintDimensions, _rowAndColumns, 30);
        }

        // general get position method from IPosition
        public Vector2 GetPosition()
        {
            return _position;
        }

        // general set position method from IPosition
        public void SetPosition(Vector2 position)
        {
            _position = position;
            _enemy.SetPosition(position);
        }

        // update the movement for enemy
        public void Update()
        {
            // update animation
            _enemy.UpdateFrames();

            // update position and movement counter
            _position += _updatePosition;
            _enemy.SetPosition(_position);
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
        public void Draw(SpriteBatch spriteBatch)
        {
            int[] sR = _enemy.GetSourceRectangle();
            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
            Rectangle destinationRectangle = _enemy.GetDestinationRectangle();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
