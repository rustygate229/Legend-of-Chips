using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private Rectangle _destinationRectangle;
        /// <returns>the rectangle position of the current sprite needed</returns>
        public Rectangle DestinationRectangle
        {
            get { return _destinationRectangle; }
            set
            {
                _destinationRectangle = value;
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
                    default: throw new ArgumentException("Invalid position on window for RednererList");
                }
            }
        }

        private Vector2 _positionOnWindow;
        /// <returns>the vector2 position of the current sprite needed</returns>
        public Vector2 PositionOnWindow
        {
            get { return _positionOnWindow; }
            set
            {
                _positionOnWindow = value;
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
                    default: throw new ArgumentException("Invalid position on window for RednererList");
                }
            }
        }

        private bool _isCentered;
        public bool IsCentered
        {
            get { return _isCentered; }
            set 
            {
                _isCentered = value;
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
                    default: break;
                }
            }
        }

        private Renderer.STATUS _animatedStatus;
        public Renderer.STATUS AnimatedStatus
        {
            get { return _animatedStatus; }
            set
            {
                _animatedStatus = value;
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