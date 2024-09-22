using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BlockSprite : ISprite
{
    private Texture2D SpriteSheet;
    private Vector2 SpritePosition;
    private Vector2 SpriteDimensions;
    private Vector2 PositionOnWindow;

    public BlockSprite(Texture2D spriteSheet, Vector2 position, int x, int y, int width, int height)
    {
        SpriteSheet = spriteSheet;
        SpritePosition.X = x;
        SpritePosition.Y = y;
        SpriteDimensions.X = width;
        SpriteDimensions.Y = height;
        PositionOnWindow = position;
    }

    public void Update()
    {
            
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        // Create a sourceRectangle.
        Rectangle sourceRectangle = new Rectangle((int)SpriteDimensions.X, (int)SpriteDimensions.Y, (int)SpritePosition.X, (int)SpritePosition.Y);
        Rectangle destinationRectangle = new Rectangle((int)PositionOnWindow.X, (int)PositionOnWindow.Y, 64, 64);

        // Only draw the area contained within the sourceRectangle.
        spriteBatch.Draw(SpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }

}
