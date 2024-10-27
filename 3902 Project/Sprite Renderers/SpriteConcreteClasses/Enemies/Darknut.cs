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
        private Vector2 _position;
        private Vector2 _updatePosition;
        private Renderer.DIRECTION _direction;

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

        private RendererLists _rendererList;

        private float _printScale = 4F;
        private int _frameRate = 20;

        // variables for moving the enemy
        private int _moveCounter = 0;
        private int _moveTotal = 40;
        private int _positionSpeed = 2;
        private static Random _random = new Random();

        // variables for shooting projectile
        private ProjectileManager _projectileManager;
        private ProjectileManager.ProjectileNames _blueArrow = ProjectileManager.ProjectileNames.BlueArrow;
        private ISprite _projectileBlueArrow;
        // variables specific to Darknuts implementation of the projectile sprite
        private float _blueArrowPrintScale = 4F;
        private float _blueArrowSpeed = 3F;
        private float[] _blueArrowFrameRange = { 0.85F }; // read summary in respective Projectile Concrete Classes for explanation
        private int _blueArrowCounter = 0;
        private int _blueArrowTotal = 200; // cool down value for firing projectiles


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.); takes the Enemy Spritesheet
        /// </summary>
        /// <param name="spriteSheet"></param>
        public Darknut(Texture2D spriteSheet, ProjectileManager manager)
        {
            _enemySpritesheet = spriteSheet;
            _projectileManager = manager;
            // create our renderer list
            Renderer[] _rendererListArray = // positions in array correlate to above positions, usually: DOWN, UP, RIGHT, LEFT
            {
                new Renderer(Renderer.STATUS.Animated, _enemySpritesheet, _spriteDownPosition, _spriteDownDimensions, _spritePrintDimensions * _printScale, _spriteDownRowAndColumns, _frameRate),
                new Renderer(Renderer.STATUS.SingleAnimated, _enemySpritesheet, _spriteUpPosition, _spriteUpDimensions, _spritePrintDimensions * _printScale, _spriteUpRowAndColumns, _frameRate),
                new Renderer(Renderer.STATUS.Animated, _enemySpritesheet, _spriteRightLeftPosition, _spriteRightLeftDimensions, _spritePrintDimensions * _printScale, _spriteRightLeftRowAndColumns, _frameRate)
            };
            // create and assign what type of renderer list it is, and if it is centered
            _rendererList = new RendererLists(_rendererListArray, RendererLists.RendOrder.Size3RightLeft);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition() { return _rendererList.GetOnePosition(); }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)  { _position = position; _rendererList.SetPositions(position); }


        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // set positions at every update
            _rendererList.SetPositions(_position);

            // set direction periodically
            if (_moveCounter == 0) { _updatePosition = _rendererList.CreateRandomMovement(_positionSpeed); }

            // increase before assignment so that it runs again
            _moveCounter++;

            // reset movement clock
            if (_moveCounter == _moveTotal) { _moveCounter = 0; }

            // set a new projectile
            if (_blueArrowCounter == 10) 
            {
                _updatePosition = new(0, 0);
                _projectileBlueArrow = _rendererList.CreateProjectile(_projectileManager, _blueArrow, _blueArrowTotal, _blueArrowSpeed, _blueArrowPrintScale, _blueArrowFrameRange); 
            }

            // increase before assignment so that it runs again
            _blueArrowCounter++;

            // reset projectile clock
            if (_blueArrowCounter == _blueArrowTotal) { _blueArrowCounter = 0; _projectileManager.UnloadProjectile(_projectileBlueArrow); }

            // update position
            _position += _updatePosition;

            // needed to constantly update the frames
            _rendererList.CreateUpdateFrames();
        }

        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            _rendererList.CreateSpriteDraw(spriteBatch, true);
        }
    }
}
