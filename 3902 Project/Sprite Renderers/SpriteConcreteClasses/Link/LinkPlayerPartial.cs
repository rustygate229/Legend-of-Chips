﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using static _3902_Project.ILinkStateMachine;

namespace _3902_Project
{
    public partial class LinkPlayer
    {

        public void AddItem(ItemManager.ItemNames name, int amount)
        {
            //some items immediately add health so must be handled in here
            //other items are handled by link inventory so must be passed into there
            switch (name)
            {
                case ItemManager.ItemNames.FlashingArrow:
                    _linkInventory.addProjectiles(LinkInventory.LINK_PROJECTILES.BLUE_ARROW, amount); break;

                case ItemManager.ItemNames.Bomb:
                    _linkInventory.addProjectiles(LinkInventory.LINK_PROJECTILES.BOMB, amount); break;

                case ItemManager.ItemNames.FlashingLife:
                    _linkMovement.getCollisionBox().Health += amount;
                    break;


                default: break;
            }

        }

        private List<Tuple<ISprite, int>> _currentProjectiles = new List<Tuple<ISprite, int>> ();

        public void FireProjectile()
        {
            int inventory = _linkStateMachine.getInventory();
            bool canFire = _linkInventory.canFireProjectiles(inventory);

            if (canFire)
            {
                MOVEMENT direction = _linkStateMachine.getMovementState();
                Vector2 linkPosition = new((int)_linkMovement.getXPosition(), (int)_linkMovement.getYPosition());

                switch (_linkStateMachine.getInventory())
                {
                    case 1:
                        float[] frameRangeArrow = { 0.85f };
                        _currentProjectiles.Add(new Tuple<ISprite, int>(_projectileManager.CallProjectile(ProjectileManager.ProjectileNames.BlueArrow, linkPosition, (int)direction, 200, 4f, 4f, frameRangeArrow), 190)); break;
                    case 2:
                        float[] frameRangeBomb = { 0.50f, 0.70f };
                        _currentProjectiles.Add(new Tuple<ISprite, int>(_projectileManager.CallProjectile(ProjectileManager.ProjectileNames.Bomb, linkPosition, (int)direction, 150, 2f, 4f, frameRangeBomb), 140)); break;
                    case 3:
                        _currentProjectiles.Add(new Tuple<ISprite, int>(_projectileManager.CallProjectile(ProjectileManager.ProjectileNames.FireBall, linkPosition, (int)direction, 70, 8f, 4f, 15), 60)); break;

                    default: break;
                }
            }
        }

        public void MoveUp()
        {
            if (CannotMove()) { return; }
            _linkStateMachine.changeStateMovingUp();
            _linkMovement.moveUp();
        }

        public void MoveDown()
        {
            if (CannotMove()) { return; }
            _linkStateMachine.changeStateMovingDown();
            _linkMovement.moveDown();
        }
        public void MoveLeft()
        {
            if (CannotMove()) { return; }
            _linkStateMachine.changeStateMovingLeft();
            _linkMovement.moveLeft();
        }

        public void MoveRight()
        {
            if (CannotMove()) { return; }
            _linkStateMachine.changeStateMovingRight();
            _linkMovement.moveRight();
        }
        public void StayStill()
        {
            switch (_linkStateMachine.getMovementState())
            {
                case MOVEMENT.MUP:
                    _linkStateMachine.changeStateStillUp(); break;
                case MOVEMENT.MLEFT:
                    _linkStateMachine.changeStateStillLeft(); break;
                case MOVEMENT.MRIGHT:
                    _linkStateMachine.changeStateStillRight(); break;
                case MOVEMENT.MDOWN:
                    _linkStateMachine.changeStateStillDown(); break;
                default: break;
            }
        }
        public void Draw()
        {
            int x = (int)_linkMovement.getXPosition();
            int y = (int)_linkMovement.getYPosition();

            if (_linkStateMachine.getDamage())
            {
                _animation.AnimDamaged(x, y);
            }

            switch (_linkStateMachine.getAttackState())
            {
                case ATTACK.MELEE:
                    _animation.AnimAttack(x, y); return;
                case ATTACK.THROW:
                    _animation.AnimItem(x, y); return;

                default: break;
            }

            switch (_linkStateMachine.getMovementState())
            {
                case MOVEMENT.MUP:
                case MOVEMENT.MDOWN:
                case MOVEMENT.MLEFT:
                case MOVEMENT.MRIGHT:
                    _animation.AnimMoving(x, y); break;

                case MOVEMENT.SUP:
                case MOVEMENT.SDOWN:
                case MOVEMENT.SLEFT:
                case MOVEMENT.SRIGHT:
                    _animation.AnimStationary(x, y); break;

                default:
                    break;
            }
        }
    }
}
