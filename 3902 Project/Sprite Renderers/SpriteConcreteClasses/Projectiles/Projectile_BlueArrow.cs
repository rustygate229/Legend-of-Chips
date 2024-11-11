using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class Projectile_BlueArrow : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private Vector2 _spritePosition_UpDownArrow = new (29, 185);
        private Vector2 _spriteDimensions_UpDownArrow = new (5, 16);

        private Vector2 _spritePosition_RightLeftArrow = new (36, 190);
        private Vector2 _spriteDimensions_RightLeftArrow = new (16, 5);

        private Vector2 _spritePosition_ExplodeArrow = new (53, 189);
        private Vector2 _spriteDimensions_ExplodeArrow = new (8, 8);

        private float[] _frameRanges;
        private RendererLists _rendererList;
        private int[] _directionArray = { 1, 0, 2, 3, 5, 4, 6, 7 };

        // create timers, movement and speed variables
        private int _timerCounter;
        private int _timerTotal;
        private Vector2 _position;
        private Vector2 _updatePosition;
        private float _positionSpeed;
        private int _direction;

        // create Renderer objects
        private Renderer _upDownArrow;
        private Renderer _rightLeftArrow;
        private Renderer _explodeArrow;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="timer">the total time until the sprite is deloaded</param>
        /// <param name="speed">the speed of the projectiles movement on screen</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        /// <param name="frameRanges">
        /// range: [0 -> 1], amountOfInputs = amountOfSprites - 1 AND MUST BE IN ORDER - values inputed are multiplied by timer to produce the
        /// framerates for the sprites being called.
        /// <example>EXAMPLE: if entered [0.5, 0.7] for a 3 sprite projectile: from 0 -> 0.5 (first sprite) to 0.5 -> 0.7 (second sprite) 
        /// to 0.7 -> 1 (third sprite). </example>
        /// </param>
        public Projectile_BlueArrow(Texture2D spriteSheet, int facingDirection, int timer, float speed, float printScale, float[] frameRanges)
        {
            _direction = facingDirection;
            _positionSpeed = speed;
            _timerTotal = timer;
            _frameRanges = frameRanges;
            // create renders of the blue arrow projectile
            _upDownArrow = new Renderer(Renderer.STATUS.Still, spriteSheet, _spritePosition_UpDownArrow, _spriteDimensions_UpDownArrow, _spriteDimensions_UpDownArrow * printScale);
            _rightLeftArrow = new Renderer(Renderer.STATUS.Still, spriteSheet, _spritePosition_RightLeftArrow, _spriteDimensions_RightLeftArrow, _spriteDimensions_RightLeftArrow * printScale);
            Renderer[] _rendererListArray = { _upDownArrow, _rightLeftArrow };
            _rendererList = new RendererLists(_rendererListArray, RendererLists.RendOrder.Size2, _directionArray);
            _explodeArrow = new Renderer(Renderer.STATUS.Still, spriteSheet, _spritePosition_ExplodeArrow, _spriteDimensions_ExplodeArrow, _spriteDimensions_ExplodeArrow * (printScale * 0.75F));
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition()
        {
            if (_timerCounter >= (_timerTotal * _frameRanges[0]))
                return _explodeArrow.GetRectanglePosition();
            else return _rendererList.GetOneRectanglePosition();
        }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            _position = position;
            _rendererList.SetPositions(position);
            _explodeArrow.SetPosition(position);
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // set positions at every update
            _rendererList.SetPositions(_position);
            _explodeArrow.SetPosition(_position);

            // if in exploding arrow frame, pause the movement for explosion sprite
            if (_timerCounter >= (_timerTotal * _frameRanges[0]))
                _updatePosition = new Vector2(0, 0);
            else
                // else update the arrow movement
                _updatePosition = _rendererList.CreateMovement(_direction, _positionSpeed);

            // update position and movement counter
            _position += _updatePosition;
            _timerCounter++;
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // if in explosion frame
            if (_timerCounter >= (_timerTotal * _frameRanges[0]))
                _explodeArrow.DrawCentered(spriteBatch, _explodeArrow.GetSourceRectangle());
            // else in normal frame
            else
                _rendererList.CreateSpriteDraw(spriteBatch, true);
        }
    }
}