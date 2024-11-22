using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class PJoiner_BlueArrow : IPJoiner
    {
        // variables to change based on where your sprite is and what to print out
        private ISprite _blueArrow;
        private ISprite _smallExplosion;
        private bool _removable;
        private ISprite _currentSprite;
        private Vector2 _position;

        private ICollisionBox _collisionBox;
        private int _counter;
        private int _arrowCounter = 0;
        private int _explosionCounter = 280;
        private int _counterTotal = 300;

        /// <summary>
        /// constructor for the projectile sprite: <c>Blue Arrow</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="direction">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PJoiner_BlueArrow(Texture2D spriteSheet, Renderer.DIRECTION direction, float printScale)
        {
            _blueArrow = new PSprite_BlueArrow(spriteSheet, direction, printScale);
            _smallExplosion = new PSprite_SmallExplosion(spriteSheet, printScale);
            _counter = _arrowCounter;
            _currentSprite = _blueArrow;
            RemovableFlip = false;
        }

        public ICollisionBox CollisionBox
        {
            get { return _collisionBox; }
            set { _collisionBox = value; }
        }

        public ISprite CurrentSprite 
        { 
            get { return _currentSprite; }
            set { _currentSprite = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public bool RemovableFlip
        {
            get { return _removable; }
            set { _removable = value; }
        }

        public void Update()
        {
            _counter++;
            
            if (_counter >= _counterTotal)
                RemovableFlip = true;

            if (_counter < _explosionCounter && CollisionBox.Health == 1)
                CurrentSprite = _blueArrow;
            else
            {
                CurrentSprite = _smallExplosion;
                CurrentSprite.SetPosition(Position);
                if (!(_counter >= _explosionCounter))
                    _counter = _explosionCounter;
            }

            CurrentSprite.Update();
            Position = CurrentSprite.GetVectorPosition();
        }
    }
}