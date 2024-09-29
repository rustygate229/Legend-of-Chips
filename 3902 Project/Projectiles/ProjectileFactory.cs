using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ProjectileFactory
    {
        private Texture2D linkSpriteSheet;

        private static ProjectileFactory instance = new ProjectileFactory();

        //CAN BE TUNED INSIDE EACH SPRITEFACTORY
        private int spriteSize = 64;
        public static ProjectileFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ProjectileFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("Link Spritesheet transparent");
        }


        public IProjectileSprite CreateArrowSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(1, 185, 8, 16));
            source.Add(new Rectangle(10, 185, 16, 16));
            source.Add(new Rectangle(53, 185, 16, 16));

            return new ProjectileArrowSprite(linkSpriteSheet, source, spriteSize / 16.0f);

        }

        public IProjectileSprite CreateBlueArrowSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(27, 185, 8, 16));
            source.Add(new Rectangle(36, 185, 16, 16));
            source.Add(new Rectangle(53, 185, 16, 16));

            return new ProjectileArrowSprite(linkSpriteSheet, source, spriteSize / 16.0f);

        }

        public IProjectileSprite CreateWoodBoomerangSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(64, 185, 8, 16));
            source.Add(new Rectangle(73, 185, 8, 16));
            source.Add(new Rectangle(82, 185, 8, 16));
            source.Add(new Rectangle(118, 185, 8, 16));

            return new ProjectileBoomerangSprite(linkSpriteSheet, source, spriteSize / 16.0f);
        }

        public IProjectileSprite CreateBlueBoomerangSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(91, 185, 8, 16));
            source.Add(new Rectangle(100, 185, 8, 16));
            source.Add(new Rectangle(109, 185, 8, 16));
            source.Add(new Rectangle(118, 185, 8, 16));

            return new ProjectileBoomerangSprite(linkSpriteSheet, source, spriteSize / 16.0f);
        }

        public IProjectileSprite CreateBombSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(129, 185, 8, 16));
            source.Add(new Rectangle(138, 185, 16, 16));
            source.Add(new Rectangle(155, 185, 16, 16));
            source.Add(new Rectangle(172, 185, 16, 16));

            return new ProjectileBombSprite(linkSpriteSheet, source, spriteSize / 16.0f);
        }

    }
}
