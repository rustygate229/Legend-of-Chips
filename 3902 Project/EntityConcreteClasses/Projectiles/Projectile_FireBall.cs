using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Threading;

namespace _3902_Project
{
    public class Projectile_FireBall : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private Vector2 _spritePosition = new (231, 62);
        private Vector2 _spriteDimensions = new (36, 10);
        private Vector2 _spriteRowsAndColumns = new (1, 4);
        private Vector2 _spritePrintDimensions = new(5, 5);

        // create timers, movement and speed variables
        private int _frameRate;
        private int _timerCounter;
        private int _timerTotal;
        private Vector2 _position;
        private Vector2 _updatePosition;
        private float _positionSpeed;
        private int _direction;

        // create Renderer objects
        private Renderer _fireBall;


        /// <summary>
        /// constructor for the projectile sprite: <c>FireBall</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="timer">the total time until the sprite is deloaded</param>
        /// <param name="speed">the speed of the projectiles movement on screen</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        /// <param name="frames">
        /// the amount of frames in the sprites animation, the greater the value, the slower the frame switching; and the inverse is true
        /// </param>
        public Projectile_FireBall(Texture2D spriteSheet, int facingDirection, int timer, float speed, float printScale, int frames)
        {
            _direction = facingDirection;
            _timerTotal = timer;
            _positionSpeed = speed;
            _frameRate = frames;
            // create renders of the blue arrow projectile
            _fireBall = new Renderer(Renderer.STATUS.Animated, spriteSheet, _spritePosition, _spriteDimensions, _spritePrintDimensions * printScale, _spriteRowsAndColumns, _frameRate);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _fireBall.GetRectanglePosition(); }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _position = position; _fireBall.SetPosition(position); }


        /// <summary>
        /// Updates the sprite (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // set positions at every update
            _fireBall.SetPosition(_position);

            // set the movement once
            if (_timerCounter == 0)
                _updatePosition = _fireBall.GetUpdatePosition(_direction, _positionSpeed);

            // update position and movement counter
            _position += _updatePosition;
            _timerCounter++;

            // update the animation frames
            _fireBall.UpdateFrames();
        }


        /// <summary>
        /// Draws the sprite in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _fireBall.DrawCentered(spriteBatch, _fireBall.GetSourceRectangle()); }
    }
}