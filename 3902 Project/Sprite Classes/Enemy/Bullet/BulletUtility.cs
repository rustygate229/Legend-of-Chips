using _3902_Project;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public static class BulletUtility
{
    public static void ShootBullet(Vector2 position, int spriteWidth, int spriteHeight, List<BulletSprite> bullets, Random rand)
    {
        float bulletSpeed = 5f;
        Vector2 bulletVelocity;

        int direction = rand.Next(4);
        switch (direction)
        {
            case 0: // Shoot left
                bulletVelocity = new Vector2(-bulletSpeed, 0);
                break;
            case 1: // Shoot right
                bulletVelocity = new Vector2(bulletSpeed, 0);
                break;
            case 2: // Shoot up
                bulletVelocity = new Vector2(0, -bulletSpeed);
                break;
            case 3: // Shoot down
                bulletVelocity = new Vector2(0, bulletSpeed);
                break;
            default:
                bulletVelocity = new Vector2(0, -bulletSpeed);
                break;
        }

        Vector2 bulletPosition = position + new Vector2(spriteWidth / 2, spriteHeight / 2);
        BulletSprite bullet = BulletSpriteFactory.Instance.FireBall(bulletPosition, bulletVelocity);
        bullets.Add(bullet);
    }
}