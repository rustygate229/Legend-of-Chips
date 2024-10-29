﻿using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public partial class RendererLists
    {
        public void SetRenderers()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    _rendDownUp = _rendererList[0];
                    _rendRightLeft = _rendererList[1];
                    break;
                case RendOrder.Size3DownUp:
                    _rendDownUp = _rendererList[0];
                    _rendRight = _rendererList[1];
                    _rendLeft = _rendererList[2];
                    break;
                case RendOrder.Size3RightLeft:
                    _rendDown = _rendererList[0];
                    _rendUp = _rendererList[1];
                    _rendRightLeft = _rendererList[2];
                    break;
                case RendOrder.Size4:
                    _rendDown = _rendererList[0];
                    _rendUp = _rendererList[1];
                    _rendRight = _rendererList[2];
                    _rendLeft = _rendererList[3];
                    break;
            }
        }

        public Renderer[] GetList() { return _rendererList; }

        public void SetDirection(int directionValue) 
        {
            if (directionValue == _directionArray[0])
                _direction = Renderer.DIRECTION.DOWN;
            else if (directionValue ==  _directionArray[1])
                _direction = Renderer.DIRECTION.UP;
            else if (directionValue == _directionArray[2])
                _direction = Renderer.DIRECTION.RIGHT;
            else if (directionValue == _directionArray[3])
                _direction = Renderer.DIRECTION.LEFT;

        }

        public Rectangle GetOneRectanglePosition()
        {
            Rectangle gettingPosition = new(0, 0, 0, 0);
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    if (_direction == Renderer.DIRECTION.DOWN || _direction == Renderer.DIRECTION.UP)
                        gettingPosition = _rendDownUp.GetRectanglePosition();
                    else if (_direction == Renderer.DIRECTION.RIGHT || _direction == Renderer.DIRECTION.LEFT)
                        gettingPosition = _rendRightLeft.GetRectanglePosition();
                    break;
                case RendOrder.Size3DownUp:
                    if (_direction == Renderer.DIRECTION.RIGHT) { gettingPosition = _rendRight.GetRectanglePosition(); }
                    else if (_direction == Renderer.DIRECTION.LEFT) { gettingPosition = _rendLeft.GetRectanglePosition(); }
                    else { gettingPosition = _rendDownUp.GetRectanglePosition(); }
                    break;
                case RendOrder.Size3RightLeft:
                    if (_direction == Renderer.DIRECTION.DOWN) { gettingPosition = _rendDown.GetRectanglePosition(); }
                    else if (_direction == Renderer.DIRECTION.UP) { gettingPosition = _rendUp.GetRectanglePosition(); }
                    else { gettingPosition = _rendRightLeft.GetRectanglePosition(); }
                    break;
                case RendOrder.Size4:
                    switch (_direction)
                    {
                        case Renderer.DIRECTION.DOWN:
                            gettingPosition = _rendDown.GetRectanglePosition(); break;
                        case Renderer.DIRECTION.UP:
                            gettingPosition = _rendUp.GetRectanglePosition(); break;
                        case Renderer.DIRECTION.RIGHT:
                            gettingPosition = _rendRight.GetRectanglePosition(); break;
                        case Renderer.DIRECTION.LEFT:
                            gettingPosition = _rendLeft.GetRectanglePosition(); break;
                        default: break;
                    }
                    break;
                default: break;
            }
            return gettingPosition;
        }

        public void SetPositions(Vector2 position)
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    _rendDownUp.SetPosition(position);
                    _rendRightLeft.SetPosition(position);
                    break;
                case RendOrder.Size3DownUp:
                    _rendDownUp.SetPosition(position);
                    _rendRight.SetPosition(position);
                    _rendLeft.SetPosition(position);
                    break;
                case RendOrder.Size3RightLeft:
                    _rendDown.SetPosition(position);
                    _rendUp.SetPosition(position);
                    _rendRightLeft.SetPosition(position);
                    break;
                case RendOrder.Size4:
                    _rendDown.SetPosition(position);
                    _rendUp.SetPosition(position);
                    _rendRight.SetPosition(position);
                    _rendLeft.SetPosition(position);
                    break;
                default: break;
            }
        }
    }
}