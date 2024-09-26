using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


// NOT IMPLEMENTED YET
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

    // constructor for animated item sprites
    public ItemSpriteAnimated(Texture2D spriteSheet, Vector2 position, int row, int column, int x, int y, int width, int height)
    {
        // sprite sheet
        _spriteAnimatedSheet = spriteSheet;

        // rows/columns for sprite animation
        _rows = row;
        _columns = column;
        _currentFrame = 0;
        _totalFrames = _rows * _columns;

        // sprite positioning
        _spritePosition.X = x;
        _spritePosition.Y = y;
        _spriteDimensions.X = width;
        _spriteDimensions.Y = height;
        _positionOnWindow = position;
    }

    // count frames
    public void Update()
    {
        _currentFrame++;
        if (_currentFrame == _totalFrames)
            _currentFrame = 0;
    }

    // draw the animation
    public void Draw(SpriteBatch spriteBatch)
    {
        int width = (int)_spriteDimensions.X / _columns;
        int height = (int)_spriteDimensions.Y / _rows;
        int row = _currentFrame / _columns;
        int column = _currentFrame % _columns;

        // removes anti-aliasing
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Create a sourceRectangle.
        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        Rectangle destinationRectangle = new Rectangle((int)_positionOnWindow.X, (int)_positionOnWindow.Y, 48, 48);

        // Only draw the area contained within the sourceRectangle.
        spriteBatch.Draw(_spriteAnimatedSheet, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }

    // never implemented (yet?)
    public void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y)
    {
        throw new System.NotImplementedException();
    }
}
