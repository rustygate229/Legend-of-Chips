using static _3902_Project.ILinkStateMachine;

namespace _3902_Project
{
    public class LinkStateMachine : ILinkStateMachine
    {

        private int Inventory;
        private bool Damage;
        private MOVEMENT _moveState;
        private ATTACK _attack;

        public LinkStateMachine()
        {
            _moveState = MOVEMENT.SDOWN;
            _attack = ATTACK.NO;
            Damage = false;
            Inventory = 1;
        }

        public MOVEMENT getMovementState() { return _moveState; }
        public ATTACK getAttackState() { return _attack; }
        public void changeStateMovingUp() { _moveState = MOVEMENT.MUP; }
        public void changeStateMovingDown() { _moveState = MOVEMENT.MDOWN; }
        public void changeStateMovingLeft() { _moveState = MOVEMENT.MLEFT; }

        public void changeStateMovingRight() { _moveState = MOVEMENT.MRIGHT; }

        public void changeStateStillUp()
        {
            _moveState = MOVEMENT.SUP;
        }

        public void changeStateStillDown()
        {
            _moveState = MOVEMENT.SDOWN;
        }

        public void changeStateStillLeft() { _moveState = MOVEMENT.SLEFT; }

        public void changeStateStillRight() { _moveState = MOVEMENT.SRIGHT; }

        public void setMelee()
        {
            _attack = ATTACK.MELEE;
        }

        public void setThrow() { _attack = ATTACK.THROW; }
        public void stopAttack() { _attack = ATTACK.NO; }
        public bool getDamage() { return Damage;}

        public void setDamage() { Damage = true; }
        public void stopDamage() { Damage = false; }
        public void setInventory1() { Inventory = 1; }
        public void setInventory2() { Inventory = 2; }
        public void setInventory3() { Inventory = 3; }
        public int getInventory() { return Inventory;}
    }
}
