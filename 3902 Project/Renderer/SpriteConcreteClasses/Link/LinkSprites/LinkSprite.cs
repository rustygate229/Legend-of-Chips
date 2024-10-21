using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using static _3902_Project.ILinkStateMachine;

namespace _3902_Project
{
    public class LinkSprite : ILinkSprite
    {
        private Texture2D spritesheet;
        private int width;
        private int height;
        private int frame;
        private int totalFrames;
        private List<Rectangle> sourceList;
        private ILinkStateMachine linkStateMachine;
        public double x {get; set; }
        public double y {get; set; }


        public LinkSprite(Texture2D sheet, List<Rectangle> sources, int numFrames, int w, int h, ILinkStateMachine state)
        {
            //width and height are size of sprite
            spritesheet = sheet;
            width = w;
            height = h;
            totalFrames = numFrames;
            frame = 0;
            sourceList = sources;
            linkStateMachine = state;

            x = y = 0;

            //hard coded values for sheet
            //sourceList[0] = down, 1 = right, 2 = up

        }

        public static bool IsOverlapping(Rectangle rect1, Rectangle rect2)
        {
            // Checking for rectangular overlap
            return !(rect1.X > rect2.X + rect2.Width ||
                     rect1.X + rect1.Width < rect2.X ||
                     rect1.Y > rect2.Y + rect2.Height ||
                     rect1.Y + rect1.Height < rect2.Y);
        }

        public void Update()
		{
            Game1.bulletManager.bullets.RemoveAll(bullet => IsOverlapping(new Rectangle((int)bullet._position.X, (int)bullet._position.Y, bullet.width, bullet.height),
               new Rectangle((int)x, (int)y, width, height)));
            //updates x and y position from LinkMovement.cs
            frame++;
            if (frame >= totalFrames)
            {
                //frame increments from 0 to count - 1
                frame = 0;
            }

        }

		public void Draw(SpriteBatch sb)
		{
            //needs access to state 
            //x and y are passed in by LinkAnimation from LinkMovement
            Rectangle destinationRectangle = new Rectangle((int)x, (int)y, width, height);
            Rectangle sourceRectangle;
            Color tint = Color.White;

            Boolean reverseFlag = false;

            //sourceList = down, right, up, order from left to right in spritesheet


            ILinkStateMachine.MOVEMENT direction = linkStateMachine.getMovementState();

            if (direction == MOVEMENT.MDOWN || direction == MOVEMENT.SDOWN)
            {
                sourceRectangle = sourceList[frame];
            }
            else if (direction == MOVEMENT.MRIGHT || direction == MOVEMENT.SRIGHT)
            {
                sourceRectangle = sourceList[frame + totalFrames];
            }
            else if (direction == MOVEMENT.MUP || direction == MOVEMENT.SUP)
            {
                sourceRectangle = sourceList[frame + 2 * totalFrames];
            }
            else if (direction == MOVEMENT.MLEFT || direction == MOVEMENT.SLEFT)
            {
                //reverse flag since spritesheet doesn't have left sprites
                reverseFlag = true;
                sourceRectangle = sourceList[frame + totalFrames];
            }
            else
            {
                //defaults to down sprite animation
                sourceRectangle = sourceList[frame];
            }


            if (linkStateMachine.getDamage()) 
            {
                //System.Diagnostics.Debug.WriteLine("tint changed in LinkSprite");
                tint = Color.Red;
            }

            sb.Begin(samplerState: SamplerState.PointClamp);
            if (reverseFlag)
            {
                //draws a reversed version of right sprites 
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, tint, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {//reverseFlag = false
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, tint);
            }
            sb.End();

		}
	}

}