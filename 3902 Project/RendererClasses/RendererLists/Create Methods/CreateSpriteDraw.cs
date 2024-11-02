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
        /// <param name="isCentered">true: centered, false: top left start</param>
        public void CreateSpriteDraw(SpriteBatch spriteBatch, bool isCentered)
        {
            switch(_rendListType)
            {
                case RendOrder.Size2:
                    CreateSpriteDrawSize2(spriteBatch, isCentered); break;
                case RendOrder.Size3DownUp:
                    CreateSpriteDrawSize3DownUp(spriteBatch, isCentered); break;
                case RendOrder.Size3RightLeft:
                    CreateSpriteDrawSize3RightLeft(spriteBatch, isCentered); break;
                case RendOrder.Size4:
                    CreateSpriteDrawSize4(spriteBatch, isCentered); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private void CreateSpriteDrawSize2(SpriteBatch spriteBatch, bool isCentered)
        {
            if (isCentered)
            {
                switch ((int)_direction)
                {
                    case 0: // DOWN sprite drawing
                        _rendDownUp.DrawCentered(spriteBatch, _rendDownUp.GetSourceRectangle()); break;
                    case 1: // UP sprite drawing
                        _rendDownUp.DrawVerticallyFlipped(spriteBatch, isCentered); break;
                    case 2: // RIGHT sprite drawing
                        _rendRightLeft.DrawCentered(spriteBatch, _rendRightLeft.GetSourceRectangle()); break;
                    case 3: // LEFT sprite drawing
                        _rendRightLeft.DrawHorizontallyFlipped(spriteBatch, isCentered); break;
                    default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
                }
            }
            else
            {
                switch ((int)_direction)
                {
                    case 0: // DOWN sprite drawing
                        _rendDownUp.Draw(spriteBatch, _rendDownUp.GetSourceRectangle(), _rendDownUp.GetDestinationRectangle()); break;
                    case 1: // UP sprite drawing
                        _rendDownUp.DrawVerticallyFlipped(spriteBatch, isCentered); break;
                    case 2: // RIGHT sprite drawing
                        _rendRightLeft.Draw(spriteBatch, _rendRightLeft.GetSourceRectangle(), _rendRightLeft.GetDestinationRectangle()); break;
                    case 3: // LEFT sprite drawing
                        _rendRightLeft.DrawHorizontallyFlipped(spriteBatch, isCentered); break;
                    default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
                }
            }
        }

        private void CreateSpriteDrawSize3DownUp(SpriteBatch spriteBatch, bool isCentered)
        {
            if (isCentered)
            {
                switch ((int)_direction)
                {
                    case 0: // DOWN sprite drawing
                        _rendDownUp.DrawCentered(spriteBatch, _rendDownUp.GetSourceRectangle()); break;
                    case 1: // UP sprite drawing
                        _rendDownUp.DrawVerticallyFlipped(spriteBatch, isCentered); break;
                    case 2: // RIGHT sprite drawing
                        _rendRight.DrawCentered(spriteBatch, _rendRightLeft.GetSourceRectangle()); break;
                    case 3: // LEFT sprite drawing
                        _rendLeft.DrawCentered(spriteBatch, _rendRightLeft.GetSourceRectangle()); break;
                    default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
                }
            }
            else
            {
                switch ((int)_direction)
                {
                    case 0: // DOWN sprite drawing
                        _rendDownUp.Draw(spriteBatch, _rendDownUp.GetSourceRectangle(), _rendDownUp.GetDestinationRectangle()); break;
                    case 1: // UP sprite drawing
                        _rendDownUp.DrawVerticallyFlipped(spriteBatch, isCentered); break;
                    case 2: // RIGHT sprite drawing
                        _rendRight.Draw(spriteBatch, _rendRight.GetSourceRectangle(), _rendRight.GetDestinationRectangle()); break;
                    case 3: // LEFT sprite drawing
                        _rendLeft.Draw(spriteBatch, _rendLeft.GetSourceRectangle(), _rendLeft.GetDestinationRectangle()); break;
                    default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
                }
            }
        }

        private void CreateSpriteDrawSize3RightLeft(SpriteBatch spriteBatch, bool isCentered)
        {
            if (isCentered)
            {
                switch ((int)_direction)
                {
                    case 0: // DOWN sprite drawing
                        _rendDown.DrawCentered(spriteBatch, _rendDown.GetSourceRectangle()); break;
                    case 1: // UP sprite drawing
                        _rendUp.DrawCentered(spriteBatch, _rendUp.GetSourceRectangle()); break;
                    case 2: // RIGHT sprite drawing
                        _rendRightLeft.DrawCentered(spriteBatch, _rendRightLeft.GetSourceRectangle()); break;
                    case 3: // LEFT sprite drawing
                        _rendRightLeft.DrawHorizontallyFlipped(spriteBatch, isCentered); break;
                    default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
                }
            }
            else
            {
                switch ((int)_direction)
                {
                    case 0: // DOWN sprite drawing
                        _rendDown.Draw(spriteBatch, _rendDown.GetSourceRectangle(), _rendDown.GetDestinationRectangle()); break;
                    case 1: // UP sprite drawing
                        _rendUp.Draw(spriteBatch, _rendUp.GetSourceRectangle(), _rendUp.GetDestinationRectangle()); break;
                    case 2: // RIGHT sprite drawing
                        _rendRightLeft.Draw(spriteBatch, _rendRightLeft.GetSourceRectangle(), _rendRightLeft.GetDestinationRectangle()); break;
                    case 3: // LEFT sprite drawing
                        _rendRightLeft.DrawHorizontallyFlipped(spriteBatch, isCentered); break;
                    default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
                }
            }
        }

        private void CreateSpriteDrawSize4(SpriteBatch spriteBatch, bool isCentered)
        {
            if (isCentered)
            {
                switch ((int)_direction)
                {
                    case 0: // DOWN sprite drawing
                        _rendDown.DrawCentered(spriteBatch, _rendDown.GetSourceRectangle()); break;
                    case 1: // UP sprite drawing
                        _rendUp.DrawCentered(spriteBatch, _rendUp.GetSourceRectangle()); break;
                    case 2: // RIGHT sprite drawing
                        _rendRight.DrawCentered(spriteBatch, _rendRight.GetSourceRectangle()); break;
                    case 3: // LEFT sprite drawing
                        _rendLeft.DrawCentered(spriteBatch, _rendLeft.GetSourceRectangle()); break;
                    default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
                }
            }
            else
            {
                switch ((int)_direction)
                {
                    case 0: // DOWN sprite drawing
                        _rendDown.Draw(spriteBatch, _rendDown.GetSourceRectangle(), _rendDown.GetDestinationRectangle()); break;
                    case 1: // UP sprite drawing
                        _rendUp.Draw(spriteBatch, _rendUp.GetSourceRectangle(), _rendUp.GetDestinationRectangle()); break;
                    case 2: // RIGHT sprite drawing
                        _rendRight.Draw(spriteBatch, _rendRight.GetSourceRectangle(), _rendRight.GetDestinationRectangle()); break;
                    case 3: // LEFT sprite drawing
                        _rendLeft.Draw(spriteBatch, _rendLeft.GetSourceRectangle(), _rendLeft.GetDestinationRectangle()); break;
                    default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
                }
            }
        }
    }
}