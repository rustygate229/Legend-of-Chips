using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        /// <summary>
        /// calls the specific type of rendereList and then updates its sprites/renderers
        /// </summary>
        public void UpdateFrames()
        {
            switch(_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:
                    CreateUpdateFramesSize2(); break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:
                    CreateUpdateFramesSize3DownUp(); break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:
                    CreateUpdateFramesSize3RightLeft(); break;
                case RendOrder.Size4:
                    CreateUpdateFramesSize4(); break;
                default: throw new ArgumentException("Invalid direction for UpdateFrames");
            }
        }

        private void CreateUpdateFramesSize2()
        {
            if (Direction == Renderer.DIRECTION.DOWN || Direction == Renderer.DIRECTION.UP)
                _rendDownUp.UpdateFrames();
            else
                _rendRightLeft.UpdateFrames();
        }

        private void CreateUpdateFramesSize3DownUp()
        {
            if (Direction == Renderer.DIRECTION.RIGHT)
                _rendRight.UpdateFrames();
            else if (Direction == Renderer.DIRECTION.LEFT)
                _rendLeft.UpdateFrames();
            else
                _rendDownUp.UpdateFrames();
        }

        private void CreateUpdateFramesSize3RightLeft()
        {
            if (Direction == Renderer.DIRECTION.DOWN)
                _rendDown.UpdateFrames();
            else if (Direction == Renderer.DIRECTION.UP)
                _rendUp.UpdateFrames();
            else
                _rendRightLeft.UpdateFrames();
        }

        private void CreateUpdateFramesSize4()
        {
            if (Direction == Renderer.DIRECTION.DOWN)
                _rendDown.UpdateFrames();
            else if (Direction == Renderer.DIRECTION.UP)
                _rendUp.UpdateFrames();
            else if (Direction == Renderer.DIRECTION.RIGHT)
                _rendRight.UpdateFrames();
            else
                _rendLeft.UpdateFrames();
        }
    }
}