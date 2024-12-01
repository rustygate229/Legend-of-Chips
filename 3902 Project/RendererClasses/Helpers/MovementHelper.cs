using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class MovementHelper
    {
        private Random _random = new Random();
        private Renderer.DIRECTION _direction;


        public MovementHelper(Renderer.DIRECTION direction)
        {
            _direction = direction;
        }

        /// <summary>
        /// the updated position increasing in a RANDOM direction by given positionSpeed
        /// </summary>
        /// <param name="positionSpeed">the rate at which the position updates</param>
        /// <returns>returns updated position that was randomly chosen</returns>
        public Renderer.DIRECTION GetRandomMovement()
        {
            return (Renderer.DIRECTION)_random.Next(4);
        }

        /// <summary>
        /// the updated position increasing in direction by positionSpeed
        /// </summary>
        /// <param name="direction">the direction this is facing</param>
        /// <param name="positionSpeed">the rate at which the position updates</param>
        /// <returns>the updated position to be added to position</returns>
        public Vector2 GetUpdatePosition(float positionSpeed)
        {
            //Console.WriteLine("renderer helper methods: " + _direction.ToString());
            // movement variables
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN:    return new Vector2(0, Math.Abs(positionSpeed));
                case Renderer.DIRECTION.UP:      return new Vector2(0, -(Math.Abs(positionSpeed)));
                case Renderer.DIRECTION.RIGHT:   return new Vector2(Math.Abs(positionSpeed), 0);
                case Renderer.DIRECTION.LEFT:    return new Vector2(-(Math.Abs(positionSpeed)), 0);
                default: throw new ArgumentException("Invalid direction type for updatePosition");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale">defaults to 0/No Scale if the range is not accurate: 0 <= scale <= 1</param>
        /// <returns>the position</returns>
        public Vector2 GetPositionAhead(float scale, Rectangle dS)
        {
            if (scale < 0 || scale > 1) { scale = 0; }
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN:    return new Vector2(dS.X, (int)(dS.Y + (dS.Height * scale)));
                case Renderer.DIRECTION.UP:      return new Vector2(dS.X, (int)(dS.Y - (dS.Height * scale)));
                case Renderer.DIRECTION.RIGHT:   return new Vector2((int)(dS.X + (dS.Width * scale)), dS.Y);
                case Renderer.DIRECTION.LEFT:    return new Vector2((int)(dS.X - (dS.Width * scale)), dS.Y);
                default: throw new ArgumentException("Invalid direction type in PositionAhead");
            }
        }
    }
}