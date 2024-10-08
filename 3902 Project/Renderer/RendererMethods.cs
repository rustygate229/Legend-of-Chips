using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public partial class Renderer : ISprite
    {

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