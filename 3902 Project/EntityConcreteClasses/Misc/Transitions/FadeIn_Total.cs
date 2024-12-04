using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class FadeIn_Total : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _leftBlack = new(8, 18, 8, 8);
        private Rectangle _rightBlack = new(8, 18, 8, 8);
        private Rectangle _leftDestinationRectangle = new(-530, 0, 530, 900);
        private Rectangle _rightDestinationRectangle = new(1024, 0, 530, 900);

        // create timers, movement and speed variables
        private float _positionSpeed = 10f;
        private Vector2 _updatePosition;
        private Renderer _transitionLeft;
        private Renderer _transitionRight;
        private bool _isCentered = false;
        private int _counter = 0;
        private int _counterTotal = 530 / 10;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public FadeIn_Total(Texture2D spriteSheet)
        {
            _transitionLeft = new Renderer(spriteSheet, _leftBlack, 1F);
            _transitionLeft.IsCentered = _isCentered;
            _transitionLeft.DestinationRectangle = _leftDestinationRectangle;
            _transitionLeft.PositionOnWindow = new(_leftDestinationRectangle.X, _leftDestinationRectangle.Y);

            _transitionRight = new Renderer(spriteSheet, _rightBlack, 1F);
            _transitionRight.IsCentered = _isCentered;
            _transitionRight.DestinationRectangle = _rightDestinationRectangle;
            _transitionRight.PositionOnWindow = new(_rightDestinationRectangle.X, _rightDestinationRectangle.Y);

            _transitionLeft.Direction = Renderer.DIRECTION.LEFT;
            _updatePosition = _transitionLeft.GetUpdatePosition(_positionSpeed);
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _transitionLeft.DestinationRectangle; }
            set { _transitionLeft.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _transitionLeft.PositionOnWindow; }
            set { _transitionLeft.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            _counter++;
            if (_counter < _counterTotal)
            {
                _transitionLeft.PositionOnWindow -= _updatePosition;
                _transitionRight.PositionOnWindow += _updatePosition;
            }
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _transitionLeft.Draw(spriteBatch); _transitionRight.Draw(spriteBatch); }

        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="tint"></param>
        public void Draw(SpriteBatch spriteBatch, Color tint) { _transitionLeft.Draw(spriteBatch, tint); _transitionRight.Draw(spriteBatch, tint); }
    }
}
