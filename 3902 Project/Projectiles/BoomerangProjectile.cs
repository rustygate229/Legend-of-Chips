using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
	public class BoomerangProjectile : IProjectile
	{
		private IProjectile.DIRECTION direction;
		double x, y;
		private int speed;
		private int timer;
		private int currentTime = 0;
		private IProjectileSprite sprite;
        private bool reversed = false;


        public BoomerangProjectile(double x, double y, IProjectileSprite sprite, IProjectile.DIRECTION dir, int speed, int timer)
        {
			//overloaded constructor with timer
            this.x = x;
            this.y = y;
            this.sprite = sprite;
            direction = dir;
            this.speed = speed;

            this.timer = timer;
        }

        public void Update()
		{
			currentTime++;
			if(direction == IProjectile.DIRECTION.UP)
			{
				y -= speed;
			} 
			else if (direction == IProjectile.DIRECTION.DOWN)
			{
				y += speed;
			} 
			else if (direction == IProjectile.DIRECTION.LEFT)
			{
				x -= speed;
			} 
			else if(direction == IProjectile.DIRECTION.RIGHT) 
            { 
                x += speed; 
            }
            //do nothing if destroyed

            if (!reversed && currentTime >= timer / 2)
            {
                //flips projectile after some allotted time AND DOES NOT FLIP AGAIN

                reversed = true;

                if (direction == IProjectile.DIRECTION.UP)
                {
                    direction = IProjectile.DIRECTION.DOWN;
                }
                else if (direction == IProjectile.DIRECTION.DOWN)
                {
                   direction = IProjectile.DIRECTION.UP;
                }
                else if (direction == IProjectile.DIRECTION.LEFT)
                {
                    direction = IProjectile.DIRECTION.RIGHT;
                }
                else if (direction == IProjectile.DIRECTION.RIGHT) 
                {
                    direction = IProjectile.DIRECTION.LEFT;
                }

            }

            if (currentTime >= timer) 
			{
				//if timer runs out
				direction = IProjectile.DIRECTION.DESTROYED;

            }

			sprite.Update();
		}

		public double getXPosition()
		{
			return x;
		}
		public double getYPosition()
		{
			return y;
		}

        public void Draw(SpriteBatch sb)
        {
			//draws sprite
			sprite.Draw(sb, direction, (int)x, (int)y);
        }

        public int getDirection()
        {
            return (int)direction;
        }
    }
}
