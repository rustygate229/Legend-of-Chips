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

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        // Constructor to initialize the factory instance
        private EnemySpriteFactory()
        {
            EnemySpriteFactory.instance = this;
        }

        // Load all necessary textures (both enemy sprites and bullet textures for shooters)
        public void LoadAllTextures(ContentManager content)
        {
            // Load the enemy spritesheet
            _enemySpritesheet = content.Load<Texture2D>("Dungeon_Enemies_Spritesheet_transparent");
        }

        // create every type of enemy
        public ISprite CreateEnemy(EnemyManager.EnemyNames enemyName)
        {
            switch (enemyName)
            {
                case EnemyManager.EnemyNames.BrownSlime:
                    return new BrownSlime(_enemySpritesheet);
                case EnemyManager.EnemyNames.GreenSlime:
                    return new GreenSlime(_enemySpritesheet);
                case EnemyManager.EnemyNames.Wizzrope:
                    return new Wizzrope(_enemySpritesheet);
                case EnemyManager.EnemyNames.Darknut:
                    return new Darknut(_enemySpritesheet);
                case EnemyManager.EnemyNames.Proto:
                    return new Proto(_enemySpritesheet);

                default: throw new ArgumentException("Invalid block name");
            }

            // Add more enemy types as necessary by specifying their source rectangles and positions
            // public ISprite OtherEnemy() { ... }
        }
    }
}
