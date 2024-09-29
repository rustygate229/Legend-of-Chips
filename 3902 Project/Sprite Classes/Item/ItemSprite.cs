using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ItemSprite : ISprite
{
    // create variables
    private Texture2D _spriteSheet;
    private Vector2 _spritePosition;
    private Vector2 _spriteDimensions;
    private Vector2 _positionOnWindow;


    // constructor linking variables
    public ItemSprite(Texture2D spriteSheet, Vector2 position, int x, int y, int width, int height)
    {
        _spriteSheet = spriteSheet;
        _spritePosition.X = x;
        _spritePosition.Y = y;
        _spriteDimensions.X = width;
        _spriteDimensions.Y = height;
        _positionOnWindow = position;
    }


    // update: no logic since items are static and don't move
    public void Update()
    {

    }


    // draw the static sprites
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

    // used for link, apart of ISprite never used in these classes (yet?)
    public void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y)
    {
        throw new System.NotImplementedException();
    }
}
