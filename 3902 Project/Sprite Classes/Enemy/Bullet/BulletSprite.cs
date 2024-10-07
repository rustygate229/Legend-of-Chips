using _3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BulletSprite : ISprite
{
    private Texture2D spritesheet;
    private Vector2 position;
    private Vector2 velocity;
    private Rectangle sourceRectangle;
    private int frameRate;
    private int size; // Size of the bullet (width and height)
    private int currentFrame;
    private int framesCounter;
    private int framesPerSprite;
    private int totalFrames;
    private int columns;
    private int rows;
    private Vector2 spriteDimensions;
    private Vector2 spritePosition;

    private int customSpriteWidth;
    private int customSpriteHeight;


    // Constructor to initialize the bullet with texture, position, velocity, source rectangle, and size
    public BulletSprite(
    Texture2D spritesheet,
    Vector2 position,
    Vector2 velocity,
    int rows,
    int columns,
    int x,
    int y,
    int frameRate,
    int width,
    int height,
    Rectangle sourceRectangle,
    int size = 20)
    {
        this.spritesheet = spritesheet;
        this.position = position;
        this.velocity = velocity;
        this.frameRate = frameRate;
        this.sourceRectangle = new Rectangle(x, y, width, height);
        this.size = size; // Initialize size
        this.rows = rows;
        this.columns = columns;
        this.spriteDimensions = new Vector2(width * columns, height * rows);
        this.spritePosition = new Vector2(x, y);

        currentFrame = 0;

    }

    // Update method to update bullet position based on velocity
    public void Update()
    {
        // Updating the bullet's position based on velocity
        position += velocity;
        framesCounter++;
        if (framesCounter >= framesPerSprite)
        {
            currentFrame++;
            if (currentFrame >= totalFrames)
            {
                currentFrame = 0;
            }
            framesCounter = 0;
        }
    }

    // Basic Draw method to render the bullet at its current position with default size
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        int frameWidth = columns > 0 ? (int)spriteDimensions.X / columns : 1;
        int frameHeight = rows > 0 ? (int)spriteDimensions.Y / rows : 1;

        // Calculate source rectangle of the current frame
        int row = currentFrame / columns;
        int column = currentFrame % columns;
        Rectangle sourceRect = new Rectangle(
            (int)spritePosition.X + (frameWidth * column),
            (int)spritePosition.Y + (frameHeight * row),
            frameWidth,
            frameHeight
        );

        // Define destination rectangle on the screen using custom or default size
        Rectangle destinationRect = new Rectangle(
            (int)position.X,
            (int)position.Y,
            customSpriteWidth > 0 ? customSpriteWidth : size, // Use custom or default width
            customSpriteHeight > 0 ? customSpriteHeight : size // Use custom or default height
        );

        spriteBatch.Draw(
            spritesheet,
            destinationRect,
            sourceRect,
            Color.White
        );

        spriteBatch.End();
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