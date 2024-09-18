using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public class LinkMovement : ILinkMovement
    {

        private float _movementTime;

        Vector2 _position;

        private float speed;

        public LinkMovement()
        {
            _position = new Vector2(0, 0);
            speed = 100f;
        }

        public void timeSinceLastUpdate(GameTime gameTime)
        {
            _movementTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public double getXPosition()
        {
            return _position.X;
        }

        public double getYPosition()
        {
            return _position.Y;
        }

        public void moveDown()
        {
            _position.Y += speed * _movementTime;
        }

        public void moveLeft()
        {
            _position.X -= speed * _movementTime;
        }

        public void moveRight()
        {
            _position.X += speed * _movementTime;
        }

        public void moveUp()
        {
            _position.Y -= speed * _movementTime;
        }
    }
}
