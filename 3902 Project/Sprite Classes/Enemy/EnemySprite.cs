using _3902_Project;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using _3902_Project.Content.command.receiver;

public class EnemySprite : ISprite
{
    // Animation fields
    private Texture2D _spriteAnimatedSheet;
    private Vector2 _spritePosition;     // Starting position in the sprite sheet (sourceRectangle.X, sourceRectangle.Y)
    private Vector2 _spriteDimensions;   // Total dimensions (sourceRectangle.Width, sourceRectangle.Height)
    private int _rows;
    private int _columns;
    private int _currentFrame;
    private int _totalFrames;
    private int _frameRate;
    private int _framesPerSprite;
    private int _framesCounter;

    // Position and movement fields
    private Vector2 position;
    private Vector2 velocity;

    // Timers and intervals
    private float changeDirectionTimer;
    private const float ChangeDirectionInterval = 120; // Frame-based interval
    private float shootTimer;
    private const float ShootInterval = 60; // Shoot every 60 frames

    // Bullets
    private List<BulletSprite> bullets;

    // Speed and other constants
    private float velocityx;
    private float velocityy;
    private bool canShoot; // Indicates if the enemy can shoot

    // Screen dimensions
    private int screenWidth;
    private int screenHeight;

    private int customSpriteWidth;
    private int customSpriteHeight;

    private int spriteWidth;  // Calculated based on source rectangle
    private int spriteHeight; // Calculated based on source rectangle

    // Static Random instance to prevent repeat random numbers
    private static Random rand = new Random();

    // Constructor with default or custom size
    public EnemySprite(Texture2D texture,
        Vector2 initialPosition,
        Rectangle sourceRectangle,
        int rows, int columns, int frameRate, bool canShoot = false, int customWidth = 50, int customHeight = 50, float velocityX = 2f, float velocityY = 2f, int screenWidth = 600, int screenHeight = 450)
    {
        this.position = initialPosition;
        this.bullets = new List<BulletSprite>();
        changeDirectionTimer = 0f;
        shootTimer = 0f;
        this.canShoot = canShoot;
        this.velocityx = velocityX;
        this.velocityy = velocityY;
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;

        // Initialize the animated sprite parameters
        _spriteAnimatedSheet = texture;
        _spritePosition = new Vector2(sourceRectangle.X, sourceRectangle.Y);
        _spriteDimensions = new Vector2(sourceRectangle.Width, sourceRectangle.Height);
        _rows = rows;
        _columns = columns;
        _frameRate = frameRate;

        _currentFrame = 0;
        _totalFrames = _rows * _columns;
        _framesCounter = 0;
        _framesPerSprite = _frameRate / _totalFrames;

        // Calculate sprite width and height based on frame dimensions
        spriteWidth = sourceRectangle.Width / _columns;
        spriteHeight = sourceRectangle.Height / _rows;

        // Set custom sprite size, defaulting to the provided constants
        customSpriteWidth = customWidth;
        customSpriteHeight = customHeight;

        // Randomly choose initial direction
        int initialDirection = rand.Next(4);
        switch (initialDirection)
        {
            case 0: // Move left
                this.velocity = new Vector2(-Math.Abs(velocityx), 0);
                break;
            case 1: // Move right
                this.velocity = new Vector2(Math.Abs(velocityx), 0);
                break;
            case 2: // Move up
                this.velocity = new Vector2(0, -Math.Abs(velocityy));
                break;
            case 3: // Move down
                this.velocity = new Vector2(0, Math.Abs(velocityy));
                break;
        }
    }

    // Update method
    public void Update()
    {
        // Increment timers
        changeDirectionTimer++;
        shootTimer++;

        // Update position
        position += velocity;

        // Handle screen boundary collisions
        (position, velocity) = Collision.BoundaryCollisions(position, velocity, velocityx, velocityy, spriteWidth, spriteHeight, screenWidth, screenHeight);

        // Update animation frames
        _framesCounter++;
        if (_framesCounter >= _framesPerSprite)
        {
            _currentFrame++;
            if (_currentFrame >= _totalFrames)
            {
                _currentFrame = 0;
            }
            _framesCounter = 0;
        }

        // Change direction periodically (random horizontal or vertical movement)
        if (changeDirectionTimer >= ChangeDirectionInterval)
        {
            // Randomly choose a direction: 0 = left, 1 = right, 2 = up, 3 = down
            int direction = rand.Next(4);
            switch (direction)
            {
                case 0: // Move left
                    velocity.X = -Math.Abs(velocityx);
                    velocity.Y = 0;
                    break;
                case 1: // Move right
                    velocity.X = Math.Abs(velocityx);
                    velocity.Y = 0;
                    break;
                case 2: // Move up
                    velocity.X = 0;
                    velocity.Y = -Math.Abs(velocityy);
                    break;
                case 3: // Move down
                    velocity.X = 0;
                    velocity.Y = Math.Abs(velocityy);
                    break;
            }
            changeDirectionTimer = 0f; // Reset the timer
        }

        // Shooting logic (only if the enemy can shoot)
        if (canShoot && shootTimer >= ShootInterval)
        {
            BulletUtility.ShootBullet(position, spriteWidth, spriteHeight, bullets, rand);
            shootTimer = 0f; // Reset the timer after shooting
        }

        // Update all bullets
        foreach (var bullet in bullets)
        {
            bullet.Update();
        }

        // Remove bullets that are off-screen
        bullets.RemoveAll(b => b.IsOffScreen(screenWidth, screenHeight));
    }

    // Draw method with custom size or default size
    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw bullets
        foreach (var bullet in bullets)
        {
            bullet.Draw(spriteBatch);
        }

        // Calculate frame dimensions from the sprite sheet
        int frameWidth = (int)_spriteDimensions.X / _columns;
        int frameHeight = (int)_spriteDimensions.Y / _rows;

        // Calculate source rectangle of the current frame
        int row = _currentFrame / _columns;
        int column = _currentFrame % _columns;
        Rectangle sourceRect = new Rectangle(
            (int)_spritePosition.X + (frameWidth * column),
            (int)_spritePosition.Y + (frameHeight * row),
            frameWidth,
            frameHeight
        );

        // Define destination rectangle on the screen using custom or default size
        Rectangle destinationRect = new Rectangle(
            (int)position.X,
            (int)position.Y,
            customSpriteWidth,   // Use custom or default width
            customSpriteHeight   // Use custom or default height
        );

        // Draw the sprite
        spriteBatch.Begin();
        spriteBatch.Draw(_spriteAnimatedSheet, destinationRect, sourceRect, Color.White);
        spriteBatch.End();
    }
}