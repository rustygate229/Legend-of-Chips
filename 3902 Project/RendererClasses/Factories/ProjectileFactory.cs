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
        public IJoiner CreateProjectile(ProjectileManager.ProjectileNames name, Renderer.DIRECTION direction, float printScale)
        {
            switch (name)
            {
                case ProjectileManager.ProjectileNames.BlueArrow:
                    return new PJoiner_BlueArrow(_linkSpriteSheet, direction, printScale);
                case ProjectileManager.ProjectileNames.FireBall:
                    return new PJoiner_FireBall(_enemySpriteSheet, direction, printScale);
                case ProjectileManager.ProjectileNames.Bomb:
                    return new PJoiner_Bomb(_linkSpriteSheet, direction, printScale);
                case ProjectileManager.ProjectileNames.Boomerang:
                    return new PJoiner_Boomerang(_linkSpriteSheet, direction, printScale);
                case ProjectileManager.ProjectileNames.WoodSwordAttack:
                    return new PJoiner_WoodSword(name, _linkSpriteSheet, direction, printScale);
                default: throw new ArgumentException("Invalid projectile name in factory");
            }

            // Add more enemy types as necessary by specifying their source rectangles and positions
            // public ISprite OtherProjectile() { ... }
        }
    }
}
