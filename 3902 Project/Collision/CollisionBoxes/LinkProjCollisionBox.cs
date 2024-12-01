using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class LinkProjCollisionBox : ICollisionBox
    {
        private ISprite _sprite;
        private Rectangle _bounds;
        private bool _collidable;
        private int _damage;
        private int _health;

        /// <summary>
        /// Create a collision box for Link projectiles.
        /// </summary>
        /// <param name="sprite">the sprite that the box bases its bounds on</param>
        public LinkProjCollisionBox(ISprite sprite)
        {
            // default values without being overwritten
            _sprite = sprite;
            _bounds = _sprite.DestinationRectangle;
            _collidable = false;
            _health = 1;
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
