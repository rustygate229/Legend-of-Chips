using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class LinkMovement : ILinkMovement
    {

        Vector2 _position;
        private float speed;

        public LinkMovement()
        {
            _position = new Vector2(200, 200);
            speed = 5f;
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
