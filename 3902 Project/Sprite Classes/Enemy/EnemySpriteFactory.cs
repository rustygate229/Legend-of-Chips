﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project
{
    public class EnemySpriteFactory
    {
        // Enemy spritesheet
        private Texture2D _enemySpritesheet;

        // Position that all enemies will initially be placed at 
        private Vector2 _initialPosition = new Vector2(20, 100);

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

            // Load bullet textures using BulletSpriteFactory
            BulletSpriteFactory.Instance.LoadAllTextures(content);
        }

        // Create an instance of Green Monster with shooting capability
        public ISprite GreenMonster1()
        {
            // Source rectangle for Green Monster
            Rectangle sourceRectangle = new Rectangle(79, 11, 30, 16);

            
            int columns = 2; 
            int rows = 1;    

           
            int frameRate = 30; 

            // Create the enemy sprite with shooting capability
            ISprite enemySprite = new EnemySprite(
                _enemySpritesheet,
                _initialPosition,
                sourceRectangle,
                rows,
                columns,
                frameRate,
                canShoot: true 
            );

            return enemySprite;
        }

        // Create an instance of Brown Monster without shooting capability
        public ISprite BrownMonster2()
        {
            // Source rectangle for Green Monster 2
            Rectangle sourceRectangle = new Rectangle(79, 28, 30, 16);

            // Animation parameters
            int columns = 2; 
            int rows = 1;
            int frameRate = 30; 

            // Create the enemy sprite without shooting capability
            ISprite enemySprite = new EnemySprite(
                _enemySpritesheet,
                _initialPosition,
                sourceRectangle,
                rows,
                columns,
                frameRate,
                canShoot: false
            );

            return enemySprite;
        }

        // Create an instance of wizzrobe without shooting capability
        public ISprite wizzrobe()
        {
            // Source rectangle for Rope 1
            Rectangle sourceRectangle = new Rectangle(127, 107, 32, 16);

            // Animation parameters
            int columns = 2; 
            int rows = 1;
            int frameRate = 30; 

            // Create the enemy sprite without shooting capability
            ISprite enemySprite = new EnemySprite(
                _enemySpritesheet,
                _initialPosition,
                sourceRectangle,
                rows,
                columns,
                frameRate,
                canShoot: false
            );

            return enemySprite;
        }

        // Create an instance of proto without shooting capability
        public ISprite Proto()
        {
            // Source rectangle for Rope 2
            Rectangle sourceRectangle = new Rectangle(300, 194, 32, 16);

            // Animation parameters
            int columns = 2; 
            int rows = 1;
            int frameRate = 30; // No animation

            // Create the enemy sprite without shooting capability
            ISprite enemySprite = new EnemySprite(
                _enemySpritesheet,
                _initialPosition,
                sourceRectangle,
                rows,
                columns,
                frameRate,
                canShoot: false
            );

            return enemySprite;
        }

        // Add more enemy types as necessary by specifying their source rectangles and positions
        // public ISprite OtherEnemy() { ... }
    }
}
