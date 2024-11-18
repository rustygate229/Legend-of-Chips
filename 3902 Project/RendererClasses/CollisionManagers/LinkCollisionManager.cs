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

        private int _linkDamagedStateCounter = 0;
        private int _linkDamagedStateCounterTotal = 50;
        private bool _linkDamagedState { get; set; }
        private bool _linkColorFlip = false;
        public bool IsLinkDamaged
        {
            get { return _linkDamagedState; }
            set { _linkDamagedState = value; }
        }

        public void flipDamaged() { _linkDamagedState = !_linkDamagedState; }

        public void SetDamagedState()
        {
            if (_linkDamagedStateCounter == _linkDamagedStateCounterTotal)
                IsLinkDamaged = false;
            else
            {
                _linkColorFlip = !_linkColorFlip;
                // send link backwards for 10 frames once damaged
                if (_linkDamagedStateCounter < 10)
                {
                    float positionSpeed = 10;
                    Vector2 updatePosition = new (0, 0);
                    switch (_direction)
                    {
                        case Renderer.DIRECTION.DOWN:    updatePosition = new (0, Math.Abs(positionSpeed)); break;
                        case Renderer.DIRECTION.UP:      updatePosition = new (0, -(Math.Abs(positionSpeed))); break;
                        case Renderer.DIRECTION.RIGHT:   updatePosition = new (Math.Abs(positionSpeed), 0); break;
                        case Renderer.DIRECTION.LEFT:    updatePosition = new (-(Math.Abs(positionSpeed)), 0); break;
                        default: break;
                    }
                    SetLinkPosition(_position + updatePosition);
                }

            }
        }

    }
}
