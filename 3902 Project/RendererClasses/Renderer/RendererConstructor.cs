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
        private int _tileSize = 64;
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
                        (int)_positionOnWindow.X + ((_tileSize - _destinationRectangle.Width) / 2),
                        (int)_positionOnWindow.Y + ((_tileSize - _destinationRectangle.Height) / 2),
                        _destinationRectangle.Width, _destinationRectangle.Height
                    );
                }
                else
                {
                    return new Rectangle(
                        (int)_positionOnWindow.X, (int)_positionOnWindow.Y,
                        _destinationRectangle.Width, _destinationRectangle.Height
                    );
                }
            }
            set { _destinationRectangle = value; }
        }

        private Vector2 _positionOnWindow;
        public Vector2 PositionOnWindow
        {
            get { return _positionOnWindow; }
            set {
                if (AnimatedStatus is STATUS.SeparatedAnimated)
                {
                    List<Tuple<Rectangle, Rectangle>> tempTupleList = new();
                    foreach (var tuple in _sAndDRectList)
                    {
                        Rectangle tempDestRect = tuple.Item2;
                        tempDestRect.X = (int)value.X;
                        tempDestRect.Y = (int)value.Y;
                        Tuple<Rectangle, Rectangle> tempTuple = new(tuple.Item1, tempDestRect);
                        tempTupleList.Add(tempTuple);
                    }
                    _sAndDRectList = tempTupleList;
                }
                else _positionOnWindow = value;
            }
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


        private List<Tuple<Rectangle, Rectangle>> _sAndDRectList = new ();

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

            _sAndDRectList.Clear();
            // go through each source rectangle and add them to our list after creating print dimensions
            foreach (var sourceRectangle in sourceRectangles)
            {
                Rectangle destinationRectangle = new(
                    0, 0,
                    (int)((sourceRectangle.Width / _rowsAndColumns.Y) * printScale),
                    (int)((sourceRectangle.Height / _rowsAndColumns.X) * printScale)
                    );
                Tuple<Rectangle, Rectangle> newListAddon = new Tuple<Rectangle, Rectangle> (sourceRectangle, destinationRectangle);
                _sAndDRectList.Add(newListAddon);
            }
            SourceRectangle = new           (_sAndDRectList[0].Item1.X, _sAndDRectList[0].Item1.Y, _sAndDRectList[0].Item1.Width, _sAndDRectList[0].Item1.Height);
            DestinationRectangle = new      (0, 0, _sAndDRectList[0].Item2.Width, _sAndDRectList[0].Item2.Height);
            _printScale = printScale;
        }
    }
}