using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        /// <summary>
        /// get and set the direction to 
        /// </summary>
        public Renderer.DIRECTION Direction
        {
            get 
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip:
                        return _rendDownUp.Direction;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        return _rendRight.Direction;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        return _rendDown.Direction;
                    case RendOrder.Size4:
                        return _rendDown.Direction;
                    default: throw new ArgumentException("Invalid direction for RendererList");
                }
            }
            set
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2Flip:
                    case RendOrder.Size2RightLeftFlip:
                        _rendDownUp.Direction = value;
                        _rendRightLeft.Direction = value; break;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        _rendDown.Direction = value;
                        _rendUp.Direction = value;
                        _rendRightLeft.Direction = value; break;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        _rendRightLeft.Direction = value;
                        _rendDown.Direction = value;
                        _rendUp.Direction = value; break;
                    case RendOrder.Size4:
                        _rendRight.Direction = value;
                        _rendLeft.Direction = value;
                        _rendUp.Direction = value;
                        _rendDown.Direction = value; break;
                    default: throw new ArgumentException("Invalid direction for RendererList");
                }
            }
        }


        /// <returns>the rectangle position of the current sprite needed</returns>
        public Rectangle DestinationRectangle
        {
            get 
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip:
                        if (Direction is Renderer.DIRECTION.DOWN || Direction is Renderer.DIRECTION.UP) return _rendDownUp.DestinationRectangle;
                        else                                                                            return _rendRightLeft.DestinationRectangle;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        if (Direction is Renderer.DIRECTION.RIGHT)      return _rendRight.DestinationRectangle;
                        else if (Direction is Renderer.DIRECTION.LEFT)  return _rendLeft.DestinationRectangle;
                        else                                            return _rendDownUp.DestinationRectangle;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        if (Direction is Renderer.DIRECTION.DOWN)       return _rendDown.DestinationRectangle;
                        else if (Direction is Renderer.DIRECTION.UP)    return _rendUp.DestinationRectangle;
                        else                                            return _rendRightLeft.DestinationRectangle;
                    case RendOrder.Size4:
                        switch (Direction)
                        {
                            case Renderer.DIRECTION.DOWN:           return _rendDown.DestinationRectangle;
                            case Renderer.DIRECTION.UP:             return _rendUp.DestinationRectangle;
                            case Renderer.DIRECTION.RIGHT:          return _rendRight.DestinationRectangle;
                            case Renderer.DIRECTION.LEFT:           return _rendLeft.DestinationRectangle;
                            default: throw new ArgumentException("Invalid destination rectangle for RendererList");
                        }
                    default: throw new ArgumentException("Invalid destination rectangle for RendererList");
                }
            }
            set
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip:
                        _rendDownUp.DestinationRectangle = value;
                        _rendRightLeft.DestinationRectangle = value; break;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        _rendDownUp.DestinationRectangle = value;
                        _rendRight.DestinationRectangle = value;
                        _rendLeft.DestinationRectangle = value; break;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        _rendDown.DestinationRectangle = value;
                        _rendUp.DestinationRectangle = value;
                        _rendRightLeft.DestinationRectangle = value; break;
                    case RendOrder.Size4:
                        _rendDown.DestinationRectangle = value;
                        _rendUp.DestinationRectangle = value;
                        _rendRight.DestinationRectangle = value;
                        _rendLeft.DestinationRectangle = value; break;
                    default: throw new ArgumentException("Invalid destination rectangle for RendererList");
                }
            }
        }

        /// <returns>the vector2 position of the current sprite needed</returns>
        public Vector2 PositionOnWindow
        {
            get 
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip:
                        if (Direction is Renderer.DIRECTION.DOWN || Direction is Renderer.DIRECTION.UP) return _rendDownUp.PositionOnWindow;
                        else                                                                            return _rendRightLeft.PositionOnWindow;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        if (Direction is Renderer.DIRECTION.RIGHT)      return _rendRight.PositionOnWindow;
                        else if (Direction is Renderer.DIRECTION.LEFT)  return _rendLeft.PositionOnWindow;
                        else                                            return _rendDownUp.PositionOnWindow;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        if (Direction is Renderer.DIRECTION.DOWN)       return _rendDown.PositionOnWindow;
                        else if (Direction is Renderer.DIRECTION.UP)    return _rendUp.PositionOnWindow;
                        else                                            return _rendRightLeft.PositionOnWindow;
                    case RendOrder.Size4:
                        switch (Direction) {
                            case Renderer.DIRECTION.DOWN: return _rendDown.PositionOnWindow;
                            case Renderer.DIRECTION.UP: return _rendUp.PositionOnWindow;
                            case Renderer.DIRECTION.RIGHT: return _rendRight.PositionOnWindow;
                            case Renderer.DIRECTION.LEFT: return _rendLeft.PositionOnWindow;
                            default: throw new ArgumentException("Invalid position on window for RendererList");
                        }
                    default: throw new ArgumentException("Invalid position on window for RendererList");
                }
            }
            set
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip:
                        _rendDownUp.PositionOnWindow = value;
                        _rendRightLeft.PositionOnWindow = value; break;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        _rendDownUp.PositionOnWindow = value;
                        _rendRight.PositionOnWindow = value;
                        _rendLeft.PositionOnWindow = value; break;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        _rendDown.PositionOnWindow = value;
                        _rendUp.PositionOnWindow = value;
                        _rendRightLeft.PositionOnWindow = value; break;
                    case RendOrder.Size4:
                        _rendDown.PositionOnWindow = value;
                        _rendUp.PositionOnWindow = value;
                        _rendRight.PositionOnWindow = value;
                        _rendLeft.PositionOnWindow = value; break;
                    default: throw new ArgumentException("Invalid position on window for RendererList");
                }
            }
        }

        public bool IsCentered
        {
            get 
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip:
                        if (Direction is Renderer.DIRECTION.DOWN || Direction is Renderer.DIRECTION.UP) return _rendDownUp.IsCentered;
                        else                                                                            return _rendRightLeft.IsCentered;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        if (Direction is Renderer.DIRECTION.RIGHT)      return _rendRight.IsCentered;
                        else if (Direction is Renderer.DIRECTION.LEFT)  return _rendLeft.IsCentered;
                        else                                            return _rendDownUp.IsCentered;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        if (Direction is Renderer.DIRECTION.DOWN)       return _rendDown.IsCentered;
                        else if (Direction is Renderer.DIRECTION.UP)    return _rendUp.IsCentered;
                        else                                            return _rendRightLeft.IsCentered;
                    case RendOrder.Size4:
                        switch (Direction)
                        {
                            case Renderer.DIRECTION.DOWN:           return _rendDown.IsCentered;
                            case Renderer.DIRECTION.UP:             return _rendUp.IsCentered;
                            case Renderer.DIRECTION.RIGHT:          return _rendRight.IsCentered;
                            case Renderer.DIRECTION.LEFT:           return _rendLeft.IsCentered;
                            default: throw new ArgumentException("Invalid centering for RendererList");
                        }
                    default: throw new ArgumentException("Invalid centering for RendererList");
                }
            }
            set 
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip:
                        _rendDownUp.IsCentered = value;
                        _rendRightLeft.IsCentered = value;
                        break;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        _rendDownUp.IsCentered = value;
                        _rendRight.IsCentered = value;
                        _rendLeft.IsCentered = value;
                        break;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        _rendDown.IsCentered = value;
                        _rendUp.IsCentered = value;
                        _rendRightLeft.IsCentered = value;
                        break;
                    case RendOrder.Size4:
                        _rendDown.IsCentered = value;
                        _rendUp.IsCentered = value;
                        _rendRight.IsCentered = value;
                        _rendLeft.IsCentered = value;
                        break;
                    default: throw new ArgumentException("Invalid centering for RendererList");
                }
            }
        }

        public Renderer.STATUS AnimatedStatus
        {
            get 
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip:
                        if (Direction is Renderer.DIRECTION.DOWN || Direction is Renderer.DIRECTION.UP) return _rendDownUp.AnimatedStatus;
                        else                                                                            return _rendRightLeft.AnimatedStatus;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        if (Direction is Renderer.DIRECTION.RIGHT)      return _rendRight.AnimatedStatus;
                        else if (Direction is Renderer.DIRECTION.LEFT)  return _rendLeft.AnimatedStatus;
                        else                                            return _rendDownUp.AnimatedStatus;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        if (Direction is Renderer.DIRECTION.DOWN)       return _rendDown.AnimatedStatus;
                        else if (Direction is Renderer.DIRECTION.UP)    return _rendUp.AnimatedStatus;
                        else                                            return _rendRightLeft.AnimatedStatus;
                    case RendOrder.Size4:
                        switch (Direction)
                        {
                            case Renderer.DIRECTION.DOWN:           return _rendDown.AnimatedStatus;
                            case Renderer.DIRECTION.UP:             return _rendUp.AnimatedStatus;
                            case Renderer.DIRECTION.RIGHT:          return _rendRight.AnimatedStatus;
                            case Renderer.DIRECTION.LEFT:           return _rendLeft.AnimatedStatus;
                            default: throw new ArgumentException("Invalid animation status for RendererList");
                        }
                    default: throw new ArgumentException("Invalid animation status for RendererList");
                }
            }
            set
            {
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip:
                        _rendDownUp.AnimatedStatus = value;
                        _rendRightLeft.AnimatedStatus = value;
                        break;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        _rendDownUp.AnimatedStatus = value;
                        _rendRight.AnimatedStatus = value;
                        _rendLeft.AnimatedStatus = value;
                        break;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        _rendDown.AnimatedStatus = value;
                        _rendUp.AnimatedStatus = value;
                        _rendRightLeft.AnimatedStatus = value;
                        break;
                    case RendOrder.Size4:
                        _rendDown.AnimatedStatus = value;
                        _rendUp.AnimatedStatus = value;
                        _rendRight.AnimatedStatus = value;
                        _rendLeft.AnimatedStatus = value;
                        break;
                    default: break;
                }
            }
        }
    }
}