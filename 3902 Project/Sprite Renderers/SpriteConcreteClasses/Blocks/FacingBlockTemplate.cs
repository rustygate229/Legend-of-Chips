using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class FacingBlockTemplate : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer.DIRECTION _direction;

        // variables to change based on where your block is and what to print out
        private Vector2 _spritePosition = new Vector2(0, 0);
        private Vector2 _spriteDimensions = new Vector2(32, 32);
        private Vector2 _spritePrintDimensions = new Vector2(128, 128);

        // create a Renderer object
        private Renderer _block;


        /// <summary>
        /// constructor for a template of a block with direction
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="facingDirection"></param>
        public FacingBlockTemplate(Texture2D spriteSheet, Renderer.DIRECTION facingDirection)
        {
            _spriteSheet = spriteSheet;
            _direction = facingDirection;
            _block = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spritePosition, _spriteDimensions, _spritePrintDimensions);
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
            _block.DrawCentered(spriteBatch, _block.GetSourceRectangle());
        }
    }
}