using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private Renderer[] _rendererList;
        public enum RendOrder { Size2, Size3DownUp, Size3RightLeft, Size4 }
        private RendOrder _rendListType;
        private int[] _directionArray = { 0, 1, 2, 3, 4, 5, 6, 7 };
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

        /// <summary>
        /// constructor for creating a plain RendererList
        /// </summary>
        /// <param name="rendererList">the list of renderers to be inputed</param>
        /// <param name="order">the type of RendererList you want based on given "rendererList"</param>
        public RendererLists(Renderer[] rendererList, RendOrder order)
        {
            _rendererList = rendererList;
            _rendListType = order;
            SetRenderers();
        }

        /// <summary>
        /// constructor for creating a RendererList with a specific rework of Renderer.DIRECTION
        /// </summary>
        /// <param name="rendererList">the list of renderers to be inputed</param>
        /// <param name="order">the type of RendererList you want based on given "rendererList"</param>
        /// <param name="directionArray">the int[] array that allows for changing sprites direction enum: 
        /// if a sprite in the texture spritesheet is not in conventinal method (either DOWN or RIGHT). This allows 
        /// for swap the DOWN with the UP and VISE-VERSA, and the same for RIGHT and LEFT</param>
        public RendererLists(Renderer[] rendererList, RendOrder order, int[] directionArray)
        {
            _rendererList = rendererList;
            _rendListType = order;
            _directionArray = directionArray;
            SetRenderers();
        }
    }
}