using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class DamageHelper
    {
        private int _counter;
        private int _counterTotal;
        private IFlashing _sprite;
        public IFlashing Sprite { get { return _sprite; } set { _sprite = value; } }
        private CollisionData.CollisionType _side;
        private bool _colorFlip = false;

        private bool _isDamaged = false;
        public bool IsDamaged { get { return _isDamaged; } set { _isDamaged = value; } }

        private Vector2 _position;
        public Vector2 Position { get { return _position; } set { _position = value; } }

        public DamageHelper() { }

        public void SetDamageHelper(int counter, IFlashing sprite, CollisionData.CollisionType side)
        {
            _counter = 0;
            _counterTotal = counter;
            _sprite = sprite;
            _side = side;
        }

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
                // send  backwards for 7 frames once damaged at 10 positions a frame
                if (_counter < 10)
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
                    Position = _sprite.GetVectorPosition() + updatePosition;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_colorFlip)
                _sprite.Draw(spriteBatch, Color.OrangeRed);
            else
                _sprite.Draw(spriteBatch, Color.White);
        }
    }
}