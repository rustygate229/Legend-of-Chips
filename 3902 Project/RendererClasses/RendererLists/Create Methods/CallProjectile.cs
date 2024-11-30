using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _3902_Project
{
    public partial class RendererLists 
    {
        private ProjectileManager _manager;
        private ProjectileManager.ProjectileNames _projName;
        private ProjectileManager.ProjectileType _projType;
        private float _printScale;

        /// <param name="manager">the projectile manager that stores all current running projectiles</param>
        /// <param name="name">the name associated with the projectile, so it can run in the manager</param>
        /// <param name="type">
        /// <param name="printScale">sprite dimensions * printScale: the scale at which you increase/decrease the print dimensions of the sprite</param>
        public void CallProjectile(ProjectileManager manager, ProjectileManager.ProjectileNames name, ProjectileManager.ProjectileType type, float printScale)
        {
            _manager = manager;
            _projName = name;
            _projType = type;
            _printScale = printScale;
            // set the directions
            switch (Direction)
            {
                case Renderer.DIRECTION.DOWN:   SetDownMovementPosition();      break;        // DOWN Direction
                case Renderer.DIRECTION.UP:     SetUpMovementPosition();        break;        // UP Direciton
                case Renderer.DIRECTION.RIGHT:  SetRightMovementPosition();     break;        // RIGHT Direciton
                case Renderer.DIRECTION.LEFT:   SetLeftMovementPosition();      break;        // LEFT Direciton
                default: throw new ArgumentException("Invalid direction type for CreateGetUpdatePosition");
            }
        }

        private void CallDownProjectile()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:
                    _manager.CallProjectile(_projName, _projType, _rendDownUp.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:
                    _manager.CallProjectile(_projName, _projType, _rendDownUp.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:
                    _manager.CallProjectile(_projName, _projType, _rendDown.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size4:
                    _manager.CallProjectile(_projName, _projType, _rendDown.PositionOnWindow, Direction, _printScale); break;
                default: throw new ArgumentException("Invalid rendOrder type for CreateProjectile");

            }
        }

        private void CallUpProjectile()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:
                    _manager.CallProjectile(_projName, _projType, _rendDownUp.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:
                    _manager.CallProjectile(_projName, _projType, _rendDownUp.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:
                    _manager.CallProjectile(_projName, _projType, _rendUp.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size4:
                    _manager.CallProjectile(_projName, _projType, _rendUp.PositionOnWindow, Direction, _printScale); break;
                default: throw new ArgumentException("Invalid rendOrder type for CreateProjectile");
            }
        }

        private void CallRightProjectile()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:
                    _manager.CallProjectile(_projName, _projType, _rendRightLeft.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:
                    _manager.CallProjectile(_projName, _projType, _rendRight.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:
                    _manager.CallProjectile(_projName, _projType, _rendRightLeft.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size4:
                    _manager.CallProjectile(_projName, _projType, _rendRight.PositionOnWindow, Direction, _printScale); break;
                default: throw new ArgumentException("Invalid rendOrder type for CreateProjectile");
            }
        }

        private void CallLeftProjectile()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip: 
                    _manager.CallProjectile(_projName, _projType,_rendRightLeft.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:
                    _manager.CallProjectile(_projName, _projType, _rendLeft.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:
                    _manager.CallProjectile(_projName, _projType, _rendRightLeft.PositionOnWindow, Direction, _printScale); break;
                case RendOrder.Size4:
                    _manager.CallProjectile(_projName, _projType, _rendLeft.PositionOnWindow, Direction, _printScale); break;
                default: throw new ArgumentException("Invalid rendOrder type for CreateProjectile");
            }
        }
    }
}