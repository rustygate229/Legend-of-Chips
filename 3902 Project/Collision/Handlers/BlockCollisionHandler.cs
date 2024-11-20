namespace _3902_Project
{
    public class BlockCollisionHandler : ICollisionHandler
    {
        private BlockManager _block;

        public BlockCollisionHandler() { }

        /// <summary>
        /// Load everything that this handler needs
        /// </summary>
        /// <param name="block">manager for blocks</param>
        public void LoadAll(BlockManager block) { _block = block; }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (objectB is LinkCollisionBox)
                HandleLinkCollision(objectA, objectB, side);
        }

        private void HandleLinkCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // add link moving the block logic
            if (_block.IsMovable(objectA))
            {

            }
            
            // destroy block logic
            if (_block.IsDestroyable(objectA))
            {
                objectA.Health -= objectB.Damage;
            }
        }
    }
}