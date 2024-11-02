using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class LinkStill : ISprite
    {
        // variables to change based on where your block is and what to print out
        private Vector2 _spriteDownPosition = new Vector2(914, 11);
        private Vector2 _spriteDownDimensions = new Vector2(32, 32);

        private Vector2 _spriteUpPosition = new Vector2(914, 110);
        private Vector2 _spriteUpDimensions = new Vector2(32, 32);

        private Vector2 _spriteRightLeftPosition = new Vector2(914, 44);
        private Vector2 _spriteRightLeftDimensions = new Vector2(32, 32);

        // create a Renderer object
        private RendererLists _rendererList;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkStill(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create different facing block sprites for the renderer list
            Renderer linkDown = new(Renderer.STATUS.Still, spriteSheet, _spriteDownPosition, _spriteDownDimensions, _spriteDownDimensions * printScale);
            Renderer linkUp = new(Renderer.STATUS.Still, spriteSheet, _spriteUpPosition, _spriteUpDimensions, _spriteUpDimensions * printScale);
            Renderer linkRightLeft = new(Renderer.STATUS.Still, spriteSheet, _spriteRightLeftPosition, _spriteRightLeftDimensions, _spriteRightLeftDimensions * printScale);
            Renderer[] rendererListSetArray = { linkDown, linkUp, linkRightLeft };
            // create renderer list
            _rendererList = new RendererLists(rendererListSetArray, RendererLists.RendOrder.Size3RightLeft);
            // set correct direciton
            _rendererList.SetDirection((int)facingDirection);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _rendererList.GetOneRectanglePosition(); }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _rendererList.SetPositions(position); }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.CreateSpriteDraw(spriteBatch, false); }
    }
}