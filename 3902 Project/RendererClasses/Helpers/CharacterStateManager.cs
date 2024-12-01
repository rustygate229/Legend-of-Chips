using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class LinkManager
    {
        // IMPORTANT: THIS HEALTH NEEDS TO MATCH THE MATH FOR THE IN GAME HUD HEALTH BAR - added the health as a parameter for just passing it
        public void SetHealthDamage(ICollisionBox box, int health) { box.Health = 10; box.Damage = 0; }


        private int _maxHealth = 10;
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

        private CollisionData.CollisionType _collisionDetectedSide;
        public void SetCollisionSide(CollisionData.CollisionType side) { _collisionDetectedSide = side; }

        private bool _isLinkDamaged = false;
        public bool IsLinkDamaged { get { return _damageHelper.IsDamaged; } set { _damageHelper.IsDamaged = value; } }

        public void SetDamaged(int counter, CollisionData.CollisionType side)
        {
            IsLinkDamaged = true;
            _damageHelper.SendBackwards = true;
            _damageHelper.CounterTotal = counter;
            _damageHelper.CollisionSide = side;
            _damageHelper.CurrentSprite = CurrentLink;
        }

        public void SetItem(ISprite item)
        {
            switch (item)
            {
                // gave 10 for testing purpose
                case AItem_FArrow: _inventory.AddItem(ProjectileManager.ProjectileNames.BlueArrow, 10); break;
                case AItem_FLife: MaxHealth += 2; break;
                default: break;
            }
        }
    }
}
