using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class LinkManager
    {
        // Method to get collision boxes for all items
        public List<ICollisionBox> GetCollisionBoxes()
        {
            List<ICollisionBox> link = new List<ICollisionBox>();
            link.Add(_collisionBox);
            return link;
        }

        public ICollisionBox CollisionBox
        {
            get { return _collisionBox; }
            set { _collisionBox = value; }
        }

        public void SetCollision(ICollisionBox box) { box.IsCollidable = true; }

        // ALSO, could add a counter in CanFireProjectile() if needed
        public ProjectileManager.ProjectileNames CurrentProjectile { get { return _inventory.CurrentProjectile; } set { _inventory.CurrentProjectile = value; } }
        private ProjectileManager.ProjectileType _linkProjectile = ProjectileManager.ProjectileType.LinkProj;
        public bool CanFireProjectile()
        {
            if (_inventory.GetProjectileInventory().GetValueOrDefault(CurrentProjectile) > 0)
                return true;
            else
                return false;
        }
        public float PositionAheadScale()
        {
            float scale = 0;
            switch(CurrentProjectile)
            {
                case ProjectileManager.ProjectileNames.Bomb:
                    scale = 0.75F; break;
                case ProjectileManager.ProjectileNames.BlueArrow:
                case ProjectileManager.ProjectileNames.Boomerang:
                case ProjectileManager.ProjectileNames.FireBall:
                    scale = 0.5F; break;
                default:  break;
            }
            return scale;
        }
        public void FireProjectile()
        {
            // create a renderer helper for the GetPositionAhead method
            MovementHelper helper = new(LinkDirection);
            // added this so link fires in front of himself
            if (CanFireProjectile())
            {
                if (CurrentProjectile is ProjectileManager.ProjectileNames.Bomb)
                    _soundEffect.PlaySound(PlaySoundEffect.Sounds.ItemPlace_Bomb);
                _manager.CallProjectile(
                    CurrentProjectile, _linkProjectile, 
                    helper.GetPositionAhead(PositionAheadScale(), LinkDestinationRectangle), _direction, _printScale
                );
                _inventory.RemoveItem(ProjectileConversion(CurrentProjectile), 1);
            }
        }

        private static ItemManager.ItemNames ProjectileConversion(ProjectileManager.ProjectileNames projectile)
        {
            switch (projectile)
            {
                case ProjectileManager.ProjectileNames.BlueArrow:   return ItemManager.ItemNames.BlueArrow;
                case ProjectileManager.ProjectileNames.Bomb:        return ItemManager.ItemNames.Bomb;
                case ProjectileManager.ProjectileNames.Boomerang:   return ItemManager.ItemNames.FlashingBanana;
                default: throw new ArgumentException("There is no conversion for this projectile");
            }
        }

        public bool IsLinkShieldFaceEnemy(CollisionData.CollisionType side)
        {
            if (
                (side.Equals(CollisionData.CollisionType.BOTTOM) && LinkDirection.Equals(Renderer.DIRECTION.DOWN))
                || (side.Equals(CollisionData.CollisionType.TOP) && LinkDirection.Equals(Renderer.DIRECTION.UP))
                || (side.Equals(CollisionData.CollisionType.RIGHT) && LinkDirection.Equals(Renderer.DIRECTION.RIGHT))
                || (side.Equals(CollisionData.CollisionType.LEFT) && LinkDirection.Equals(Renderer.DIRECTION.LEFT))
                )
                return true;
            else return false;
        }


        private int _swordDamageDecrementTotal = 10;
        public bool CanSwordAttack() {
            if (_swordDamageDecrementTotal == 10) return true;
            else return false;
        }
        public void SwordAttack()
        {
            // create a renderer helper for the GetPositionAhead method
            MovementHelper helper = new (LinkDirection);
            // based on what link current sword is and if Link can attack
            if (CanSwordAttack())
            {
                _swordDamageDecrementTotal--;
                switch (_inventory.CurrentLinkSword)
                {
                    case LinkInventory.LinkSwordType.WOOD:
                        _manager.CallProjectile(
                            ProjectileManager.ProjectileNames.WoodSwordAttack, _linkProjectile, 
                            helper.GetPositionAhead(0.4F, LinkDestinationRectangle), _direction, _printScale
                        ); break;
                    case LinkInventory.LinkSwordType.IRON:
                        _manager.CallProjectile(
                            ProjectileManager.ProjectileNames.IronSwordAttack, _linkProjectile,
                            helper.GetPositionAhead(0.4F, LinkDestinationRectangle), _direction, _printScale
                        ); break;
                    case LinkInventory.LinkSwordType.MASTER:
                        _manager.CallProjectile(
                            ProjectileManager.ProjectileNames.MasterSwordAttack, _linkProjectile,
                            helper.GetPositionAhead(0.4F, LinkDestinationRectangle), _direction, _printScale
                        ); break;
                    case LinkInventory.LinkSwordType.STAFF:
                        _manager.CallProjectile(
                            ProjectileManager.ProjectileNames.MagicStaffSAttack, _linkProjectile,
                            helper.GetPositionAhead(0.4F, LinkDestinationRectangle), _direction, _printScale
                        ); break;
                    case LinkInventory.LinkSwordType.DEBUG:
                        _manager.CallProjectile(
                            ProjectileManager.ProjectileNames.DebugSwordAttack, _linkProjectile,
                            helper.GetPositionAhead(0.4F, LinkDestinationRectangle), _direction, _printScale
                        ); break;
                    default: break;
                }
            }
        }
    }
}
