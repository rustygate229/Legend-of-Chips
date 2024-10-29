using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class FBlock_BombedDoor : ISprite
    {
        // variables to change based on where your block is and what to print out
        private Vector2 _spriteDownPosition = new Vector2(914, 11);
        private Vector2 _spriteDownDimensions = new Vector2(32, 32);

        private Vector2 _spriteUpPosition = new Vector2(914, 110);
        private Vector2 _spriteUpDimensions = new Vector2(32, 32);

        private Vector2 _spriteRightPosition = new Vector2(914, 44);
        private Vector2 _spriteRightDimensions = new Vector2(32, 32);

        private Vector2 _spriteLeftPosition = new Vector2(914, 77);
        private Vector2 _spriteLeftDimensions = new Vector2(32, 32);

        // create a Renderer object
        private RendererLists _rendererList;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public FBlock_BombedDoor(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create different facing block sprites for the renderer list
            Renderer blockDown = new(Renderer.STATUS.Still, spriteSheet, _spriteDownPosition, _spriteDownDimensions, _spriteDownDimensions * printScale);
            Renderer blockUp = new(Renderer.STATUS.Still, spriteSheet, _spriteUpPosition, _spriteUpDimensions, _spriteUpDimensions * printScale);
            Renderer blockRight = new(Renderer.STATUS.Still, spriteSheet, _spriteRightPosition, _spriteRightDimensions, _spriteRightDimensions * printScale);
            Renderer blockLeft = new(Renderer.STATUS.Still, spriteSheet, _spriteLeftPosition, _spriteLeftDimensions, _spriteLeftDimensions * printScale);
            Renderer[] rendererListSetArray = { blockDown, blockUp, blockRight, blockLeft };
            // create renderer list
            _rendererList = new RendererLists(rendererListSetArray, RendererLists.RendOrder.Size4);
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