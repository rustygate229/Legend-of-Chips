using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace _3902_Project
{
	public class ItemLinkSprite : ISprite
	{
        private Texture2D spritesheet;
        private int width;
        private int height;
        private int frame;
        private int totalFrames;
        private List<Rectangle> sourceList;


        public ItemLinkSprite(Texture2D sheet, int w, int h)
        {
            //width and height are size of sprite
            spritesheet = sheet;
            width = w;
            height = h;
            totalFrames = 1;
            frame = 0;
            sourceList = new List<Rectangle>();

            //hard coded values for sheet
            //sourceList[0] = down, 1 = right, 2 = up
            sourceList.Add(new Microsoft.Xna.Framework.Rectangle(-107, -11, 16, 16)); 
            sourceList.Add(new Rectangle(-124, -11, 16, 16));
            sourceList.Add(new Rectangle(-141, -11, 16, 16));

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

            if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MUP)
            {
                sourceRectangle = sourceList[2];
            }
            else if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MDOWN)
            {
                sourceRectangle = sourceList[0];
            }
            else if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MLEFT) 
            {
                sourceRectangle = sourceList[1];
            } 
            else
            {
                //defaults to right for reverse, fix later
                sourceRectangle= sourceList[0];
            }

            sb.Begin(samplerState: SamplerState.PointClamp);
            sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White);
            sb.End();

		}
	}

}