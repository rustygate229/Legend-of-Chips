using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using System.Collections.Generic;

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
            sourceList.Add(new Rectangle(-107, -11, 16, 16)); 
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

		public void Draw(SpriteBatch sb, ILinkStateMachine state, ILinkMovement mvt)
		{
            //needs access to state and movement 
			


		}
	}

}