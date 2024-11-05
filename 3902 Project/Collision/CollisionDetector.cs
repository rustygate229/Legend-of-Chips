using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3902_Project
{

    public class CollisionDetector
    {
        public static List<CollisionData> DetectCollisions(List<List<ICollisionBox>> gameObjects)
        {
            List<CollisionData> collisions = new List<CollisionData>();
            //broken into multiple segments - one is link and everything, one is enemy and block
            ICollisionBox link = gameObjects[0][0];

            for (int i = 1; i < gameObjects.Count; i++)
            {
                if (i == 2)
                {
                    //runs block collisions
                    CollisionData collision = DetectBlockCollisions(link, gameObjects[i]);
                    if (collision != null) collisions.Add(collision);
                }
                else
                {
                    //for all other collision lists
                    for (int j = 0; j < gameObjects[i].Count; j++)
                    {
                        ICollisionBox objectB = gameObjects[i][j];
                        if (link.Bounds.Intersects(objectB.Bounds))
                        {
                            collisions.Add(new CollisionData(link, objectB));

                        }
                    }
                }
            }

            //looping over enemy and blocks
            for (int i = 0; i < gameObjects[1].Count; i++)
            {
                for (int j = 0; j < gameObjects[2].Count; j++)
                {
                    //enemy, block collision checks
                    ICollisionBox objectA = gameObjects[1][i];
                    ICollisionBox objectB = gameObjects[2][j];
                    if (objectA.Bounds.Intersects(objectB.Bounds))
                    {
                        collisions.Add(new CollisionData(objectA, objectB));
                    }
                }
            }

            //enemy and PROJECTILES collision checks
            for (int i = 0; i < gameObjects[1].Count; i++)
            {
                for (int j = 0; j < gameObjects[4].Count; j++)
                {
                    ICollisionBox objectA = gameObjects[1][i];
                    ICollisionBox objectB = gameObjects[4][j];
                    if (objectA.Bounds.Intersects(objectB.Bounds))
                    {
                        //enemy, projectiles
                        collisions.Add(new CollisionData(objectA, objectB));
                    }
                }

            }

            return collisions;
        }

        private static CollisionData DetectBlockCollisions(ICollisionBox link, List<ICollisionBox> collisions)
        {
            bool collidedWithBlock = false;
            float percent = 0f;
            CollisionData collision = null;

            for (int x = 0; x < collisions.Count; x++)
            {
                ICollisionBox block = collisions[x];
                if (link.Bounds.Intersects(block.Bounds))
                {
                    float tempPercent = IntersectsPercentage(link.Bounds, block.Bounds);
                    if (!collidedWithBlock)
                    {
                        collidedWithBlock = true;
                        collision = new CollisionData(link, block);
                        percent = tempPercent;
                    }
                    else if (collidedWithBlock && tempPercent > percent)
                    {
                        //Debug.Print("detected second block collision");
                        collision = new CollisionData(link, block);
                        percent = tempPercent;
                    }
                }
            }

            return collision;

        }

        private static float IntersectsPercentage(Rectangle source, Rectangle target)
        {
            if (source.Width == 0 || source.Height == 0)
            {
                //checks for divide by 0 exception
                return 0f;
            }

            Rectangle.Intersect(ref source, ref target, out Rectangle overlap);

            float xIntersect = (float)overlap.Width / (float)source.Width;
            float yIntersect = (float)overlap.Height / (float)source.Height;

            return xIntersect * yIntersect;
        }




    }
}

