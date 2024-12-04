using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class PSprite_MagicWave : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private Rectangle _spriteDownUpPositions = new (170, 154, 68, 16);
        private Rectangle _spriteRightLeftPositions = new(238, 154, 68, 16);
        private Vector2 _spriteRowsAndColumns = new (1, 4);
        private int _frames = 15;

        // create Renderer objects
        private RendererLists _rendererList;
        private bool _isCentered = true;

        // create timers, movement and speed variables
        private float _positionSpeed = 10f;
        private Vector2 _updatePosition;


        /// <summary>
        /// constructor for the projectile sprite: <c>MagicWave</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_MagicWave(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create renders of the bomb projectile
            Renderer magicWaveDownUp = new(spriteSheet, _spriteDownUpPositions, _spriteRowsAndColumns, printScale, _frames);
            Renderer magicWaveRightLeft = new(spriteSheet, _spriteRightLeftPositions, _spriteRowsAndColumns, printScale, _frames);
            Renderer[] rendererList = { magicWaveDownUp, magicWaveRightLeft };
            _rendererList = new(rendererList, RendererLists.RendOrder.Size2DownUpFlip);
            _rendererList.IsCentered = _isCentered;
            // set correct direciton
            _rendererList.Direction = facingDirection;
            // only want it set once
            _updatePosition = _rendererList.GetUpdatePosition(_positionSpeed);
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _rendererList.DestinationRectangle; }
            set { _rendererList.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _rendererList.PositionOnWindow; }
            set { _rendererList.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            _rendererList.UpdateFrames();
            _rendererList.PositionOnWindow += _updatePosition;
        }


        /// <summary>
        /// Draws the sprite in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.Draw(spriteBatch); }
    }
}