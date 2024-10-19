using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game objects and managers
        internal LinkPlayer Player { get; private set; }  // Player object
        internal BlockManager BlockManager { get; private set; }  // Block manager
        internal ItemManager ItemManager { get; private set; }  // Item manager
        internal ProjectileManager ProjectileManager { get; private set; } //projectile manager FOR LINK'S PROJECTILES ONLY
        internal EnemyManager EnemyManager { get; private set; }
        internal EnvironmentFactory EnvironmentFactory { get; private set; }

        // Collision Logic
        internal CollisionHandlerManager CollisionHandlerManager;
        internal CollisionDetector CollisionDetector;
        internal List<ICollisionBox> collisionBoxes;
        Texture2D whiteRectangle;
        private List<BlockCollisionBox> _blockCollisionBoxes;

        // Input controller
        private IController keyboardController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 700;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize the game objects and input system
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);

            // Initialize all managers
            BlockManager = new BlockManager(Content, _spriteBatch);
            ItemManager = new ItemManager(Content, _spriteBatch);
            EnemyManager = new EnemyManager(Content, _spriteBatch);
            ProjectileManager = new ProjectileManager(Content, _spriteBatch);
            Player = new LinkPlayer(_spriteBatch, Content, ProjectileManager);

            EnvironmentFactory = new EnvironmentFactory(BlockManager, ItemManager, EnemyManager);

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput

            // Initialize collision logic
            CollisionDetector = new CollisionDetector();
            _blockCollisionBoxes = BlockCollisionBox.GetDefaultBlocks(); // Load default block collision boxes
            CollisionHandlerManager = new CollisionHandlerManager(Player, EnemyManager, ItemManager);

            // Add collision objects to the collisionBoxes list
            collisionBoxes = new List<ICollisionBox>();
            collisionBoxes.Add(Player.getCollisionBox());
            collisionBoxes.AddRange(_blockCollisionBoxes); // Add all block collision boxes
            

            // Block and Item Texture Loading
            BlockManager.LoadAllTextures();
            ItemManager.LoadAllTextures();
            EnemyManager.LoadAllTextures();

            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });

            EnvironmentFactory.loadLevel();
        }

        protected override void Update(GameTime gameTime)
        {
            Player.Update();
            ItemManager.Update();
            EnemyManager.Update();
            ProjectileManager.Update();
            // Update input controls
            keyboardController.Update();

            // Detect and handle collisions
            List<CollisionData> collisions = CollisionDetector.DetectCollisions(collisionBoxes);
            CollisionHandlerManager.HandleCollisions(collisions);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            BlockManager.Draw();
            ItemManager.Draw();
            EnemyManager.Draw();
            ProjectileManager.Draw();
            Player.Draw();

            _spriteBatch.Begin();
            // Draw block collision boxes for testing purposes
            foreach (var block in _blockCollisionBoxes)
            {
                _spriteBatch.Draw(whiteRectangle, block.Bounds, Color.White);
            }
            _spriteBatch.Draw(whiteRectangle, collisionBoxes[2].Bounds, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            Initialize();
        }
    }
}