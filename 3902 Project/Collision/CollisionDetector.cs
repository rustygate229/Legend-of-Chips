using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace _3902_Project
{

    public class CollisionDetector 
    {
        public static List<CollisionData> DetectCollisions(List<List<ICollisionBox>> gameObjects)
        {
            List<CollisionData> collisions = new List<CollisionData>();
            //broken into multiple segments - one is link and everything, one is enemy and block
            ICollisionBox link = gameObjects[0][0];

            for(int i = 1; i < gameObjects.Count; i++)
            {
                for(int j = 0; j < gameObjects[i].Count; j++)
                {
                    ICollisionBox objectB = gameObjects[i][j];
                    if(link.Bounds.Intersects(objectB.Bounds))
                    {
                        collisions.Add(new CollisionData(link, objectB));
                    }
                }
            }



            //List<ICollisionBox> gameObjects = gameCollisions.SelectMany
            /*var collisions = new List<CollisionData>();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = i + 1; j < gameObjects.Count; j++)
                {
                    var objectA = gameObjects[i];
                    var objectB = gameObjects[j];
                    if (objectA.Bounds.Intersects(objectB.Bounds))
                    {
                        CollisionType side = DetermineCollisionSide(objectA, objectB);
                        
                            collisions.Add(new CollisionData(objectA, objectB, side));
                        
                    }
                }
            }*/
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
