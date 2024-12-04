using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class StoryScreen : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteScreen1 = new(1, 250, 256, 224);
        private Rectangle _spriteScreen2 = new(258, 250, 256, 224);
        private Rectangle _spriteScreen3 = new(515, 250, 256, 224);
        private Rectangle _spriteScreen4 = new(772, 250, 256, 224);
        private Rectangle _spriteScreen5 = new(1, 475, 256, 224);
        private Rectangle _spriteScreen6 = new(258, 475, 256, 224);
        private Rectangle _spriteScreen7 = new(515, 475, 256, 224);
        private Rectangle _spriteScreen8 = new(772, 475, 256, 64);
        private Rectangle _destinationRectangle1 = new(0, 900 * 0, 1024, 900);
        private Rectangle _destinationRectangle2 = new(0, 900 * 1, 1024, 900);
        private Rectangle _destinationRectangle3 = new(0, 900 * 2, 1024, 900);
        private Rectangle _destinationRectangle4 = new(0, 900 * 3, 1024, 900);
        private Rectangle _destinationRectangle5 = new(0, 900 * 4, 1024, 900);
        private Rectangle _destinationRectangle6 = new(0, 900 * 5, 1024, 900);
        private Rectangle _destinationRectangle7 = new(0, 900 * 6, 1024, 900);
        private Rectangle _destinationRectangle8 = new(0, 900 * 7, 1024, 64 * 4);


        // create timers, movement and speed variables
        private float _positionSpeed = 4f;
        private Vector2 _updatePosition;
        private Renderer _screen1;
        private Renderer _screen2;
        private Renderer _screen3;
        private Renderer _screen4;
        private Renderer _screen5;
        private Renderer _screen6;
        private Renderer _screen7;
        private Renderer _screen8;
        private bool _isCentered = false;
        private int _counter = 0;
        private int _counterHoldAtStart = (int)((900 * 1) / 3.5);
        private int _counterTotal = (int)((900 * 8) / 3.5);


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public StoryScreen(Texture2D spriteSheet)
        {
            _screen1 = new (spriteSheet, _spriteScreen1, 1F);
            _screen1.IsCentered = _isCentered; _screen1.DestinationRectangle = _destinationRectangle1; _screen1.PositionOnWindow = new(_destinationRectangle1.X, _destinationRectangle1.Y);

            _screen2 = new (spriteSheet, _spriteScreen2, 1F);
            _screen2.IsCentered = _isCentered; _screen2.DestinationRectangle = _destinationRectangle2; _screen2.PositionOnWindow = new(_destinationRectangle2.X, _destinationRectangle2.Y);

            _screen3 = new (spriteSheet, _spriteScreen3, 1F);
            _screen3.IsCentered = _isCentered; _screen3.DestinationRectangle = _destinationRectangle3; _screen3.PositionOnWindow = new(_destinationRectangle3.X, _destinationRectangle3.Y);

            _screen4 = new (spriteSheet, _spriteScreen4, 1F);
            _screen4.IsCentered = _isCentered; _screen4.DestinationRectangle = _destinationRectangle4; _screen4.PositionOnWindow = new(_destinationRectangle4.X, _destinationRectangle4.Y);

            _screen5 = new (spriteSheet, _spriteScreen5, 1F);
            _screen5.IsCentered = _isCentered; _screen5.DestinationRectangle = _destinationRectangle5; _screen5.PositionOnWindow = new(_destinationRectangle5.X, _destinationRectangle5.Y);

            _screen6 = new (spriteSheet, _spriteScreen6, 1F);
            _screen6.IsCentered = _isCentered; _screen6.DestinationRectangle = _destinationRectangle6; _screen6.PositionOnWindow = new(_destinationRectangle6.X, _destinationRectangle6.Y);

            _screen7 = new (spriteSheet, _spriteScreen7, 1F);
            _screen7.IsCentered = _isCentered; _screen7.DestinationRectangle = _destinationRectangle7; _screen7.PositionOnWindow = new(_destinationRectangle7.X, _destinationRectangle7.Y);

            _screen8 = new (spriteSheet, _spriteScreen8, 1F);
            _screen8.IsCentered = _isCentered; _screen8.DestinationRectangle = _destinationRectangle8; _screen8.PositionOnWindow = new(_destinationRectangle8.X, _destinationRectangle8.Y);

            _screen1.Direction = Renderer.DIRECTION.DOWN;
            _updatePosition = _screen1.GetUpdatePosition(_positionSpeed);
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _screen1.DestinationRectangle; }
            set { _screen1.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _screen1.PositionOnWindow; }
            set { _screen1.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            _counter++;
            if (_counter >= _counterHoldAtStart && _counter < _counterTotal)
            {
                _screen1.PositionOnWindow -= _updatePosition;
                _screen2.PositionOnWindow -= _updatePosition;
                _screen3.PositionOnWindow -= _updatePosition;
                _screen4.PositionOnWindow -= _updatePosition;
                _screen5.PositionOnWindow -= _updatePosition;
                _screen6.PositionOnWindow -= _updatePosition;
                _screen7.PositionOnWindow -= _updatePosition;
                _screen8.PositionOnWindow -= _updatePosition;
            }
        }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) 
        { 
            _screen1.Draw(spriteBatch);
            _screen2.Draw(spriteBatch);
            _screen3.Draw(spriteBatch);
            _screen4.Draw(spriteBatch);
            _screen5.Draw(spriteBatch);
            _screen6.Draw(spriteBatch);
            _screen7.Draw(spriteBatch);
            _screen8.Draw(spriteBatch);
        }

        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="tint"></param>
        public void Draw(SpriteBatch spriteBatch, Color tint) 
        { 
            _screen1.Draw(spriteBatch, tint);
            _screen2.Draw(spriteBatch, tint);
            _screen3.Draw (spriteBatch, tint);
            _screen4.Draw(spriteBatch, tint);
            _screen5.Draw(spriteBatch, tint);
            _screen6.Draw(spriteBatch, tint);
            _screen7.Draw(spriteBatch, tint);
            _screen8.Draw(spriteBatch, tint);
        }
    }
}
