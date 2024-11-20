using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace _3902_Project
{
    public class CollisionData
    {
        public ICollisionBox ObjectA { get; set; }
        public ICollisionBox ObjectB { get; set; }
        public CollisionType CollisionSide { get; set; }

        public enum CollisionType
        {
            NONE, BOTTOM, TOP, RIGHT, LEFT
        }


        public CollisionData(ICollisionBox a, ICollisionBox b)
        {
            /*
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
            else if (b is EnemyProjCollisionBox)
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
            */
            ObjectA = a;
            ObjectB = b;
            CollisionSide = DetermineCollisionSide(a, b);
        }

        private static CollisionType DetermineCollisionSide(ICollisionBox objectA, ICollisionBox objectB)
        {
            // Determine collision side based on positions and overlap areas
            Rectangle intersection = Rectangle.Intersect(objectA.Bounds, objectB.Bounds);
            if (intersection.Width >= intersection.Height)
            {
                return objectA.Bounds.Top < objectB.Bounds.Top ? CollisionType.BOTTOM : CollisionType.TOP;
            }
            else if (intersection.Width < intersection.Height)
            {
                return objectA.Bounds.Left < objectB.Bounds.Left ? CollisionType.RIGHT : CollisionType.LEFT;
            }
            else
                return CollisionType.NONE;
        }


    }
}
