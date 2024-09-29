using _3902_Project;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using _3902_Project.Content.command.receiver;

public class EnemySprite : ISprite
{
    private Texture2D texture;
    private Rectangle sourceRectangle;
    private Vector2 position;
    private Vector2 velocity;
    private float changeDirectionTimer;
    private const float ChangeDirectionInterval = 120; // Frame-based interval (e.g., every 120 frames)
    private float shootTimer;
    private const float ShootInterval = 60; // Shoot every 60 frames
    private List<BulletSprite> bullets;
    private int currentFrame = 0;
    private float velocityx = 2f; // Horizontal speed (per frame)
    private float velocityy = 1f; // Vertical speed (per frame)
    private bool canShoot; // Indicates if the enemy can shoot

    // Fixed screen dimensions (can be dynamically set if necessary)
    private int screenWidth = 800;  // Example screen width
    private int screenHeight = 600; // Example screen height

    // Static Random instance to prevent repeat random numbers
    private static Random rand = new Random();

    // Constructor to accept a texture, position, source rectangle, and canShoot flag
    public EnemySprite(Texture2D texture, Vector2 initialPosition, Rectangle sourceRectangle, bool canShoot = false)
    {
        this.texture = texture;
        this.position = initialPosition;
        this.sourceRectangle = sourceRectangle;
        this.velocity = new Vector2(velocityx, 0); // Set initial velocity, moving horizontally
        this.bullets = new List<BulletSprite>();
        changeDirectionTimer = 0f;
        shootTimer = 0f;
        this.canShoot = canShoot;
    }

    // Update method
    public void Update()
    {
        // Increment frame-based timers
        changeDirectionTimer++;
        shootTimer++;

        // Update position based on velocity
        position += velocity;

        // Handle screen boundary collisions
        if (position.X < 0 || position.X + sourceRectangle.Width > screenWidth)
        {
            velocity.X = -velocity.X; // Reverse the horizontal direction
        }

        if (position.Y < 0 || position.Y + sourceRectangle.Height > screenHeight)
        {
            velocity.Y = -velocity.Y; // Reverse the vertical direction if needed
        }

        // Change direction periodically (random horizontal movement)
        if (changeDirectionTimer >= ChangeDirectionInterval)
        {
            // Randomly choose left or right direction
            velocity.X = rand.Next(2) == 0 ? -velocityx : velocityx;
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
        Vector2 bulletPosition = position + new Vector2(sourceRectangle.Width / 2, 0); // Start at the enemy's position

        // Create the bullet using BulletSpriteFactory
        BulletSprite bullet = BulletSpriteFactory.Instance.FireBall(bulletPosition, bulletVelocity);

        // Add new bullet to the list of bullets
        bullets.Add(bullet);
    }

    // Implementing the ISprite Draw method
    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw bullets
        foreach (var bullet in bullets)
        {
            bullet.Draw(spriteBatch);
        }

        // Draw the enemy sprite
        spriteBatch.Begin();
        spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
        spriteBatch.End();
    }

    // Implementing the ISprite Draw method with extra parameters
    public void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y)
    {
        // Create a position vector based on the double coordinates provided
        Vector2 drawPosition = new Vector2((float)x, (float)y);

        // Draw bullets
        foreach (var bullet in bullets)
        {
            bullet.Draw(sb);
        }

        // Draw the enemy sprite at the given position
        sb.Draw(texture, drawPosition, sourceRectangle, Color.White);
    }
}
