using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public interface ILinkStateMachine
    {
            int getMovementState();
            int getAttackState();

            void changeStateMovingUp();
            void changeStateMovingDown();
            void changeStateMovingLeft();
            void changeStateMovingRight();
            void changeStateStillUp();
            void changeStateStillDown();
            void changeStateStillLeft();
            void changeStateStillRight();

            void setMelee();
            void setThrow();
            void stopAttack();
    }
}
