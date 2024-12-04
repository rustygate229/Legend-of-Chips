using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace _3902_Project
{
    public class PSprite_MagicStaff : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteDownUpPositions = new(147, 154, 4, 16);
        private Rectangle _spriteRightLeftPositions = new(154, 160, 16, 4);


        // create Renderer objects
        private RendererLists _rendererList;
        private bool _isCentered = true;

        // create timers, movement and speed variables
        private float _positionSpeed = 10f;
        private Vector2 _updatePosition;
        private int _counter = 0;
        private int _counterTotal;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_MagicStaff(Texture2D spriteSheet, Renderer.DIRECTION direction, float printScale, int timerTotal)
        {
            // create renders of the bomb projectile
            Renderer magicStaffDownUp = new(spriteSheet, _spriteDownUpPositions, printScale);
            Renderer magicStaffRightLeft = new(spriteSheet, _spriteRightLeftPositions, printScale);
            Renderer[] rendererList = { magicStaffDownUp, magicStaffRightLeft };
            _rendererList = new(rendererList, RendererLists.RendOrder.Size2DownUpFlip);
            _counterTotal = timerTotal;
            _rendererList.IsCentered = _isCentered;
            // set correct direciton
            _rendererList.Direction = direction;
            // only want it set once
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
        public void Update()
        {
            _counter++;
            if (_counter < (_counterTotal / 2))
                _rendererList.PositionOnWindow += _updatePosition;
            else
                _rendererList.PositionOnWindow -= _updatePosition;
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _rendererList.Draw(spriteBatch); }
    }
}