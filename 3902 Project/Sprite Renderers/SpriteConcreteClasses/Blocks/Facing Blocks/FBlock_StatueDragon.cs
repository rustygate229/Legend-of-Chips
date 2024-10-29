using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class FBlock_StatueDragon : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer.DIRECTION _direction;

        // variables to change based on where your block is and what to print out
        private Vector2 _spritePosition = new Vector2(1035, 11);
        private Vector2 _spriteDimensions = new Vector2(16, 16);

        // create a Renderer object
        private Renderer _block;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public FBlock_StatueDragon(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            _spriteSheet = spriteSheet;
            _direction = facingDirection;
            _block = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spritePosition, _spriteDimensions, _spriteDimensions * printScale);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _block.GetRectanglePosition(); }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _position = position; _block.SetPosition(position); }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_direction == Renderer.DIRECTION.RIGHT)
                _block.Draw(spriteBatch, _block.GetSourceRectangle(), _block.GetDestinationRectangle());
            else if (_direction == Renderer.DIRECTION.LEFT)
                _block.DrawHorizontallyFlipped(spriteBatch, false);
        }
    }
}