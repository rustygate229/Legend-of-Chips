using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BulletSprite : ISprite
{
    private Texture2D[] frames;
    private Vector2 position;
    private Vector2 velocity;
    private float animationTimer;
    private int currentFrame;

    // Constructor to initialize the bullet with frames, position, and velocity
    public BulletSprite(Texture2D[] frames, Vector2 position, Vector2 velocity)
    {
        this.frames = frames;
        this.position = position;
        this.velocity = velocity;
        currentFrame = 0;
        animationTimer = 0f;
    }

    // Implementing the ISprite Update method without parameters (empty because bullet always needs gameTime to update)
    public void Update()
    {
        // Required by the ISprite interface, can be left empty or provide default behavior
    }

    // Update the bullet position and animate it
    public void Update(GameTime gameTime)
    {
        // Update the bullet's position
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Update the animation frames
        animationTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= 0.2f) // Change frame every 0.2 seconds
        {
            currentFrame = (currentFrame + 1) % frames.Length;
            animationTimer = 0f;
        }
    }

    // Implementing the ISprite Draw method (basic version)
    public void Draw(SpriteBatch spriteBatch)
    {
        float scale = 0.5f;
        // Draw the bullet at its position with scaling and centered
        spriteBatch.Draw(frames[currentFrame], position, null, Color.White, 0f, new Vector2(frames[currentFrame].Width / 2, frames[currentFrame].Height / 2), scale, SpriteEffects.None, 0f);
    }

    // Implementing the ISprite Draw method with extra parameters
    public void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y)
    {
        // Draw at the position defined by x and y (converted to float)
        Vector2 drawPosition = new Vector2((float)x, (float)y);
        float scale = 0.5f;
        sb.Draw(frames[currentFrame], drawPosition, null, Color.White, 0f, new Vector2(frames[currentFrame].Width / 2, frames[currentFrame].Height / 2), scale, SpriteEffects.None, 0f);
    }

    // Method to check if the bullet is off-screen
    public bool IsOffScreen(int screenWidth, int screenHeight)
    {
        return position.X < 0 || position.X > screenWidth || position.Y < 0 || position.Y > screenHeight;
    }
}

