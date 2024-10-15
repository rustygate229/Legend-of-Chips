using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using _3902_Project;

namespace _3902_Project
{
    public class Renderer : ISprite
    {
        // animation status
        private bool _isAnimated;


        // NON-ANIMATED SPRITE


        // create variables
        private Texture2D _spriteSheet;
        private Vector2 _spritePosition;
        private Vector2 _spriteDimensions;
        private Vector2 _spritePrintDimensions;
        private Vector2 _positionOnWindow;


        // constructor linking variables
        public Renderer(bool IsAnimated, Texture2D spriteSheet, Vector2 spawnPosition, int xSpritePosition, int ySpritePosition, int xDimension, int yDimension, int xPrintDimension, int yPrintDimension)
        {
            // set animated state and import spritesheet
            _isAnimated = IsAnimated;
            _spriteSheet = spriteSheet;

            // set all positions
            _spritePosition.X = xSpritePosition;
            _spritePosition.Y = ySpritePosition;
            _spriteDimensions.X = xDimension;
            _spriteDimensions.Y = yDimension;
            _spritePrintDimensions.X = xPrintDimension;
            _spritePrintDimensions.Y = yPrintDimension;
            _positionOnWindow = spawnPosition;
        }


        // ANIMATOR


        // item animation requirements
        public int _rows;
        public int _columns;
        private int _currentFrame;
        private int _totalFrames;

        // frame rate to change speed of animations
        private int _frameRate;
        private int _framesPerSprite;
        private int _framesCounter;
        private int _frameTotalSpriteShift;


        // constructor for animated item sprites
        public Renderer(bool IsAnimated, Texture2D spriteSheet, Vector2 windowPosition, int xPosition, int yPosition, int xDimension, int yDimension, int xPrintDimension, int yPrintDimension, int row, int column, int frameRate)
        {
            // set animated state and import spritesheet
            _isAnimated = IsAnimated;
            _spriteSheet = spriteSheet;

            // rows/columns stuff for sprite animation
            _rows = row;
            _columns = column;
            _currentFrame = 0;
            _totalFrames = _rows * _columns;

            // get the total amount of sprite shifts in animation
            _frameTotalSpriteShift = 0;
            while (_framesPerSprite < frameRate)
            {
                _frameTotalSpriteShift++;
                _framesPerSprite += frameRate / _totalFrames;
                if (_framesPerSprite > frameRate)
                    _frameTotalSpriteShift--;
            }
            _framesPerSprite = 0;

            // if the framerate is not a clean division, fix it by shuffling down the value by the modulo
            if (frameRate % _frameTotalSpriteShift != 0)
                frameRate -= (frameRate % _frameTotalSpriteShift);

            // frame rate variables
            _frameRate = frameRate;
            _framesCounter = 0;
            _framesPerSprite = _frameRate / _totalFrames;

            // sprite positioning
            _spritePosition.X = xPosition;
            _spritePosition.Y = yPosition;
            _spriteDimensions.X = xDimension;
            _spriteDimensions.Y = yDimension;
            _spritePrintDimensions.X = xPrintDimension;
            _spritePrintDimensions.Y = yPrintDimension;
            _positionOnWindow = windowPosition;
        }


        // count/reset frames and sprite levels (levels meaning at what stage of animation)
        public void Update()
        {
            if (_isAnimated)
            {
                // logic for creating a framerate
                if (_framesCounter < _framesPerSprite)
                {
                    _framesCounter++;
                }
                else if (_framesCounter == _frameRate)
                {
                    _currentFrame = 0;
                    _framesCounter = 0;
                    _framesPerSprite = _frameRate / _totalFrames;
                }
                else
                {
                    _currentFrame++;
                    _framesPerSprite += _frameRate / _totalFrames;
                }
            }
        }


        // draw the animated sprites
        public void Draw(SpriteBatch spriteBatch)
        {

            // logic for seperating sprites into columns/rows to animate
            int width, height, row, column;

            // removes anti-aliasing
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = new Rectangle((int)_positionOnWindow.X - ((int)_spritePrintDimensions.X / 2), (int)_positionOnWindow.Y - ((int)_spritePrintDimensions.Y / 2), (int)_spritePrintDimensions.X, (int)_spritePrintDimensions.Y);

            if (_isAnimated)
            {
                // logic for seperating sprites into columns/rows to animate
                width = (int)_spriteDimensions.X / _columns;
                height = (int)_spriteDimensions.Y / _rows;
                row = _currentFrame / _columns;
                column = _currentFrame % _columns;

                // create a sourceRectangle for animated sprites
                sourceRectangle = new Rectangle((width * column) + (int)_spritePosition.X, (height * row) + (int)_spritePosition.Y, width, height);
            }
            else
            {
                // create a source rectangle for non-animated sprites
                sourceRectangle = new Rectangle((int)_spritePosition.X, (int)_spritePosition.Y, (int)_spriteDimensions.X, (int)_spriteDimensions.Y);
            }

            // draw the area contained by the sourceRectangle to the destinationRectangle
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}