using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class RendererLists
    {
        private Renderer[] _rendererList;
        private int[] _rendererOrder; // 0: DOWN, 1: UP, 2: RIGHT, 3: LEFT
        private int _listSize;

        public RendererLists(Renderer[] rendererList, int[] order)
        {
            _rendererList = rendererList;
            _listSize = rendererList.Length;
        }

        public void DrawDirections()
        {
            
        }
    }
}