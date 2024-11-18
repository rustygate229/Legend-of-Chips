using System.Collections.Generic;

namespace _3902_Project
{
    public partial class ProjectileManager
    {
        public List<ICollisionBox> GetCollisionBoxes() { return _collisionBoxes; }

        public List<IPJoiner> GetJoinerSprites() { return _runningProjectileJoiners; }

        public bool IsDamagable(ICollisionBox box)
        {
            switch (box.Sprite)
            {
                // *NOTE* also implement bomb being moved away from a block collision when placed
                case PSprite_BombCloud:
                    return false;
                default: return box.IsCollidable;
            }
        }

        public void SetDamageHealth(ICollisionBox box)
        {
            switch (box.Sprite)
            {
                case PSprite_BlueArrow:     box.Health = 1; box.Damage = 3; break;
                case PSprite_FireBall:      box.Health = 1; box.Damage = 1; break;
                case PSprite_BombCloud:     box.Health = 1; box.Damage = 3; break;
                default:                    box.Health = 1; box.Damage = 0; break;
            }
        }

        public void SetCollidable(ICollisionBox box)
        {
            switch (box.Sprite)
            {
                case PSprite_BlueArrow:
                case PSprite_FireBall:
                case PSprite_BombCloud:
                    box.IsCollidable = true;
                    break;
                case PSprite_SmallExplosion:
                // bomb will become collidable since it needs to not be on top of blocks
                case PSprite_Bomb:
                case PSprite_Fire:
                    box.IsCollidable = false;
                    break;
                default:
                    box.IsCollidable = false;
                    break;
            }
        }
    }
}