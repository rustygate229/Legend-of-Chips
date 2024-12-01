using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class DamageHelper
    {
        private int _counter = 0;
        private bool _colorFlip = false;

        private int _counterTotal = 50;
        public int CounterTotal { get { return _counterTotal; } set { _counterTotal = value; } }

        private CollisionData.CollisionType _side;
        public CollisionData.CollisionType CollisionSide { get { return _side; } set { _side = value; } }

        private ISprite _currentSprite;
        public ISprite CurrentSprite { get { return _currentSprite; } set { _currentSprite = value; } }

        private bool _isDamaged = false;
        public bool IsDamaged { get { return _isDamaged; } set { _isDamaged = value; } }

        private bool _sendBackwards = false;
        public bool SendBackwards { get { return _sendBackwards; } set { _sendBackwards = value; } }

        public Vector2 PositionOnWindow { get { return CurrentSprite.PositionOnWindow; } set { CurrentSprite.PositionOnWindow = value; } }
        public Rectangle DestinationRectangle { get { return CurrentSprite.DestinationRectangle; } set { CurrentSprite.DestinationRectangle = value; } }

        public DamageHelper() { }

        public void UpdateDamagedState()
        {
            if (_counter >= _counterTotal)
            {
                IsDamaged = false;
                _counter = 0;
            }
            else
            {
                _counter++;
                _colorFlip = !_colorFlip;
                if (SendBackwards)
                    SendEntityBackwards(10);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_colorFlip)
                (CurrentSprite as IColor).Draw(spriteBatch, Color.Red);
            else
                (CurrentSprite as IColor).Draw(spriteBatch, Color.White);
        }


        private void SendEntityBackwards(int amount)
        {
            // send  backwards for 7 frames once damaged at 10 positions a frame
            if (_counter < amount)
            {
                float positionSpeed = 7;
                Vector2 updatePosition = new(0, 0);
                switch (_side)
                {
                    case CollisionData.CollisionType.BOTTOM: updatePosition = new(0, -(Math.Abs(positionSpeed))); break;
                    case CollisionData.CollisionType.TOP: updatePosition = new(0, Math.Abs(positionSpeed)); break;
                    case CollisionData.CollisionType.RIGHT: updatePosition = new(-(Math.Abs(positionSpeed)), 0); break;
                    case CollisionData.CollisionType.LEFT: updatePosition = new(Math.Abs(positionSpeed), 0); break;
                    default: break;
                }
                CurrentSprite.PositionOnWindow += updatePosition;
            }
        }
    }
}