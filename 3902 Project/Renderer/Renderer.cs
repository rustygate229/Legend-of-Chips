using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using _3902_Project;
using System;
using System.Diagnostics;

namespace _3902_Project
{
    public class Renderer
    {
        // animation status
        public enum STATUS { Still, SingleAnimated, Animated };
        private int _statusNumber = 0;

        public enum DIRECTION { UP, DOWN, LEFT, RIGHT }


        // NON-ANIMATED SPRITE


        // create variables
        private Texture2D _spriteSheet;
        private Vector2 _spritePosition;
        private Vector2 _spriteDimensions;
        private Vector2 _spritePrintDimensions;
        private Vector2 _positionOnWindow;


        // constructor linking variables
        public Renderer(Renderer.STATUS status, Texture2D spriteSheet, Vector2 spawnPosition, Vector2 spritePosition, Vector2 spriteDimension, Vector2 spritePrintDimension)
        {
            // set animated state and import spritesheet
            _statusNumber = (int)status;
            _spriteSheet = spriteSheet;

            // set all positions
            _spritePosition = spritePosition;
            _spriteDimensions = spriteDimension;
            _spritePrintDimensions = spritePrintDimension;
            _positionOnWindow = spawnPosition;
        }


        // ANIMATOR/FRAMERATE


        // item animation requirements
        private Vector2 _rowsAndColumns;
        private int _currentFrame;
        private int _totalFrames;

        // frame rate to change speed of animations
        private int _frameRate;
        private int _framesPerSprite;
        private int _framesCounter;
        private int _frameTotalSpriteShift;


        // constructor for animated item sprites
        public Renderer(Renderer.STATUS status, Texture2D spriteSheet, Vector2 windowPosition, Vector2 spritePosition, Vector2 spriteDimension, Vector2 spritePrintDimension, Vector2 rowAndColumn, int frameRate)
        {
            // set animated state and import spritesheet
            _statusNumber = (int)status;
            _spriteSheet = spriteSheet;

            // call framerate manager
            _rowsAndColumns = rowAndColumn;
            _frameRate = frameRate;
            SetUpFrames();

            // sprite positioning
            _spritePosition = spritePosition;
            _spriteDimensions = spriteDimension;
            _spritePrintDimensions = spritePrintDimension;
            _positionOnWindow = windowPosition;
        }

        public void SetUpFrames()
        {
            // rows/columns stuff for sprite animation
            _currentFrame = 0;
            // needed for Single Animation
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
        }


        // count/reset frames and sprite levels (levels meaning at what stage of animation)
        public void UpdateFrames()
        {
            if (_statusNumber > 0)
            {
                // logic for creating a framerate
                if (_framesCounter < _framesPerSprite)
                {
                    Debug.WriteLine("_framesCounter < _framesPerSprite");
                    _framesCounter++;
                }
                else if (_framesCounter == _frameRate)
                {
                    Debug.WriteLine("_framesCounter == _frameRate");
                    _currentFrame = 0;
                    _framesCounter = 0;
                    _framesPerSprite = _frameRate / _totalFrames;
                }
                else
                {
                    Debug.WriteLine("increment frame and _framesPerSprite");
                    _currentFrame++;
                    _framesPerSprite += _frameRate / _totalFrames;
                }
            }
        }


        // draw the animated sprites
        public int[] GetSourceRectangle()
        {
            int[] sourceRectangle = new int[4];

            // logic for seperating sprites into columns/rows to animate
            int width, height, row, column;

            // create source rectangle
            sourceRectangle[0] = (int)_spritePosition.X;
            sourceRectangle[1] = (int)_spritePosition.Y;
            sourceRectangle[2] = (int)_spriteDimensions.X; 
            sourceRectangle[3] = (int)_spriteDimensions.Y;

            // set sourceRectangle depending on animation type of sprite
            if (_statusNumber == 1 && _currentFrame == 1) // opposite frame for Single Animated Sprite
            {
                Debug.WriteLine("in Single Animated");
                sourceRectangle[0] = (int)_spritePosition.X + (int)_spriteDimensions.X;
                sourceRectangle[1] = (int)_spritePosition.Y;
                sourceRectangle[2] = -(int)_spriteDimensions.X;
                sourceRectangle[3] = (int)_spriteDimensions.Y;
            }
            else if (_statusNumber == 2) // Animated Sprite
            {
                Debug.WriteLine("In Aminated");
                width = (int)_spriteDimensions.X / (int)_rowsAndColumns.Y;
                height = (int)_spriteDimensions.Y / (int)_rowsAndColumns.X;
                row = _currentFrame / (int)_rowsAndColumns.Y;
                column = _currentFrame % (int)_rowsAndColumns.Y;

                sourceRectangle[0] = (width * column) + (int)_spritePosition.X;
                sourceRectangle[1] = (height * row) + (int)_spritePosition.Y;
                sourceRectangle[2] = width;
                sourceRectangle[3] = height;
            } 


            // return the new rectangle
            return sourceRectangle;
        }

        // general get position method from IPosition
        public Vector2 GetPosition()
        {
            return _positionOnWindow;
        }

        // general set position method from IPosition
        public void SetPosition(Vector2 position)
        {
            _positionOnWindow = position;
        }

        public Rectangle GetDestinationRectangle()
        {
            return new Rectangle((int)_positionOnWindow.X, (int)_positionOnWindow.Y, (int)_spritePrintDimensions.X, (int)_spritePrintDimensions.Y);
        }
    }
}