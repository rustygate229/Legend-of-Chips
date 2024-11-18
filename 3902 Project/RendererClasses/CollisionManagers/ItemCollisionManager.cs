using System.Collections.Generic;

namespace _3902_Project
{
    public partial class ItemManager
    {
        public List<ICollisionBox> GetCollisionBoxes() { return _collisionBoxes; }

        public void SetCollision(ICollisionBox box)
        {
            switch (box.Sprite)
            {
                // example item that we never want link to pick up (if we want environment items)
                case SItem_Flute:
                    box.IsCollidable = false; break;
                default:
                    box.IsCollidable = true; break;
            }
        }

        public void SetHealthDamage(ICollisionBox box) { box.Health = 1; box.Damage = 0; }
    }
}