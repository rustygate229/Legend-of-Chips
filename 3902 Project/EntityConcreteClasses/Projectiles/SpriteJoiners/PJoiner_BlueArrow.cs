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

        private ICollisionBox _collisionBox;
        private int _counter;
        private int _arrowCounter = 0;
        private int _explosionCounter = 290;
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
            set
            {
                if (value is PSprite_BlueArrow)
                    _currentSprite = _blueArrow;
                else
                    _currentSprite = _smallExplosion;
            }
        }

        public bool RemovableFlip
        {
            get { return _removable; }
            set { _removable = value; }
        }

        public void Update()
        {
            _counter++;
            if (_collisionBox.Health == 1)
                _currentSprite = _blueArrow;
            else if (_collisionBox.Health != 1)
            {
                _counter = _explosionCounter;
                _currentSprite = _smallExplosion;
            }
            else if ((CollisionBox.Health == 1) && (_counter == _counterTotal))
                CollisionBox.Health--;
            else if (_counter == _counterTotal)
                RemovableFlip = false;
        }
    }
}