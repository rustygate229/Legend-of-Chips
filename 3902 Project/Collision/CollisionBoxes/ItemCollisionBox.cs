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

        public ItemCollisionBox(Rectangle bounds)
        {
            _bounds = bounds;
            _isCollidable = true; 
            _health = 0; 
            _damage = 0; 
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

        // Method to get default items for testing purposes
        public static List<ItemCollisionBox> GetDefaultItems()
        {
            return new List<ItemCollisionBox>
            {
                new ItemCollisionBox(new Rectangle(400, 150, 20, 20)), // Test Item 1
                new ItemCollisionBox(new Rectangle(800, 300, 20, 20)), // Test Item 2
                new ItemCollisionBox(new Rectangle(350, 250, 20, 20))  // Test Item 3
            };
        }
    }
}