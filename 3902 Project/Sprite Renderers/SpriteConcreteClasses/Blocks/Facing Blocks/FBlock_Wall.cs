using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class FBlock_Wall : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer.DIRECTION _direction;

        // variables to change based on where your block is and what to print out
        private Vector2 _spriteDownPosition = new Vector2(815, 11);
        private Vector2 _spriteDownDimensions = new Vector2(32, 32);

        private Vector2 _spriteUpPosition = new Vector2(815, 110);
        private Vector2 _spriteUpDimensions = new Vector2(32, 32);

        private Vector2 _spriteRightPosition = new Vector2(815, 44);
        private Vector2 _spriteRightDimensions = new Vector2(32, 32);

        private Vector2 _spriteLeftPosition = new Vector2(815, 77);
        private Vector2 _spriteLeftDimensions = new Vector2(32, 32);

        // create a Renderer object
        private Renderer _blockDown;
        private Renderer _blockUp;
        private Renderer _blockRight;
        private Renderer _blockLeft;
        private RendererLists _rendererList;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public FBlock_Wall(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            _spriteSheet = spriteSheet;
            _direction = facingDirection;
            _blockDown = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spriteDownPosition, _spriteDownDimensions, _spriteDownDimensions * printScale);
            _blockUp = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spriteUpPosition, _spriteUpDimensions, _spriteUpDimensions * printScale);
            _blockRight = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spriteRightPosition, _spriteRightDimensions, _spriteRightDimensions * printScale);
            _blockLeft = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spriteLeftPosition, _spriteLeftDimensions, _spriteLeftDimensions * printScale);
            Renderer[] rendererList = { _blockDown, _blockUp, _blockRight, _blockLeft };
            _rendererList = new RendererLists(rendererList, RendererLists.RendOrder.Size4);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition() { return _rendererList.GetOnePosition(); }


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