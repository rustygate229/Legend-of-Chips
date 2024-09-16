using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project.Content
{
    public class LinkMovement : ILinkMovement
    {

        private GameTime _gameTime;

        Vector2 _position;

        private float speed;

        public LinkMovement(GameTime gameTime)
        {
            _gameTime = gameTime;

            _position = new Vector2(0, 0);

            speed = 100f;
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
            _position.Y += speed * (float)_gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void moveLeft()
        {
            _position.X -= speed * (float)_gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void moveRight()
        {
            _position.X += speed * (float)_gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void moveUp()
        {
            _position.Y -= speed * (float)_gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
