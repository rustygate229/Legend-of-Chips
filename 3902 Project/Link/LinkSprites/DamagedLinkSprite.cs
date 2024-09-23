using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace _3902_Project
{
	public class DamagedLinkSprite
	{
        private Texture2D spritesheet;
        private int width;
        private int height;
        private int frame;
        private int totalFrames;
        private List<Rectangle> sourceList;



        public DamagedLinkSprite(Texture2D sheet, int w, int h)
        {
            //width and height are size of sprite
            spritesheet = sheet;
            width = w;
            height = h;
            totalFrames = 3;
            frame = 0;
            sourceList = new List<Rectangle>();
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

        public void Draw(SpriteBatch sb, ILinkStateMachine state, int x, int y)
        {
            throw new NotImplementedException();
        }
    }

}