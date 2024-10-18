using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        // Input controller
        private IController keyboardController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 960;
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


            // initialize all managers
            BlockManager = new BlockManager(Content, _spriteBatch);
            ItemManager = new ItemManager(Content, _spriteBatch);
            EnemyManager = new EnemyManager(Content, _spriteBatch);
            ProjectileManager = new ProjectileManager(Content, _spriteBatch);
            Player = new LinkPlayer(_spriteBatch, Content, ProjectileManager);

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput

            // load all textures
            BlockManager.LoadAllTextures();
            ItemManager.LoadAllTextures();
            EnemyManager.LoadAllTextures();

            BlockManager.PlaceBlock(BlockManager.BlockNames.Environment, new Vector2(0, 0));
            BlockManager.PlaceBlock(BlockManager.BlockNames.Stairs_RIGHT, new Vector2(100, 100));
            BlockManager.PlaceBlock(BlockManager.BlockNames.Stairs_RIGHT, new Vector2(100, 200));
            EnemyManager.PlaceEnemy(EnemyManager.EnemyNames.GreenSlime, new Vector2(800, 480));
            EnemyManager.PlaceEnemy(EnemyManager.EnemyNames.BrownSlime, new Vector2(800, 480));
            EnemyManager.PlaceEnemy(EnemyManager.EnemyNames.Proto, new Vector2(800, 480));
            EnemyManager.PlaceEnemy(EnemyManager.EnemyNames.Wizzrope, new Vector2(800, 480));
            EnemyManager.PlaceEnemy(EnemyManager.EnemyNames.Darknut, new Vector2(800, 480));
            EnemyManager.PlaceEnemy(EnemyManager.EnemyNames.Darknut, new Vector2(800, 480));
            EnemyManager.PlaceEnemy(EnemyManager.EnemyNames.Darknut, new Vector2(800, 480));
        }

        protected override void Update(GameTime gameTime)
        {
            Player.Update();
            ItemManager.Update();
            EnemyManager.Update();
            ProjectileManager.Update();

            // Update input controls
            keyboardController.Update();

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

            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            Initialize();
        }
    }
}
