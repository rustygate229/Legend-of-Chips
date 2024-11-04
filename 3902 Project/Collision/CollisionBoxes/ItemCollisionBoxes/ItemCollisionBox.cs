// ItemCollisionBox.cs
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemCollisionBox : ICollisionBox
    {
        private Rectangle _bounds;
        private bool _isCollidable;
        private int _health;
        private int _damage;
        private ItemManager.ItemNames _itemName;
        private int _itemCount;

        public ItemCollisionBox(Rectangle bounds, ItemManager.ItemNames itemName, int amount)
        {
            _bounds = bounds;
            _isCollidable = true;
            _health = -1;
            _damage = 0;
            _itemName = itemName;
            _itemCount = amount;
        }

        public ItemCollisionBox(Rectangle bounds, ItemManager.ItemNames itemName)
        {
            _bounds = bounds;
            _isCollidable = true;
            _health = -1;
            _damage = 0;
            _itemName = itemName;
            switch (itemName)
            {
                case ItemManager.ItemNames.FlashingArrow: _itemCount = 10; break;

                case ItemManager.ItemNames.FlashingPotion: _itemCount = 2; break;

                default: _itemCount = 1; break;
            }
        }

        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        public bool IsCollidable
        {
            get { return _isCollidable; }
            set { _isCollidable = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }


        public (ItemManager.ItemNames name, int amount) getItemInfo() {
            return (_itemName, _itemCount);
        }
    }
}