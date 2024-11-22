using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        /// <summary>
        /// Draws the specific current sprite based on other methods
        /// </summary>
        /// <param name="spriteBatch">the spritebatch where we draw all sprites</param>
        public void CreateSpriteDraw(SpriteBatch spriteBatch)
        {
            switch(_rendListType)
            {
                case RendOrder.Size2:
                    CreateSpriteDrawSize2(spriteBatch); break;
                case RendOrder.Size2DownUpFlip:
                    CreateSpriteDrawSize2DownUpFlip(spriteBatch); break;
                case RendOrder.Size2RightLeftFlip:
                    CreateSpriteDrawSize2RightLeftFlip(spriteBatch); break;
                case RendOrder.Size2Flip:
                    CreateSpriteDrawSize2Flip(spriteBatch); break;
                case RendOrder.Size3DownUp:
                    CreateSpriteDrawSize3DownUp(spriteBatch); break;
                case RendOrder.Size3DownUpFlip:
                    CreateSpriteDrawSize3DownUpFlip(spriteBatch); break;
                case RendOrder.Size3RightLeft:
                    CreateSpriteDrawSize3RightLeft(spriteBatch); break;
                case RendOrder.Size3RightLeftFlip:
                    CreateSpriteDrawSize3RightLeftFlip(spriteBatch); break;
                case RendOrder.Size4:
                    CreateSpriteDrawSize4(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private void CreateSpriteDrawSize2(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private void CreateSpriteDrawSize2DownUpFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private void CreateSpriteDrawSize2RightLeftFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private void CreateSpriteDrawSize2Flip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private void CreateSpriteDrawSize3DownUp(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical); break;
                case Renderer.DIRECTION.RIGHT: _rendRight.Draw(spriteBatch); break;
                case Renderer.DIRECTION.LEFT: _rendLeft.Draw(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private void CreateSpriteDrawSize3DownUpFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, Renderer.DrawFlips.Vertical); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch); break;
                case Renderer.DIRECTION.RIGHT: _rendRight.Draw(spriteBatch); break;
                case Renderer.DIRECTION.LEFT: _rendLeft.Draw(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }


        private void CreateSpriteDrawSize3RightLeft(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDown.Draw(spriteBatch); break;
                case Renderer.DIRECTION.UP: _rendUp.Draw(spriteBatch); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private void CreateSpriteDrawSize3RightLeftFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDown.Draw(spriteBatch); break;
                case Renderer.DIRECTION.UP: _rendUp.Draw(spriteBatch); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, Renderer.DrawFlips.Horizontal); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }


        private void CreateSpriteDrawSize4(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDown.Draw(spriteBatch); break;
                case Renderer.DIRECTION.UP: _rendUp.Draw(spriteBatch); break;
                case Renderer.DIRECTION.RIGHT: _rendRight.Draw(spriteBatch); break;
                case Renderer.DIRECTION.LEFT: _rendLeft.Draw(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }
    }
}