using _3902_Project;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

public class EnemySprite : ISprite
{
    private Texture2D texture;
    private Rectangle sourceRectangle;
    private Vector2 position;
    private Vector2 velocity;
    private float changeDirectionTimer;
    private const float ChangeDirectionInterval = 2f;
    private float shootTimer;
    private const float ShootInterval = 1f;
    private Texture2D[] bulletFrames;
    private List<BulletSprite> bullets;
    private int currentFrame = 0;
    private float animationTimer = 0f;
    private float velocityx = 200f;

    // Constructor to accept a texture and rectangle for the enemy's sprite, optionally bullets
    public EnemySprite(Texture2D texture, Vector2 initialPosition, Rectangle sourceRectangle, Texture2D[] bulletFrames = null)
    {
        this.texture = texture;
        this.position = initialPosition;
        this.sourceRectangle = sourceRectangle;
        this.velocity = new Vector2(0, 0); // Default velocity (can modify this as needed)
        this.bulletFrames = bulletFrames;
        this.bullets = new List<BulletSprite>();
        changeDirectionTimer = 0f;
        shootTimer = 0f;
    }
    public void Update()
    {
        // This method is required by ISprite but may be left empty or contain default logic
    }


    // Implementing the ISprite Update method (with parameters)
    public void Update(GameTime gameTime, int screenWidth, int screenHeight)
    {
        // Updating position and other logic
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        changeDirectionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        animationTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Handle screen boundary collisions
        if (position.X < 0 || position.X + sourceRectangle.Width > screenWidth)
        {
            velocity.X = -velocity.X;
        }

        if (position.Y < 0 || position.Y + sourceRectangle.Height > screenHeight)
        {
            velocity.Y = -velocity.Y;
        }

        // Change direction periodically
        if (changeDirectionTimer >= ChangeDirectionInterval)
        {
            Random rand = new Random();
            velocity = rand.Next(2) == 0 ? new Vector2(-velocityx, 0) : new Vector2(velocityx, 0);
            changeDirectionTimer = 0f;
        }

        // Shooting logic (only if bullet frames are provided)
        if (bulletFrames != null)
        {
            shootTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (shootTimer >= ShootInterval)
            {
                ShootBullet();
                shootTimer = 0f;
            }

            // Update all bullets
            foreach (var bullet in bullets)
            {
                bullet.Update(gameTime);
            }

            // Remove bullets that are off-screen
            bullets.RemoveAll(b => b.IsOffScreen(screenWidth, screenHeight));
        }
    }

    // Method to handle bullet shooting (if bullet frames exist)
    private void ShootBullet()
    {
        if (bulletFrames == null) return; // No bullet shooting if no bullet frames are provided

        Vector2 bulletVelocity = Vector2.Normalize(velocity) * 300f;
        Vector2 bulletPosition = position + new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);

        if (velocity.X > 0) bulletPosition.X += sourceRectangle.Width / 2;
        else if (velocity.X < 0) bulletPosition.X -= sourceRectangle.Width / 2;
        else if (velocity.Y > 0) bulletPosition.Y += sourceRectangle.Height / 2;
        else if (velocity.Y < 0) bulletPosition.Y -= sourceRectangle.Height / 2;

        // Adding a new bullet to the list of bullets
        bullets.Add(new BulletSprite(bulletFrames, bulletPosition, bulletVelocity));
    }

    // Implementing the ISprite Draw method (basic version)
    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw bullets (only if bullet frames exist)
        if (bulletFrames != null)
        {
            foreach (var bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }

        // Draw the enemy sprite using the given texture and source rectangle
        spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
    }

    // Implementing the ISprite Draw method with extra parameters (as per interface)
    public void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y)
    {
        // Create a position vector based on the double coordinates provided
        Vector2 drawPosition = new Vector2((float)x, (float)y);

        // Draw bullets (only if bullet frames exist)
        if (bulletFrames != null)
        {
            foreach (var bullet in bullets)
            {
                bullet.Draw(sb);
            }
        }

        // Drawing the sprite at the given position
        sb.Draw(texture, drawPosition, sourceRectangle, Color.White);
    }
}
