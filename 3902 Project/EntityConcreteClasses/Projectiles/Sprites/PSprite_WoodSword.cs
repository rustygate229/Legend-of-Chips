using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace _3902_Project
{
    public class PSprite_WoodSword : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteDownUpPositions = new(1, 154, 7, 16);
        private Rectangle _spriteRightLeftPositions = new(10, 159, 16, 7);


        // create Renderer objects
        private RendererLists _rendererList;
        private bool _isCentered = true;

        // create timers, movement and speed variables
        private Vector2 _position;
        private Vector2 _updatePosition;
        private float _positionSpeed = 10f;
        private int _counter = 0;
        private int _counterTotal;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_WoodSword(Texture2D spriteSheet, Renderer.DIRECTION direction, float printScale, int timerTotal)
        {
            // create renders of the bomb projectile
            Renderer woodSwordDownUp = new(spriteSheet, _spriteDownUpPositions, printScale);
            Renderer woodSwordRightLeft = new(spriteSheet, _spriteRightLeftPositions, printScale);
            Renderer[] rendererList = { woodSwordDownUp, woodSwordRightLeft };
            _rendererList = new(rendererList, RendererLists.RendOrder.Size2DownUpFlip);
            _rendererList.CreateSetAnimationStatus(Renderer.STATUS.Still);
            _rendererList.SetCentered(_isCentered);
            _rendererList.SetDirection(direction);
            _updatePosition = _rendererList.CreateGetUpdatePosition(_positionSpeed);
            _counterTotal = timerTotal;
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _rendererList.GetOneRectanglePosition(); }

        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _rendererList.GetVectorPosition(); }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _position = position; _rendererList.SetPositions(position); }


        /// <summary>
        /// Updates the projectile (movement, animation, etc.)
        /// </summary>
        public void Update() 
        {
            // set positions at every update
            _rendererList.SetPositions(_position);

            // update position and movement counter
            _counter++;
            if (_counter < (_counterTotal / 2))
                _position += _updatePosition;
            else
                _position -= _updatePosition;
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _rendererList.CreateSpriteDraw(spriteBatch); }
    }
}