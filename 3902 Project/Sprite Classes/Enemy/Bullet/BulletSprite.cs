using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BulletSprite : ISprite
{
    private Texture2D spritesheet;
    private Vector2 position;
    private Vector2 velocity;
    private Rectangle sourceRectangle;

    // Constructor to initialize the bullet with texture, position, velocity, and source rectangle
    public BulletSprite(Texture2D spritesheet, Vector2 position, Vector2 velocity, int x, int y, int width, int height)
    {
        this.spritesheet = spritesheet;
        this.position = position;
        this.velocity = velocity;
        this.sourceRectangle = new Rectangle(x, y, width, height);
    }

    // Update method to update bullet position based on velocity
    public void Update()
    {
        // Updating the bullet's position based on velocity
        position += velocity;
    }

    // Basic Draw method to render the bullet at its current position
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        spriteBatch.Draw(spritesheet, position, sourceRectangle, Color.White);
        spriteBatch.End();
    }

    // Draw method with extra parameters to support flexible rendering
    public void Draw(SpriteBatch spriteBatch, ILinkStateMachine state, double x, double y)
    {
        // Drawing the bullet at a specific position provided by x and y
        Vector2 drawPosition = new Vector2((float)x, (float)y);

        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        spriteBatch.Draw(spritesheet, drawPosition, sourceRectangle, Color.White);
        spriteBatch.End();
    }

    // Additional method to check if the bullet is off-screen
    public bool IsOffScreen(int screenWidth, int screenHeight)
    {
        return position.X < 0 || position.X > screenWidth || position.Y < 0 || position.Y > screenHeight;
    }
}

