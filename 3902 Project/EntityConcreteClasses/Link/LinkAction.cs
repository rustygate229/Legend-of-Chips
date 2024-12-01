using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class LinkAction : IColor
    {
        // variables for link in frame 1 of the moving link sprite animation
        private Rectangle _spriteDownPosition = new(107, 11, 16, 16);
        private Rectangle _spriteUpPosition = new(141, 11, 16, 16);
        private Rectangle _spriteRightLeftPosition = new(123, 11, 16, 16);

        // create a Renderer object
        private RendererLists _rendererList;
        private bool _isCentered = true;

        private int _currentFrame;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkAction(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create different facing block sprites for the renderer list
            Renderer linkDown = new(spriteSheet, _spriteDownPosition, printScale);
            Renderer linkUp = new(spriteSheet, _spriteUpPosition, printScale);
            Renderer linkRightLeft = new(spriteSheet, _spriteRightLeftPosition, printScale);
            Renderer[] rendererListSetArray = { linkDown, linkUp, linkRightLeft };
            // create renderer list
            _rendererList = new RendererLists(rendererListSetArray, RendererLists.RendOrder.Size3RightLeft);
            _rendererList.IsCentered = _isCentered;
            // set correct direciton
            _rendererList.Direction = facingDirection;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _rendererList.DestinationRectangle; }
            set { _rendererList.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _rendererList.PositionOnWindow; }
            set { _rendererList.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.Draw(spriteBatch); }

        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch, Color tint) { _rendererList.Draw(spriteBatch, tint); }
    }
}