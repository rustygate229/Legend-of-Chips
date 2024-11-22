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
        private Vector2 _position;
        private Vector2 _updatePosition;
        private float _positionSpeed = 2f;

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
            _boomerang.SetAnimationStatus(Renderer.STATUS.ReverseRowAndColumnAnimated);
            _boomerang.SetDirection(direction);
            _boomerang.SetCentered(_isCentered);
            _updatePosition = _boomerang.GetUpdatePosition(_positionSpeed);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _boomerang.GetRectanglePosition(); }

        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _boomerang.GetVectorPosition(); }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _position = position; _boomerang.SetPosition(position); }


        /// <summary>
        /// Updates the projectile (movement, animation, etc.)
        /// </summary>
        public void Update() 
        {
            _boomerang.UpdateFrames();

            // set positions at every update
            _boomerang.SetPosition(_position);

            // update position and movement counter
            _position += _updatePosition;
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _boomerang.Draw(spriteBatch); }
    }
}