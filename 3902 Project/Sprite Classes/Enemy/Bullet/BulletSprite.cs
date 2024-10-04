using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BulletSprite : ISprite
{
    private Texture2D spritesheet;
    private Vector2 position;
    private Vector2 velocity;
    private Rectangle sourceRectangle;
    private int size; // Size of the bullet (width and height)

    // Constructor to initialize the bullet with texture, position, velocity, source rectangle, and size
    public BulletSprite(
        Texture2D spritesheet,
        Vector2 position,
        Vector2 velocity,
        int x,
        int y,
        int width,
        int height,
        int size = 20 
    )
    {
        this.spritesheet = spritesheet;
        this.position = position;
        this.velocity = velocity;
        this.sourceRectangle = new Rectangle(x, y, width, height);
        this.size = size; // Initialize size
    }

    // Update method to update bullet position based on velocity
    public void Update()
    {
        // Updating the bullet's position based on velocity
        position += velocity;
    }

    // Basic Draw method to render the bullet at its current position with default size
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(
            spritesheet,
            new Rectangle(
                (int)position.X,
                (int)position.Y,
                size,
                size
            ),
            sourceRectangle,
            Color.White
        );
        spriteBatch.End();
    }

    // Draw method with extra parameters to support flexible rendering
    public void Draw(SpriteBatch spriteBatch, double x, double y)
    {
        throw new System.NotImplementedException();
    }

    // Additional method to check if the bullet is off-screen, adjusted for size
    public bool IsOffScreen(int screenWidth, int screenHeight)
    {
        return position.X + size < 0 ||
               position.X > screenWidth ||
               position.Y + size < 0 ||
               position.Y > screenHeight;
    }
}
