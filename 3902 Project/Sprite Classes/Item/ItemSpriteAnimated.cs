using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class ItemSpriteAnimated : ISprite
{
    // texture positioning requirements
    private Texture2D _spriteAnimatedSheet;
    private Vector2 _spritePosition;
    private Vector2 _spriteDimensions;
    private Vector2 _positionOnWindow;

    // item animation requirements
    public int _rows;
    public int _columns;
    private int _currentFrame;
    private int _totalFrames;

    // frame rate to change speed of animations
    private int _frameRate;
    private int _framesPerSprite;
    private int _framesCounter;
    private int _frameTotalSpriteShift;


    // constructor for animated item sprites
    public ItemSpriteAnimated(Texture2D spriteSheet, Vector2 position, int x, int y, int width, int height, int row, int column, int frameRate)
    {
        // sprite sheet
        _spriteAnimatedSheet = spriteSheet;

        // rows/columns stuff for sprite animation
        _rows = row;
        _columns = column;
        _currentFrame = 0;
        _totalFrames = _rows * _columns;

        // get the total amount of sprite shifts in animation
        _frameTotalSpriteShift = 0;
        while (_framesPerSprite < frameRate)
        {
            _frameTotalSpriteShift++;
            _framesPerSprite += frameRate / _totalFrames;
            if (_framesPerSprite > frameRate)
                _frameTotalSpriteShift--;
        }
        _framesPerSprite = 0;

        // if the framerate is not a clean division, fix it by shuffling down the value by the modulo
        if (frameRate % _frameTotalSpriteShift != 0)
            frameRate -= (frameRate % _frameTotalSpriteShift);

        // frame rate variables
        _frameRate = frameRate;
        _framesCounter = 0;
        _framesPerSprite = _frameRate / _totalFrames;

        // sprite positioning
        _spritePosition.X = x;
        _spritePosition.Y = y;
        _spriteDimensions.X = width;
        _spriteDimensions.Y = height;
        _positionOnWindow = position;
    }


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
