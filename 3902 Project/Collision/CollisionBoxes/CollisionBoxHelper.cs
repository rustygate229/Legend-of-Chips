using Microsoft.Xna.Framework;
using System.Collections.Generic;
using _3902_Project;
using System;

public static class CollisionBoxHelper
{
    public static void KeepInBounds(ICollisionBox collisionBox, Rectangle boundary)
    {
        Rectangle currentBounds = collisionBox.Bounds;

        // Check and correct the X-axis boundaries
        if (currentBounds.X < boundary.Left)
        {
            currentBounds.X = boundary.Left;
        }
        else if (currentBounds.Right > boundary.Right)
        {
            currentBounds.X = boundary.Right - currentBounds.Width;
        }

        // Check and correct the Y-axis boundaries
        if (currentBounds.Y < boundary.Top)
        {
            currentBounds.Y = boundary.Top;
        }
        else if (currentBounds.Bottom > boundary.Bottom)
        {
            currentBounds.Y = boundary.Bottom - currentBounds.Height;
        }

        //Update the collision box position
        collisionBox.Bounds = currentBounds;
    }
    
    

}
