using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using static _3902_Project.ILinkStateMachine;


namespace Content.Projectiles
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

        private static IProjectile.DIRECTION getDirection(MOVEMENT movement)
        {
            IProjectile.DIRECTION direction;
            if (movement == MOVEMENT.SUP || movement == MOVEMENT.MUP)
            {
                direction = IProjectile.DIRECTION.UP;
            }
            else if (movement == MOVEMENT.SDOWN || movement == MOVEMENT.MDOWN)
            {
                direction = IProjectile.DIRECTION.DOWN;
            }
            else if (movement == MOVEMENT.MLEFT || movement == MOVEMENT.SLEFT)
            {
                direction = IProjectile.DIRECTION.LEFT;
            }
            else if (movement == MOVEMENT.MRIGHT || movement == MOVEMENT.SRIGHT)
            {
                direction = IProjectile.DIRECTION.RIGHT;
            }
            else
            {
                //defaults to right
                direction = IProjectile.DIRECTION.RIGHT;
            }

            return direction;
        }

		public void launchArrow(int x, int y, MOVEMENT movement)
		{
			IProjectile arrow;

            IProjectile.DIRECTION arrowDirection = getDirection(movement);

            arrow = factory.CreateArrowProjectile(x, y, arrowDirection);

            projectiles.Add(arrow);

        }

        public void launchBlueArrow(int x, int y, MOVEMENT movement)
        {
            IProjectile arrow;

            IProjectile.DIRECTION arrowDirection = getDirection(movement);

            arrow = factory.CreateBlueArrowProjectile(x, y, arrowDirection);

            projectiles.Add(arrow);

        }
        public void launchWoodBoomerang(int x, int y, MOVEMENT movement)
        {
            IProjectile boomerang;

            IProjectile.DIRECTION direction = getDirection(movement);

            boomerang = factory.CreateWoodBoomerangProjectile(x, y, direction);

            projectiles.Add(boomerang);
        }

        public void launchBlueBoomerang(int x, int y, MOVEMENT movement)
        {
            IProjectile boomerang;

            IProjectile.DIRECTION direction = getDirection(movement);

            boomerang = factory.CreateBlueBoomerangProjectile(x, y, direction);

            projectiles.Add(boomerang);
        }


        public void launchBomb(int x, int y)
        {
            IProjectile bomb;

            bomb = factory.CreateBombProjectile(x, y);

            projectiles.Add(bomb);
        }


        public void Update()
        {
            currentFrame++;
            if (currentFrame >= totalFrames)
            {
                currentFrame = 0;
                //updates each projectile in list
                foreach (IProjectile proj in projectiles.ToList())
                {
                    if (proj.getDirection() == (int)IProjectile.DIRECTION.DESTROYED)
                    {
                        projectiles.Remove(proj);
                    }
                    proj.Update();
                }

            }
        }


        public void Draw()
        {
            //draws each projectile in list
            foreach (IProjectile projectile in projectiles) { projectile.Draw(spriteBatch); }
        }
    }
}
