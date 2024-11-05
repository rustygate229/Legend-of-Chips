using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

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
        internal EnemyManager EnemyManager { get; private set; }
        public ProjectileManager ProjectileManager { get;  set; }
        internal EnvironmentFactory EnvironmentFactory { get; private set; }
        internal BackgroundMusic BackgroundMusic { get; set; }
        internal Menu Menu { get; set; }

        //private List<ICollisionBox> _EnemyCollisionBoxes;



        Texture2D whiteRectangle;
        //private List<ICollisionBox> _blockCollisionBoxes;
        //private List<ICollisionBox> _itemCollisionBoxes;

        // Input controller
        private IController keyboardController;
        private IController mouseController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 900;
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

            // Initialize all managers
            BackgroundMusic = new BackgroundMusic(Content);
            BlockManager = new BlockManager(Content, _spriteBatch);
            ItemManager = new ItemManager(Content, _spriteBatch);
            ProjectileManager = new ProjectileManager(Content, _spriteBatch);
            EnemyManager = new EnemyManager(this, _spriteBatch, ProjectileManager);
            Player = new LinkPlayer(_spriteBatch, Content, ProjectileManager);
            Menu = new Menu(Content, _spriteBatch, ItemManager);

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput
            mouseController = new MouseInput(this);

            // Block and Item Texture Loading
            BlockManager.LoadAllTextures();
            ItemManager.LoadAllTextures();
            EnemyManager.LoadAllTextures();
            ProjectileManager.LoadAllTextures(Content);
            BackgroundMusic.LoadSongs();
            Menu.LoadContent();

            EnvironmentFactory = new EnvironmentFactory(BlockManager, ItemManager, Player, EnemyManager);

            EnvironmentFactory.loadLevel();

        }

        protected override void Update(GameTime gameTime)
        {
            ItemManager.Update();
            ProjectileManager.Update();
            EnemyManager.Update();
            Player.Update();
            EnvironmentFactory.Update(Player);
            // Update input controls
            keyboardController.Update();
            mouseController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            BlockManager.Draw();
            ItemManager.Draw();
            ProjectileManager.Draw();
            Player.Draw();
            EnemyManager.Draw();
            Menu.Draw();

            //DrawCollidables();


            base.Draw(gameTime);
        }
        public void ResetGame() { Initialize(); }
    }
}