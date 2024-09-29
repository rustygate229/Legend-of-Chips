using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public partial class ItemSpriteAnimated : ISprite
{

    // count/reset frames and sprite levels (levels meaning at what stage of animation)
    public void Update()
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


    // draw the animated sprites
    public void Draw(SpriteBatch spriteBatch)
    {
        // logic for seperating sprites into columns/rows to animate
        int width = (int)_spriteDimensions.X / _columns;
        int height = (int)_spriteDimensions.Y / _rows;
        int row = _currentFrame / _columns;
        int column = _currentFrame % _columns;

        // removes anti-aliasing
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        
        // create a sourceRectangle and a destinationRectangle
        Rectangle sourceRectangle = new Rectangle((width * column) + (int)_spritePosition.X, (height * row) + (int)_spritePosition.Y, width, height);
        Rectangle destinationRectangle = new Rectangle((int)_positionOnWindow.X, (int)_positionOnWindow.Y, 48, 48);

        // draw the area contained by the sourceRectangle to the destinationRectangle
        spriteBatch.Draw(_spriteAnimatedSheet, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }


    // used for link, apart of ISprite never used in these classes (yet?)
    public void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y)
    {
        throw new System.NotImplementedException();
    }
}
