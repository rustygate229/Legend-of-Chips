using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class LinkManager
    {
        // IMPORTANT: THIS HEALTH NEEDS TO MATCH THE MATH FOR THE IN GAME HUD HEALTH BAR - added the health as a parameter for just passing it
        public void SetHealthDamage(ICollisionBox box, int health) { box.Health = _maxHealth; box.Damage = 0; }


        private int _maxHealth = 6;

        public int MaxHealth { get { return _maxHealth; } set { if (value <= 48) _maxHealth = value; CollisionBox.Health = _maxHealth; } }

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
                case AItem_FBoomerang: _inventory.AddItem(ItemManager.ItemNames.FlashingBanana, 1); break;
                case AItem_FEmerald: _inventory.AddItem(ItemManager.ItemNames.FlashingEmerald, 1); break;
                case SItem_Rupees: _inventory.AddItem(ItemManager.ItemNames.FlashingEmerald, 5); break;
                case SItem_NormalKey:
                case SItem_BossKey: _inventory.AddItem(ItemManager.ItemNames.NormalKey, 1); break;
                case SItem_AddLife: MaxHealth += 2; break;
                case AItem_FLife:
                    if (CollisionBox.Health + 2 <= MaxHealth) CollisionBox.Health += 2; break;
                case AItem_FPotion:
                case SItem_Meat:
                    if (CollisionBox.Health + 3 <= MaxHealth) CollisionBox.Health += 3; break;
                case SItem_Shield: _inventory.LinkShield = !_inventory.LinkShield; break;
                case SItem_IronSword: 
                    if (_inventory.CurrentLinkSword <= LinkInventory.LinkSwordType.IRON) _inventory.CurrentLinkSword = LinkInventory.LinkSwordType.IRON; break;
                case SItem_MasterSword:
                    if (_inventory.CurrentLinkSword <= LinkInventory.LinkSwordType.MASTER) _inventory.CurrentLinkSword = LinkInventory.LinkSwordType.MASTER; break;
                case SItem_MagicStaff:
                    if (_inventory.CurrentLinkSword <= LinkInventory.LinkSwordType.STAFF) _inventory.CurrentLinkSword = LinkInventory.LinkSwordType.STAFF; break;
                case SItem_DebugSword:
                    if (_inventory.CurrentLinkSword <= LinkInventory.LinkSwordType.DEBUG) _inventory.CurrentLinkSword = LinkInventory.LinkSwordType.DEBUG; break;
                default: break;
            }
             Console.WriteLine("Current Link Health: " + CollisionBox.Health);
        }
    }
}
