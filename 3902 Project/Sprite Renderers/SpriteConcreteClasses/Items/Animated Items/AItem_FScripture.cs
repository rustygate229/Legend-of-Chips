using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class AItem_FScripture : ISprite
    {
        // variables for constructor assignments
        private Vector2 _position;

        // variables to change based on where your item is and what to print out
        private Vector2 _spritePosition = new Vector2(88, 0);
        private Vector2 _spriteDimensions = new Vector2(8, 32);
        private Vector2 _spriteRowAndColumn = new Vector2(2, 1);
        private Vector2 _spritePrintDimensions = new (8, 16);

        // create a Renderer object
        private Renderer _item;


        /// <summary>
        /// construct the sprite, pass in spritesheet, print dimension scale and amount of frames
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="printScale"></param>
        /// <param name="frames"></param>
        public AItem_FScripture(Texture2D spriteSheet, float printScale, int frames)
        {
            _item = new (Renderer.STATUS.Animated, spriteSheet, _spritePosition, _spriteDimensions, _spritePrintDimensions * printScale, _spriteRowAndColumn, frames);
        }

        /// <summary>
        /// Get position from sprites renderer position
        /// </summary>
        /// <returns>the position of the </returns>
        public Rectangle GetRectanglePosition() { return _item.GetRectanglePosition(); }

        /// <summary>
        /// Set position in the this method and in the sprites renderer
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position) { _position = position; _item.SetPosition(position); }

        /// <summary>
        /// update the sprite via Renderer method
        /// </summary>
        public void Update() { _item.UpdateFrames(); }


        /// <summary>
        /// draw the sprite via Renderer method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _item.DrawCentered(spriteBatch, _item.GetSourceRectangle()); }
    }
}