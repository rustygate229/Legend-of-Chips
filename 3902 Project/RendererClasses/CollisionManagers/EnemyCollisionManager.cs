using System.Collections.Generic;

namespace _3902_Project
{
    public partial class EnemyManager
    {
        // Method to get collision boxes for all items
        public List<ICollisionBox> GetCollisionBoxes()
        {
            return _collisionBoxes;
        }

        public void SetCollision(ICollisionBox box) { box.IsCollidable = true; }

        public void SetHealthDamage(ICollisionBox box)
        {
            switch(box.Sprite)
            {
                case GreenSlime:
                    box.Health = 10;
                    box.Damage = 1;
                    break;
                case BrownSlime:
                    box.Health = 10;
                    box.Damage = 1;
                    break;
                case Darknut:
                    box.Health = 10;
                    box.Damage = 1;
                    break;
                default: break;
            }
        }
    }
}

