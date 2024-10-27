using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;

namespace _3902_Project
{
    public class ProjectileFactory
    {
        private Texture2D _enemySpriteSheet;
        private Texture2D _linkSpriteSheet;

        private static ProjectileFactory instance = new ProjectileFactory();

        public static ProjectileFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ProjectileFactory()
        {
            instance = this;
        }

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
        public ISprite CreateProjectile(ProjectileManager.ProjectileNames projectileName, Renderer.DIRECTION direction, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch (projectileName)
            {
                case ProjectileManager.ProjectileNames.Bomb:
                    return new Projectile_Bomb(_linkSpriteSheet, direction, timer, printScale, frameRanges);
                case ProjectileManager.ProjectileNames.BlueArrow:
                    return new Projectile_BlueArrow(_linkSpriteSheet, direction, timer, speed, printScale, frameRanges);
                default: throw new ArgumentException("Invalid projectile name");
            }

            // Add more enemy types as necessary by specifying their source rectangles and positions
            // public ISprite OtherProjectile() { ... }
        }
    }
}
