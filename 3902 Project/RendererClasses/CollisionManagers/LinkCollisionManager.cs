using Microsoft.Xna.Framework;
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
        private ProjectileManager.ProjectileNames _currentProjectile;
        public ProjectileManager.ProjectileNames CurrentProjectile { get { return _currentProjectile; } set { _currentProjectile = value; } }
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
                case ProjectileManager.ProjectileNames.BlueArrow:
                case ProjectileManager.ProjectileNames.Boomerang:
                case ProjectileManager.ProjectileNames.Bomb:
                case ProjectileManager.ProjectileNames.FireBall:
                    scale = 0.5F;
                    break;
                default:  break;
            }
            return scale;
        }
        public void FireProjectile()
        {
            // create a renderer helper for the GetPositionAhead method
            Renderer rendererHelper = new Renderer(_currentLink, GetLinkPosition(), _direction, _printScale);
            // added this so link fires in front of himself
            if (CanFireProjectile())
            {
                _manager.CallProjectile(CurrentProjectile, ProjectileManager.ProjectileType.LinkProj, rendererHelper.GetPositionAhead(PositionAheadScale()), _direction, _printScale);
                _inventory.RemoveItem(CurrentProjectile, 1);
                Console.WriteLine("Current Projectile: " + CurrentProjectile.ToString());
                Console.WriteLine("Amount of Projectile: " + _inventory.GetProjectileInventory().GetValueOrDefault(CurrentProjectile) + "\n");
            }
        }


        private int _swordDamageDecrementTotal = 10;
        public bool CanSwordAttack() {
            if (_swordDamageDecrementTotal == 10) return true;
            else return false;
        }
        public void SwordAttack()
        {
            // create a renderer helper for the GetPositionAhead method
            Renderer rendererHelper = new Renderer(_currentLink, GetLinkPosition(), _direction, _printScale);
            // based on what link current sword is and if Link can attack
            if (CanSwordAttack())
            {
                _swordDamageDecrementTotal--;
                switch (_inventory.CurrentLinkSword)
                {
                    case LinkInventory.LinkSwordType.WOOD:
                        _manager.CallProjectile(ProjectileManager.ProjectileNames.WoodSwordAttack, _linkProjectile, rendererHelper.GetPositionAhead(0.3F), _direction, _printScale);
                        break;
                    default: break;
                }
            }
        }
    }
}
