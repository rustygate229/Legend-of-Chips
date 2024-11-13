using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.Design;

namespace _3902_Project
{
    public class PJoiner_BlueArrow
    {
        // variables to change based on where your sprite is and what to print out
        private ISprite _blueArrow;
        private ISprite _smallExplosion;
        private int _smallExplosionCounter = 0;
        private int _smallExplosionCounterTotal = 10;

        public enum STATUS { BlueArrow, SmallExplosion, Removable }
        private STATUS _status;

        private ICollisionBox _collisionBox;
        private int _counter = 0;
        private int _counterTotal = 200;

        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PJoiner_BlueArrow(ISprite blueArrow, ISprite smallExplosion)
        {
            _blueArrow = blueArrow;
            _smallExplosion = smallExplosion;
        }

        public ICollisionBox CollisionBox
        {
            get { return _collisionBox; }
            set { _collisionBox = value; _collisionBox.Health = 1;  }
        }

        public void Update()
        {
            _counter++;
            if (_collisionBox.Health == 1)
                _status = STATUS.BlueArrow;
            else if (_collisionBox.Health != 1)
            {
                _smallExplosionCounter++;
                _status = STATUS.SmallExplosion;
            }
            else if (_counter == _counterTotal || _smallExplosionCounter == _smallExplosionCounterTotal)
                _status = STATUS.Removable;
        }

        public ISprite CurrentSprite
        {
            get
            {
                if (_status == STATUS.BlueArrow) return _blueArrow;
                else if (_status == STATUS.SmallExplosion) return _smallExplosion;
                else return null;
            }
        }
    }
}