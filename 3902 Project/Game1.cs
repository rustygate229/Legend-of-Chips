using _3902_Project.Link;
using Content.Projectiles;
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



        internal CollisionHandlerManager CollisionHandlerManager;
        internal CollisionDetector CollisionDetector;
        internal List<ICollisionBox> collisionBoxes;
        Texture2D whiteRectangle;


        // Input controller
        private IController keyboardController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            BulletSpriteFactory.Instance.LoadAllTextures(Content);


            // Initialize the block and item manager
            BlockManager = new BlockManager(Content, _spriteBatch);
            ItemManager = new ItemManager(Content, _spriteBatch);
            ProjectileManager = new ProjectileManager(Content, _spriteBatch);

            // Initialize the player and character state
            Player = new LinkPlayer(_spriteBatch, Content, ProjectileManager);
            EnemyManager = new EnemyManager(Content, _spriteBatch);

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput


            CollisionHandlerManager = new CollisionHandlerManager(Player, EnemyManager, ItemManager);
            CollisionDetector = new CollisionDetector();

            collisionBoxes = new List<ICollisionBox>();
            collisionBoxes.Add(Player.getCollisionBox());
            collisionBoxes.Add(new BlockCollisionBox(new Rectangle(400, 200, 64, 64), true));
            collisionBoxes.Add(new EnemyCollisionBox(new Rectangle(300, 100, 32, 32), true, 100, 10));


            // TODO: use this.Content to load your game content here
            // Block and Item Texture Loading
            BlockManager.LoadAllTextures();
            ItemManager.LoadAllTextures();
            EnemyManager.LoadAllTextures();



            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });

        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            Player.Update();
            ItemManager.Update();
            EnemyManager.Update();


            ProjectileManager.Update();

            // Update input controls
            keyboardController.Update();

            List<CollisionData> collisions = CollisionDetector.DetectCollisions(collisionBoxes);
            CollisionHandlerManager.HandleCollisions(collisions);

            // TODO: Add your update logic here (e.g., update player, blocks, etc.)
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Player.Draw();
            BlockManager.Draw();
            ItemManager.Draw();
            EnemyManager.Draw();
            ProjectileManager.Draw();

            _spriteBatch.Begin();
            _spriteBatch.Draw(whiteRectangle, collisionBoxes[1].Bounds, Color.White);
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
