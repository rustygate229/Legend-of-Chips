 using Microsoft.Xna.Framework.Graphics;
using System;

namespace Content.Projectiles
{
    public interface IProjectile
    {
        public enum DIRECTION { UP, DOWN, LEFT, RIGHT, DESTROYED }
        void Update();

        void Draw(SpriteBatch sb);

        double getXPosition();
        double getYPosition();

        int getDirection();


        /*
        abstract public void changeStateMovingUp();
        abstract public void changeStateMovingDown();
        abstract public void changeStateMovingLeft();
        abstract public void changeStateMovingRight();
        */


    }
}
