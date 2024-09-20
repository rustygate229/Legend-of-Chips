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

		public void Draw(SpriteBatch sb, ILinkStateMachine state, int x, int y)
		{
            //needs access to state 
            //x and y are passed in by LinkAnimation from LinkMovement
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            Rectangle sourceRectangle;

            Boolean reverseFlag = false; 

            if (state.getDirectionState() == (int)LinkStateMachine.Direction.UP)
            {
                sourceRectangle = sourceList[2];
            }
            else if (state.getDirectionState() == (int)LinkStateMachine.Direction.DOWN)
            {
                sourceRectangle = sourceList[0];
            }
            else if (state.getDirectionState() == (int)LinkStateMachine.Direction.LEFT) 
            {
                sourceRectangle = sourceList[1];
            } 
            else
            {
                //defaults to right for reverse, fix later
                reverseFlag = true;
                sourceRectangle = sourceList[0];
            }

            sb.Begin(samplerState: SamplerState.PointClamp);
            if (reverseFlag)
            {
                //commented out until i fix the reverse flag stuff
                //sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White, SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {//reverseFlag = false
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White);
            }
            sb.End();

		}
	}

}