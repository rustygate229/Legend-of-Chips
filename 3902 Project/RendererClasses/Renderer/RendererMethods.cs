using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {

        /// <summary>
        /// draws a sourceRectangle in an int array based on what status of animation was selected
        /// </summary>
        /// <returns>the sourceRectangle in an int[] array</returns>
        public int[] GetSourceRectangleArray()
        {
            int[] sourceRectangle = new int[4];

            // logic for seperating sprites into columns/rows to animate
            sourceRectangle[0] = GetSourceRectangle().X;
            sourceRectangle[1] = GetSourceRectangle().Y;
            sourceRectangle[2] = GetSourceRectangle().Width;
            sourceRectangle[3] = GetSourceRectangle().Height;

            return sourceRectangle;
        }


        /// <summary>
        /// draws a sourceRectangle in a Rectangle() based on what status of animation was selected
        /// </summary>
        /// <returns>return the sourceRectangle in a rectangle</returns>
        public Rectangle GetSourceRectangle()
        {
            switch(_status)
            {
                case STATUS.Still: return GetSourceRectangle_Still();
                case STATUS.SingleAnimated: return GetSourceRectangle_SingleAnimated();
                case STATUS.RowAndColumnAnimated: return GetSourceRectangle_RowAndColumnAnimated();
                case STATUS.ReverseRowAndColumnAnimated: return GetSourceRectangle_ReversedRowAndColumnAnimated();
                case STATUS.SeparatedAnimated: return GetSourceRectangle_Separated();
                default: throw new ArgumentException("Invalid STATUS for GetSourceRectangle() in Renderer");
            }
        }

        private Rectangle GetSourceRectangle_Still()
        {
            return SourceRectangle;
        }

        private Rectangle GetSourceRectangle_SingleAnimated()
        {
            if (_currentFrame == 0) return SourceRectangle;
            else return new Rectangle(SourceRectangle.X + SourceRectangle.Width, SourceRectangle.Y, -SourceRectangle.Width, SourceRectangle.Height);
        }

        private Rectangle GetSourceRectangle_RowAndColumnAnimated()
        {
            int width, height, row, column;
            width = SourceRectangle.Width / (int)_rowsAndColumns.Y;         // sprites x dimension / column
            height = SourceRectangle.Height / (int)_rowsAndColumns.X;       // sprites y dimension / row
            row = _currentFrame / (int)_rowsAndColumns.Y;                   // current frame / column
            column = _currentFrame % (int)_rowsAndColumns.Y;                // current frame % column
            return new (
                (width * column) + SourceRectangle.X, 
                (height * row) + SourceRectangle.Y, 
                width, height
            );
        }

        private Rectangle GetSourceRectangle_ReversedRowAndColumnAnimated()
        {
            int width, height, row, column;
            if (_previousFrame == (_frameTotalSpriteShift - 1) && _currentFrame == 0)           _isReversed = true;
            else if (_previousFrame == 0 && _reversedFrame == (_frameTotalSpriteShift - 1))     _isReversed = false;

            width = SourceRectangle.Width / (int)_rowsAndColumns.Y;         // sprites x dimension / column
            height = SourceRectangle.Height / (int)_rowsAndColumns.X;       // sprites y dimension / row

            if (!_isReversed)
            {
                row = _currentFrame / (int)_rowsAndColumns.Y;                   // current frame / column
                column = _currentFrame % (int)_rowsAndColumns.Y;                // current frame % column
            }
            else
            {
                row = _reversedFrame / (int)_rowsAndColumns.Y;                   // current frame / column
                column = _reversedFrame % (int)_rowsAndColumns.Y;                // current frame % column
            }
            // then get the sourceRectangle based on the choice
            return new (
                (width * column) + SourceRectangle.X, 
                (height * row) + SourceRectangle.Y, 
                width, height
            );
        }

        private Rectangle GetSourceRectangle_Separated() { return _sourceRectangleList[_currentFrame]; }

        public DIRECTION GetOppositeDirection() 
        { 
            switch (_direction)
            {
                case DIRECTION.DOWN: return DIRECTION.UP;
                case DIRECTION.UP: return DIRECTION .DOWN;
                case DIRECTION.RIGHT: return DIRECTION .LEFT;
                case DIRECTION.LEFT: return DIRECTION .RIGHT;
                default: throw new ArgumentException("That direction does not exist; in RendererMethods");
            }
        }
    }
}