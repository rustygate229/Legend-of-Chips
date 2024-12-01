using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Threading;
using static _3902_Project.Renderer;

namespace _3902_Project
{
    public class PSprite_FireBall : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private Rectangle _spriteFireBall = new (231, 62, 36, 10);
        private Vector2 _spriteRowsAndColumns = new (1, 4);

        // create Renderer objects
        private Renderer _fireBall;
        private bool _isCentered = true;

        // create timers, movement and speed variables
        private int _frameRate = 15;
        private Vector2 _updatePosition;
        private float _positionSpeed = 2f;


        /// <summary>
        /// constructor for the projectile sprite: <c>FireBall</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_FireBall(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create renders of the blue arrow projectile
            _fireBall = new (spriteSheet, _spriteFireBall, _spriteRowsAndColumns, printScale, _frameRate);
            _fireBall.IsCentered = _isCentered;
            // set correct direciton
            _fireBall.Direction = facingDirection;
            // only want it set once
            _updatePosition = _fireBall.GetUpdatePosition(_positionSpeed);
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _fireBall.DestinationRectangle; }
            set { _fireBall.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _fireBall.PositionOnWindow; }
            set { _fireBall.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            Vector2 newPosition = _fireBall.PositionOnWindow + _updatePosition;
            _fireBall.PositionOnWindow = newPosition;
        }


        /// <summary>
        /// Draws the sprite in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _fireBall.Draw(spriteBatch); }
    }
}