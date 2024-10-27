using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {
        // animation status
        public enum STATUS { Still, SingleAnimated, Animated, ReverseAnimated };
        private int _statusNumber = 0;

        public enum DIRECTION { DOWN, UP, RIGHT, LEFT }
        private int _directionNumber = 0;


        // NON-ANIMATED SPRITE


        // create variables
        private Texture2D _spriteSheet;
        private Vector2 _spritePosition;
        private Vector2 _spriteDimensions;
        private Vector2 _spritePrintDimensions;
        private Vector2 _positionOnWindow;


        /// <summary>
        /// constructor for getting information for rendering STILL sprites
        /// </summary>
        /// <param name="status"></param>
        /// <param name="spriteSheet"></param>
        /// <param name="spritePosition"></param>
        /// <param name="spriteDimension"></param>
        /// <param name="spritePrintDimension"></param>
        public Renderer(Renderer.STATUS status, Texture2D spriteSheet, Vector2 spritePosition, Vector2 spriteDimension, Vector2 spritePrintDimension)
        {
            // set animated state and import spritesheet
            _statusNumber = (int)status;
            _spriteSheet = spriteSheet;

            // set all positions
            _spritePosition = spritePosition;
            _spriteDimensions = spriteDimension;
            _spritePrintDimensions = spritePrintDimension;
        }


        // ANIMATOR/FRAMERATE


        // item animation requirements
        private Vector2 _rowsAndColumns;
        private int _currentFrame;
        private int _previousFrame;
        private int _reversedFrame;
        private int _totalFrames;

        // frame rate to change speed of animations
        private int _frameRate;
        private int _framesPerSprite;
        private int _framesCounter;
        private int _frameTotalSpriteShift;

        // boolean for AnimatedReversed
        private bool _isReversed = false;


        /// <summary>
        /// constructor for getting information for rendering ANIMATED sprites
        /// </summary>
        /// <param name="status"></param>
        /// <param name="spriteSheet"></param>
        /// <param name="spritePosition"></param>
        /// <param name="spriteDimension"></param>
        /// <param name="spritePrintDimension"></param>
        /// <param name="rowAndColumn"></param>
        /// <param name="frameRate"></param>
        public Renderer(Renderer.STATUS status, Texture2D spriteSheet, Vector2 spritePosition, Vector2 spriteDimension, Vector2 spritePrintDimension, Vector2 rowAndColumn, int frameRate)
        {
            // set animated state and import spritesheet
            _statusNumber = (int)status;
            _spriteSheet = spriteSheet;

            // call framerate manager
            _rowsAndColumns = rowAndColumn;
            _frameRate = frameRate;
            _currentFrame = 0;
            SetUpFrames();

            // sprite positioning
            _spritePosition = spritePosition;
            _spriteDimensions = spriteDimension;
            _spritePrintDimensions = spritePrintDimension;
        }


        /// <summary>
        /// sets up frame variables and their values for UpdateFrames()
        /// </summary>
        public void SetUpFrames()
        {
            // rows/columns stuff for sprite animation - if statement needed for Single Animation
            if ((int)_rowsAndColumns.X * (int)_rowsAndColumns.Y == 1)
                _totalFrames = 2;
            else
                _totalFrames = (int)_rowsAndColumns.X * (int)_rowsAndColumns.Y;

            // get the total amount of sprite shifts in animation
            _frameTotalSpriteShift = 0;
            while (_framesPerSprite < _frameRate)
            {
                _frameTotalSpriteShift++;
                _framesPerSprite += _frameRate / _totalFrames;
                if (_framesPerSprite > _frameRate)
                    _frameTotalSpriteShift--;
            }

            // if the framerate is not a clean division, fix it by shuffling down the value by the modulo
            if (_frameRate % _frameTotalSpriteShift != 0)
                _frameRate -= (_frameRate % _frameTotalSpriteShift);

            // reset frame rate variables
            _framesCounter = 0;
            _framesPerSprite = _frameRate / _totalFrames;
            _reversedFrame = _frameTotalSpriteShift;
        }


        /// <summary>
        /// count/reset frames and sprite levels (levels meaning at what stage of animation)
        /// </summary>
        public void UpdateFrames()
        {
            // if crea
            if (_statusNumber > 0)
            {
                // logic for creating a framerate
                if (_framesCounter < _framesPerSprite)
                {
                    _framesCounter++;
                }
                else if (_framesCounter == _frameRate)
                {
                    _currentFrame = 0;
                    _reversedFrame = _frameTotalSpriteShift;
                    _framesCounter = 0;
                    _framesPerSprite = _frameRate / _totalFrames;
                }
                else
                {
                    _previousFrame = _currentFrame;
                    _currentFrame++;
                    _reversedFrame--;
                    _framesPerSprite += _frameRate / _totalFrames;
                }
            }
        }


        /// <summary>
        /// gets current position of sprite
        /// </summary>
        public Vector2 GetPosition() { return _positionOnWindow; }


        /// <summary>
        /// sets current position of sprite
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position) { _positionOnWindow = position; }

    }
}