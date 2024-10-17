//CollisionDetectorHelper.cs (New Helper Class for Collision Side Determination)
using _3902_Project;
using Microsoft.Xna.Framework;

public static class CollisionDetectorHelper
{
    public static CollisionType DetermineCollisionSide(ICollisionBox objectA, ICollisionBox objectB)
    {
        Rectangle intersection = Rectangle.Intersect(objectA.Bounds, objectB.Bounds);
        if (intersection.Width >= intersection.Height)
        {
            return objectA.Bounds.Top < objectB.Bounds.Top ? CollisionType.BOTTOM : CollisionType.TOP;
        }
        else
        {
            return objectA.Bounds.Left < objectB.Bounds.Left ? CollisionType.RIGHT : CollisionType.LEFT;
        }
    }
}