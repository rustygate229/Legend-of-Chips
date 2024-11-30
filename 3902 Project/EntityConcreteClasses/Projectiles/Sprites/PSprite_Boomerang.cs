using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class PSprite_Boomerang : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteBoomerang = new (90, 189, 28, 8);
        private Vector2 _spriteRowAndColumn = new (1, 3);
        private int _frames = 30;

        // create timers, movement and speed variables
        private float _positionSpeed = 4f;

        private Renderer _boomerang;
        private bool _isCentered = true;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_Boomerang(Texture2D spriteSheet, Renderer.DIRECTION direction, float printScale)
        {
            _boomerang = new (spriteSheet, _spriteBoomerang, _spriteRowAndColumn, printScale, _frames);
            _boomerang.IsCentered = _isCentered;
            // set correct direciton
            _boomerang.Direction = direction;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _boomerang.DestinationRectangle; }
            set { _boomerang.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _boomerang.PositionOnWindow; }
            set { _boomerang.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            Vector2 updatePosition = _boomerang.GetUpdatePosition(_positionSpeed);
            _boomerang.PositionOnWindow = _boomerang.PositionOnWindow + updatePosition;
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _boomerang.Draw(spriteBatch); }
    }
}