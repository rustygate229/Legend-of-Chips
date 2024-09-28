using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
	public class ProjectileArrowSprite : IProjectileSprite
	{
        private Texture2D spritesheet;
        private float scale;
        private int frame;
        //private int totalFrames;
        private List<Rectangle> sourceList;
        public ProjectileArrowSprite(Texture2D sheet, List<Rectangle> sources, float s)
		{
            spritesheet = sheet;
            scale = s;
            frame = 0;
            sourceList = sources;

		}

        public void Update()
        {
            //nothing to update (no animations) timing is done by ForwardProjectile
        }

        //weirdly similar to IStateMachine call
        public void Draw(SpriteBatch sb, IProjectile.DIRECTION dir, int x, int y)
        {
            Rectangle sourceRectangle;
            if (dir == IProjectile.DIRECTION.UP || dir == IProjectile.DIRECTION.DOWN)
            {
                sourceRectangle = sourceList[0];
            } 
            else if(dir == IProjectile.DIRECTION.RIGHT ||  dir == IProjectile.DIRECTION.LEFT)
            {
                //horizontal sprite
                sourceRectangle= sourceList[1];
            } else
            {
                //DIRECTION has to be equal to DESTROYED
                sourceRectangle = sourceList[2];

            }

            Rectangle destinationRectangle = new Rectangle(x, y, sourceRectangle.Width * (int)scale, sourceRectangle.Height * (int)scale);
            

            sb.Begin(samplerState: SamplerState.PointClamp);
            
            if (dir == IProjectile.DIRECTION.LEFT)
            {
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else if (dir == IProjectile.DIRECTION.DOWN)
            {
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipVertically, 0f);
            } 
            else
            {
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White);
            }

            sb.End();
        }
    }
}
