using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
	public class DamagedLinkSprite : ISprite
	{
        private Texture2D spritesheet;
        private int width;
        private int height;
        private int frame;
        private int totalFrames;


        public DamagedLinkSprite(Texture2D sheet, int w)
        {
            //width and height are size of sprite
            spritesheet = sheet;
            width = w;
            height = h;
            totalFrames = 3;
            frame = 0;
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
		
		public void Draw(SpriteBatch sb)
		{
			


		}
	}

}