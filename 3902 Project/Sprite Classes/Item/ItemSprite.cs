using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ItemSprite : ISprite
{
    // create variables
    private Texture2D _spriteSheet;
    private Vector2 _spritePosition;
    private Vector2 _spriteDimensions;
    private Vector2 _spritePrintDimensions;
    private Vector2 _positionOnWindow;


    // constructor linking variables
    public ItemSprite(Texture2D spriteSheet, Vector2 spawnPosition, int xSpritePosition, int ySpritePosition, int xDimension, int yDimension, int xPrintDimension, int yPrintDimension)
    {
        _spriteSheet = spriteSheet;
        _spritePosition.X = xSpritePosition;
        _spritePosition.Y = ySpritePosition;
        _spriteDimensions.X = xDimension;
        _spriteDimensions.Y = yDimension;
        _spritePrintDimensions.X = xPrintDimension;
        _spritePrintDimensions.Y = yPrintDimension;
        _positionOnWindow = spawnPosition;
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
        Rectangle destinationRectangle = new Rectangle((int)_positionOnWindow.X - ((int)_spritePrintDimensions.X / 2), (int)_positionOnWindow.Y - ((int)_spritePrintDimensions.Y / 2), (int)_spritePrintDimensions.X, (int)_spritePrintDimensions.Y);

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
