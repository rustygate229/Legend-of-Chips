using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private Renderer[] _rendererList;
        public enum _rendOrder { Size2, Size3DownUp, Size3RightLeft, Size4 }
        private _rendOrder _rendListType;
        private Renderer.DIRECTION _direction;
        private bool _centered;

        // case 1: Size2
        private Renderer _rendDownUp;
        private Renderer _rendRightLeft;
        // case 2 - 4: Size3DownUp, Size3RightLeft, Size4
        private Renderer _rendDown;
        private Renderer _rendUp;
        private Renderer _rendRight;
        private Renderer _rendLeft;

        private Random _random = new Random();

        public RendererLists(Renderer[] rendererList, _rendOrder order, bool isCentered)
        {
            _rendererList = rendererList;
            _rendListType = order;
            _centered = isCentered;
            SetRenderers();
        }

        public void SetRenderers()
        {
            switch (_rendListType)
            {
                case _rendOrder.Size2:
                    _rendDownUp = _rendererList[0];
                    _rendRightLeft = _rendererList[1];
                    break;
                case _rendOrder.Size3DownUp:
                    _rendDownUp = _rendererList[0];
                    _rendRight = _rendererList[1];
                    _rendLeft = _rendererList[2];
                    break;
                case _rendOrder.Size3RightLeft:
                    _rendDown = _rendererList[0];
                    _rendUp = _rendererList[1];
                    _rendRightLeft = _rendererList[2];
                    break;
                case _rendOrder.Size4:
                    _rendDown = _rendererList[0];
                    _rendUp = _rendererList[1];
                    _rendRight = _rendererList[2];
                    _rendLeft = _rendererList[3];
                    break;
            }
        }

        public void SetDirection(Renderer.DIRECTION direction) { _direction = direction; }

        public Renderer[] GetList() { return _rendererList; }

        public Vector2 GetOnePosition()
        {
            Vector2 gettingPosition = new(0, 0);
            switch (_rendListType)
            {
                case _rendOrder.Size2:
                    if (_direction == Renderer.DIRECTION.DOWN || _direction == Renderer.DIRECTION.UP)
                        gettingPosition = _rendDownUp.GetPosition();
                    else if (_direction == Renderer.DIRECTION.RIGHT || _direction == Renderer.DIRECTION.LEFT)
                        gettingPosition = _rendRightLeft.GetPosition();
                    break;
                case _rendOrder.Size3DownUp:
                    if (_direction == Renderer.DIRECTION.RIGHT) { gettingPosition = _rendRight.GetPosition(); }
                    else if (_direction == Renderer.DIRECTION.LEFT) { gettingPosition = _rendLeft.GetPosition(); }
                    else { gettingPosition = _rendDownUp.GetPosition(); }
                    break;
                case _rendOrder.Size3RightLeft:
                    if (_direction == Renderer.DIRECTION.DOWN) { gettingPosition = _rendDown.GetPosition(); }
                    else if (_direction == Renderer.DIRECTION.UP) { gettingPosition = _rendUp.GetPosition(); }
                    else { gettingPosition = _rendRightLeft.GetPosition(); }
                    break;
                case _rendOrder.Size4:
                    switch (_direction)
                    {
                        case Renderer.DIRECTION.DOWN:
                            gettingPosition = _rendDown.GetPosition(); break;
                        case Renderer.DIRECTION.UP:
                            gettingPosition = _rendUp.GetPosition(); break;
                        case Renderer.DIRECTION.RIGHT:
                            gettingPosition = _rendRight.GetPosition(); break;
                        case Renderer.DIRECTION.LEFT:
                            gettingPosition = _rendLeft.GetPosition(); break;
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
                case _rendOrder.Size2:
                    _rendDownUp.SetPosition(position);
                    _rendRightLeft.SetPosition(position);
                    break;
                case _rendOrder.Size3DownUp:
                    _rendDownUp.SetPosition(position);
                    _rendRight.SetPosition(position);
                    _rendLeft.SetPosition(position);
                    break;
                case _rendOrder.Size3RightLeft:
                    _rendDown.SetPosition(position);
                    _rendUp.SetPosition(position);
                    _rendRightLeft.SetPosition(position);
                    break;
                case _rendOrder.Size4:
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