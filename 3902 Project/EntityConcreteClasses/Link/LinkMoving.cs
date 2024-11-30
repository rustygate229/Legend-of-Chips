using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class LinkMoving : IFlashing
    {
        // variables for link in frame 1 of the moving link sprite animation
        private Rectangle _spriteDownPosition = new(0, 11, 32, 16);
        private Rectangle _spriteUpPosition = new(69, 11, 32, 16);
        private Rectangle _spriteRightLeftPosition = new(34, 11, 32, 16);

        private Vector2 _spriteRowAndColumn = new(1, 2);
        private int _framerate = 12;
        private float _positionSpeed = 2f;


        // create a Renderer object
        private RendererLists _rendererList;
        private bool _isCentered = true;

        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkMoving(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale, ProjectileManager manager)
        {
            // create different facing block sprites for the renderer list
            Renderer linkDown = new(spriteSheet, _spriteDownPosition, _spriteRowAndColumn, printScale, _framerate);
            Renderer linkUp = new(spriteSheet, _spriteUpPosition, _spriteRowAndColumn, printScale, _framerate);
            Renderer linkRightLeft = new(spriteSheet, _spriteRightLeftPosition, _spriteRowAndColumn, printScale, _framerate);
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
        public void Update() {
            Vector2 updatePosition = _rendererList.GetUpdatePosition(_positionSpeed);
            _rendererList.PositionOnWindow = _rendererList.PositionOnWindow + updatePosition;
            _rendererList.UpdateFrames(); 
        }


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