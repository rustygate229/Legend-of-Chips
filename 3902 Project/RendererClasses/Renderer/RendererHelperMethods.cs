using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {
        /// <summary>
        /// the updated position increasing in a RANDOM direction by given positionSpeed
        /// </summary>
        /// <param name="positionSpeed">the rate at which the position updates</param>
        /// <returns>returns updated position that was randomly chosen</returns>
        public void SetRandomMovement()
        {
            MovementHelper helper = new(_direction);
            Direction = helper.GetRandomMovement();
        }

        /// <summary>
        /// the updated position increasing in direction by positionSpeed
        /// </summary>
        /// <param name="direction">the direction this is facing</param>
        /// <param name="positionSpeed">the rate at which the position updates</param>
        /// <returns>the updated position to be added to position</returns>
        public Vector2 GetUpdatePosition(float positionSpeed)
        {
            MovementHelper helper = new(_direction);
            return helper.GetUpdatePosition(positionSpeed);
        }

        /// <param name="scale">defaults to 0/No Scale if the range is not accurate: 0 <= scale <= 1</param>
        /// <returns>the position ahead of the sprite</returns>
        public Vector2 GetPositionAhead(float scale)
        {
            MovementHelper helper = new(_direction);
            return helper.GetPositionAhead(scale, DestinationRectangle);
        }
    }
}