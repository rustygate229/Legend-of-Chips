using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class ProjectileFactory
    {
        private Texture2D _enemySpriteSheet;
        private Texture2D _linkSpriteSheet;

        private static ProjectileFactory instance = new ProjectileFactory();

        public enum ProjectileSpriteNames
        {
            BlueArrow, FireBall,
            SmallExplosion, Bomb, BombCloud, BombFire
        }

        public static ProjectileFactory Instance { get { return instance; } }

        private ProjectileFactory() { instance = this; }

        public void LoadAllTextures(ContentManager content)
        {
            _enemySpriteSheet = content.Load<Texture2D>("Dungeon_Enemies_Spritesheet_transparent");
            _linkSpriteSheet = content.Load<Texture2D>("Link Spritesheet transparent");
        }

        public void UnloadAllTextures(ContentManager content)
        {
            _enemySpriteSheet.Dispose();
            _linkSpriteSheet.Dispose();
        }


        // create every type of projectile
        public ISprite CreateProjectile(ProjectileSpriteNames projectileSpriteName, Renderer.DIRECTION direction, float printScale)
        {
            switch (projectileSpriteName)
            {
                case ProjectileSpriteNames.BlueArrow:
                    return new PSprite_BlueArrow(_linkSpriteSheet, direction, printScale);
                case ProjectileSpriteNames.FireBall:
                    return new PJoiner_FireBall(_linkSpriteSheet, direction, printScale);
                default: throw new ArgumentException("Invalid projectile name in factory");
            }

            // Add more enemy types as necessary by specifying their source rectangles and positions
            // public ISprite OtherProjectile() { ... }
        }

        // create every type of projectile
        public ISprite CreateProjectile(ProjectileSpriteNames projectileSpriteName, float printScale)
        {
            switch (projectileSpriteName)
            {
                case ProjectileSpriteNames.Bomb:
                    return new PSprite_Bomb(_linkSpriteSheet, printScale);
                case ProjectileSpriteNames.BombCloud:
                    return new PSprite_BombCloud(_linkSpriteSheet, printScale);
                case ProjectileSpriteNames.BombFire:
                    return new PSprite_Fire(_linkSpriteSheet, printScale);
                case ProjectileSpriteNames.SmallExplosion:
                    return new PSprite_SmallExplosion(_linkSpriteSheet, printScale);
                default: throw new ArgumentException("Invalid projectile name in factory");
            }

            // Add more enemy types as necessary by specifying their source rectangles and positions
            // public ISprite OtherProjectile() { ... }
        }
    }
}
