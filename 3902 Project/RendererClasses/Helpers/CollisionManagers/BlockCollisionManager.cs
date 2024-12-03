using System.Collections;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class BlockManager
    {
        // Method to get collision boxes for all items
        public List<ICollisionBox> GetCollisionBoxes() { return _collisionBoxes; }

        public bool IsMovable(ICollisionBox box)
        {
            switch (box.Sprite)
            {
                case PBlock_Square:
                    return true;
                default: return false;
            }
        }

        public bool IsOpenable(ICollisionBox box)
        {
            switch (box.Sprite)
            {
                case FBlock_Wall:
                case FBlock_DiamondHoleLockedDoor:
                case FBlock_KeyHoleLockedDoor:
                    return true;
                default: return false;
            }
        }

        private void SetHealthDamage(ICollisionBox box) { box.Health = 1; box.Damage = 1; }

        private void SetCollision(ICollisionBox box)
        {
            switch (box.Sprite)
            {
                case PBlock_Square:
                case FBlock_StatueDragon:
                case PBlock_Water:
                case SBlock_Invisible:
                case FBlock_DiamondHoleLockedDoor:
                case FBlock_KeyHoleLockedDoor:
                case FBlock_Wall:
                    box.IsCollidable = true; break;
                default:
                    box.IsCollidable = false; break;
            }
        }
    }
}
