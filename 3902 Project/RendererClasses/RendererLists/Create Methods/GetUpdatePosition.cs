using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private float _positionSpeed;
        public Vector2 GetUpdatePosition(float positionSpeed)
        {
            _positionSpeed = positionSpeed;
            // set the directions
            switch (Direction)
            {
                case Renderer.DIRECTION.DOWN:       return SetDownMovementPosition();
                case Renderer.DIRECTION.UP:         return SetUpMovementPosition();
                case Renderer.DIRECTION.RIGHT:      return SetRightMovementPosition();
                case Renderer.DIRECTION.LEFT:       return SetLeftMovementPosition();
                default: throw new ArgumentException("Invalid direction type for CreateGetUpdatePosition");
            }
        }

        private Vector2 SetDownMovementPosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:           return _rendDownUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:     return _rendDownUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:  return _rendDown.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size4:               return _rendDown.GetUpdatePosition(_positionSpeed);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetUpdatePosition");

            }
        }

        private Vector2 SetUpMovementPosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:               return _rendDownUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendDownUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size4:                   return _rendUp.GetUpdatePosition(_positionSpeed);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetUpdatePosition");
            }
        }

        private Vector2 SetRightMovementPosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:               return _rendRightLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendRight.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendRightLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size4:                   return _rendRight.GetUpdatePosition(_positionSpeed);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetUpdatePosition");
            }
        }

        private Vector2 SetLeftMovementPosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:               return _rendRightLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendRightLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size4:                   return _rendLeft.GetUpdatePosition(_positionSpeed);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetUpdatePosition");
            }
        }
    }
}