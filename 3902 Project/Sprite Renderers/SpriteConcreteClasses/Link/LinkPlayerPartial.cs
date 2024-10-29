using static _3902_Project.ILinkStateMachine;

namespace _3902_Project
{
    public partial class LinkPlayer
    {

        public void FireProjectile()
        {
            int inventory = _linkStateMachine.getInventory();
            bool canFire = _linkInventory.canFireProjectiles(inventory);

            if (canFire)
            {
                MOVEMENT dir = _linkStateMachine.getMovementState();
                int x = (int)_linkMovement.getXPosition();
                int y = (int)_linkMovement.getYPosition();

                switch (_linkStateMachine.getInventory())
                {
                    case 1:
                        _projectileManager.launchBlueArrow(x, y, dir); break;
                    case 2:
                        _projectileManager.launchBomb(x, y); break;
                    case 3:
                        _projectileManager.launchBlueBoomerang(x, y, dir); break;

                    default: break;
                }
            }
            */
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
