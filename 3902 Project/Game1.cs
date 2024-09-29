using _3902_Project.Content.command.receiver;
using _3902_Project.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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
        internal EnemyManager EnemyManager { get; private set; }  // Enemy manager
        internal CharacterState CharacterState { get; private set; }  // Character state

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
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BulletSpriteFactory.Instance.LoadAllTextures(Content);

            // Initialize the player and character state
            Player = new LinkPlayer(_spriteBatch, Content);
            CharacterState = new CharacterState();

            // Initialize the block and item manager
            BlockManager = new BlockManager(Content, _spriteBatch);
            ItemManager = new ItemManager(Content, _spriteBatch);
            EnemyManager = new EnemyManager(Content, _spriteBatch);

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput

            // TODO: use this.Content to load your game content here
            // Block and Item Texture Loading
            BlockManager.LoadAllTextures();
            ItemManager.LoadAllTextures();
            EnemyManager.LoadAllTextures();
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            Player.Update();
            ItemManager.Update();
            EnemyManager.Update();


            // Update input controls
            keyboardController.Update();

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

            base.Draw(gameTime);
        }

        // Exiting the game logic
        internal void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
