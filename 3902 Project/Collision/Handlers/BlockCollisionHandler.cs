using System.Collections.Generic;
using _3902_Project;
using Microsoft.Xna.Framework;


namespace _3902_Project
{
    public class BlockCollisionHandler : ICollisionHandler
    {
        private List<BlockCollisionBox> _blocks;

        public BlockCollisionHandler(List<BlockCollisionBox> blocks)
        {
            _blocks = blocks;
        }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
        {
            BlockCollisionBox block = objectA as BlockCollisionBox ?? objectB as BlockCollisionBox;
            LinkCollisionBox player = objectA as LinkCollisionBox ?? objectB as LinkCollisionBox;

            if (block != null && player != null && block.IsCollidable)
            {
                // Prevent player from moving through block
                PreventPlayerMovement(player, block,side);
            }
        }

        private void PreventPlayerMovement(LinkCollisionBox player, BlockCollisionBox block, CollisionType side)
        {
            // Logic to prevent the player from moving through the block
            if (player != null && block != null)
            {
                switch (CollisionDetector.DetermineCollisionSide(player, block))
                {
                    case CollisionType.LEFT:
                        player.Bounds = new Rectangle(player.Bounds.X + 5, player.Bounds.Y, player.Bounds.Width, player.Bounds.Height);
                        break;
                    case CollisionType.RIGHT:
                        player.Bounds = new Rectangle(player.Bounds.X - 5, player.Bounds.Y, player.Bounds.Width, player.Bounds.Height);
                        break;
                    case CollisionType.TOP:
                        player.Bounds = new Rectangle(player.Bounds.X, player.Bounds.Y + 5, player.Bounds.Width, player.Bounds.Height);
                        break;
                    case CollisionType.BOTTOM:
                        player.Bounds = new Rectangle(player.Bounds.X, player.Bounds.Y - 5, player.Bounds.Width, player.Bounds.Height);
                        break;
                }
            }
        }
    }
}
