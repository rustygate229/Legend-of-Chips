using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class PJoiner_Bomb : IJoiner
    {
        // variables to change based on where your sprite is and what to print out
        private ISprite _bomb;
        private ISprite _bombFire;
        private ISprite _bombCloud;
        private bool _removable;
        private ISprite _currentSprite;

        private ICollisionBox _collisionBox;
        private int _counter = 0;
        private int _bombCounter = 0;
        private int _bombFireCounter = 80;
        private int _bombCloudCounter = 100;
        private int _counterTotal = 130;

        /// <summary>
        /// constructor for the projectile sprite: <c>Blue Arrow</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PJoiner_Bomb(Texture2D spriteSheet, Renderer.DIRECTION direction, float printScale)
        {
            _bomb = new PSprite_Bomb(spriteSheet, printScale);
            _bombFire = new PSprite_Fire(spriteSheet, printScale);
            _bombCloud = new PSprite_BombCloud(spriteSheet, printScale);
            _counter = 0;
            _currentSprite = _bomb;
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
            set { Vector2 oldPosition = _currentSprite.PositionOnWindow; _currentSprite = value; _currentSprite.PositionOnWindow = oldPosition; }
        }

        public Vector2 PositionOnWindow
        {
            get { return CurrentSprite.PositionOnWindow; }
            set { CurrentSprite.PositionOnWindow = value; }
        }

        public Rectangle DestinationRectangle
        {
            get { return CurrentSprite.DestinationRectangle; }
            set { CurrentSprite.DestinationRectangle = value; }
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

            if (_counter < _bombFireCounter)
                CurrentSprite = _bomb;
            else if (_counter < _bombCloudCounter)
                CurrentSprite = _bombFire;
            else
                CurrentSprite = _bombCloud;

            CurrentSprite.Update();
        }
    }
}