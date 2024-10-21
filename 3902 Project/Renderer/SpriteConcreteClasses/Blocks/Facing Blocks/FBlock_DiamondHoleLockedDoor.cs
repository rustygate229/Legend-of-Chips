using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class FBlock_DiamondHoleLockedDoor : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer.DIRECTION _direction;

        // variables to change based on where your block is and what to print out
        private Vector2 _spriteDownPosition = new Vector2(914, 11);
        private Vector2 _spriteDownDimensions = new Vector2(32, 32);

        private Vector2 _spriteUpPosition = new Vector2(914, 110);
        private Vector2 _spriteUpDimensions = new Vector2(32, 32);

        private Vector2 _spriteRightPosition = new Vector2(914, 44);
        private Vector2 _spriteRightDimensions = new Vector2(32, 32);

        private Vector2 _spriteLeftPosition = new Vector2(914, 77);
        private Vector2 _spriteLeftDimensions = new Vector2(32, 32);

        private Vector2 _spritePrintDimensions = new Vector2(128, 128);

        // create a Renderer object
        private Renderer _blockDown;
        private Renderer _blockUp;
        private Renderer _blockRight;
        private Renderer _blockLeft;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public FBlock_DiamondHoleLockedDoor(Texture2D spriteSheet, Renderer.DIRECTION facingDirection)
        {
            _spriteSheet = spriteSheet;
            _direction = facingDirection;
            _blockDown = new Renderer(Renderer.STATUS.Still, _spriteSheet, _position, _spriteDownPosition, _spriteDownDimensions, _spritePrintDimensions);
            _blockUp = new Renderer(Renderer.STATUS.Still, _spriteSheet, _position, _spriteUpPosition, _spriteUpDimensions, _spritePrintDimensions);
            _blockRight = new Renderer(Renderer.STATUS.Still, _spriteSheet, _position, _spriteRightPosition, _spriteRightDimensions, _spritePrintDimensions);
            _blockLeft = new Renderer(Renderer.STATUS.Still, _spriteSheet, _position, _spriteLeftPosition, _spriteLeftDimensions, _spritePrintDimensions);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition()
        {
            switch((int)_direction)
            {
                case 0:
                    return _blockDown.GetPosition();
                case 1:
                    return _blockUp.GetPosition();
                case 2:
                    return _blockRight.GetPosition();
                case 3:
                    return _blockLeft.GetPosition();
                default: return _blockDown.GetPosition();
            }
        }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            switch ((int)_direction)
            {
                case 0:
                    _blockDown.SetPosition(position); _position = position; break;
                case 1:
                    _blockUp.SetPosition(position); _position = position; break;
                case 2:
                    _blockRight.SetPosition(position); _position = position; break;
                case 3:
                    _blockLeft.SetPosition(position); _position = position; break; 
                default: break;
            }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            int[] sR;
            Rectangle destinationRectangle;
            Rectangle sourceRectangle;

            switch((int)_direction)
            {
                case 0:
                    sR = _blockDown.GetSourceRectangle();
                    destinationRectangle = _blockDown.GetDestinationRectangle();
                    sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
                    break;
                case 1:
                    sR = _blockUp.GetSourceRectangle();
                    destinationRectangle = _blockUp.GetDestinationRectangle();
                    sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
                    break;
                case 2:
                    sR = _blockRight.GetSourceRectangle();
                    destinationRectangle = _blockRight.GetDestinationRectangle();
                    sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
                    break;
                case 3:
                    sR = _blockLeft.GetSourceRectangle();
                    destinationRectangle = _blockLeft.GetDestinationRectangle();
                    sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
                    break;
                default: 
                    destinationRectangle = _blockDown.GetDestinationRectangle();
                    sourceRectangle = new Rectangle(0, 0, 0, 0);
                    break;
            }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}