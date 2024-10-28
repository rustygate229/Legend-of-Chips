using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class SItem_BossKey : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;

        // variables to change based on where your item is and what to print out
        private Vector2 _spritePosition = new Vector2(248, 0);
        private Vector2 _spriteDimensions = new Vector2(8, 16);

        // create a Renderer object
        private Renderer _item;


        /// <summary>
        /// construct the sprite, pass in spritesheet and print dimension scale
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="printScale"></param>
        /// <param name="frames"></param>
        public SItem_BossKey(Texture2D spriteSheet, float printScale)
        {
            _spriteSheet = spriteSheet;
            _item = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _spritePosition, _spriteDimensions, _spriteDimensions * printScale);
        }

        /// <summary>
        /// Get position from sprites renderer position
        /// </summary>
        /// <returns>the position of the </returns>
        public Vector2 GetPosition() { return _item.GetPosition(); }

        /// <summary>
        /// Set position in the this method and in the sprites renderer
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position) { _position = position; _item.SetPosition(position); }

        /// <summary>
        /// update the sprite via Renderer method(s)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// draw the sprite via Renderer method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _item.DrawCentered(spriteBatch, _item.GetSourceRectangle()); }
    }
}