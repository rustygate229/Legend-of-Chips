using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class ProjectileSprite : ISprite
    {
        private Texture2D spritesheet;
        private float scale;
        private int frame;
        private int totalFrames;
        private List<Rectangle> sourceList;
        public ProjectileSprite(Texture2D sheet, List<Rectangle> sources, int numFrames, float s)
        {
            spritesheet = sheet;
            scale = s;
            frame = 0;
            totalFrames = numFrames;
            sourceList = sources;

        }

        public void Update()
        {
            frame++;
            if (frame >= totalFrames)
            {
                //frame increments from 0 to count - 1
                frame = 0;
            }
        }

        //weirdly similar to IStateMachine call
        public void Draw(SpriteBatch spriteBatch, IProjectile proj, int x, int y)
        {


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
