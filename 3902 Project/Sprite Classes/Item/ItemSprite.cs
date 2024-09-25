using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ItemSprite : ISprite
{
    private Texture2D _spriteSheet;
    private Vector2 _spritePosition;
    private Vector2 _spriteDimensions;
    private Vector2 _positionOnWindow;

    public ItemSprite(Texture2D spriteSheet, Vector2 position, int x, int y, int width, int height)
    {
        _spriteSheet = spriteSheet;
        _spritePosition.X = x;
        _spritePosition.Y = y;
        _spriteDimensions.X = width;
        _spriteDimensions.Y = height;
        _positionOnWindow = position;
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        // Create a sourceRectangle.
        Rectangle sourceRectangle = new Rectangle((int)_spritePosition.X, (int)_spritePosition.Y, (int)_spriteDimensions.X, (int)_spriteDimensions.Y);
        Rectangle destinationRectangle = new Rectangle((int)_positionOnWindow.X, (int)_positionOnWindow.Y, 48, 48);

        // Only draw the area contained within the sourceRectangle.
        spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }

    // never implemented (yet?)
    public void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y)
    {
        throw new System.NotImplementedException();
    }
}
