using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private Renderer[] _rendererList;
        public enum RendOrder { Size2, Size3DownUp, Size3RightLeft, Size4 }
        private RendOrder _rendListType;
        private int[] _directionArray = { 0, 1, 2, 3 };
        private Renderer.DIRECTION _direction;

        // case 1: Size2
        private Renderer _rendDownUp;
        private Renderer _rendRightLeft;
        // case 2 - 4: Size3DownUp, Size3RightLeft, Size4
        private Renderer _rendDown;
        private Renderer _rendUp;
        private Renderer _rendRight;
        private Renderer _rendLeft;

        private Random _random = new Random();

        public RendererLists(Renderer[] rendererList, RendOrder order)
        {
            _rendererList = rendererList;
            _rendListType = order;
            SetRenderers();
        }

        public RendererLists(Renderer[] rendererList, RendOrder order, int[] directionArray)
        {
            _rendererList = rendererList;
            _rendListType = order;
            _directionArray = directionArray;
            SetRenderers();
        }
    }
}