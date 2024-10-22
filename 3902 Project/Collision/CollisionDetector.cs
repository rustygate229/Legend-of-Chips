using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3902_Project
{

    public class CollisionDetector : ICollisionDetector
    {
        public List<CollisionData> DetectCollisions(List<ICollisionBox> gameObjects)
        {
            //List<ICollisionBox> gameObjects = gameCollisions.SelectMany
            var collisions = new List<CollisionData>();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = i + 1; j < gameObjects.Count; j++)
                {
                    var objectA = gameObjects[i];
                    var objectB = gameObjects[j];
                    if (objectA.Bounds.Intersects(objectB.Bounds))
                    {
                        CollisionType side = DetermineCollisionSide(objectA, objectB);
                        
                        if (objectB.GetType() == typeof(LinkCollisionBox))
                        {
                            //Link, <Other> collision
                            collisions.Add(new CollisionData(objectB, objectA, side));
                        }
                        else if (objectB.GetType() == typeof(EnemyCollisionBox))
                        {
                            //Enemy, <Other> collision (NOT link.) 
                            collisions.Add(new CollisionData(objectB, objectA, side));
                        }
                        else if(objectB is BulletCollisionBox)
                        {

                            collisions.Add(new CollisionData(objectB, objectA, side));
                        }
                        else
                        {
                            collisions.Add(new CollisionData(objectA, objectB, side));
                        }
                    }
                }
            }
            return collisions;
        }

        internal static CollisionType DetermineCollisionSide(ICollisionBox objectA, ICollisionBox objectB)
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
}
