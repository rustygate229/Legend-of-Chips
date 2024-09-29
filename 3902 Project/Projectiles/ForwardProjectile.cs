using System;

namespace _3902_Project
{
	public class ForwardProjectile : IProjectile
	{
		private IProjectile.DIRECTION direction;
		double x, y;
		int speed;
		int timer;
		int currentTime;

        public ForwardProjectile(double x, double y, IProjectile.DIRECTION dir, int speed)
		{
			this.x = x;
			this.y = y;
			direction = dir;
			this.speed = speed;

			//TUNE THIS VALUE LATER IF NEED BE. OR ADD TO CONSTRUCTOR
			timer = 100;
			currentTime = 0;
		}

        public ForwardProjectile(double x, double y, IProjectile.DIRECTION dir, int speed, int timer)
        {
			//overloaded constructor with timer
            this.x = x;
            this.y = y;
            direction = dir;
            this.speed = speed;

            this.timer = timer;
            currentTime = 0;
        }

        public void Update()
		{
			currentTime++;
			if(direction == IProjectile.DIRECTION.UP)
			{
				y += speed;
			} 
			else if (direction == IProjectile.DIRECTION.DOWN)
			{
				y -= speed;
			} 
			else if (direction == IProjectile.DIRECTION.LEFT)
			{
				x -= speed;
			} 
			else
			{ // final is facing right 
				x += speed;
			}

			if (currentTime >= timer || (-4000 <= x && x <= 4000 || -4000 <= y && y <= 4000)) 
			{
				//if it gets too far offscreen or timer runs out
				direction = IProjectile.DIRECTION.DESTROYED;
			}
		}

		public double getXPosition()
		{
			return x;
		}
		public double getYPosition()
		{
			return y;
		}

        public void changeStateMovingUp()
        {
			direction = IProjectile.DIRECTION.UP;
        }

        public void changeStateMovingDown()
        {
            direction = IProjectile.DIRECTION.DOWN;
        }

        public void changeStateMovingLeft()
        {
            direction = IProjectile.DIRECTION.LEFT;
        }

        public void changeStateMovingRight()
        {
            direction = IProjectile.DIRECTION.RIGHT;
        }

        public void changeStateDestroyed()
        {
            direction = IProjectile.DIRECTION.DESTROYED;
        }
    }
}
