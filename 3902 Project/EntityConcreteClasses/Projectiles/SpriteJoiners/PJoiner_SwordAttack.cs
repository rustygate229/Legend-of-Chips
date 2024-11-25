using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class PJoiner_WoodSword : IJoiner
    {
        // variables to change based on where your sprite is and what to print out
        private ISprite _woodSword;
        private bool _removable;
        private ISprite _currentSprite;
        private Vector2 _position;
        private ProjectileManager.ProjectileNames _currentSword;

        private ICollisionBox _collisionBox;
        private int _counter;
        private int _counterTotal = 10;

        /// <summary>
        /// constructor for the projectile sprite: <c>Blue Arrow</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="direction">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PJoiner_WoodSword(ProjectileManager.ProjectileNames name, Texture2D spriteSheet, Renderer.DIRECTION direction, float printScale)
        {
            _woodSword = new PSprite_WoodSword(spriteSheet, direction, printScale, _counterTotal);
            _currentSword = name;
            _counter = 0;
            _currentSprite = _woodSword;
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

            CurrentSprite.Update();
            Position = CurrentSprite.GetVectorPosition();
        }
    }
}