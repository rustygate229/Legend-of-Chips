namespace _3902_Project
{
    public interface ILinkStateMachine
    {

        public enum MOVEMENT { SDOWN, SUP, SRIGHT, SLEFT, MDOWN, MUP, MRIGHT, MLEFT }
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

        void setInventory(int num);
        int getInventory();
    }
}
