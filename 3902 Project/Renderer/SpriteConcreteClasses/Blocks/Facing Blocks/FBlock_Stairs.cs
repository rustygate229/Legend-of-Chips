using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class FBlock_Stairs : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer.DIRECTION _direction;

        // variables to change based on where your block is and what to print out
        private Vector2 _spritePosition = new Vector2(1035, 28);
        private Vector2 _spriteDimensions = new Vector2(16, 16);
        private Vector2 _spritePrintDimensions = new Vector2(64, 64);

        // create a Renderer object
        private Renderer _block;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public FBlock_Stairs(Texture2D spriteSheet, Renderer.DIRECTION facingDirection)
        {
            _spriteSheet = spriteSheet;
            _direction = facingDirection;
            _block = new Renderer(Renderer.STATUS.Still, _spriteSheet, _position, _spritePosition, _spriteDimensions, _spritePrintDimensions);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition()
        {
            return _block.GetPosition();
        }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            _position = position;
            _block.SetPosition(position);
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
            // create source rectangle
            int[] sR = _block.GetSourceRectangle();

            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
            Rectangle destinationRectangle = _block.GetDestinationRectangle();

            // since a stair only has two directions (right and left)
            if ((int)_direction == 2) // if facing Right, flip vertically
                sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1], -sR[2], sR[3]);
            
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}