using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        // basic get set methods for certain renderer list addons
        private Renderer[] _rendererList;
        public Renderer[] RendererList { get { return _rendererList; } set { _rendererList = value; } }

        public enum RendOrder { Size2, Size2DownUpFlip, Size2RightLeftFlip, Size2Flip, Size3DownUp, Size3DownUpFlip, Size3RightLeft, Size3RightLeftFlip, Size4 }
        private RendOrder _rendListType;
        public RendOrder RendListType { get { return _rendListType; } set { _rendListType = value; } }

        private Renderer.DIRECTION _direction;
        /// <summary>
        /// get and set the direction to 
        /// </summary>
        public Renderer.DIRECTION Direction {
            get { return _direction; }
            set
            {
                _direction = value;
                switch (_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2Flip:
                    case RendOrder.Size2RightLeftFlip:
                        _rendDownUp.Direction = _direction;
                        _rendRightLeft.Direction = _direction;
                        break;

                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip:
                        _rendDown.Direction = _direction;
                        _rendUp.Direction = _direction;
                        _rendRightLeft.Direction = _direction;
                        break;


                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip:
                        _rendRightLeft.Direction = _direction;
                        _rendDown.Direction = _direction;
                        _rendUp.Direction = _direction;
                        break;

                    case RendOrder.Size4:
                        _rendRight.Direction = _direction;
                        _rendLeft.Direction = _direction;
                        _rendUp.Direction = _direction;
                        _rendDown.Direction = _direction;
                        break;

                    default: break;
                }
            }
        }

        // case 1: Size2
        private Renderer _rendDownUp;
        private Renderer _rendRightLeft;
        // case 2 - 4: Size3DownUp, Size3RightLeft, Size4
        private Renderer _rendDown;
        private Renderer _rendUp;
        private Renderer _rendRight;
        private Renderer _rendLeft;

        private Random _random = new Random();
        

        /// <summary>
        /// constructor for creating a plain RendererList
        /// </summary>
        /// <param name="rendererList">the list of renderers to be inputed</param>
        /// <param name="order">the type of RendererList you want based on given "rendererList"</param>
        public RendererLists(Renderer[] rendererList, RendOrder order)
        {
            RendererList = rendererList;
            RendListType = order;
            SetRenderers();
        }


        /// <summary>
        /// sets the renderers, so they can be used in the METHODS
        /// </summary>
        public void SetRenderers()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:
                    _rendDownUp = RendererList[0];
                    _rendRightLeft = RendererList[1];
                    break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:
                    _rendDownUp = RendererList[0];
                    _rendRight = RendererList[1];
                    _rendLeft = RendererList[2];
                    break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:
                    _rendDown = RendererList[0];
                    _rendUp = RendererList[1];
                    _rendRightLeft = RendererList[2];
                    break;
                case RendOrder.Size4:
                    _rendDown = RendererList[0];
                    _rendUp = RendererList[1];
                    _rendRight = RendererList[2];
                    _rendLeft = RendererList[3];
                    break;
            }
        }
    }
}