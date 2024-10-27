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
        /// Constructs the projectile (set values, create Rendering, etc.); takes the Projectile Spritesheet
        /// </summary>
        public Projectile_Bomb(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, int timer, float scale)
        {
            _spriteSheet = spriteSheet;
            _direction = facingDirection;
            _timerTotal = timer;
            _bombFire_Frames = (int)((_timerTotal * 0.20) / 2);
            _bombCloud_Frames = (int)((_timerTotal * 0.30) / 2);
            // create renders of the bomb projectile
            _bomb = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spritePosition_Bomb, _spriteDimensions_Bomb, _spriteDimensions_Bomb * scale);
            _bombFire = new Renderer(Renderer.STATUS.SingleAnimated, _spriteSheet, _spritePosition_BombFire, _spriteDimensions_BombFire, _spriteDimensions_BombFire * scale, _spriteRowAndColumn_BombFire, _bombFire_Frames);
            _bombCloud = new Renderer(Renderer.STATUS.Animated, _spriteSheet, _spritePosition_BombCloud, _spriteDimensions_BombCloud, _spriteDimensions_BombFire * scale, _spriteRowAndColumn_BombCloud, _bombCloud_Frames);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition()
        {
            if (_timerCounter < _timerCounter * 0.5) { return _bomb.GetPosition(); }
            else if (_timerCounter < _timerCounter * 0.7) { return _bombFire.GetPosition(); }
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
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_timerCounter < _timerTotal * 0.5)
                _bomb.DrawCentered(spriteBatch, _bomb.GetSourceRectangle());
            else if (_timerCounter < _timerTotal * 0.7)
                _bombFire.DrawCentered(spriteBatch, _bombFire.GetSourceRectangle());
            else
                _bombCloud.DrawCentered(spriteBatch, _bombCloud.GetSourceRectangle());
        }
    }
}