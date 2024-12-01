using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private float _scale;
        public Vector2 GetPositionAhead(float scale)
        {
            _scale = scale;
            // set the directions
            switch (Direction)
            {
                case Renderer.DIRECTION.DOWN:       return SetDownPositionAhead();
                case Renderer.DIRECTION.UP:         return SetUpPositionAhead();
                case Renderer.DIRECTION.RIGHT:      return SetRightPositionAhead();
                case Renderer.DIRECTION.LEFT:       return SetLeftPositionAhead();
                default: throw new ArgumentException("Invalid direction type for CreateGetPositionAhead");
            }
        }

        private Vector2 SetDownPositionAhead()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:           return _rendDownUp.GetPositionAhead(_scale);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:     return _rendDownUp.GetPositionAhead(_scale);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:  return _rendDown.GetPositionAhead(_scale);
                case RendOrder.Size4:               return _rendDown.GetPositionAhead(_scale);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetPositionAhead");

            }
        }

        private Vector2 SetUpPositionAhead()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:               return _rendDownUp.GetPositionAhead(_scale);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendDownUp.GetPositionAhead(_scale);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendUp.GetPositionAhead(_scale);
                case RendOrder.Size4:                   return _rendUp.GetPositionAhead(_scale);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetPositionAhead");
            }
        }

        private Vector2 SetRightPositionAhead()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:               return _rendRightLeft.GetPositionAhead(_scale);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendRight.GetPositionAhead(_scale);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendRightLeft.GetPositionAhead(_scale);
                case RendOrder.Size4:                   return _rendRight.GetPositionAhead(_scale);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetPositionAhead");
            }
        }

        private Vector2 SetLeftPositionAhead()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:               return _rendRightLeft.GetPositionAhead(_scale);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendLeft.GetPositionAhead(_scale);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendRightLeft.GetPositionAhead(_scale);
                case RendOrder.Size4:                   return _rendLeft.GetPositionAhead(_scale);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetPositionAhead");
            }
        }
    }
}