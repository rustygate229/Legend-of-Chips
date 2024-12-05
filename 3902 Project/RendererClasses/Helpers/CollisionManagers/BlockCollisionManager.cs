using Microsoft.Xna.Framework;
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
                case SBlock_Teleport:
                case FBlock_WallStop:
                    box.IsCollidable = true; break;
                case FBlock_BombedDoor:
                case FBlock_OpenDoor:
                default:
                    box.IsCollidable = false; break;
            }
        }

        public void ChangeDoors(ICollisionBox current, CollisionData.CollisionType side)
        {
            Vector2 oldPosition = current.Sprite.PositionOnWindow;
            UnloadBlock(current);
            // sadly needs to be accurate to current scaling in Environment
            float printScale = 4F;
            switch (current.Sprite)
            {
                case FBlock_Wall:
                    switch (side)
                    {
                        case CollisionData.CollisionType.BOTTOM:    AddBlock(BlockNames.BombedDoor_DOWN, oldPosition, printScale); break;
                        case CollisionData.CollisionType.TOP:       AddBlock(BlockNames.BombedDoor_UP, oldPosition, printScale); break;
                        case CollisionData.CollisionType.RIGHT:     AddBlock(BlockNames.BombedDoor_RIGHT, oldPosition, printScale); break;
                        case CollisionData.CollisionType.LEFT:      AddBlock(BlockNames.BombedDoor_LEFT, oldPosition, printScale); break;
                        default: break;
                    }
                    break;
                case FBlock_DiamondHoleLockedDoor:
                case FBlock_KeyHoleLockedDoor:
                    switch (side)
                    {
                        case CollisionData.CollisionType.BOTTOM:    AddBlock(BlockNames.OpenDoor_UP, oldPosition, printScale); break;
                        case CollisionData.CollisionType.TOP:       AddBlock(BlockNames.OpenDoor_DOWN, oldPosition, printScale); break;
                        case CollisionData.CollisionType.RIGHT:     AddBlock(BlockNames.OpenDoor_LEFT, oldPosition, printScale); break;
                        case CollisionData.CollisionType.LEFT:      AddBlock(BlockNames.OpenDoor_RIGHT, oldPosition, printScale); break;
                        default: break;
                    }
                    break;
                default: break;
            }
        }

        public void CreateTeleportBlocks(BlockNames name, float printScale)
        {
            // sadly needs to be accurate to current scaling in Environment
            Vector2 startPos = new(0, 900 - (176 * 4));
            int dimScale = (int)(printScale * 8);
            switch (name)
            {
                case BlockNames.BombedDoor_DOWN:    AddBlock(BlockNames.Teleport, new Rectangle((int)(startPos.X + (124 * printScale)), (int)(startPos.Y + (8 * printScale)), dimScale, dimScale), printScale); break;
                case BlockNames.BombedDoor_UP:      AddBlock(BlockNames.Teleport, new Rectangle((int)(startPos.X + (124 * printScale)), (int)(startPos.Y + (160 * printScale)), dimScale, dimScale), printScale); break;
                case BlockNames.BombedDoor_RIGHT:   AddBlock(BlockNames.Teleport, new Rectangle((int)(startPos.X + (8 * printScale)), (int)(startPos.Y + (84 * printScale)), dimScale, dimScale), printScale); break;
                case BlockNames.BombedDoor_LEFT:    AddBlock(BlockNames.Teleport, new Rectangle((int)(startPos.X + (240 * printScale)), (int)(startPos.Y + (84 * printScale)), dimScale, dimScale), printScale); break;
                case BlockNames.OpenDoor_DOWN:      AddBlock(BlockNames.Teleport, new Rectangle((int)(startPos.X + (124 * printScale)), (int)(startPos.Y + (8 * printScale)), dimScale, dimScale), printScale); break;
                case BlockNames.OpenDoor_UP:        AddBlock(BlockNames.Teleport, new Rectangle((int)(startPos.X + (124 * printScale)), (int)(startPos.Y + (160 * printScale)), dimScale, dimScale), printScale); break;
                case BlockNames.OpenDoor_RIGHT:     AddBlock(BlockNames.Teleport, new Rectangle((int)(startPos.X + (8 * printScale)), (int)(startPos.Y + (84 * printScale)), dimScale, dimScale), printScale); break;
                case BlockNames.OpenDoor_LEFT:      AddBlock(BlockNames.Teleport, new Rectangle((int)(startPos.X + (240 * printScale)), (int)(startPos.Y + (84 * printScale)), dimScale, dimScale), printScale); break;
                default: break;
            }
        }
    }
}
