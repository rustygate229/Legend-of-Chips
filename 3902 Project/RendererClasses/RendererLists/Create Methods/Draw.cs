using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private Color _tint;

        /// <summary>
        /// Draws the specific current sprite based on other methods
        /// </summary>
        /// <param name="spriteBatch">the spritebatch where we draw all sprites</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            _tint = Color.White;
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    DrawSize2(spriteBatch); break;
                case RendOrder.Size2DownUpFlip:
                    DrawSize2DownUpFlip(spriteBatch); break;
                case RendOrder.Size2RightLeftFlip:
                    DrawSize2RightLeftFlip(spriteBatch); break;
                case RendOrder.Size2Flip:
                    DrawSize2Flip(spriteBatch); break;
                case RendOrder.Size3DownUp:
                    DrawSize3DownUp(spriteBatch); break;
                case RendOrder.Size3DownUpFlip:
                    DrawSize3DownUpFlip(spriteBatch); break;
                case RendOrder.Size3RightLeft:
                    DrawSize3RightLeft(spriteBatch); break;
                case RendOrder.Size3RightLeftFlip:
                    DrawSize3RightLeftFlip(spriteBatch); break;
                case RendOrder.Size4:
                    DrawSize4(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }

        /// <summary>
        /// Draws the specific current sprite based on other methods
        /// </summary>
        /// <param name="spriteBatch">the spritebatch where we draw all sprites</param>
        public void Draw(SpriteBatch spriteBatch, Color tint)
        {
            _tint = tint;
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    DrawSize2(spriteBatch); break;
                case RendOrder.Size2DownUpFlip:
                    DrawSize2DownUpFlip(spriteBatch); break;
                case RendOrder.Size2RightLeftFlip:
                    DrawSize2RightLeftFlip(spriteBatch); break;
                case RendOrder.Size2Flip:
                    DrawSize2Flip(spriteBatch); break;
                case RendOrder.Size3DownUp:
                    DrawSize3DownUp(spriteBatch); break;
                case RendOrder.Size3DownUpFlip:
                    DrawSize3DownUpFlip(spriteBatch); break;
                case RendOrder.Size3RightLeft:
                    DrawSize3RightLeft(spriteBatch); break;
                case RendOrder.Size3RightLeftFlip:
                    DrawSize3RightLeftFlip(spriteBatch); break;
                case RendOrder.Size4:
                    DrawSize4(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }

        private void DrawSize2(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }

        private void DrawSize2DownUpFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }

        private void DrawSize2RightLeftFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }

        private void DrawSize2Flip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }

        private void DrawSize3DownUp(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRight.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendLeft.Draw(spriteBatch, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }

        private void DrawSize3DownUpFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRight.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendLeft.Draw(spriteBatch, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }


        private void DrawSize3RightLeft(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDown.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.UP: _rendUp.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }

        private void DrawSize3RightLeftFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDown.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.UP: _rendUp.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }


        private void DrawSize4(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDown.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.UP: _rendUp.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRight.Draw(spriteBatch, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendLeft.Draw(spriteBatch, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for Draw");
            }
        }
    }
}