using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class LinkStanding : ISprite
    {
        // create a Renderer object
        private RendererLists _rendererList;

        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkStanding(RendererLists rendereList) { _rendererList = rendereList; }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _rendererList.GetOneRectanglePosition(); }

        public Vector2 GetVectorPosition() { return _rendererList.GetVectorPosition(); }

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
        public void Draw(SpriteBatch spriteBatch) { _rendererList.CreateSpriteDraw(spriteBatch, true); }
    }
}