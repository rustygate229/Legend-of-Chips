using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class LinkCollisionHandler : ICollisionHandler
    {
        private LinkManager _link;
        private PlaySoundEffect _sound;
        private EnvironmentFactory _environmentFactory;

        public LinkCollisionHandler() { }

        /// <summary>
        /// Load everything that this handler needs
        /// </summary>
        /// <param name="link">manager for Link</param>
        public void LoadAll(LinkManager link, PlaySoundEffect sound, EnvironmentFactory enviro) { _link = link; _sound = sound; _environmentFactory = enviro;  }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (objectB is EnemyCollisionBox)
                HandleEnemyCollision(objectA, objectB, side);
            else if (objectB is EnemyProjCollisionBox)
                HandleEnemyProjCollision(objectA, objectB, side);
            else if (objectB is BlockCollisionBox)
                HandleBlockCollision(objectA, objectB, side);
            else if (objectB is ItemCollisionBox)
                HandleItemCollision(objectA, objectB, side);
        }


        private void HandleEnemyCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // if link is NOT in damage state, activate the state and remove health from link
            if (_link.IsLinkDamaged == false)
            {
                _sound.PlaySound(PlaySoundEffect.Sounds.Link_Zapped);
                objectA.Health -= objectB.Damage;
                _link.SetDamaged(50, side);
            }
        }

        private void HandleEnemyProjCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // if link is NOT in damage state, activate the state and remove health from link
            if (_link.IsLinkDamaged == false && !_link.IsLinkShieldFaceEnemy(side))
            {
                _sound.PlaySound(PlaySoundEffect.Sounds.Link_Zapped);
                objectA.Health -= objectB.Damage;
                _link.SetDamaged(50, side);
            }
        }


        private void HandleBlockCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (objectB.Sprite is SBlock_Teleport)
            {
                Vector2 startPos = new(0, 900 - (176 * 4));
                float printScale = 4f;
                switch (side)
                {
                    case CollisionData.CollisionType.BOTTOM:    _link.LinkPositionOnWindow = new(startPos.X + (119 * printScale), startPos.Y + (34 * printScale)); break;
                    case CollisionData.CollisionType.TOP:       _link.LinkPositionOnWindow = new(startPos.X + (120 * printScale), startPos.Y + (126 * printScale)); break;
                    case CollisionData.CollisionType.RIGHT:     _link.LinkPositionOnWindow = new(startPos.X + (34 * printScale), startPos.Y + (80 * printScale)); break;
                    case CollisionData.CollisionType.LEFT:      _link.LinkPositionOnWindow = new(startPos.X + (206 * printScale), startPos.Y + (80 * printScale)); break;
                    default: break;
                }

                _environmentFactory.moveToNextRoom(side);
            }
            else
            {
                // Handle player collision with block
                Rectangle BoundsA = objectA.Bounds;
                Rectangle BoundsB = objectB.Bounds;

                switch (side)
                {
                    case CollisionData.CollisionType.BOTTOM:
                        BoundsA.Y = BoundsB.Top - BoundsA.Height; break;    // Move player above the block
                    case CollisionData.CollisionType.TOP:
                        BoundsA.Y = BoundsB.Bottom; break;                  // Move player below the block
                    case CollisionData.CollisionType.RIGHT:
                        BoundsA.X = BoundsB.Left - BoundsA.Width; break;    // Move player to the left of the block
                    case CollisionData.CollisionType.LEFT:
                        BoundsA.X = BoundsB.Right; break;                   // Move player to the right of the block
                    default: break;
                }

                _link.LinkPositionOnWindow = new(BoundsA.X, BoundsA.Y);
            }
        }

        private void HandleItemCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            _link.SetItem(objectB.Sprite);
        }
    }
}