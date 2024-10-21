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
        private Renderer.DIRECTION _direction;

        private Renderer _enemyUp;
        private Renderer _enemyDownRightLeft;

        // variables to change based on where your block is and what to print out
        private Vector2 _spriteUpPosition = new Vector2(160, 107);
        private Vector2 _spriteUpDimensions = new Vector2(33, 16);
        private Vector2 _spriteUpRowAndColumns = new Vector2(1, 2);

        private Vector2 _spriteDownRightLeftPosition = new Vector2(127, 107);
        private Vector2 _spriteDownRightLeftDimensions = new Vector2(32, 16);
        private Vector2 _spriteDownRightLeftRowAndColumns = new Vector2(1, 2);

        private Vector2 _spritePrintDimensions = new Vector2(64, 64);


        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 10;
        private int _positionSpeed = 2;
        private Vector2 _updatePosition;
        private static Random random = new Random();


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.); takes the Enemy Spritesheet
        /// </summary>
        /// <param name="spriteSheet"></param>
        public Wizzrope(Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _enemyUp = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _position, _spriteUpPosition, _spriteUpDimensions, _spritePrintDimensions, _spriteUpRowAndColumns, 30);
            _enemyDownRightLeft = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _position, _spriteDownRightLeftPosition, _spriteDownRightLeftDimensions, _spritePrintDimensions, _spriteDownRightLeftRowAndColumns, 30);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition()
        {
            return _position;
        }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            _position = position;
            _enemyUp.SetPosition(position);
            _enemyDownRightLeft.SetPosition(position);
        }



        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // update position and movement counter
            _position += _updatePosition;
            _enemyDownRightLeft.SetPosition(_position);
            _enemyUp.SetPosition(_position);
            _moveCounter++;

            // Change direction periodically (random horizontal or vertical movement)
            if (_moveCounter >= _moveTotal)
            {
                // Randomly choose a direction: 0 = left, 1 = right, 2 = up, 3 = down
                switch (random.Next(4))
                {
                    case 0: // Move DOWN
                        _updatePosition = new Vector2(0, Math.Abs(_positionSpeed));
                        _direction = Renderer.DIRECTION.DOWN;
                        break;
                    case 1: // Move UP
                        _updatePosition = new Vector2(0, -(Math.Abs(_positionSpeed)));
                        _direction = Renderer.DIRECTION.UP;
                        break;
                    case 2: // Move RIGHT
                        _updatePosition = new Vector2(Math.Abs(_positionSpeed), 0);
                        _direction = Renderer.DIRECTION.RIGHT;
                        break;
                    case 3: // Move LEFT
                        _updatePosition = new Vector2(-(Math.Abs(_positionSpeed)), 0);
                        _direction = Renderer.DIRECTION.LEFT;
                        break;
                }
                _moveCounter = 0; // Reset the timer
            }
            // needed to constantly update the frames - only switch when up (since only other direction sprite)
            if (_direction == Renderer.DIRECTION.UP)
                _enemyUp.UpdateFrames();
            else
                _enemyDownRightLeft.UpdateFrames();
        }


        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // create source rectangles
            int[] sR_DRL = _enemyDownRightLeft.GetSourceRectangle();
            int[] sR_U = _enemyUp.GetSourceRectangle();

            Rectangle downRightSourceRectangle = new Rectangle(sR_DRL[0], sR_DRL[1], sR_DRL[2], sR_DRL[3]);
            Rectangle upSourceRectangle = new Rectangle(sR_U[0], sR_U[1], sR_U[2], sR_U[3]);
            // invert the rightSourceRectangle vertically
            Rectangle leftSourceRectangle = new Rectangle(sR_DRL[0] + sR_DRL[2], sR_DRL[1], -sR_DRL[2], sR_DRL[3]);

            Rectangle downRightLeftDestinationRectangle = _enemyDownRightLeft.GetDestinationRectangle();
            Rectangle upDestinationRectangle = _enemyUp.GetDestinationRectangle();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            switch ((int)_direction)
            {
                case 0: // DOWN sprite drawing
                    spriteBatch.Draw(_spriteSheet, downRightLeftDestinationRectangle, downRightSourceRectangle, Color.White); break;
                case 1: // UP sprite drawing
                    spriteBatch.Draw(_spriteSheet, upDestinationRectangle, upSourceRectangle, Color.White); break;
                case 2: // RIGHT sprite drawing
                    spriteBatch.Draw(_spriteSheet, downRightLeftDestinationRectangle, downRightSourceRectangle, Color.White); break;
                case 3: // LEFT sprite drawing
                    spriteBatch.Draw(_spriteSheet, downRightLeftDestinationRectangle, leftSourceRectangle, Color.White); break;
                default: break;
            }
            spriteBatch.End();
        }
    }
}
