using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace _3902_Project
{
    public class PSprite_WoodSword : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteDownUpPositions = new(1, 154, 7, 16);
        private Rectangle _spriteRightLeftPositions = new(10, 159, 16, 7);


        // create Renderer objects
        private RendererLists _rendererList;
        private bool _isCentered = true;

        // create timers, movement and speed variables
        private float _positionSpeed = 10f;
        private int _counter = 0;
        private int _counterTotal;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_WoodSword(Texture2D spriteSheet, Renderer.DIRECTION direction, float printScale, int timerTotal)
        {
            // create renders of the bomb projectile
            Renderer woodSwordDownUp = new(spriteSheet, _spriteDownUpPositions, printScale);
            Renderer woodSwordRightLeft = new(spriteSheet, _spriteRightLeftPositions, printScale);
            Renderer[] rendererList = { woodSwordDownUp, woodSwordRightLeft };
            _rendererList = new(rendererList, RendererLists.RendOrder.Size2DownUpFlip);
            _counterTotal = timerTotal;
            _rendererList.IsCentered = _isCentered;
            // set correct direciton
            _rendererList.Direction = direction;
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

            // set positions at every update
            _rendererList.SetPositions(_position);

            // update position and movement counter
            _counter++;
            if (_counter < (_counterTotal / 2))
                _position += _updatePosition;
            else
                _position -= _updatePosition;
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _rendererList.Draw(spriteBatch); }
    }
}