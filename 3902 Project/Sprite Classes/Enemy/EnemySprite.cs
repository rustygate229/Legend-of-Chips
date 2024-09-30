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
    private float velocityx = 2f; // Horizontal speed
    private float velocityy = 2f; // Vertical speed
    private bool canShoot; // Indicates if the enemy can shoot

    // Screen dimensions (update these as per your game's settings)
    private int screenWidth = 800;  // Example screen width
    private int screenHeight = 800; // Example screen height

    // Actual sprite size when drawn on screen
    private int spriteWidth;  // Will be set based on frame width
    private int spriteHeight; // Will be set based on frame height

    // Static Random instance to prevent repeat random numbers
    private static Random rand = new Random();

    // Constructor
    public EnemySprite(Texture2D texture, Vector2 initialPosition, Rectangle sourceRectangle, int rows, int columns, int frameRate, bool canShoot = false)
    {
        this.position = initialPosition;
        this.bullets = new List<BulletSprite>();
        changeDirectionTimer = 0f;
        shootTimer = 0f;
        this.canShoot = canShoot;

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

        // Handle screen boundary collisions

        // Horizontal boundaries
        if (position.X < 0)
        {
            position.X = 0;
            velocity.X = Math.Abs(velocityx); // Move right
            velocity.Y = 0;
        }
        else if (position.X + spriteWidth >= screenWidth)
        {
            position.X = screenWidth - spriteWidth;
            velocity.X = -Math.Abs(velocityx); // Move left
            velocity.Y = 0;
        }

        // Vertical boundaries
        if (position.Y < 0)
        {
            position.Y = 0;
            velocity.Y = Math.Abs(velocityy); // Move down
            velocity.X = 0;
        }
        else if (position.Y + spriteHeight >= screenHeight)
        {
            position.Y = screenHeight - spriteHeight;
            velocity.Y = -Math.Abs(velocityy); // Move up
            velocity.X = 0;
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
            ShootBullet();
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

    // Method to handle bullet shooting
    private void ShootBullet()
    {
        // Bullet's initial position and velocity
        Vector2 bulletVelocity = new Vector2(0, -5f); // Bullets move upwards
        Vector2 bulletPosition = position + new Vector2(spriteWidth / 2, 0); // Start at the enemy's position

        // Create the bullet using FireBall method
        BulletSprite bullet = BulletSpriteFactory.Instance.FireBall(bulletPosition, bulletVelocity);

        // Add new bullet to the list of bullets
        bullets.Add(bullet);
    }

    // Draw method
    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw bullets
        foreach (var bullet in bullets)
        {
            bullet.Draw(spriteBatch);
        }

        // Calculate frame dimensions
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

        // Define destination rectangle on the screen
        Rectangle destinationRect = new Rectangle(
            (int)position.X,
            (int)position.Y,
            frameWidth,
            frameHeight
        );

        // Draw the sprite
        spriteBatch.Begin();
            spriteBatch.Draw(_spriteAnimatedSheet, destinationRect, sourceRect, Color.White);
        spriteBatch.End();
    }

    // Draw method with extra parameters (not implemented)
    public void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y)
    {
        throw new NotImplementedException();
    }
}