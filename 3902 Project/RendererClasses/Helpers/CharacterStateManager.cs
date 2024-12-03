using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class LinkManager
    {
        // IMPORTANT: THIS HEALTH NEEDS TO MATCH THE MATH FOR THE IN GAME HUD HEALTH BAR - added the health as a parameter for just passing it
        public void SetHealthDamage(ICollisionBox box, int health) { box.Health = _maxHealth; box.Damage = 0; }


        private int _maxHealth = 10;
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

        private CollisionData.CollisionType _collisionDetectedSide;
        public void SetCollisionSide(CollisionData.CollisionType side) { _collisionDetectedSide = side; }

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
                case AItem_FArrow:  _inventory.AddItem(ItemManager.ItemNames.BlueArrow, 5); break;
                case SItem_Bomb:    _inventory.AddItem(ItemManager.ItemNames.Bomb, 3); break;
                case AItem_FBanana: _inventory.AddItem(ItemManager.ItemNames.FlashingBanana, 1); break;
                case AItem_FEmerald: _inventory.AddItem(ItemManager.ItemNames.FlashingEmerald, 1); break;
                case SItem_NormalKey:
                case SItem_BossKey: _inventory.AddItem(ItemManager.ItemNames.NormalKey, 1); break;
                case SItem_AddLife: MaxHealth += 2; CollisionBox.Health += 2; break;
                case AItem_FLife:
                case AItem_FPotion:
                    if (CollisionBox.Health + 2 > MaxHealth) CollisionBox.Health = MaxHealth;
                    else CollisionBox.Health += 2; break;
                default: break;
            }
            Console.WriteLine("Current Link Health: " + CollisionBox.Health);
        }
    }
}
