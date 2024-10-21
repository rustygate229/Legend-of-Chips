using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class ForwardProjectile : IProjectile
    {
        private IProjectile.DIRECTION direction;
        double x, y;
        int speed;
        int timer;
        int currentTime = 0;
        private IProjectileSprite sprite;

        public ForwardProjectile(double x, double y, IProjectileSprite sprite, IProjectile.DIRECTION dir, int speed)
        {
            this.x = x;
            this.y = y;
            this.sprite = sprite;
            direction = dir;
            this.speed = speed;

            //TUNE THIS VALUE LATER IF NEED BE. OR ADD TO CONSTRUCTOR
            timer = 25;
        }

        public ForwardProjectile(double x, double y, IProjectileSprite sprite, IProjectile.DIRECTION dir, int speed, int timer)
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
            if (direction == IProjectile.DIRECTION.UP)
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
            else if (direction == IProjectile.DIRECTION.RIGHT) { x += speed; }
            //do nothing if destroyed

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

        public int getDirection()
        {
            return (int)direction;
        }
    }
}
