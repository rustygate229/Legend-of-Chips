using Microsoft.Xna.Framework.Graphics;
using System;

namespace Content.Projectiles
{
    public class BombProjectile : IProjectile
    {
        private IProjectile.DIRECTION direction;
        double x, y;
        int speed;
        int timer;
        int currentTime = 0;
        private IProjectileSprite sprite;
        private bool explode = false;

        public BombProjectile(double x, double y, IProjectileSprite sprite, IProjectile.DIRECTION dir, int speed, int timer)
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
            if (!explode && currentTime >= 2 * (timer / 3))
            {
                explode = true;

                //TEMPORARILY using enum direction UP to represent explosion sequence
                direction = IProjectile.DIRECTION.UP;

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
