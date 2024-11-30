using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class PSprite_BlueArrow : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private Rectangle _spriteUpDownArrow = new (29, 185, 5, 16);
        private Rectangle _spriteRightLeftArrow = new (36, 190, 16, 5);

        private RendererLists _rendererList;
        private bool _isCentered = true;

        // create speed variable
        private float _positionSpeed = 4f;

        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_BlueArrow(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create renders of the blue arrow projectile
            Renderer upDownArrow = new (spriteSheet, _spriteUpDownArrow, printScale);
            Renderer rightLeftArrow = new (spriteSheet, _spriteRightLeftArrow, printScale);
            Renderer[] _rendererListArray = { upDownArrow, rightLeftArrow };
            _rendererList = new RendererLists(_rendererListArray, RendererLists.RendOrder.Size2DownUpFlip);
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
        public void Update()
        {
            Vector2 updatePosition = _rendererList.GetUpdatePosition(_positionSpeed);
            _rendererList.PositionOnWindow = _rendererList.PositionOnWindow + updatePosition;
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.Draw(spriteBatch); }
    }
}