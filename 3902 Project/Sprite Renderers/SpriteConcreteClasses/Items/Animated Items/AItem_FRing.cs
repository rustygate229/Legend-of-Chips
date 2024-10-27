using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class AItem_FRing : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;

        // variables to change based on where your item is and what to print out
        private Vector2 _spritePosition = new Vector2(168, 0);
        private Vector2 _spriteDimensions = new Vector2(8, 32);
        private Vector2 _spritePrintDimensions = new Vector2(16, 32);
        private Vector2 _spriteRowAndColumn = new Vector2(2, 1);

        // create a Renderer object
        private Renderer _item;


        // constructor for item
        public AItem_FRing(Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _item = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _spritePosition, _spriteDimensions, _spritePrintDimensions, _spriteRowAndColumn, 30);
        }

        /// Get position from sprites renderer position
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            return _item.GetPosition();
        }

        /// <summary>
        /// Set position in the sprites renderer
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position)
        {
            _position = position;
            _item.SetPosition(position);
        }

        // update the movement for item
        public void Update()
        {
            _item.UpdateFrames();
        }


        // draw the item
        public void Draw(SpriteBatch spriteBatch)
        {
            _item.DrawCentered(spriteBatch, _item.GetSourceRectangle());
        }
    }
}