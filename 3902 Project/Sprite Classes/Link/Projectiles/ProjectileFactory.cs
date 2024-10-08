using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Content.Projectiles
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


        public IProjectile CreateArrowProjectile(int x, int y, IProjectile.DIRECTION dir)
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(1, 185, 8, 16));
            source.Add(new Rectangle(10, 185, 16, 16));
            source.Add(new Rectangle(53, 185, 8, 16));

            IProjectileSprite s = new ProjectileArrowSprite(linkSpriteSheet, source, spriteSize / 16.0f);
            return new ForwardProjectile(x, y, s, dir, 6, 35);

        }

        public IProjectile CreateBlueArrowProjectile(int x, int y, IProjectile.DIRECTION dir)
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(27, 185, 8, 16));
            source.Add(new Rectangle(36, 185, 16, 16));
            source.Add(new Rectangle(53, 185, 8, 16));


            IProjectileSprite s = new ProjectileArrowSprite(linkSpriteSheet, source, spriteSize / 16.0f);
            return new ForwardProjectile(x, y, s, dir, 12, 25);

        }

        public IProjectile CreateWoodBoomerangProjectile(int x, int y, IProjectile.DIRECTION dir)
        {
            //TODO: FINISH BOOMERANG AND BOMB PROJECTILES
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(64, 185, 8, 16));
            source.Add(new Rectangle(73, 185, 8, 16));
            source.Add(new Rectangle(82, 185, 8, 16));
            source.Add(new Rectangle(118, 185, 8, 16));

            IProjectileSprite s = new ProjectileBoomerangSprite(linkSpriteSheet, source, spriteSize / 16.0f);
            return new BoomerangProjectile(x, y, s, dir, 12, 40);
        }

        public IProjectile CreateBlueBoomerangProjectile(int x, int y, IProjectile.DIRECTION dir)
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(91, 185, 8, 16));
            source.Add(new Rectangle(100, 185, 8, 16));
            source.Add(new Rectangle(109, 185, 8, 16));
            source.Add(new Rectangle(118, 185, 8, 16));

            IProjectileSprite s = new ProjectileBoomerangSprite(linkSpriteSheet, source, spriteSize / 16.0f);
            return new BoomerangProjectile(x, y, s, dir, 18, 35);
        }

        public IProjectile CreateBombProjectile(int x, int y)
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(129, 185, 8, 16));
            source.Add(new Rectangle(138, 185, 16, 16));
            source.Add(new Rectangle(155, 185, 16, 16));
            source.Add(new Rectangle(172, 185, 16, 16));

            IProjectileSprite s = new ProjectileBombSprite(linkSpriteSheet, source, spriteSize / 16.0f);
            return new BombProjectile(x, y, s, IProjectile.DIRECTION.RIGHT, 18, 35);
        }

    }
}
