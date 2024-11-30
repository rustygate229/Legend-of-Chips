namespace _3902_Project
{
    public partial class RendererLists
    {
        public void SetRandomDirection()
        {
            Direction = (Renderer.DIRECTION)_random.Next(4);
            // Randomly choose a direction:
            switch (Direction)
            {
                case Renderer.DIRECTION.DOWN:       SetDownDirection();     break;
                case Renderer.DIRECTION.UP:         SetUpDirection();       break;
                case Renderer.DIRECTION.RIGHT:      SetRightDirection();    break;
                case Renderer.DIRECTION.LEFT:       SetLeftDirection();     break;
            }
        }

        private void SetDownDirection()
        {
            switch(_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip: _rendDownUp.Direction = Direction; break;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip: _rendDownUp.Direction = Direction; break;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip: _rendDown.Direction = Direction; break;
                    case RendOrder.Size4: _rendDown.Direction = Direction; break;
                }
        }

        private void SetUpDirection()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip: _rendDownUp.Direction = Direction; break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip: _rendDownUp.Direction = Direction; break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip: _rendUp.Direction = Direction; break;
                case RendOrder.Size4: _rendUp.Direction = Direction; break;
            }
        }

        private void SetRightDirection()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip: _rendRightLeft.Direction = Direction; break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip: _rendRight.Direction = Direction; break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip: _rendRightLeft.Direction = Direction; break;
                case RendOrder.Size4: _rendRight.Direction = Direction; break;
            }
        }

        private void SetLeftDirection()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip: _rendRightLeft.Direction = Direction; break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip: _rendLeft.Direction = Direction; break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip: _rendRightLeft.Direction = Direction; break;
                case RendOrder.Size4: _rendLeft.Direction = Direction; break;
            }
        }
    }
}