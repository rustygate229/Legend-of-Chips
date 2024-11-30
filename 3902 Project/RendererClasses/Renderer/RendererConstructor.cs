using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class Renderer
    {
        // animation status
        public enum STATUS { Still, SingleAnimated, RowAndColumnAnimated, ReverseRowAndColumnAnimated, SeparatedAnimated };
        private STATUS _status;
        public STATUS AnimatedStatus { get { return _status; } set { _status = value; } }

        public enum DIRECTION { DOWN, UP, RIGHT, LEFT }
        private DIRECTION _direction;
        public DIRECTION Direction { get { return _direction; } set { _direction = value; } }

        private bool _isCentered = false;
        public bool IsCentered { get { return _isCentered; } set { _isCentered = value; } }

        // NON-ANIMATED SPRITE


        // create variables
        private Texture2D _spriteSheet;
        private Rectangle _sourceRectangle;
        private Rectangle SourceRectangle { get { return _sourceRectangle; } set { _sourceRectangle = value; } }

        private Rectangle _destinationRectangle;
        /// <summary>
        /// gets current position of sprite in a Rectangle of position and dimensions on screen
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get
            {
                if (_isCentered)
                {
                    return new Rectangle(
                        _destinationRectangle.X + ((_tileSize - _destinationRectangle.Width) / 2),
                        _destinationRectangle.Y + ((_tileSize - _destinationRectangle.Height) / 2),
                        _destinationRectangle.Width, _destinationRectangle.Height
                    );
                }
                else
                    return _destinationRectangle;
            }
            set { _destinationRectangle = value; }
        }

        public Vector2 PositionOnWindow
        {
            get { return new(DestinationRectangle.X, DestinationRectangle.Y); }
            set { _destinationRectangle.X = (int)value.X; _destinationRectangle.Y = (int)value.Y; }
        }

        private float _printScale;


        /// <summary>
        /// constructor for getting information for rendering STILL sprites
        /// </summary>
        /// <param name="status"></param>
        /// <param name="spriteSheet"></param>
        /// <param name="spritePosition"></param>
        /// <param name="spriteDimension"></param>
        /// <param name="spritePrintDimension"></param>
        public Renderer(Texture2D spriteSheet, Rectangle sourceRectangle, float printScale)
        {
            // set animated state and import spritesheet
            _spriteSheet = spriteSheet;
            AnimatedStatus = STATUS.Still;

            // set sprite
            SourceRectangle = new (sourceRectangle.X, sourceRectangle.Y, sourceRectangle.Width, sourceRectangle.Height);
            DestinationRectangle = new (0, 0, (int)(sourceRectangle.Width * printScale), (int)(sourceRectangle.Height * printScale));
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
        public Renderer(Texture2D spriteSheet, Rectangle sourceRectangle, Vector2 rowAndColumn, float printScale, int frameRate)
        {
            // set animated state and import spritesheet
            _spriteSheet = spriteSheet;
            AnimatedStatus = STATUS.RowAndColumnAnimated;

            // call framerate manager
            _rowsAndColumns = rowAndColumn;
            _frameRate = frameRate;
            _currentFrame = 0;
            SetUpFrames();

            // sprite positioning
            SourceRectangle = new(sourceRectangle.X, sourceRectangle.Y, sourceRectangle.Width, sourceRectangle.Height);
            // needed since dimensions are in terms of the whole row/column
            DestinationRectangle = new(
                    0, 0,
                    (int)((sourceRectangle.Width / _rowsAndColumns.Y) * printScale), 
                    (int)((sourceRectangle.Height / _rowsAndColumns.X) * printScale)
                    );
            _printScale = printScale;
        }


        private List<Rectangle> _sourceRectangleList;
        private List<Rectangle> _destinationRectangleList;

        /// <summary>
        /// constructor for getting information for rendering SEPERATED ANIMATED sprites
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="rowAndColumn"></param>
        /// <param name="frameRate"></param>
        public Renderer(Texture2D spriteSheet, List<Rectangle> sourceRectangles, Vector2 rowAndColumn, float printScale, int frameRate)
        {
            // set animated state and import spritesheet
            _spriteSheet = spriteSheet;
            AnimatedStatus = STATUS.SeparatedAnimated;

            // call framerate manager
            _rowsAndColumns = rowAndColumn;
            _frameRate = frameRate;
            _currentFrame = 0;
            SetUpFrames();

            // go through each source rectangle and add them to our list after creating print dimensions
            foreach (var sourceRectangle in _sourceRectangleList)
            {
                Rectangle destinationRectangle = new(
                    0, 0,
                    (int)((sourceRectangle.Width / _rowsAndColumns.Y) * printScale),
                    (int)((sourceRectangle.Height / _rowsAndColumns.X) * printScale)
                    );
                _destinationRectangleList.Add(destinationRectangle);
            }
            SourceRectangle = new           (_sourceRectangleList[0].X, _sourceRectangleList[0].Y, _sourceRectangleList[0].Width, _sourceRectangleList[0].Height);
            DestinationRectangle = new      (0, 0, _destinationRectangleList[0].Width, _destinationRectangleList[0].Height);
            _printScale = printScale;
        }
    }
}