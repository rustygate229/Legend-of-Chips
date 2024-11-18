using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace _3902_Project
{
    public class PJoiner_Bomb : IPJoiner
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
        private int _bombCloudCounter = 120;
        private int _counterTotal = 300;

        /// <summary>
        /// constructor for the projectile sprite: <c>Blue Arrow</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PJoiner_Bomb(Texture2D spriteSheet, float printScale)
        {
            _bomb = new PSprite_Bomb(spriteSheet, printScale);
            _bombFire = new PSprite_Fire(spriteSheet, printScale);
            _bombFire = new PSprite_BombCloud(spriteSheet, printScale);
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
            set
            {
                if (value is PSprite_Bomb)
                {
                    _currentSprite = _bomb;
                }
                else if (value is PSprite_Fire)
                    _currentSprite = _bombFire;
                else
                    _currentSprite = _bombCloud;
            }
        }

        public bool RemovableFlip
        {
            get { return _removable; }
            set { _removable = value; }
        }

        // simple fix, might be bad practice to reach these methods for update()
        ProjectileManager man = new();


        public void Update()
        {
            _counter++;
            if (_counter < _bombFireCounter)
                _currentSprite = _bomb;
            else if (_counter < _bombCloudCounter)
                _currentSprite = _bombFire;
            else if (_counter < _counterTotal)
                _currentSprite = _bombCloud;
            else if (_counter == _counterTotal)
                RemovableFlip = false;
            // uses the manager to set the clouds damage once it hits the state
            if (_counter == _bombCloudCounter)
                man.SetDamageHealth(CollisionBox);

        }
    }
}