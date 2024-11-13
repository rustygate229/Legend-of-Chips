using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class EnemyProjCollisionBox : ICollisionBox
    {
        private ISprite _sprite;
        private Rectangle _bounds;
        private bool _collidable;
        private int _damage;
        private int _health;

        public EnemyProjCollisionBox(ISprite sprite, int damage, int health)
        {
            _sprite = sprite;
            _bounds = _sprite.GetRectanglePosition();
            _collidable = true; 
            _damage = damage;
            _health = health;
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
            get { return _collidable; }
            set { _collidable = value; }
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
    }
}
