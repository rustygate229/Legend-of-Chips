using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public partial class ItemSpriteAnimated : ISprite
{
    // texture positioning requirements
    private Texture2D _spriteAnimatedSheet;
    private Vector2 _spritePosition;
    private Vector2 _spriteDimensions;
    private Vector2 _spritePrintDimensions;
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
    public ItemSpriteAnimated(Texture2D spriteSheet, Vector2 spawnPosition, int xPosition, int yPosition, int xDimension, int yDimension, int xPrintDimension, int yPrintDimension, int row, int column, int frameRate)
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
        _spritePosition.X = xPosition;
        _spritePosition.Y = yPosition;
        _spriteDimensions.X = xDimension;
        _spriteDimensions.Y = yDimension;
        _spritePrintDimensions.X = xPrintDimension;
        _spritePrintDimensions.Y = yPrintDimension;
        _positionOnWindow = spawnPosition;
    }

}
