using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace _3902_Project
{
    public class EnemySpriteFactory
    {
        // Enemy spritesheet
        private Texture2D _enemySpritesheet;

        // Create a singleton instance of EnemySpriteFactory
        private static EnemySpriteFactory instance = new EnemySpriteFactory();
        private static ProjectileManager _projectileManager;

        public static EnemySpriteFactory Instance { get { return instance; } }

        // Constructor to initialize the factory instance
        private EnemySpriteFactory() { EnemySpriteFactory.instance = this; }

        public void LoadAllTextures(ContentManager content) { _enemySpritesheet = content.Load<Texture2D>("Dungeon_Enemies_Spritesheet_transparent"); }

        public void UnloadAllTextures(ContentManager content) { _enemySpritesheet.Dispose(); }

        public void SetManager(ProjectileManager manager) { _projectileManager = manager; }


        // create every type of enemy
        public ISprite CreateEnemy(EnemyManager.EnemyNames enemyName, float printScale, float spriteSpeed, int moveTotalTimerTotal, int frames)
        {
            switch (enemyName)
            {
                case EnemyManager.EnemyNames.BrownSlime:
                    return new BrownSlime(_enemySpritesheet, _projectileManager, printScale, spriteSpeed, moveTotalTimerTotal, frames);
                case EnemyManager.EnemyNames.GreenSlime:
                    return new GreenSlime(_enemySpritesheet, _projectileManager, printScale, spriteSpeed, moveTotalTimerTotal, frames);
                case EnemyManager.EnemyNames.Darknut:
                    return new Darknut(_enemySpritesheet, _projectileManager, printScale, spriteSpeed, moveTotalTimerTotal, frames);
                default: throw new ArgumentException("invalid enemy name");
            }
        }
        // Add more enemy types as necessary by specifying their source rectangles and positions
        // public ISprite OtherEnemy() { ... }
    }
}
