using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game objects and managers
        internal LinkPlayer Player { get; private set; }
        internal BlockManager BlockManager { get; private set; }
        internal ItemManager ItemManager { get; private set; }
        internal EnemyManager EnemyManager { get; private set; }
        public ProjectileManager ProjectileManager { get; set; }
        internal EnvironmentFactory EnvironmentFactory { get; private set; }

        private List<ICollisionBox> _EnemyCollisionBoxes;
        internal CollisionHandlerManager CollisionHandlerManager;
        internal CollisionDetector CollisionDetector;
        public List<ICollisionBox> collisionBoxes;
        private List<ICollisionBox> _blockCollisionBoxes;
        private List<ICollisionBox> _itemCollisionBoxes;

        // Input controllers
        private IController keyboardController;
        private IController mouseController;

        // **Added ProjectileCollisionManager**
        private ProjectileCollisionManager _projectileCollisionManager;

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

            collisionBoxes = new List<ICollisionBox>();
            EnemySpriteFactory.Instance.LoadAllTextures(Content);

            // Initialize all managers
            BlockManager = new BlockManager(Content, _spriteBatch);
            ItemManager = new ItemManager(Content, _spriteBatch);
            ProjectileManager = new ProjectileManager(Content, _spriteBatch);
            EnemyManager = new EnemyManager(this, _spriteBatch, ProjectileManager);
            Player = new LinkPlayer(_spriteBatch, Content, ProjectileManager);

            // **Initialize ProjectileCollisionManager**
            _projectileCollisionManager = new ProjectileCollisionManager(EnemyManager);

            EnvironmentFactory = new EnvironmentFactory(BlockManager, ItemManager, Player, EnemyManager, _blockCollisionBoxes);

            // Initialize input controllers
            keyboardController = new KeyboardInput(this);
            mouseController = new MouseInput(this);

            // Initialize collision logic
            CollisionDetector = new CollisionDetector();
            _blockCollisionBoxes = new List<ICollisionBox>();

            // Load all textures
            BlockManager.LoadAllTextures();
            ItemManager.LoadAllTextures();
            EnemyManager.LoadAllTextures();
            ProjectileManager.LoadAllTextures(Content);

            EnvironmentFactory.loadLevel();

            // Load collision boxes from environment
            Dictionary<BlockManager.BlockNames, List<ICollisionBox>> BlockCollisionDict = EnvironmentFactory.getCollidables();
            if (BlockCollisionDict.TryGetValue(BlockManager.BlockNames.Square, out List<ICollisionBox> collisionList))
            {
                _blockCollisionBoxes.AddRange(collisionList);
            }

            // **Update CollisionHandlerManager instantiation**
            CollisionHandlerManager = new CollisionHandlerManager(
                Player,
                EnemyManager,
                ItemManager,
                _blockCollisionBoxes,
                _projectileCollisionManager);

            // Add collision objects to the collisionBoxes list
            _EnemyCollisionBoxes = EnemyManager.collisionBoxes;

            collisionBoxes.AddRange(_blockCollisionBoxes);
            collisionBoxes.AddRange(_EnemyCollisionBoxes);
            collisionBoxes.AddRange(_projectileCollisionManager.GetCollisionBoxes());
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

            // **Update projectile collisions**
            _projectileCollisionManager.UpdateCollisions(collisionBoxes);

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
            ProjectileManager.Draw();
            Player.Draw();
            EnemyManager.Draw();

            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            Initialize();
        }
    }
}
