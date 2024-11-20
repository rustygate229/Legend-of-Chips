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

        public void SetCollision(ICollisionBox box) { box.IsCollidable = true; }

        // IMPORTANT: THIS HEALTH NEEDS TO MATCH THE MATH FOR THE IN GAME HUD HEALTH BAR - added the health as a parameter for just passing it
        public void SetHealthDamage(ICollisionBox box, int health) { box.Health = 10; box.Damage = 0; }

        private CollisionData.CollisionType _collisionDetectedSide;
        public void SetCollisionSide(CollisionData.CollisionType side) { _collisionDetectedSide = side; }

        private int _linkDamagedStateCounter = 0;
        private int _linkDamagedStateCounterTotal = 50;
        private bool _linkDamagedState { get; set; }
        private bool _linkColorFlip = false;
        public bool IsLinkDamaged { get { return _linkDamagedState; } set { _linkDamagedState = value; } }

        public void flipDamaged() { _linkDamagedState = !_linkDamagedState; }

        public void UpdateDamagedState()
        {
            if (_linkDamagedStateCounter >= _linkDamagedStateCounterTotal)
            {
                IsLinkDamaged = false;
                _linkDamagedStateCounter = 0;
            }
            else
            {
                _linkColorFlip = !_linkColorFlip;
                // send link backwards for 7 frames once damaged at 10 positions a frame
                if (_linkDamagedStateCounter < 10)
                {
                    float positionSpeed = 7;
                    Vector2 updatePosition = new(0, 0);
                    switch (_collisionDetectedSide)
                    {
                        case CollisionData.CollisionType.BOTTOM: updatePosition = new(0, -(Math.Abs(positionSpeed))); break;
                        case CollisionData.CollisionType.TOP: updatePosition = new(0, Math.Abs(positionSpeed)); break;
                        case CollisionData.CollisionType.RIGHT: updatePosition = new(-(Math.Abs(positionSpeed)), 0); break;
                        case CollisionData.CollisionType.LEFT: updatePosition = new(Math.Abs(positionSpeed), 0); break;
                        default: break;
                    }
                    SetLinkPosition(_position + updatePosition);
                }
            }
        }

        public void SetItem(ISprite item)
        {
            switch (item)
            {
                // gave 10 for testing purpose
                case AItem_FArrow: _inventory.AddItem(ProjectileManager.ProjectileNames.BlueArrow, 10); break;
                default: break;
            }
        }

        private ProjectileManager.ProjectileNames _currentProjectile;
        public ProjectileManager.ProjectileNames CurrentProjectile { get { return _currentProjectile; } set { _currentProjectile = value; } }
        public bool CanFireProjectile()
        {
            if (_inventory.GetProjectileInventory().GetValueOrDefault(CurrentProjectile) > 0)
                return true;
            else
                return false;
        }
        public void FireProjectile()
        {
            // create a renderer helper for the GetPositionAhead method
            Renderer rendererHelper = new Renderer(_currentLink, GetLinkPosition(), _direction, _printScale);
            // added this so link fires in front of himself
            if (CanFireProjectile())
            {
                _manager.CallProjectile(CurrentProjectile, ProjectileManager.ProjectileType.LinkProj, rendererHelper.GetPositionAhead(), _direction, _printScale);
            }
        }


        private int _swordAttackDecrement;
        private int _swordDamageDecrementTotal = 20;
        public void SwordAttack()
        {
            if (_swordDamageDecrementTotal < _swordAttackDecrement)
            {

            }
        }
    }
}
