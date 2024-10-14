
using Microsoft.Xna.Framework;
using Collision.I;
using System.Collections.Generic;
using System;


namespace _3902_Project;

    public class CollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameObject objectA, IGameObject objectB, CollisionType side)
        {
            if (objectB is Block)
            {
                // Prevent player from moving through the block
                if (objectA is LinkPlayer player)
                {
                    switch (side)
                    {
                        case CollisionType.Left:
                            player.SetPosition(player.Bounds.Right, player.Bounds.Y);
                            break;
                        case CollisionType.Right:
                            player.SetPosition(player.Bounds.Left - player.Bounds.Width, player.Bounds.Y);
                            break;
                        case CollisionType.Top:
                            player.SetPosition(player.Bounds.X, player.Bounds.Bottom);
                            break;
                        case CollisionType.Bottom:
                            player.SetPosition(player.Bounds.X, player.Bounds.Top - player.Bounds.Height);
                            break;
                    }
                }
            }
        }
    }



