using System;

namespace _3902_Project
{
	public interface IProjectile
    {
        public enum DIRECTION { UP, DOWN, LEFT, RIGHT, DESTROYED}
		void Update();

        double getXPosition();
        double getYPosition();

        /*
        abstract public void changeStateMovingUp();
        abstract public void changeStateMovingDown();
        abstract public void changeStateMovingLeft();
        abstract public void changeStateMovingRight();*/



    }
}
