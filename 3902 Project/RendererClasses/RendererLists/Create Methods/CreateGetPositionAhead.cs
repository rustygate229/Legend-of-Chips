using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        /// <param name="positionSpeed">the speed at which the update position is set to</param>
        /// <returns>returns the updated position direction of the current renderer in the list</returns>
        public Vector2 CreateGetPositionAhead() { return GetPositionAhead(); }

        private Vector2 GetPositionAhead()
        {
            // set the directions
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: return SetDownPositionAhead();         // DOWN Direction
                case Renderer.DIRECTION.UP: return SetUpPositionAhead();             // UP Direciton
                case Renderer.DIRECTION.RIGHT: return SetRightPositionAhead();       // RIGHT Direciton
                case Renderer.DIRECTION.LEFT: return SetLeftPositionAhead();         // LEFT Direciton
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
                case RendOrder.Size2Flip:           return _rendDownUp.GetPositionAhead();
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:     return _rendDownUp.GetPositionAhead();
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:  return _rendDown.GetPositionAhead();
                case RendOrder.Size4:               return _rendDown.GetPositionAhead();
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
                case RendOrder.Size2Flip:               return _rendDownUp.GetPositionAhead();
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendDownUp.GetPositionAhead();
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendUp.GetPositionAhead();
                case RendOrder.Size4:                   return _rendUp.GetPositionAhead();
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
                case RendOrder.Size2Flip:               return _rendRightLeft.GetPositionAhead();
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendRight.GetPositionAhead();
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendRightLeft.GetPositionAhead();
                case RendOrder.Size4:                   return _rendRight.GetPositionAhead();
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
                case RendOrder.Size2Flip:               return _rendRightLeft.GetPositionAhead();
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendLeft.GetPositionAhead();
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendRightLeft.GetPositionAhead();
                case RendOrder.Size4:                   return _rendLeft.GetPositionAhead();
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetPositionAhead");
            }
        }
    }
}