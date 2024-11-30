using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class PSprite_BombCloud : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteBombCloud = new (138, 185, 51, 16);
        private Vector2 _spriteRowAndColumn = new Vector2(1, 3);
        private int _bombCloudFrames = 30;

        private Renderer _bombCloud;
        private bool _isCentered = true;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_BombCloud(Texture2D spriteSheet, float printScale)
        {
            _bombCloud = new (spriteSheet, _spriteBombCloud, _spriteRowAndColumn, printScale, _bombCloudFrames);
            _bombCloud.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _bombCloud.DestinationRectangle; }
            set { _bombCloud.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _bombCloud.PositionOnWindow; }
            set { _bombCloud.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the projectile (movement, animation, etc.)
        /// </summary>
        public void Update() { _bombCloud.UpdateFrames(); }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _bombCloud.Draw(spriteBatch); }
    }
}