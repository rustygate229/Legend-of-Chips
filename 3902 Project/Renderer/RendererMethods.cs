using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {
        public void SetDirection(Renderer.DIRECTION direction) { this._directionNumber = (int)direction; }


        /// <summary>
        /// draws a sourceRectangle in an int array based on what status of animation was selected
        /// </summary>
        /// <returns></returns>
        public int[] GetSourceRectangleArray()
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
                // flip vertically
                sourceRectangle[0] = (int)_spritePosition.X + (int)_spriteDimensions.X;
                sourceRectangle[1] = (int)_spritePosition.Y;
                sourceRectangle[2] = -(int)_spriteDimensions.X;
                sourceRectangle[3] = (int)_spriteDimensions.Y;
            }
            else if (_statusNumber == 2 || _statusNumber == 3) // Animated & Reversed Sprite
            {
                if (_statusNumber == 3 && (_previousFrame == _frameTotalSpriteShift && _currentFrame == 0))
                    _isReversed = true;
                else if (_statusNumber == 3 && (_previousFrame == 0 && _currentFrame == _frameTotalSpriteShift))
                    _isReversed = false;

                width = (int)_spriteDimensions.X / (int)_rowsAndColumns.Y;      // sprites x dimension / column
                height = (int)_spriteDimensions.Y / (int)_rowsAndColumns.X;     // sprites y dimension / row

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
                // then get the sourceRectangle based on the chose
                sourceRectangle[0] = (width * column) + (int)_spritePosition.X;
                sourceRectangle[1] = (height * row) + (int)_spritePosition.Y;
                sourceRectangle[2] = width;
                sourceRectangle[3] = height;
            }
            // return the new rectangle
            return sourceRectangle;
        }


        /// <summary>
        /// draws a sourceRectangle in a Rectangle() based on what status of animation was selected
        /// </summary>
        /// <returns></returns>
        public Rectangle GetSourceRectangle()
        {
            // logic for seperating sprites into columns/rows to animate
            int width, height, row, column;

            // create source rectangle
            Rectangle sourceRectangle = new Rectangle((int)_spritePosition.X, (int)_spritePosition.Y, (int)_spriteDimensions.X, (int)_spriteDimensions.Y);

            // set sourceRectangle depending on animation type of sprite
            if (_statusNumber == 1 && _currentFrame == 1) // opposite frame for Single Animated Sprite
            {
                sourceRectangle = new Rectangle((int)_spritePosition.X + (int)_spriteDimensions.X, (int)_spritePosition.Y, -(int)_spriteDimensions.X, (int)_spriteDimensions.Y);
            }
            else if (_statusNumber == 2 || _statusNumber == 3) // row and column method for Animated Sprite and its Reverse
            {
                if (_statusNumber == 3 && (_previousFrame == _frameTotalSpriteShift && _currentFrame == 0))
                    _isReversed = true;
                else if (_statusNumber == 3 && (_previousFrame == 0 && _currentFrame == _frameTotalSpriteShift))
                    _isReversed = false;

                width = (int)_spriteDimensions.X / (int)_rowsAndColumns.Y;      // sprites x dimension / column
                height = (int)_spriteDimensions.Y / (int)_rowsAndColumns.X;     // sprites y dimension / row

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
                // then get the sourceRectangle based on the chose
                sourceRectangle = new Rectangle((width * column) + (int)_spritePosition.X, (height * row) + (int)_spritePosition.Y, width, height);
            }

            // return the new rectangle
            return sourceRectangle;
        }


        /// <summary>
        /// get the destinationRectangle of your current sprite
        /// </summary>
        public Rectangle GetDestinationRectangle() { return new Rectangle((int)_positionOnWindow.X, (int)_positionOnWindow.Y, (int)_spritePrintDimensions.X, (int)_spritePrintDimensions.Y); }


        public Vector2 PositionAhead(Rectangle destinationRectangle)
        {
            switch ((int)_directionNumber)
            {
                case 0: // DOWN
                    return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y + (int)destinationRectangle.Height);
                case 1: // UP
                    return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y - (int)destinationRectangle.Height);
                case 2: // RIGHT
                    return new Vector2((int)destinationRectangle.X + (int)destinationRectangle.Width, (int)destinationRectangle.Y);
                case 3: // LEFT
                    return new Vector2((int)destinationRectangle.X - (int)destinationRectangle.Width, (int)destinationRectangle.Y);
                default: throw new ArgumentException("Invalid direction type in PositionAhead");
            }
        }


        public Vector2 GetUpdatePosition(int positionSpeed)
        {
            switch ((int)_directionNumber)
            {
                case 0: // DOWN
                    return new Vector2(0, Math.Abs(positionSpeed));
                case 1: // UP
                    return new Vector2(0, -(Math.Abs(positionSpeed)));
                case 2: // RIGHT
                    return new Vector2(Math.Abs(positionSpeed), 0);
                case 3: // LEFT
                    return new Vector2(-(Math.Abs(positionSpeed)), 0);
                default: throw new ArgumentException("Invalid direction type for updatePosition");
            }
        }


        public void Draw(SpriteBatch spriteBatch, Rectangle sourceRectangle, Rectangle destinationRectangle)
        {
            // draw the current sprite
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }


        public void DrawCentered(SpriteBatch spriteBatch, Rectangle sourceRectangle)
        {
            int tileSize = 64;

            Rectangle destinationRectangle = new Rectangle(
                (int)_positionOnWindow.X + ((tileSize - (int)_spritePrintDimensions.X) / 2),
                (int)_positionOnWindow.Y + ((tileSize - (int)_spritePrintDimensions.Y) / 2),
                (int)_spritePrintDimensions.X, (int)_spritePrintDimensions.Y);

            // draw the current sprite
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }


        public void DrawVerticallyFlipped(SpriteBatch spriteBatch, bool isCentered)
        {
            Rectangle destinationRectangle = this.GetDestinationRectangle();
            int[] sR = this.GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1] + sR[3], sR[2], -sR[3]);

            // draw the current sprite
            if (isCentered)
                this.DrawCentered(spriteBatch, sourceRectangle);
            else
                this.Draw(spriteBatch, sourceRectangle, destinationRectangle);
        }


        public void DrawHorizontallyFlipped(SpriteBatch spriteBatch, bool isCentered)
        {
            Rectangle destinationRectangle = this.GetDestinationRectangle();
            int[] sR = this.GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1], -sR[2], sR[3]);

            // draw the current sprite
            if (isCentered)
                this.DrawCentered(spriteBatch, sourceRectangle);
            else
                this.Draw(spriteBatch, sourceRectangle, destinationRectangle);
        }


        public void DrawCompletelyFlipped(SpriteBatch spriteBatch, bool isCentered)
        {
            Rectangle destinationRectangle = this.GetDestinationRectangle();
            int[] sR = this.GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1] + sR[3], -sR[2], -sR[3]);

            // draw the current sprite
            if (isCentered)
                this.DrawCentered(spriteBatch, sourceRectangle);
            else
                this.Draw(spriteBatch, sourceRectangle, destinationRectangle);
        }
    }
}