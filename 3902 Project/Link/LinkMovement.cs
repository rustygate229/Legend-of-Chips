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

        Vector2 _position;
        private float speed;

        public LinkMovement()
        {
            _position = new Vector2(200, 200);
            speed = 15f;
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
            _position.Y += speed;
        }

        public void moveLeft()
        {
            _position.X -= speed;
        }

        public void moveRight()
        {
            _position.X += speed;
        }

        public void moveUp()
        {
            _position.Y -= speed;
        }
    }
}
