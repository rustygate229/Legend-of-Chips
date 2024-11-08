using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class LinkMoving
    {
        // create a Renderer object
        private RendererLists _rendererList;

        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkMoving(RendererLists rendererList) { _rendererList = rendererList; }


        /// <summary>
        /// Passes to the Renderer GetRectanglePosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _rendererList.GetOneRectanglePosition(); }

        public Vector2 GetPosition() { return _rendererList.GetVectorPosition(); }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _rendererList.SetPositions(position); }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            float positionSpeed = 4f;
            Vector2 updatePosition = _rendererList.CreateGetUpdatePosition(positionSpeed);
            //Console.WriteLine("renderer direction: " + _rendererList.GetDirection().ToString());
            //Console.WriteLine("updatePosition: " +  updatePosition);
            Vector2 currentPosition = _rendererList.GetVectorPosition() + updatePosition;
            _rendererList.SetPositions(currentPosition);
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.CreateSpriteDraw(spriteBatch, false); }
    }
}