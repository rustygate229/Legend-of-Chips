using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace _3902_Project
{
    public class Darknut : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer.DIRECTION _direction;

        // create multiple sprites
        private Renderer _enemyDown;
        private Renderer _enemyUp;
        private Renderer _enemyRightLeft;

        // variables to change based on where your block is and what to print out
        private Vector2 _spriteDownPosition = new Vector2(1, 90);
        private Vector2 _spriteDownDimensions = new Vector2(34, 16);
        private Vector2 _spriteDownRowAndColumns = new Vector2(1, 2);

        private Vector2 _spriteUpPosition = new Vector2(36, 90);
        private Vector2 _spriteUpDimensions = new Vector2(15, 16);
        private Vector2 _spriteUpRowAndColumns = new Vector2(1, 1);

        private Vector2 _spriteRightLeftPosition = new Vector2(52, 90);
        private Vector2 _spriteRightLeftDimensions = new Vector2(33, 16);
        private Vector2 _spriteRightLeftRowAndColumns = new Vector2(1, 2);

        private Vector2 _spritePrintDimensions = new Vector2(64, 64);

        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 40;
        private int _positionSpeed = 2;
        private Vector2 _updatePosition;
        private static Random random = new Random();


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.); takes the Enemy Spritesheet
        /// </summary>
        /// <param name="spriteSheet"></param>
        public Darknut(Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _enemyDown = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _position, _spriteDownPosition, _spriteDownDimensions, _spritePrintDimensions, _spriteDownRowAndColumns, 10);
            _enemyUp = new Renderer(Renderer.STATUS.SingleAnimated, _spriteSheet, _position, _spriteUpPosition, _spriteUpDimensions, _spritePrintDimensions, _spriteUpRowAndColumns, 10);
            _enemyRightLeft = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _position, _spriteRightLeftPosition, _spriteRightLeftDimensions, _spritePrintDimensions, _spriteRightLeftRowAndColumns, 10);
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
            _enemyDown.SetPosition(position);
            _enemyUp.SetPosition(position);
            _enemyRightLeft.SetPosition(position);
        }


        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // update position and movement counter
            _position += _updatePosition;
            _enemyDown.SetPosition(_position);
            _enemyUp.SetPosition(_position);
            _enemyRightLeft.SetPosition(_position);
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
            // needed to constantly update the frames
            switch((int)_direction)
            {
                case 0: // DOWN sprite drawing
                    _enemyDown.UpdateFrames(); break;
                case 1: // UP sprite drawing
                    _enemyUp.UpdateFrames(); break;
                case 2: // RIGHT sprite drawing
                    _enemyRightLeft.UpdateFrames(); break;
                case 3: // LEFT sprite drawing
                    _enemyRightLeft.UpdateFrames(); ; break;
                default: break;
            }
        }


        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // create source rectangles
            int[] sR_D = _enemyDown.GetSourceRectangle();
            int[] sR_U = _enemyUp.GetSourceRectangle();
            int[] sR_RL = _enemyRightLeft.GetSourceRectangle();

            Rectangle downSourceRectangle = new Rectangle(sR_D[0], sR_D[1], sR_D[2], sR_D[3]);
            Rectangle upSourceRectangle = new Rectangle(sR_U[0], sR_U[1], sR_U[2], sR_U[3]);
            Rectangle rightSourceRectangle = new Rectangle(sR_RL[0], sR_RL[1], sR_RL[2], sR_RL[3]);
            // invert the rightSourceRectangle vertically
            Rectangle leftSourceRectangle = new Rectangle(sR_RL[0] + sR_RL[2], sR_RL[1], -sR_RL[2], sR_RL[3]);

            Rectangle DownDestinationRectangle = _enemyDown.GetDestinationRectangle();
            Rectangle UpDestinationRectangle = _enemyUp.GetDestinationRectangle();
            Rectangle rightLeftDestinationRectangle = _enemyRightLeft.GetDestinationRectangle();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            switch ((int)_direction)
            {
                case 0: // DOWN sprite drawing
                    spriteBatch.Draw(_spriteSheet, DownDestinationRectangle, downSourceRectangle, Color.White); break;
                case 1: // UP sprite drawing
                    spriteBatch.Draw(_spriteSheet, UpDestinationRectangle, upSourceRectangle, Color.White); break;
                case 2: // RIGHT sprite drawing
                    spriteBatch.Draw(_spriteSheet, rightLeftDestinationRectangle, rightSourceRectangle, Color.White); break;
                case 3: // LEFT sprite drawing
                    spriteBatch.Draw(_spriteSheet, rightLeftDestinationRectangle, leftSourceRectangle, Color.White); break;
                default: break;
            }

            spriteBatch.End();
        }
    }
}
