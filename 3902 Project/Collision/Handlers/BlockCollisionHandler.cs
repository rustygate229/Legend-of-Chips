namespace _3902_Project
{
    public class BlockCollisionHandler : ICollisionHandler
    {
        private BlockManager _block;

        public BlockCollisionHandler() { }

        public void LoadAll(BlockManager block)
        {
            _block = block;
        }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            bool isCollidable = objectA.IsCollidable && objectB.IsCollidable;
            if (isCollidable && objectB is LinkCollisionBox)
                HandleLinkCollision(objectA, objectB, side);
        }

        private void HandleLinkCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // add link moving the block logic
        }
    }
}