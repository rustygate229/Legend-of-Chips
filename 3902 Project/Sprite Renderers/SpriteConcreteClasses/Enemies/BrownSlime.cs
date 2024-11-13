using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class BrownSlime : ISprite
    {
        // variables for constructor assignments
        private Vector2 _position;
        private Vector2 _updatePosition;
        private int _direction;

        // variables to change based on where your block is and what to print out
        private Vector2 _spritePosition = new Vector2(79, 28);
        private Vector2 _spriteDimensions = new Vector2(30, 16);
        private Vector2 _spritePrintDimensions = new Vector2(64, 64);
        private Vector2 _rowAndColumns = new Vector2(1, 2);

        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 10;
        private float _positionSpeed = 2;
        private static Random random = new Random();

        // variables for shooting projectile
        private ISprite _projectileFireBall;
        private ProjectileManager _projectileManager;
        private ProjectileManager.ProjectileNames _fireBall = ProjectileManager.ProjectileNames.FireBall;
        private float _fireBallPrintScale = 3F;
        // variables specific to Darknuts implementation of the blue arrow sprite
        private int _fireBallCounter;
        private int _fireBallTotal = 100; // cool down value for firing projectiles
        private float _fireBallSpeed = 5F;
        private int _fireBallFrames = 12; // read summary in respective Projectile Concrete Classes for explanation

        // create enemy renderer
        private Renderer _enemy;


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.)
        /// </summary>
        /// <param name="spriteSheet"></param>
        public BrownSlime(Texture2D spriteSheet, ProjectileManager projectileManager, float printScale, float speed, int moveTimerTotal, int frames)
        {
            _projectileManager = projectileManager;
            _positionSpeed = speed;
            _moveTotal = moveTimerTotal;
            _enemy = new Renderer(Renderer.STATUS.Animated, spriteSheet, _spritePosition, _spriteDimensions, _spritePrintDimensions, _rowAndColumns, frames);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _enemy.GetRectanglePosition(); }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _position = position; _enemy.SetPosition(position); }


        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // update animation
            _enemy.UpdateFrames();
            _enemy.SetPosition(_position);

            // Change direction periodically (random horizontal or vertical movement)
            if (_moveCounter == 0) { _updatePosition = _enemy.GetRandomMovement(_positionSpeed); _direction = (int)_enemy.GetDirection(); }
            // increase movement counter
            _moveCounter++;
            // Reset the timer
            if (_moveCounter > _moveTotal) { _moveCounter = 0; }

            // update position
            _position += _updatePosition;

            // set a new projectile
            /*  if (_fireBallCounter == 10)
             // {
                  _updatePosition = new(0, 0);
                 _projectileFireBall = _projectileManager.CallProjectile(_fireBall, _position, _direction, _fireBallTotal, _fireBallSpeed, _fireBallPrintScale, _fireBallFrames);
              }
              // increase before assignment so that it runs again
              _fireBallCounter++;
              // reset projectile clock
              if (_fireBallCounter == _fireBallTotal) { _fireBallCounter = 0; _projectileManager.UnloadProjectile(_projectileFireBall); }
          }*/
        }


        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // create and draw sprites
            _enemy.DrawCentered(spriteBatch, _enemy.GetSourceRectangle());
        }
    }
}