using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        public ISprite CreateProjectile(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch(_rendListType)
            {
                case RendOrder.Size2:
                    return CreateProjectileSize2(manager, projectileName, timer, speed, printScale, frameRanges);
                case RendOrder.Size3DownUp:
                    return CreateProjectileSize3DownUp(manager, projectileName, timer, speed, printScale, frameRanges);
                case RendOrder.Size3RightLeft:
                    return CreateProjectileSize3RightLeft(manager, projectileName, timer, speed, printScale, frameRanges);
                case RendOrder.Size4:
                    return CreateProjectileSize4(manager, projectileName, timer, speed, printScale, frameRanges);
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private ISprite CreateProjectileSize2(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch ((int)_direction)
            {
                case 0: // spawn DOWN
                    return manager.CallProjectile(projectileName, _rendDownUp.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 1: // spawn UP
                    return manager.CallProjectile(projectileName,_rendDownUp.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 2: // spawn RIGHT
                    return manager.CallProjectile(projectileName, _rendRightLeft.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 3: // spawn LEFT
                    return manager.CallProjectile(projectileName, _rendRightLeft.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                default: throw new ArgumentException("Invalid direction for CreateProjectile");
            }
        }

        private ISprite CreateProjectileSize3DownUp(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch ((int)_direction)
            {
                case 0: // spawn DOWN
                    return manager.CallProjectile(projectileName, _rendDownUp.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 1: // spawn UP
                    return manager.CallProjectile(projectileName, _rendDownUp.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 2: // spawn RIGHT
                    return manager.CallProjectile(projectileName, _rendRight.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 3: // spawn LEFT
                    return manager.CallProjectile(projectileName, _rendLeft.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                default: throw new ArgumentException("Invalid direction for CreateProjectile");
            }
        }

        private ISprite CreateProjectileSize3RightLeft(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch ((int)_direction)
            {
                case 0: // spawn DOWN
                    return manager.CallProjectile(projectileName, _rendDown.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 1: // spawn UP
                    return manager.CallProjectile(projectileName, _rendUp.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 2: // spawn RIGHT
                    return manager.CallProjectile(projectileName, _rendRightLeft.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 3: // spawn LEFT
                    return manager.CallProjectile(projectileName, _rendRightLeft.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                default: throw new ArgumentException("Invalid direction for CreateProjectile");
            }
        }

        private ISprite CreateProjectileSize4(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch ((int)_direction)
            {
                case 0: // spawn DOWN
                    return manager.CallProjectile(projectileName, _rendDown.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 1: // spawn UP
                    return manager.CallProjectile(projectileName, _rendUp.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 2: // spawn RIGHT
                    return manager.CallProjectile(projectileName, _rendRight.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                case 3: // spawn LEFT
                    return manager.CallProjectile(projectileName, _rendLeft.GetPosition(), _direction, timer, speed, printScale, frameRanges);
                default: throw new ArgumentException("Invalid direction for CreateProjectile");
            }
        }
    }
}