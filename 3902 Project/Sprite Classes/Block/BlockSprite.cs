using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BlockSprite : ISprite
{
    // create variables
    private Texture2D _spriteSheet;
    private Vector2 _spritePosition;
    private Vector2 _spriteDimensions;
    private Vector2 _positionOnWindow;


    // constructor linking variables
    public BlockSprite(Texture2D spriteSheet, Vector2 position, int x, int y, int width, int height)
    {
        _spriteSheet = spriteSheet;
        _spritePosition.X = x;
        _spritePosition.Y = y;
        _spriteDimensions.X = width;
        _spriteDimensions.Y = height;
        _positionOnWindow = position;
    }


    // update: no logic since blocks are static and don't move - might need a BlockSpriteAnimated in future
    public void Update()
    {
            
    }


    // draw the static blocks
    public void Draw(SpriteBatch spriteBatch)
    {
        // removes anti-aliasing
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // create a sourceRectangle and a destinationRectangle
        Rectangle sourceRectangle = new Rectangle((int)_spritePosition.X, (int)_spritePosition.Y, (int)_spriteDimensions.X, (int)_spriteDimensions.Y);
        Rectangle destinationRectangle = new Rectangle((int)_positionOnWindow.X, (int)_positionOnWindow.Y, 64, 64);

        // draw the area contained by the sourceRectangle to the destinationRectangle
        spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }
}
