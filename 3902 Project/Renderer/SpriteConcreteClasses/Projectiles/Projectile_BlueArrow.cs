using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class Projectile_BlueArrow : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Renderer.DIRECTION _direction;

        // variables to change based on where your sprite is and what to print out
        private Vector2 _spritePosition_UpDownArrow = new (29, 185);
        private Vector2 _spriteDimensions_UpDownArrow = new (5, 16);

        private Vector2 _spritePosition_RightLeftArrow = new (36, 190);
        private Vector2 _spriteDimensions_RightLeftArrow = new (16, 5);

        private Vector2 _spritePosition_ExplodeArrow = new (53, 189);
        private Vector2 _spriteDimensions_ExplodeArrow = new (8, 8);


        // create timers, movement and speed variables
        private int _timerCounter;
        private int _timerTotal;
        private Vector2 _position;
        private Vector2 _updatePosition;
        private int _positionSpeed = 2;

        // create Renderer objects
        private Renderer _upDownArrow;
        private Renderer _rightLeftArrow;
        private Renderer _explodeArrow;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        /// <param name="facingDirection"></param>
        /// <param name="spriteSheet"></param>
        public Projectile_BlueArrow(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, int timer, float printScale)
        {
            _spriteSheet = spriteSheet;
            _direction = facingDirection;
            _timerTotal = timer;
            // create renders of the bomb projectile
            _upDownArrow = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spritePosition_UpDownArrow, _spriteDimensions_UpDownArrow, _spriteDimensions_UpDownArrow * printScale);
            _rightLeftArrow = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spritePosition_RightLeftArrow, _spriteDimensions_RightLeftArrow, _spriteDimensions_RightLeftArrow * printScale);
            _explodeArrow = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spritePosition_ExplodeArrow, _spriteDimensions_ExplodeArrow, _spriteDimensions_ExplodeArrow * printScale / 2);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition()
        {
            if (_direction == Renderer.DIRECTION.DOWN || _direction == Renderer.DIRECTION.UP)
                return _upDownArrow.GetPosition();
            else if (_direction == Renderer.DIRECTION.RIGHT || _direction == Renderer.DIRECTION.LEFT)
                return _rightLeftArrow.GetPosition();
            else
                return _explodeArrow.GetPosition();
        }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            _position = position;
            _upDownArrow.SetPosition(position);
            _rightLeftArrow.SetPosition(position);
            _explodeArrow.SetPosition(position);
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // set positions at every update
            _upDownArrow.SetPosition(_position);
            _rightLeftArrow.SetPosition(_position);
            _explodeArrow.SetPosition(_position);

            // get updated position
            if (_timerCounter >= _timerTotal - (_timerCounter * (0.15)))
                _updatePosition = new Vector2(0, 0);
            else if (_direction == Renderer.DIRECTION.DOWN || _direction == Renderer.DIRECTION.UP)
            {
                _upDownArrow.SetDirection(_direction);
                _updatePosition = _upDownArrow.GetUpdatePosition(_positionSpeed);
            }
            else if (_direction == Renderer.DIRECTION.RIGHT || _direction == Renderer.DIRECTION.LEFT)
            {
                _rightLeftArrow.SetDirection(_direction);
                _updatePosition = _rightLeftArrow.GetUpdatePosition(_positionSpeed);
            }

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
            if (_timerCounter >= _timerTotal - (_timerCounter * (0.15)))
                _explodeArrow.DrawCentered(spriteBatch, _explodeArrow.GetSourceRectangle());
            // else in normal frame
            else
            {
                // create sourceRectangle of arrow based on direction
                switch ((int)_direction)
                {
                    case 0: // DOWN
                        _upDownArrow.DrawVerticallyFlipped(spriteBatch, true);
                        break;
                    case 1: // UP
                        _upDownArrow.DrawCentered(spriteBatch, _upDownArrow.GetSourceRectangle());
                        break;
                    case 2: // RIGHT
                        _rightLeftArrow.DrawCentered(spriteBatch, _rightLeftArrow.GetSourceRectangle());
                        break;
                    case 3: // LEFT
                        _rightLeftArrow.DrawHorizontallyFlipped(spriteBatch, true);
                        break;
                    default: throw new ArgumentException("Invalid projectile direction");
                }
            }
        }
    }
}