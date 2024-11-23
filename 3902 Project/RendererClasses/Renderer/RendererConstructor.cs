using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class Renderer
    {
        // animation status
        public enum STATUS { Still, SingleAnimated, RowAndColumnAnimated, ReverseRowAndColumnAnimated, SeperatedAnimated };
        private STATUS _status;

        public enum DIRECTION { DOWN, UP, RIGHT, LEFT }
        private DIRECTION _direction;

        private bool _isCentered = false;
        private bool _isNewDR = false;

        // NON-ANIMATED SPRITE


        // create variables
        private Texture2D _spriteSheet;
        private Vector2 _spritePosition;
        private Vector2 _spriteDimensions;
        private Vector2 _spritePrintDimensions;
        private Rectangle _destinationRectangle = new (0, 0, 0, 0);
        private Vector2 _positionOnWindow;
        private float _printScale;


        // constructor for helper/ISprite methods
        public Renderer(ISprite sprite, Vector2 positionOnWindow, DIRECTION direction, float printScale)
        {
            _spritePosition = sprite.GetVectorPosition();
            _spriteDimensions = new(sprite.GetRectanglePosition().Width / printScale, sprite.GetRectanglePosition().Height / printScale);
            _spritePrintDimensions = new(sprite.GetRectanglePosition().Width, sprite.GetRectanglePosition().Height);
            _direction = direction;
            _positionOnWindow = positionOnWindow;
            _printScale = printScale;
        }


        /// <summary>
        /// constructor for getting information for rendering STILL sprites
        /// </summary>
        /// <param name="status"></param>
        /// <param name="spriteSheet"></param>
        /// <param name="spritePosition"></param>
        /// <param name="spriteDimension"></param>
        /// <param name="spritePrintDimension"></param>
        public Renderer(Texture2D spriteSheet, Rectangle spritePositionAndDimension, float printScale)
        {
            // set animated state and import spritesheet
            _spriteSheet = spriteSheet;

            // set sprite
            _spritePosition = new (spritePositionAndDimension.X, spritePositionAndDimension.Y);
            _spriteDimensions = new (spritePositionAndDimension.Width, spritePositionAndDimension.Height);
            _spritePrintDimensions = new (spritePositionAndDimension.Width * printScale, spritePositionAndDimension.Height * printScale);
            _printScale = printScale;
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
        /// <param name="spriteSheet"></param>
        /// <param name="rowAndColumn"></param>
        /// <param name="frameRate"></param>
        public Renderer(Texture2D spriteSheet, Rectangle spritePositionAndDimension, Vector2 rowAndColumn, float printScale, int frameRate)
        {
            // set animated state and import spritesheet
            _spriteSheet = spriteSheet;

            // call framerate manager
            _rowsAndColumns = rowAndColumn;
            _frameRate = frameRate;
            _currentFrame = 0;
            SetUpFrames();

            // sprite positioning
            _spritePosition = new(spritePositionAndDimension.X, spritePositionAndDimension.Y);
            _spriteDimensions = new(spritePositionAndDimension.Width, spritePositionAndDimension.Height);
            // needed since dimensions are in terms of the whole row/column
            _spritePrintDimensions = 
                new(
                    (spritePositionAndDimension.Width / _rowsAndColumns.Y) * printScale, 
                    (spritePositionAndDimension.Height / _rowsAndColumns.X) * printScale
                    );
            _printScale = printScale;
        }


        private List<Rectangle> _spriteListPositions;

        /// <summary>
        /// constructor for getting information for rendering SEPERATED ANIMATED sprites
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="rowAndColumn"></param>
        /// <param name="frameRate"></param>
        public Renderer(Texture2D spriteSheet, List<Rectangle> spritePositionAndDimensions, Vector2 rowAndColumn, float printScale, int frameRate)
        {
            // set animated state and import spritesheet
            _spriteSheet = spriteSheet;

            // call framerate manager
            _rowsAndColumns = rowAndColumn;
            _frameRate = frameRate;
            _currentFrame = 0;
            SetUpFrames();

            // go through each source rectangle and add them to our list after creating print dimensions
            foreach (var sourceRectangle in spritePositionAndDimensions)
            {
                Rectangle newSourceRectangle = sourceRectangle;
                newSourceRectangle.Width = (int)((sourceRectangle.Width / _rowsAndColumns.Y) * printScale);
                newSourceRectangle.Height = (int)((sourceRectangle.Height / _rowsAndColumns.X) * printScale);
                _spriteListPositions.Add(newSourceRectangle);
            }
            _spritePosition = new           (_spriteListPositions[0].X, _spriteListPositions[0].Y);
            _spriteDimensions = new         (spritePositionAndDimensions[0].Width, spritePositionAndDimensions[0].Height);
            _spritePrintDimensions = new    (_spriteListPositions[0].Width, _spriteListPositions[0].Height);
            _printScale = printScale;
        }
    }
}