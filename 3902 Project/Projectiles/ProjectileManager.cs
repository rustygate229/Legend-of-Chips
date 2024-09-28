using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace _3902_Project
{
	public class ProjectileManager
	{
		List<IProjectile> projectiles;
		ContentManager content;
		SpriteBatch spriteBatch;
		ProjectileFactory factory;
		private int currentFrame = 0;
		private int totalFrames = 3;


		public ProjectileManager(ContentManager c, SpriteBatch _spritebatch)
		{
			projectiles = new List<IProjectile>();
			content = c;
			spriteBatch = _spritebatch;

			ProjectileFactory.Instance.LoadAllTextures(c);
			factory = ProjectileFactory.Instance;
		}

		public void launchArrow(int x, int y, LinkStateMachine.MOVEMENT movement)
		{
			IProjectile arrow;
			if (movement == LinkStateMachine.MOVEMENT.SUP || movement == LinkStateMachine.MOVEMENT.MUP)
			{
				arrow = factory.CreateArrowProjectile(x, y, IProjectile.DIRECTION.UP);
			}
			else if(movement == LinkStateMachine.MOVEMENT.SDOWN || movement == LinkStateMachine.MOVEMENT.MDOWN)
			{
				arrow = factory.CreateArrowProjectile(x, y, IProjectile.DIRECTION.DOWN);
			}
			else if(movement == LinkStateMachine.MOVEMENT.MLEFT || movement == LinkStateMachine.MOVEMENT.SLEFT)
			{
				arrow = factory.CreateArrowProjectile(x, y, IProjectile.DIRECTION.LEFT);
            }
			else
			{
				//defaults to right
				arrow = factory.CreateArrowProjectile(x, y, IProjectile.DIRECTION.RIGHT);
			}

			projectiles.Add(arrow);

		}
		public void launchBoomerang()
		{

		}


		public void launchBomb()
		{

		}


        public void Update()
        {
            currentFrame++;
            if (currentFrame >= totalFrames)
            {
                currentFrame = 0;
                //updates each projectile in list
                //may want to add some sort of timer to this later so projs aren't INSTANTLY removed when destroyed
                foreach (IProjectile proj in projectiles.ToList())
                {
                    /*if (proj.getDirection() == (int)(IProjectile.DIRECTION.DESTROYED))
                    {
                        projectiles.Remove(proj);
                    }*/
                    proj.Update();
                }

            }
        }


        public void Draw()
		{
			//draws each projectile in list
			foreach(IProjectile projectile in projectiles) { projectile.Draw(spriteBatch); }
		}
	}
}
