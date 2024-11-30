using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class Renderer
    {
        /// <summary>
        /// sets up frame variables and their values for UpdateFrames()
        /// </summary>
        public void SetUpFrames()
        {
            // rows/columns stuff for sprite animation - if statement needed for Single Animation
            if ((int)_rowsAndColumns.X * (int)_rowsAndColumns.Y == 1) _totalFrames = 2;
            else _totalFrames = (int)_rowsAndColumns.X * (int)_rowsAndColumns.Y;
            // safety measure for if someone enters a value below the available frames: sets it too lowest value = _totalFrames
            if (_frameRate < _totalFrames) _frameRate = _totalFrames;


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
            _reversedFrame = (_frameTotalSpriteShift - 1);
        }


        /// <summary>
        /// count/reset frames and sprite levels (levels meaning at what stage of animation)
        /// </summary>
        public void UpdateFrames()
        {
            if (_status != STATUS.Still)
            {
                // logic for creating a framerate
                if (_framesCounter < _framesPerSprite)
                    _framesCounter++;
                else if (_framesCounter == _frameRate)
                {
                    _currentFrame = 0;
                    _reversedFrame = (_frameTotalSpriteShift - 1);
                    _framesCounter = 0;
                    _framesPerSprite = _frameRate / _totalFrames;
                }
                else
                {
                    if (_isReversed)        { _previousFrame = _reversedFrame; _reversedFrame--; }
                    else if (!_isReversed)  { _previousFrame = _currentFrame; _currentFrame++; }
                    _framesPerSprite += _frameRate / _totalFrames;
                }
                if (_status == STATUS.SeparatedAnimated)
                {
                    SourceRectangle = _sourceRectangleList[_currentFrame];
                    DestinationRectangle = _destinationRectangleList[_currentFrame];
                }
            }
        }
    }
}