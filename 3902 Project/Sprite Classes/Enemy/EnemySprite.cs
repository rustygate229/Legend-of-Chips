using _3902_Project;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;

public class EnemySprite : ISprite
{
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

    // Animation instance
    private Animation animation;

    // Static Random instance to prevent repeat random numbers
    private static Random rand = new Random();

    // Constructor with default or custom size
    public EnemySprite(Texture2D texture,
        Vector2 initialPosition,
        Rectangle sourceRectangle,
        int rows, int columns,
        int frameRate, bool canShoot = false,
        int customWidth = 50, int customHeight = 50, 
        float velocityX = 2f, float velocityY = 2f, 
        int screenWidth = 800, int screenHeight = 450)
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
        animation = new Animation(texture, sourceRectangle, rows, columns, frameRate);

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
        (position, velocity) = Collision.BoundaryCollisions(position, velocity, velocityx, velocityy, customSpriteWidth, customSpriteHeight, screenWidth, screenHeight);

        // Update animation frames
        animation.Update();

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
            BulletUtility.ShootBullet(position, customSpriteWidth, customSpriteHeight, bullets, rand);
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

        // Draw the animated sprite
        animation.Draw(spriteBatch, position, customSpriteWidth, customSpriteHeight);
    }
}