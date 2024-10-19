namespace _3902_Project
{
    public interface ILinkStateMachine
    {

        public enum MOVEMENT { SUP, SDOWN, SLEFT, SRIGHT, MUP, MDOWN, MLEFT, MRIGHT }
        public enum ATTACK { MELEE, THROW, NO }

        MOVEMENT getMovementState();
        ATTACK getAttackState();

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

        bool getDamage();
        void setDamage();
        void stopDamage();

        void setInventory1();
        void setInventory2(); 
        void setInventory3();
        int getInventory();
    }
}
