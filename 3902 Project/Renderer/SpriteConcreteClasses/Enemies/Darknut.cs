using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Xml;

namespace _3902_Project
{
    public class Darknut : ISprite
    {
        // variables for constructor assignments
        private Texture2D _enemySpritesheet;
        private Texture2D _linkSpritesheet;
        private Vector2 _position;
        private Vector2 _updatePosition;
        private Renderer.DIRECTION _direction;

        // create multiple sprites
        private Renderer _enemyDown;
        private Renderer _enemyUp;
        private Renderer _enemyRightLeft;

        // variables to change based on where your block is and what to print out
        private Vector2 _spriteDownPosition = new Vector2(1, 90);
        private Vector2 _spriteDownDimensions = new Vector2(32, 16);
        private Vector2 _spriteDownRowAndColumns = new Vector2(1, 2);

        private Vector2 _spriteUpPosition = new Vector2(36, 90);
        private Vector2 _spriteUpDimensions = new Vector2(16, 16);
        private Vector2 _spriteUpRowAndColumns = new Vector2(1, 1);

        private Vector2 _spriteRightLeftPosition = new Vector2(52, 90);
        private Vector2 _spriteRightLeftDimensions = new Vector2(32, 16);
        private Vector2 _spriteRightLeftRowAndColumns = new Vector2(1, 2);

        private Vector2 _spritePrintDimensions = new Vector2(16, 16);

        private float _printScale = 4F;
        private int _frameRate = 10;

        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 40;
        private int _positionSpeed = 2;
        private static Random _random = new Random();

        // variables for shooting projectile
        private ISprite _projectile;
        private ProjectileManager _projectileManager;
        private ProjectileManager.ProjectileNames _blueArrow = ProjectileManager.ProjectileNames.BlueArrow;
        private int _projectileCounter = 0;
        private int _projectileTotal = 200; // cool down value for firing projectiles
        private float _projectileScale = 3.5F;


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.); takes the Enemy Spritesheet
        /// </summary>
        /// <param name="spriteSheet"></param>
        public Darknut(Texture2D spriteSheet, ProjectileManager manager)
        {
            _enemySpritesheet = spriteSheet;
            _projectileManager = manager;
            _enemyDown = new Renderer(Renderer.STATUS.Animated, _enemySpritesheet, _spriteDownPosition, _spriteDownDimensions, _spritePrintDimensions * _printScale, _spriteDownRowAndColumns, _frameRate);
            _enemyUp = new Renderer(Renderer.STATUS.SingleAnimated, _enemySpritesheet, _spriteUpPosition, _spriteUpDimensions, _spritePrintDimensions * _printScale, _spriteUpRowAndColumns, _frameRate);
            _enemyRightLeft = new Renderer(Renderer.STATUS.Animated, _enemySpritesheet, _spriteRightLeftPosition, _spriteRightLeftDimensions, _spritePrintDimensions * _printScale, _spriteRightLeftRowAndColumns, _frameRate);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition() {
            if (_direction == Renderer.DIRECTION.DOWN)
                return _enemyDown.GetPosition();
            else if (_direction == Renderer.DIRECTION.UP)
                return _enemyUp.GetPosition();
            else
                return _enemyRightLeft.GetPosition();
        }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) 
        {
            _position = position;
            _enemyDown.SetPosition(position);
            _enemyUp.SetPosition(position);
            _enemyRightLeft.SetPosition(position);
        }


        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // set positions at every update
            _enemyDown.SetPosition(_position);
            _enemyUp.SetPosition(_position);
            _enemyRightLeft.SetPosition(_position);

            // set direction periodically
            if (_moveCounter == 0)
            {
                // Randomly choose a direction:
                switch (_random.Next(4))
                {
                    case 0: // Move DOWN
                        _direction = Renderer.DIRECTION.DOWN;
                        _enemyDown.SetDirection(_direction);
                        _updatePosition = _enemyDown.GetUpdatePosition(_positionSpeed);
                        break;
                    case 1: // Move UP
                        _direction = Renderer.DIRECTION.UP;
                        _enemyUp.SetDirection(_direction);
                        _updatePosition = _enemyUp.GetUpdatePosition(_positionSpeed);
                        break;
                    case 2: // Move RIGHT
                        _direction = Renderer.DIRECTION.RIGHT;
                        _enemyRightLeft.SetDirection(_direction);
                        _updatePosition = _enemyRightLeft.GetUpdatePosition(_positionSpeed);
                        break;
                    case 3: // Move LEFT
                        _direction = Renderer.DIRECTION.LEFT;
                        _enemyRightLeft.SetDirection(_direction);
                        _updatePosition = _enemyRightLeft.GetUpdatePosition(_positionSpeed);
                        break;
                }
            }

            // increase before assignment so that it runs again
            _moveCounter++;
            
            // reset movement clock
            if (_moveCounter == _moveTotal)
                _moveCounter = 0;

            // set projectile
            if (_projectileCounter == 0)
            {
                switch ((int)_direction)
                {
                    case 0: // DOWN
                        _projectile = _projectileManager.CallProjectile(_blueArrow, _enemyDown.PositionAhead(_enemyDown.GetDestinationRectangle()), _direction, _projectileTotal, _projectileScale); break;
                    case 1: // UP
                        _projectile = _projectileManager.CallProjectile(_blueArrow, _enemyUp.PositionAhead(_enemyUp.GetDestinationRectangle()), _direction, _projectileTotal, _projectileScale); break;
                    case 2: // RIGHT
                        _projectile = _projectileManager.CallProjectile(_blueArrow, _enemyRightLeft.PositionAhead(_enemyRightLeft.GetDestinationRectangle()), _direction, _projectileTotal, _projectileScale); break;
                    case 3: // LEFT
                        _projectile = _projectileManager.CallProjectile(_blueArrow, _enemyRightLeft.PositionAhead(_enemyRightLeft.GetDestinationRectangle()), _direction, _projectileTotal, _projectileScale); break;
                    default: break;
                }
            }

            // increase before assignment so that it runs again
            _projectileCounter++;

            // reset projectile clock
            if (_projectileCounter == _projectileTotal) { _projectileCounter = 0; _projectileManager.UnloadProjectile(_projectile); }

            // update position
            _position += _updatePosition;

            // needed to constantly update the frames
            if (_direction == Renderer.DIRECTION.DOWN)
                _enemyDown.UpdateFrames();
            else if (_direction == Renderer.DIRECTION.UP)
                _enemyUp.UpdateFrames();
            else
                _enemyRightLeft.UpdateFrames();
        }


        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            switch ((int)_direction)
            {
                case 0: // DOWN sprite drawing
                    _enemyDown.DrawCentered(spriteBatch, _enemyDown.GetSourceRectangle()); break;
                case 1: // UP sprite drawing
                    _enemyUp.DrawCentered(spriteBatch, _enemyUp.GetSourceRectangle()); break;
                case 2: // RIGHT sprite drawing
                    _enemyRightLeft.DrawCentered(spriteBatch, _enemyRightLeft.GetSourceRectangle()); break;
                case 3: // LEFT sprite drawing
                    _enemyRightLeft.DrawHorizontallyFlipped(spriteBatch, true); break;
                default: throw new ArgumentException("Invalid drawing direction for Darknut");
            }
        }
    }
}
