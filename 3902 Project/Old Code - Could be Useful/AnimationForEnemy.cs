using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

public class Animation
{
    private Texture2D _spriteAnimatedSheet;
    private Vector2 _spritePosition;     // Starting position in the sprite sheet (sourceRectangle.X, sourceRectangle.Y)
    private Vector2 _spriteDimensions;   // Total dimensions (sourceRectangle.Width, sourceRectangle.Height)
    private int _rows;
    private int _columns;
    private int _currentFrame;
    private int _totalFrames;
    private int _frameRate;
    private int _framesPerSprite;
    private int _framesCounter;

    public Animation(Texture2D texture, Rectangle sourceRectangle, int rows, int columns, int frameRate)
    {
        _spriteAnimatedSheet = texture;
        _spritePosition = new Vector2(sourceRectangle.X, sourceRectangle.Y);
        _spriteDimensions = new Vector2(sourceRectangle.Width, sourceRectangle.Height);
        _rows = rows;
        _columns = columns;
        _frameRate = frameRate;

        _currentFrame = 0;
        _totalFrames = _rows * _columns;
        _framesCounter = 0;
        _framesPerSprite = _frameRate / _totalFrames;
    }

    public void Update()
    {
        _framesCounter++;
        if (_framesCounter >= _framesPerSprite)
        {
            _currentFrame++;
            if (_currentFrame >= _totalFrames)
            {
                _currentFrame = 0;
            }
            _framesCounter = 0;
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, int customWidth, int customHeight)
    {
        // Calculate frame dimensions from the sprite sheet
        int frameWidth = (int)_spriteDimensions.X / _columns;
        int frameHeight = (int)_spriteDimensions.Y / _rows;

        // Calculate source rectangle of the current frame
        int row = _currentFrame / _columns;
        int column = _currentFrame % _columns;
        Rectangle sourceRect = new Rectangle(
            (int)_spritePosition.X + (frameWidth * column),
            (int)_spritePosition.Y + (frameHeight * row),
            frameWidth,
            frameHeight
        );

        // Define destination rectangle on the screen using custom or default size
        Rectangle destinationRect = new Rectangle(
            (int)position.X,
            (int)position.Y,
            customWidth,   // Use custom or default width
            customHeight   // Use custom or default height
        );

        // Draw the sprite
        spriteBatch.Begin();
        spriteBatch.Draw(_spriteAnimatedSheet, destinationRect, sourceRect, Color.White);
        spriteBatch.End();
    }
}