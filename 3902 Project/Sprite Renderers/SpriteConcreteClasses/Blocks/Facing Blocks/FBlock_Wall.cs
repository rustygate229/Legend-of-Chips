using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class FBlock_Wall : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer.DIRECTION _direction;

        // variables to change based on where your block is and what to print out
        private Vector2 _spriteDownUpPosition = new Vector2(815, 11);
        private Vector2 _spriteDownUpDimensions = new Vector2(32, 32);

        private Vector2 _spriteRightLeftPosition = new Vector2(815, 44);
        private Vector2 _spriteRightLeftDimensions = new Vector2(32, 32);

        private Vector2 _spritePrintDimensions = new Vector2(256, 256);

        // create a Renderer object
        private Renderer _blockDownUp;
        private Renderer _blockRightLeft;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public FBlock_Wall(Texture2D spriteSheet, Renderer.DIRECTION facingDirection)
        {
            _spriteSheet = spriteSheet;
            _direction = facingDirection;
            _blockDownUp = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spriteDownUpPosition, _spriteDownUpDimensions, _spritePrintDimensions);
            _blockRightLeft = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spriteRightLeftPosition, _spriteRightLeftDimensions, _spritePrintDimensions);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition()
        {
            if (_direction == Renderer.DIRECTION.DOWN || _direction == Renderer.DIRECTION.UP)
                return _blockDownUp.GetPosition();
            else return _blockRightLeft.GetPosition();
        }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            _position = position;
            if (_direction == Renderer.DIRECTION.DOWN || _direction == Renderer.DIRECTION.UP)
                _blockDownUp.SetPosition(position);
            else _blockRightLeft.SetPosition(position);
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

            if (_direction == Renderer.DIRECTION.DOWN)
            {
                sR = _blockDownUp.GetSourceRectangleArray();
                sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);

                if (_direction == Renderer.DIRECTION.UP)
                    sourceRectangle = new Rectangle(sR[0], sR[1] + sR[3], sR[2], -sR[3]);

                destinationRectangle = _blockDownUp.GetDestinationRectangle();
            }
            else
            {
                sR = _blockRightLeft.GetSourceRectangleArray();
                sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);

                if (_direction == Renderer.DIRECTION.LEFT)
                    sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1], -sR[2], sR[3]);

                destinationRectangle = _blockRightLeft.GetDestinationRectangle();
            }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}