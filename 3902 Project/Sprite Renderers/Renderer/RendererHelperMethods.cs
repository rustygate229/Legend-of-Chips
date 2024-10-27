using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {
        public Vector2 PositionAhead(Rectangle destinationRectangle)
        {
            switch ((int)_directionNumber)
            {
                case 0: // DOWN
                    return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y + (int)destinationRectangle.Height);
                case 1: // UP
                    return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y - (int)destinationRectangle.Height);
                case 2: // RIGHT
                    return new Vector2((int)destinationRectangle.X + (int)destinationRectangle.Width, (int)destinationRectangle.Y);
                case 3: // LEFT
                    return new Vector2((int)destinationRectangle.X - (int)destinationRectangle.Width, (int)destinationRectangle.Y);
                default: throw new ArgumentException("Invalid direction type in PositionAhead");
            }
        }


        public Vector2 GetUpdatePosition(float positionSpeed)
        {
            // movement variables
            switch ((int)_directionNumber)
            {
                case 0: // DOWN
                    return new Vector2(0, Math.Abs(positionSpeed));
                case 1: // UP
                    return new Vector2(0, -(Math.Abs(positionSpeed)));
                case 2: // RIGHT
                    return new Vector2(Math.Abs(positionSpeed), 0);
                case 3: // LEFT
                    return new Vector2(-(Math.Abs(positionSpeed)), 0);
                default: throw new ArgumentException("Invalid direction type for updatePosition");
            }
        }


        public void DrawVerticallyFlipped(SpriteBatch spriteBatch, bool isCentered)
        {
            Rectangle destinationRectangle = this.GetDestinationRectangle();
            int[] sR = this.GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1] + sR[3], sR[2], -sR[3]);

            // draw the current sprite
            if (isCentered)
                this.DrawCentered(spriteBatch, sourceRectangle);
            else
                this.Draw(spriteBatch, sourceRectangle, destinationRectangle);
        }


        public void DrawHorizontallyFlipped(SpriteBatch spriteBatch, bool isCentered)
        {
            Rectangle destinationRectangle = this.GetDestinationRectangle();
            int[] sR = this.GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1], -sR[2], sR[3]);

            // draw the current sprite
            if (isCentered)
                this.DrawCentered(spriteBatch, sourceRectangle);
            else
                this.Draw(spriteBatch, sourceRectangle, destinationRectangle);
        }


        public void DrawCompletelyFlipped(SpriteBatch spriteBatch, bool isCentered)
        {
            Rectangle destinationRectangle = this.GetDestinationRectangle();
            int[] sR = this.GetSourceRectangleArray();
            Rectangle sourceRectangle = new Rectangle(sR[0] + sR[2], sR[1] + sR[3], -sR[2], -sR[3]);

            // draw the current sprite
            if (isCentered)
                this.DrawCentered(spriteBatch, sourceRectangle);
            else
                this.Draw(spriteBatch, sourceRectangle, destinationRectangle);
        }
    }
}