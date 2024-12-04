using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class LinkMoving : IColor
    {
        // variables for link in frame 1 of the moving link sprite animation
        private Rectangle _spriteLittleShieldDownPosition = new(0, 11, 32, 16);
        private Rectangle _spriteLittleShieldRightLeftPosition = new(34, 11, 32, 16);

        // Big Shield link
        private Rectangle _spriteBigShieldDownPosition = new(289, 11, 32, 16);
        private Rectangle _spriteBigShieldRightLeftPosition = new(323, 11, 32, 16);

        private Rectangle _spriteUpPosition = new(69, 11, 32, 16);


        private Vector2 _spriteRowAndColumn = new(1, 2);
        private int _frames = 12;
        private float _positionSpeed = 3f;
        private Vector2 _updatePosition;


        // create a Renderer object
        private Renderer _linkDown;
        private Renderer _linkUp;
        private Renderer _linkRightLeft;
        private bool _isCentered = true;
        private RendererLists _rendererList;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkMoving(Texture2D spriteSheet, bool shieldStatus, Renderer.DIRECTION facingDirection, float printScale, ProjectileManager manager)
        {
            // create current shield Link
            if (!shieldStatus)
            {
                _linkDown = new(spriteSheet, _spriteLittleShieldDownPosition, _spriteRowAndColumn, printScale, _frames);
                _linkRightLeft = new(spriteSheet, _spriteLittleShieldRightLeftPosition, _spriteRowAndColumn, printScale, _frames);
            }
            else
            {
                _linkDown = new(spriteSheet, _spriteBigShieldDownPosition, _spriteRowAndColumn, printScale, _frames);
                _linkRightLeft = new(spriteSheet, _spriteBigShieldRightLeftPosition, _spriteRowAndColumn, printScale, _frames);
            }
            _linkUp = new(spriteSheet, _spriteUpPosition, _spriteRowAndColumn, printScale, _frames);

            // create different facing block sprites for the renderer list
            Renderer[] rendererListSetArray = { _linkDown, _linkUp, _linkRightLeft };
            // create renderer list
            _rendererList = new RendererLists(rendererListSetArray, RendererLists.RendOrder.Size3RightLeft);
            _rendererList.IsCentered = _isCentered;
            // set correct direciton
            _rendererList.Direction = facingDirection;
            // set only once update position
            _updatePosition = _rendererList.GetUpdatePosition(_positionSpeed);
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
            _rendererList.PositionOnWindow = _rendererList.PositionOnWindow + _updatePosition;
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