using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class SItem_Horn : ISprite
    {
        // variables to change based on where your item is and what to print out
        private Rectangle _spritePosition = new (176, 0, 8, 16);

        // create a Renderer object
        private Renderer _item;
        private bool _isCentered = true;


        /// <summary>
        /// construct the sprite, pass in spritesheet and print dimension scale
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="printScale"></param>
        public SItem_Horn(Texture2D spriteSheet, float printScale)
        {
            _item = new(spriteSheet, _spritePosition, printScale);
            _item.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _item.DestinationRectangle; }
            set { _item.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _item.PositionOnWindow; }
            set { _item.PositionOnWindow = value; }
        }


        /// <summary>
        /// update the sprite via Renderer method
        /// </summary>
        public void Update() { _item.UpdateFrames(); }


        /// <summary>
        /// draw the sprite via Renderer method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _item.Draw(spriteBatch); }
    }
}