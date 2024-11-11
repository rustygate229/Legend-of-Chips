using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {
        public DIRECTION GetDirection() { return _direction; }

        private Random _random = new Random();

        /// <summary>
        /// the updated position increasing in a RANDOM direction by given positionSpeed
        /// </summary>
        /// <param name="positionSpeed">the rate at which the position updates</param>
        /// <returns>returns updated position that was randomly chosen</returns>
        public Vector2 GetRandomMovement(float positionSpeed)
        {
            int randomValue = _random.Next(4);
            // Randomly choose a direction:
            switch (randomValue)
            {
                case 0: // Move DOWN
                    SetDirection(DIRECTION.DOWN);
                    this.SetDirection(_direction);
                    return this.GetUpdatePosition(randomValue, positionSpeed);
                case 1: // Move UP
                    SetDirection(DIRECTION.UP);
                    this.SetDirection(_direction);
                    return this.GetUpdatePosition(randomValue, positionSpeed);
                case 2: // Move RIGHT
                    SetDirection(DIRECTION.RIGHT);
                    this.SetDirection(_direction);
                    return this.GetUpdatePosition(randomValue, positionSpeed);
                case 3: // Move LEFT
                    SetDirection(DIRECTION.LEFT);
                    this.SetDirection(_direction);
                    return this.GetUpdatePosition(randomValue, positionSpeed);
                default: throw new ArgumentException("Invalid direction type for updatePosition");
            }
        }

        /// <summary>
        /// the updated position increasing in direction by positionSpeed
        /// </summary>
        /// <param name="direction">the direction this is facing</param>
        /// <param name="positionSpeed">the rate at which the position updates</param>
        /// <returns>the updated position to be added to position</returns>
        public Vector2 GetUpdatePosition(int direction, float positionSpeed)
        {
            // movement variables
            switch (direction)
            {
                case 0: // DOWN
                    return new Vector2(0, Math.Abs(positionSpeed));
                case 1: // UP
                    return new Vector2(0, -(Math.Abs(positionSpeed)));
                case 2: // RIGHT
                    return new Vector2(Math.Abs(positionSpeed), 0);
                case 3: // LEFT
                    return new Vector2(-(Math.Abs(positionSpeed)), 0);
                case 4: // DOWN
                    return new Vector2(0, Math.Abs(positionSpeed));
                case 5: // UP
                    return new Vector2(0, -(Math.Abs(positionSpeed)));
                case 6: // RIGHT
                    return new Vector2(Math.Abs(positionSpeed), 0);
                case 7: // LEFT
                    return new Vector2(-(Math.Abs(positionSpeed)), 0);
                default: throw new ArgumentException("Invalid direction type for updatePosition");
            }
        }

        /// <summary>
        /// draws the sprite flipped vertically from it's normal settings (the sprites opposite along the vertical plane)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        /// <param name="isCentered">is the sprite going to be drawn centererd or not</param>
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

        /// <summary>
        /// draws the sprite flipped horizontally from it's normal settings (the sprites opposite along the horiztonal plane)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        /// <param name="isCentered">is the sprite going to be drawn centererd or not</param>
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

        /// <summary>
        /// draws the sprite flipped both horizontally and vertically from it's normal settings (the sprites opposite along both planes)
        /// </summary>
        /// <param name="spriteBatch">the spriteBatch where this is drawn in</param>
        /// <param name="isCentered">is the sprite going to be drawn centererd or not</param>
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

        /*
         * old method that proved to be kind of useless, but could return
        public Vector2 PositionAhead(Rectangle destinationRectangle)
        {
            // commented out old place in front code since it may affect how collision is running
            switch ((int)_directionNumber)
            {
                case 0: // DOWN
                    // return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y + (int)destinationRectangle.Height);
                    return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y);
                case 1: // UP
                    // return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y - (int)destinationRectangle.Height);
                    return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y);
                case 2: // RIGHT
                    // return new Vector2((int)destinationRectangle.X + (int)destinationRectangle.Width, (int)destinationRectangle.Y);
                    return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y);
                case 3: // LEFT
                    // return new Vector2((int)destinationRectangle.X - (int)destinationRectangle.Width, (int)destinationRectangle.Y);
                    return new Vector2((int)destinationRectangle.X, (int)destinationRectangle.Y);
                default: throw new ArgumentException("Invalid direction type in PositionAhead");
            }
        }
        */
    }
}