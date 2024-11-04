using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace _3902_Project
{
    public class CollisionData
    {
        public ICollisionBox ObjectA { get; set; }
        public ICollisionBox ObjectB { get; set; }
        public CollisionType CollisionSide { get; set; }


        public CollisionData(ICollisionBox a, ICollisionBox b)
        {
            if (b is LinkCollisionBox)
            {
                //Debug.Print("b is link collision box, swapping args");
                ObjectA = b;
                ObjectB = a;
            }
            else if (a is not LinkCollisionBox && b is EnemyCollisionBox)
            {
                //Debug.Print("b is enemy collision box, swapping args");
                //enemy, OTHER collision (not link.)
                ObjectA = b;
                ObjectB = a;
            }
            else if (b is BulletCollisionBox)
            {
                //bullet, OTHER (collision) (probably either an item or a block)
                ObjectA = b;
                ObjectB = a;
            }
            else
            {
                ObjectA = a;
                ObjectB = b;
            }
            CollisionSide = DetermineCollisionSide(ObjectA, ObjectB);

        }

        private static CollisionType DetermineCollisionSide(ICollisionBox objectA, ICollisionBox objectB)
        {
            // Determine collision side based on positions and overlap areas
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

    public enum CollisionType
    {
        NONE, LEFT, RIGHT, TOP, BOTTOM
    }
}
