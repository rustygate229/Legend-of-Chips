using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace _3902_Project
{
    public class PJoiner_SwordAttack : IJoiner
    {
        // variables to change based on where your sprite is and what to print out
        private ISprite _currentSword;
        private bool _removable;

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
        public PJoiner_SwordAttack(ProjectileManager.ProjectileNames name, Texture2D spriteSheet, Renderer.DIRECTION direction, float printScale)
        {
            switch(name)
            {
                case ProjectileManager.ProjectileNames.WoodSwordAttack: _currentSword = new PSprite_WoodSword(spriteSheet, direction, printScale, _counterTotal); break;
                case ProjectileManager.ProjectileNames.IronSwordAttack: _currentSword = new PSprite_IronSword(spriteSheet, direction, printScale, _counterTotal); break;
                case ProjectileManager.ProjectileNames.MasterSwordAttack: _currentSword = new PSprite_MasterSword(spriteSheet, direction, printScale, _counterTotal); break;
                case ProjectileManager.ProjectileNames.MagicStaffSAttack: _currentSword = new PSprite_MagicStaff(spriteSheet, direction, printScale, _counterTotal); break;
                case ProjectileManager.ProjectileNames.DebugSwordAttack: _currentSword = new PSprite_DebugSword(spriteSheet, direction, printScale, _counterTotal); break;
                default: break;
            }
            _counter = 0;
            RemovableFlip = false;
        }

        public ICollisionBox CollisionBox
        {
            get { return _collisionBox; }
            set { _collisionBox = value; }
        }

        public ISprite CurrentSprite 
        { 
            get { return _currentSword; }
            set { Vector2 oldPosition = _currentSword.PositionOnWindow; _currentSword = value; _currentSword.PositionOnWindow = oldPosition; CollisionBox.Sprite = value; }
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

            CurrentSprite.Update();
        }
    }
}