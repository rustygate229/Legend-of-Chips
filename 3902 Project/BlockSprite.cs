using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

public class BlockSprite : ISprite
{
    private Texture2D SpriteSheet;
    private Vector2 SpritePosition;
    private Vector2 SpriteDimensions;
    private Vector2 Position;

    public BlockSprite(Texture2D spriteSheet, Vector2 position, int x, int y, int width, int height)
    {
        SpriteSheet = spriteSheet;
        SpritePosition.X = x;
        SpritePosition.Y = y;
        SpriteDimensions.X = width;
        SpriteDimensions.Y = height;
        Position = position;

    }

    public void Update()
    {
            
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        // Create a sourceRectangle.
        Rectangle sourceRectangle = new Rectangle((int)SpriteDimensions.X, (int)SpriteDimensions.Y, (int)SpritePosition.X, (int)SpritePosition.Y);

        // Only draw the area contained within the sourceRectangle.
        spriteBatch.Draw(SpriteSheet, Position, sourceRectangle, Color.White);
        spriteBatch.End();
    }

}
