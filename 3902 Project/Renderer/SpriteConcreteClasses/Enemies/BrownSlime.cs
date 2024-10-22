using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class BrownSlime : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private Renderer _enemy;
        private BulletManager _bulletManager;

        // variables to change based on where your block is and what to print out
        private Vector2 _spritePosition = new Vector2(79, 28);
        private Vector2 _spriteDimensions = new Vector2(30, 16);
        private Vector2 _spriteRowAndColumns = new Vector2(1, 2);
        private Vector2 _spritePrintDimensions = new Vector2(64, 64);



        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _fireCounter = 4;
        private int _moveTotal = 10;
        private int _positionSpeed = 2;
        private Vector2 _updatePosition;
        private static Random random = new Random();


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.); takes the Enemy Spritesheet
        /// </summary>
        /// <param name="spriteSheet"></param>
        public BrownSlime(Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _enemy = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _position, _spritePosition, _spriteDimensions, _spritePrintDimensions, _spriteRowAndColumns, 30);
            _bulletManager = BulletManager.Instance;
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition()
        {
            return _enemy.GetPosition();
        }



        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            _position = position;
            _enemy.SetPosition(position);
        }


        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // Update animation
            _enemy.UpdateFrames();

            // Update position and check for boundary collision
            _position += _updatePosition;

            if (_position.X < 0 || _position.X + _spritePrintDimensions.X > 800)
            {
                _updatePosition.X = -_updatePosition.X; // Reverse horizontal direction
            }
            if (_position.Y < 0 || _position.Y + _spritePrintDimensions.Y > 600)
            {
                _updatePosition.Y = -_updatePosition.Y; // Reverse vertical direction
            }

            _enemy.SetPosition(_position);

            _moveCounter++;
            _fireCounter++;

            // Add bullet logic
            if (_fireCounter >= _moveTotal * 5)
            {
                _fireCounter = 0;
                Vector2 position = new Vector2(_enemy.GetDestinationRectangle().X, _enemy.GetDestinationRectangle().Y);
                if (_bulletManager._bulletsTextures.Count > 0 && _updatePosition != Vector2.Zero)
                {
                    _bulletManager.addBullet(position, _updatePosition);
                }
            }

            // Change direction periodically
            if (_moveCounter >= _moveTotal * 3)
            {
                Vector2 newDirection = Vector2.Zero;
                switch (random.Next(4))
                {
                    case 0: // Move DOWN
                        newDirection = new Vector2(0, Math.Abs(_positionSpeed));
                        break;
                    case 1: // Move UP
                        newDirection = new Vector2(0, -(Math.Abs(_positionSpeed)));
                        break;
                    case 2: // Move RIGHT
                        newDirection = new Vector2(Math.Abs(_positionSpeed), 0);
                        break;
                    case 3: // Move LEFT
                        newDirection = new Vector2(-(Math.Abs(_positionSpeed)), 0);
                        break;
                }

                if (newDirection != Vector2.Zero)
                {
                    _updatePosition = newDirection;
                    _moveCounter = 0; // Reset the timer
                }

                checkBounds(new Rectangle(128, 128, 768, 448), 64, 64);
            }
        }


        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // create and draw sprites
            int[] sR = _enemy.GetSourceRectangle();
            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
            Rectangle destinationRectangle = _enemy.GetDestinationRectangle();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        private void checkBounds(Rectangle playableArea, int width, int height)
        {
            //checks bounds and updates bounds as necessary
            Rectangle bounds = new Rectangle((int)_position.X, (int)_position.Y, width, height);

            if(!playableArea.Intersects(bounds))
            {
                //bounds is OUTSIDE playable area
                
            
            }

        }

    }
}
