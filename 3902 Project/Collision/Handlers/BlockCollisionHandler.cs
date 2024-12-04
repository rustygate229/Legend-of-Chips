namespace _3902_Project
{
    public class BlockCollisionHandler : ICollisionHandler
    {
        private BlockManager _block;
        private PlaySoundEffect _sound;
        private LinkManager _link;

        public BlockCollisionHandler() { }

        /// <summary>
        /// Load everything that this handler needs
        /// </summary>
        /// <param name="block">manager for blocks</param>
        public void LoadAll(BlockManager block, PlaySoundEffect sound, LinkManager link) { _block = block; _sound = sound; _link = link; }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (objectB is LinkCollisionBox)
                HandleLinkCollision(objectA, objectB, side);
            if (objectB is LinkProjCollisionBox)
                HandleLinkProjectileCollision(objectA, objectB, side);

            if (objectA.Health <= 0)
                _block.ChangeDoors(objectA, side);
        }

        private void HandleLinkCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // add link moving the block logic
            if (_block.IsMovable(objectA))
            {
                
            }
            
            // destroy block logic
            if (_block.IsOpenable(objectA))
            {
                switch (objectA.Sprite)
                {
                    case FBlock_DiamondHoleLockedDoor:
                    case FBlock_KeyHoleLockedDoor:
                        if (_link.GetLinkInventory().KeyAmount > 0)
                        {
                            // call move sprite here
                            _sound.PlaySound(PlaySoundEffect.Sounds.Block_DoorOpens);
                            _block.ChangeDoors(objectA, side);
                            _link.GetLinkInventory().KeyAmount -= 1;
                        }
                        break;
                    default: break;
                }
            }
        }

        private void HandleLinkProjectileCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (objectB.Sprite is PSprite_BombCloud && _block.IsOpenable(objectA))
            {
                objectA.Health -= objectB.Damage;
            }
        }
    }
}