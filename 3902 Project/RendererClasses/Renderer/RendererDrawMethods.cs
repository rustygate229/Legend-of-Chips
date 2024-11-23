using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {
        private int _tileSize = 64;
        public enum DrawFlips { None, Vertical, Horizontal, Both }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draw the current sprite
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, GetDestinationRectangle(), GetSourceRectangle(), Color.White);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, Color tint)
        {
            // draw the current sprite
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, GetDestinationRectangle(), GetSourceRectangle(), tint);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, DrawFlips flipStatus) 
        { 
            switch (flipStatus)
            {
                case DrawFlips.None: DrawNoneFlipped(spriteBatch); break;
                case DrawFlips.Vertical: DrawVerticallyFlipped(spriteBatch); break;
                case DrawFlips.Horizontal: DrawHorizontallyFlipped(spriteBatch); break;
                case DrawFlips.Both: DrawBothFlipped(spriteBatch); break;
                default: break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, DrawFlips flipStatus, Color tint)
        {
            switch (flipStatus)
            {
                case DrawFlips.None: DrawNoneFlipped(spriteBatch, tint); break;
                case DrawFlips.Vertical: DrawVerticallyFlipped(spriteBatch, tint); break;
                case DrawFlips.Horizontal: DrawHorizontallyFlipped(spriteBatch, tint); break;
                case DrawFlips.Both: DrawBothFlipped(spriteBatch, tint); break;
                default: break;
            }
        }

// --------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// draw the sprite at the top left of the set position
        /// </summary>
        /// <param name="spriteBatch">the spritebatch where everything is drawn in</param>
        /// <param name="sourceRectangle">the sourceRectangle of the sprite</param>
        private void Draw(SpriteBatch spriteBatch, Rectangle sourceRectangle)
        {
            // draw the current sprite
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, GetDestinationRectangle(), sourceRectangle, Color.White);
            spriteBatch.End();
        }

        /// <summary>
        /// draw the sprite at the top left of the set position
        /// </summary>
        /// <param name="spriteBatch">the spritebatch where everything is drawn in</param>
        /// <param name="sourceRectangle">the sourceRectangle of the sprite</param>
        /// <param name="tint">change the coloring of the sprite</param>
        private void Draw(SpriteBatch spriteBatch, Rectangle sourceRectangle, Color tint)
        {
            // draw the current sprite
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, GetDestinationRectangle(), sourceRectangle, tint);
            spriteBatch.End();
        }

// --------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// draws the sprite flipped vertically from it's normal settings (the sprites opposite along the vertical plane)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        private void DrawNoneFlipped(SpriteBatch spriteBatch)
        {
            // draw the current sprite
            Draw(spriteBatch);
        }

        /// <summary>
        /// draws the sprite flipped vertically from it's normal settings (the sprites opposite along the vertical plane)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        private void DrawNoneFlipped(SpriteBatch spriteBatch, Color tint)
        {
            // draw the current sprite
            Draw(spriteBatch, tint);
        }

// --------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// draws the sprite flipped vertically from it's normal settings (the sprites opposite along the vertical plane)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        private void DrawVerticallyFlipped(SpriteBatch spriteBatch)
        {
            int[] sR = GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1] + sR[3], sR[2], -sR[3]);

            // draw the current sprite
            Draw(spriteBatch, sourceRectangle);
        }

        /// <summary>
        /// draws the sprite flipped vertically from it's normal settings (the sprites opposite along the vertical plane)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        private void DrawVerticallyFlipped(SpriteBatch spriteBatch, Color tint)
        {
            int[] sR = GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1] + sR[3], sR[2], -sR[3]);

            // draw the current sprite
            Draw(spriteBatch, sourceRectangle, tint);
        }

// --------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// draws the sprite flipped horizontally from it's normal settings (the sprites opposite along the horiztonal plane)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        private void DrawHorizontallyFlipped(SpriteBatch spriteBatch)
        {
            int[] sR = GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1], -sR[2], sR[3]);

            // draw the current sprite
            Draw(spriteBatch, sourceRectangle);
        }

        /// <summary>
        /// draws the sprite flipped horizontally from it's normal settings (the sprites opposite along the horiztonal plane)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        private void DrawHorizontallyFlipped(SpriteBatch spriteBatch, Color tint)
        {
            int[] sR = GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1], -sR[2], sR[3]);

            // draw the current sprite
            Draw(spriteBatch, sourceRectangle, tint);
        }

// --------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// draws the sprite flipped both horizontally and vertically from it's normal settings (the sprites opposite along both planes)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        private void DrawBothFlipped(SpriteBatch spriteBatch)
        {
            int[] sR = GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1] + sR[3], -sR[2], -sR[3]);

            // draw the current sprite
            Draw(spriteBatch, sourceRectangle);
        }

        /// <summary>
        /// draws the sprite flipped both horizontally and vertically from it's normal settings (the sprites opposite along both planes)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        private void DrawBothFlipped(SpriteBatch spriteBatch, Color tint)
        {
            int[] sR = GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1] + sR[3], -sR[2], -sR[3]);

            // draw the current sprite
            Draw(spriteBatch, sourceRectangle, tint);
        }
    }
}