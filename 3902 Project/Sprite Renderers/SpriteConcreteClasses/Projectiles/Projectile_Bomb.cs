using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class Projectile_Bomb : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        public Renderer.DIRECTION _direction;

        // variables to change based on where your projectile is and what to print out
        private Vector2 _spritePosition_Bomb = new Vector2(129, 185);
        private Vector2 _spriteDimensions_Bomb = new Vector2(8, 14);

        private Vector2 _spritePosition_BombFire = new Vector2(191, 185);
        private Vector2 _spriteDimensions_BombFire = new Vector2(16, 16);
        private Vector2 _spriteRowAndColumn_BombFire = new Vector2(1, 1);

        private Vector2 _spritePosition_BombCloud = new Vector2(138, 185);
        private Vector2 _spriteDimensions_BombCloud = new Vector2(48, 16);
        private Vector2 _spriteRowAndColumn_BombCloud = new Vector2(1, 3);

        private float[] _frameRanges;
        private int _bombFire_Frames;
        private int _bombCloud_Frames;

        // create timers
        private int _timerCounter;
        private int _timerTotal;

        // create Renderer objects
        private Renderer _bomb;
        private Renderer _bombFire;
        private Renderer _bombCloud;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="timer">the total time until the sprite is deloaded</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        /// <param name="frameRanges">
        /// range: [0 -> 1], amountOfInputs = amountOfSprites - 1 AND MUST BE IN ORDER - values inputed are multiplied by timer to produce the
        /// framerates for the sprites being called.
        /// <example>EXAMPLE: if entered [0.5, 0.7] for a 3 sprite projectile: from 0 -> 0.5 (first sprite) to 0.5 -> 0.7 (second sprite) 
        /// to 0.7 -> 1 (third sprite). </example>
        /// </param>
        public Projectile_Bomb(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, int timer, float printScale, float[] frameRanges)
        {
            _spriteSheet = spriteSheet;
            _direction = facingDirection;
            _timerTotal = timer;
            _frameRanges = frameRanges;
            _bombFire_Frames = (int)((_timerTotal * (1 - frameRanges[0])) / 4);
            _bombCloud_Frames = (int)(_timerTotal * (1 - frameRanges[1]));
            // create renders of the bomb projectile
            _bomb = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spritePosition_Bomb, _spriteDimensions_Bomb, _spriteDimensions_Bomb * printScale);
            _bombFire = new Renderer(Renderer.STATUS.SingleAnimated, _spriteSheet, _spritePosition_BombFire, _spriteDimensions_BombFire, _spriteDimensions_BombFire * printScale, _spriteRowAndColumn_BombFire, _bombFire_Frames);
            _bombCloud = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _spritePosition_BombCloud, _spriteDimensions_BombCloud, _spriteDimensions_BombFire * printScale, _spriteRowAndColumn_BombCloud, _bombCloud_Frames);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition()
        {
            if (_timerCounter < _timerCounter * _frameRanges[0]) { return _bomb.GetPosition(); }
            else if (_timerCounter < _timerCounter * _frameRanges[1]) { return _bombFire.GetPosition(); }
            else { return _bombCloud.GetPosition(); }
        }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            _position = position;
            _bomb.SetPosition(position);
            _bombFire.SetPosition(position);
            _bombCloud.SetPosition(position);
        }


        /// <summary>
        /// Updates the projectile (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            _timerCounter++;
            _bombFire.UpdateFrames();
            _bombCloud.UpdateFrames();
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_timerCounter < _timerTotal * _frameRanges[0])
                _bomb.DrawCentered(spriteBatch, _bomb.GetSourceRectangle());
            else if (_timerCounter < _timerTotal * _frameRanges[1])
                _bombFire.DrawCentered(spriteBatch, _bombFire.GetSourceRectangle());
            else
                _bombCloud.DrawCentered(spriteBatch, _bombCloud.GetSourceRectangle());
        }
    }
}