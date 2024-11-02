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
        /// <returns>return the sourceRectangle in a rectangle</returns>
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

        /// <summary>
        /// set the direction of the current "this" sprite
        /// </summary>
        /// <param name="direction">the direction in which you want to move</param>
        public void SetDirection(Renderer.DIRECTION direction) { this._direction = direction; }

        /// <summary>
        /// draw the sprite at the top left of the set position
        /// </summary>
        /// <param name="spriteBatch">the spritebatch where everything is drawn in</param>
        /// <param name="sourceRectangle">the sourceRectangle of the sprite</param>
        /// <param name="destinationRectangle">the destinationRectangle of the sprite</param>
        public void Draw(SpriteBatch spriteBatch, Rectangle sourceRectangle, Rectangle destinationRectangle)
        {
            // draw the current sprite
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        /// <summary>
        /// draw the sprite at the center of the set position centered around the tile size (in this case, all blocks/tiles are formed in 64x64)
        /// </summary>
        /// <param name="spriteBatch">the spritebatch where everything is drawn in</param>
        /// <param name="sourceRectangle">the sourceRectangle of the sprite</param>
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
    }
}