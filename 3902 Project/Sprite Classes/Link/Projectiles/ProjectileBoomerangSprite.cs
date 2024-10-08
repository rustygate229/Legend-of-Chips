using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace Content.Projectiles
{
    public class ProjectileBoomerangSprite : IProjectileSprite
    {
        private Texture2D spritesheet;
        private float scale;
        private int frame;
        private int totalFrames;
        private List<Rectangle> sourceList;
        bool reverse;
        public ProjectileBoomerangSprite(Texture2D sheet, List<Rectangle> sources, float s)
        {
            spritesheet = sheet;
            scale = s;
            frame = 0;
            totalFrames = 3;
            sourceList = sources;
            reverse = false;

        }

        public void Update()
        {
            frame++;
            if (frame >= totalFrames)
            {
                //frame increments from 0 to count - 1
                frame = 0;
                reverse = !reverse;
            }
        }

        public void Draw(SpriteBatch sb, IProjectile.DIRECTION dir, int x, int y)
        {
            //no notion of direction for boomerangs
            Rectangle sourceRectangle = sourceList[frame];

            if (dir == IProjectile.DIRECTION.DESTROYED)
            {
                sourceRectangle = sourceList[3];
            }

            Rectangle destinationRectangle = new Rectangle(x, y, sourceRectangle.Width * (int)scale, sourceRectangle.Height * (int)scale);

            sb.Begin(samplerState: SamplerState.PointClamp);
            if (reverse)
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
