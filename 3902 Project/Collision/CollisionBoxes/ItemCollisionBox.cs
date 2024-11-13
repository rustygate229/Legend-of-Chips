// ItemCollisionBox.cs
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemCollisionBox : ICollisionBox
    {
        private ISprite _sprite;
        private Rectangle _bounds;
        private bool _isCollidable;
        private int _health;
        private int _damage;

        public ItemCollisionBox(ISprite sprite)
        {
            _sprite = sprite;
            _bounds = _sprite.GetRectanglePosition();
            _isCollidable = true;
            _health = -1;
            _damage = 0;
        }

        public ISprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
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
    }
}