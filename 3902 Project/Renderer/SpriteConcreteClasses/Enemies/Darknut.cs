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
        private Renderer _enemyTop;
        private Renderer _enemyBottom;
        private Renderer _enemyLeftRight;

        // variables to change based on where your block is and what to print out
        private Vector2 _spriteTopPosition = new Vector2(1, 90);
        private Vector2 _spriteTopDimensions = new Vector2(34, 16);
        private Vector2 _spriteTopRowAndColumns = new Vector2(1, 2);

        private Vector2 _spriteBottomPosition = new Vector2(36, 90);
        private Vector2 _spriteBottomDimensions = new Vector2(15, 16);
        private Vector2 _spriteBottomRowAndColumns = new Vector2(1, 1);

        private Vector2 _spriteLeftRightPosition = new Vector2(52, 90);
        private Vector2 _spriteLeftRightDimensions = new Vector2(33, 16);
        private Vector2 _spriteLeftRightRowAndColumns = new Vector2(1, 2);

        private Vector2 _spritePrintDimensions = new Vector2(64, 64);

        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 40;
        private int _positionSpeed = 2;
        private Vector2 _updatePosition;
        private static Random random = new Random();


        // constructor for enemy
        public Darknut(Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _enemyTop = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _position, _spriteTopPosition, _spriteTopDimensions, _spritePrintDimensions, _spriteTopRowAndColumns, 10);
            _enemyBottom = new Renderer(Renderer.STATUS.SingleAnimated, _spriteSheet, _position, _spriteBottomPosition, _spriteBottomDimensions, _spritePrintDimensions, _spriteBottomRowAndColumns, 10);
            _enemyLeftRight = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _position, _spriteLeftRightPosition, _spriteLeftRightDimensions, _spritePrintDimensions, _spriteLeftRightRowAndColumns, 10);
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
            _enemyTop.SetPosition(position);
            _enemyBottom.SetPosition(position);
            _enemyLeftRight.SetPosition(position);
        }


        // update the movement for enemy
        public void Update()
        {
            // update position and movement counter
            _position += _updatePosition;
            _enemyTop.SetPosition(_position);
            _enemyBottom.SetPosition(_position);
            _enemyLeftRight.SetPosition(_position);
            _moveCounter++;

            // Change direction periodically (random horizontal or vertical movement)
            if (_moveCounter >= _moveTotal)
            {
                // Randomly choose a direction: 0 = left, 1 = right, 2 = up, 3 = down
                switch (random.Next(4))
                {
                    case 0: // Move left
                        _updatePosition = new Vector2(-(Math.Abs(_positionSpeed)), 0);
                        _direction = Renderer.DIRECTION.LEFT;
                        break;
                    case 1: // Move right
                        _updatePosition = new Vector2(Math.Abs(_positionSpeed), 0);
                        _direction = Renderer.DIRECTION.RIGHT;
                        break;
                    case 2: // Move up
                        _updatePosition = new Vector2(0, -(Math.Abs(_positionSpeed)));
                        _direction = Renderer.DIRECTION.DOWN;
                        break;
                    case 3: // Move down
                        _updatePosition = new Vector2(0, Math.Abs(_positionSpeed));
                        _direction = Renderer.DIRECTION.UP;
                        break;
                }
                _moveCounter = 0; // Reset the timer
            }
            // needed to constantly update the frames
            switch((int)_direction)
            {
                case 0: // Top/UP sprite drawing
                    _enemyTop.UpdateFrames(); break;
                case 1: // Bottom/DOWN sprite drawing
                    _enemyBottom.UpdateFrames(); break;
                case 2: // Left/LEFT sprite drawing
                    _enemyLeftRight.UpdateFrames(); break;
                case 3: // Right/RIGHT sprite drawing
                    _enemyLeftRight.UpdateFrames(); ; break;
                default: break;
            }
        }
    


        // draw the enemy
        public void Draw(SpriteBatch spriteBatch)
        {
            int[] sR_T = _enemyTop.GetSourceRectangle();
            int[] sR_B = _enemyBottom.GetSourceRectangle();
            int[] sR_LR = _enemyLeftRight.GetSourceRectangle();

            Rectangle topSourceRectangle = new Rectangle(sR_T[0], sR_T[1], sR_T[2], sR_T[3]);
            Rectangle bottomSourceRectangle = new Rectangle(sR_B[0], sR_B[1], sR_B[2], sR_B[3]);
            Rectangle leftSourceRectangle = new Rectangle(sR_LR[0] + sR_LR[2], sR_LR[1], -sR_LR[2], sR_LR[3]);
            Rectangle rightSourceRectangle = new Rectangle(sR_LR[0], sR_LR[1], sR_LR[2], sR_LR[3]);

            Rectangle topDestinationRectangle = _enemyTop.GetDestinationRectangle();
            Rectangle bottomDestinationRectangle = _enemyBottom.GetDestinationRectangle();
            Rectangle leftRightDestinationRectangle = _enemyLeftRight.GetDestinationRectangle();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            switch ((int)_direction)
            {
                case 0: // Top/UP sprite drawing
                    spriteBatch.Draw(_spriteSheet, topDestinationRectangle, topSourceRectangle, Color.White); break;
                case 1: // Bottom/DOWN sprite drawing
                    spriteBatch.Draw(_spriteSheet, bottomDestinationRectangle, bottomSourceRectangle, Color.White); break;
                case 2: // Left/LEFT sprite drawing
                    spriteBatch.Draw(_spriteSheet, leftRightDestinationRectangle, leftSourceRectangle, Color.White); break;
                case 3: // Right/RIGHT sprite drawing
                    spriteBatch.Draw(_spriteSheet, leftRightDestinationRectangle, rightSourceRectangle, Color.White); break;
                default: break;
            }

            spriteBatch.End();
        }
    }
}
