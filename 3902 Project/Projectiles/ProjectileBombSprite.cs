using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
	public class ProjectileBombSprite : IProjectileSprite, IProjectile
    {
        private Texture2D spritesheet;
        private float scale;
        private int frame;
        private int totalFrames;
        private List<Rectangle> sourceList;
        public ProjectileBombSprite(Texture2D sheet, List<Rectangle> sources, float s)
		{
            spritesheet = sheet;
            scale = s;
            frame = 0;
            totalFrames = 1;
            sourceList = sources;

		}

        public void Update()
        {
        }

        public void Draw(SpriteBatch sb, IProjectile.DIRECTION dir, int x, int y)
        {
            Rectangle sourceRectangle = sourceList[frame];
            if (dir == IProjectile.DIRECTION.DESTROYED)
            {
                sourceRectangle = sourceList[4];
            }

            Rectangle destinationRectangle = new Rectangle(x, y, sourceRectangle.Width * (int)scale, sourceRectangle.Height * (int)scale);

            sb.Begin(samplerState: SamplerState.PointClamp);
            sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White);
            sb.End();
        }

        public double getXPosition()
        {
            throw new NotImplementedException();
        }

        public double getYPosition()
        {
            throw new NotImplementedException();
        }
    }
}
