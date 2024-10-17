using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class LinkMovement : ILinkMovement
    {

        //Vector2 _position;
        ICollisionBox _linkCollisionBox;
        private float speed;

        public LinkMovement()
        {
            //_position = new Vector2(200, 200);

            Microsoft.Xna.Framework.Rectangle bounds = new Microsoft.Xna.Framework.Rectangle(200, 200, 64, 64);
            _linkCollisionBox = new LinkCollisionBox(bounds, true, 100, 10);
            speed = 5f;
        }

        public LinkMovement(int x, int y)
        {
            //specify specific location for link to be made
            Microsoft.Xna.Framework.Rectangle bounds = new Microsoft.Xna.Framework.Rectangle(x, y, 64, 64);
            _linkCollisionBox = new LinkCollisionBox(bounds, true, 100, 10);
            speed = 5f;

        }


        public double getXPosition()
        {
            return _linkCollisionBox.Bounds.X;
        }

        public double getYPosition()
        {
            return _linkCollisionBox.Bounds.Y;
        }

        public void moveDown()
        {
            Rectangle rect = _linkCollisionBox.Bounds;
            rect.Y = rect.Y + (int)speed;

            _linkCollisionBox.Bounds = rect;
        }

        public void moveLeft()
        {
            Rectangle rect = _linkCollisionBox.Bounds;
            rect.X = rect.X - (int)speed;

            _linkCollisionBox.Bounds = rect;
            //_position.X -= speed;
        }

        public void moveRight()
        {
            Rectangle rect = _linkCollisionBox.Bounds;
            rect.X = rect.X + (int)speed;

            _linkCollisionBox.Bounds = rect;
            //_position.X += speed;
        }

        public void moveUp()
        {
            Rectangle rect = _linkCollisionBox.Bounds;
            rect.Y = rect.Y - (int)speed;

            _linkCollisionBox.Bounds = rect;
            //_position.Y -= speed;
        }

        public void setXPosition(double x)
        {
            Rectangle rect = _linkCollisionBox.Bounds;
            rect.X = (int)x;

            _linkCollisionBox.Bounds = rect;
            // _position = new Vector2((float)x, _position.Y);
        }

        public void setYPosition(double y)
        {
            Rectangle rect = _linkCollisionBox.Bounds;
            rect.Y = (int)y;

            _linkCollisionBox.Bounds = rect;

            //_position = new Vector2(_position.X, (float)y);
        }

        public ICollisionBox getCollisionBox() { return _linkCollisionBox; }
    }
}
