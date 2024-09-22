using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public class LinkStateMachine : ILinkStateMachine
{
        public enum MOVEMENT { SUP, SDOWN, SLEFT, SRIGHT , MUP, MDOWN, MLEFT, MRIGHT}
        public enum ATTACK { YES, NO }

        private MOVEMENT _moveState;
        private ATTACK _attack;

        public LinkStateMachine()
        {
            _moveState = MOVEMENT.SDOWN;
            _attack = ATTACK.NO;
        }

        public int getMovementState()
        {
            return (int) _moveState;
        }

        public int getAttackState() { return (int) _attack; }

        public void changeStateMovingUp()
        {
            _moveState = MOVEMENT.MUP;
        }

        public void changeStateMovingDown()
        {
            _moveState = MOVEMENT.MDOWN;
        }

        public void changeStateMovingLeft()
        {
            _moveState = MOVEMENT.MLEFT;
        }

        public void changeStateMovingRight()
        {
            _moveState = MOVEMENT.MRIGHT;
        }

        public void changeStateStillUp()
        {
            _moveState = MOVEMENT.SUP;
        }

        public void changeStateStillDown()
        {
            _moveState = MOVEMENT.SDOWN;
        }

        public void changeStateStillLeft()
        {
            _moveState = MOVEMENT.SLEFT;
        }

        public void changeStateStillRight()
        {
            _moveState = MOVEMENT.SRIGHT;
        }

        public void setAttack()
        {
            _attack = ATTACK.YES;
        }

        public void stopAttack()
        {
            _attack = ATTACK.NO;
        }
    }
}
