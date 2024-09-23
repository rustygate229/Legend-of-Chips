using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
	public class LinkSprite : ISprite
	{
        private Texture2D spritesheet;
        private int width;
        private int height;
        private int frame;
        private int totalFrames;
        private List<Rectangle> sourceList;


        public LinkSprite(Texture2D sheet, List<Rectangle> sources, int numFrames, int w, int h)
        {
            //width and height are size of sprite
            spritesheet = sheet;
            width = w;
            height = h;
            totalFrames = numFrames;
            frame = 0;
            sourceList = sources;

            //hard coded values for sheet
            //sourceList[0] = down, 1 = right, 2 = up

        }

        public void Update()
		{
            //updates x and y position from LinkMovement.cs
            frame++;
            if (frame >= totalFrames)
            {
                //frame increments from 0 to count - 1
                frame = 0;
            }

        }
		public void Draw(SpriteBatch spritebatch)
        {
            //just for interface reasons
        }

		public void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y)
		{
            //needs access to state 
            //x and y are passed in by LinkAnimation from LinkMovement
            Rectangle destinationRectangle = new Rectangle((int)x, (int)y, width, height);
            Rectangle sourceRectangle;

            Boolean reverseFlag = false; 

            //sourceList = down, right, up, order from left to right in spritesheet


            if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MDOWN || state.getMovementState() == (int)LinkStateMachine.MOVEMENT.SDOWN)
            {
                sourceRectangle = sourceList[frame];
            }
            else if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MRIGHT || state.getMovementState() == (int)LinkStateMachine.MOVEMENT.SRIGHT) 
            {
                sourceRectangle = sourceList[frame + totalFrames];
            }
            else if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MUP || state.getMovementState() == (int)LinkStateMachine.MOVEMENT.SUP)
            {
                sourceRectangle = sourceList[frame + 2 * totalFrames];
            }
            else if (state.getMovementState() == (int) LinkStateMachine.MOVEMENT.MLEFT || state.getMovementState() == (int)LinkStateMachine.MOVEMENT.SLEFT) 
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

            sb.Begin(samplerState: SamplerState.PointClamp);
            if (reverseFlag)
            {
                //draws a reversed version of right sprites 
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {//reverseFlag = false
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White);
            }
            sb.End();

		}
	}

}