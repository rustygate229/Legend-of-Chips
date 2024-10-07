using _3902_Project;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public static class Collision
{
    public static (Vector2 position, Vector2 velocity) BoundaryCollisions(Vector2 position, Vector2 velocity, float velocityx, float velocityy, int spriteWidth, int spriteHeight, int screenWidth, int screenHeight)
    {
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

        return (position, velocity);
    }
}