using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class LinkStanding : IColor
    {
        // variables for link in frame 1 of the moving link sprite animation
        private Rectangle _spriteLittleShieldDownPosition = new(0, 11, 16, 16);
        private Rectangle _spriteLittleShieldUpPosition = new(69, 11, 16, 16);
        private Rectangle _spriteLittleShieldRightLeftPosition = new(34, 11, 16, 16);

        // Big Shield link
        private Rectangle _spriteBigShieldDownPosition = new(289, 11, 16, 16);
        private Rectangle _spriteBigShieldUpPosition = new(305, 11, 16, 16);
        private Rectangle _spriteBigShieldRightLeftPosition = new(34, 11, 16, 16);

        // create a Renderer object
        private RendererLists _rendererList;
        private bool _isCentered = true;
        private Renderer _linkDown;
        private Renderer _linkUp;
        private Renderer _linkRightLeft;

        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkStanding(Texture2D spriteSheet, bool shieldStatus, Renderer.DIRECTION facingDirection, float printScale)
        {
            // if false = Little Shield, if true = Big Shield
            if (!shieldStatus)
            {
                _linkDown = new(spriteSheet, _spriteLittleShieldDownPosition, printScale);
                _linkUp = new(spriteSheet, _spriteLittleShieldUpPosition, printScale);
                _linkRightLeft = new(spriteSheet, _spriteLittleShieldRightLeftPosition, printScale);
            }
            else
            {
                _linkDown = new(spriteSheet, _spriteBigShieldDownPosition, printScale);
                _linkUp = new(spriteSheet, _spriteBigShieldUpPosition, printScale);
                _linkRightLeft = new(spriteSheet, _spriteBigShieldRightLeftPosition, printScale);
            }
            Renderer[] rendererListSetArray = { _linkDown, _linkUp, _linkRightLeft };
            // create renderer list
            _rendererList = new RendererLists(rendererListSetArray, RendererLists.RendOrder.Size3RightLeft);
            _rendererList.IsCentered = _isCentered;
            // set correct direciton
            _rendererList.Direction = facingDirection;
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
        public void Update() { }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.Draw(spriteBatch); }

        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch, Color tint) { _rendererList.Draw(spriteBatch, tint); }
    }
}