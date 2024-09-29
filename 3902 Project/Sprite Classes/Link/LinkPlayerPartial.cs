using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902_Project.ILinkStateMachine;

namespace _3902_Project.Link
{
    public partial class LinkPlayer
    {
        IAnimation _animation;
        ILinkMovement _linkMovement;
        ILinkStateMachine _linkStateMachine;
        private bool CannotMove()
        {
            return (_linkStateMachine.getAttackState() == ATTACK.THROW
                || _linkStateMachine.getDamage());
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
    }
}
