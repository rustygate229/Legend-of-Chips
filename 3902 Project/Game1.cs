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
        internal LinkPlayer Player { get; private set; }  // Player object
        internal BlockManager BlockManager { get; private set; }  // Block manager
        internal ItemManager ItemManager { get; private set; }  // Item manager
        internal EnemyManager EnemyManager { get; private set; }
        public ProjectileManager ProjectileManager { get;  set; }
        internal EnvironmentFactory EnvironmentFactory { get; private set; }

        private List<ICollisionBox> _EnemyCollisionBoxes;



        internal CollisionHandlerManager CollisionHandlerManager;
        internal CollisionDetector CollisionDetector;
        public List<ICollisionBox> collisionBoxes;
        Texture2D whiteRectangle;
        private List<ICollisionBox> _blockCollisionBoxes;
        private List<ICollisionBox> _itemCollisionBoxes;

        // Input controller
        private IController keyboardController;
        private IController mouseController;

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
            EnvironmentFactory = new EnvironmentFactory(BlockManager, ItemManager, EnemyManager);


            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput
            mouseController = new MouseInput(this);

            // Initialize collision logic
            CollisionDetector = new CollisionDetector();
            _blockCollisionBoxes = new List<ICollisionBox>();

            // Block and Item Texture Loading
            BlockManager.LoadAllTextures();
            ItemManager.LoadAllTextures();
            EnemyManager.LoadAllTextures();
            ProjectileManager.LoadAllTextures(Content);

            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });

            EnvironmentFactory.loadLevel();


            Dictionary<BlockManager.BlockNames, List<ICollisionBox>> BlockCollisionDict = EnvironmentFactory.getCollidables(); // Load collision boxes from ENVIRONMENT
            List<ICollisionBox> CollisionList = new List<ICollisionBox>();
            if (BlockCollisionDict.TryGetValue(BlockManager.BlockNames.Square, out CollisionList))
            {
                _blockCollisionBoxes.AddRange(CollisionList);
            }

            _itemCollisionBoxes = ItemCollisionBox.GetDefaultItems(); // Load default item collision boxes for testing
            CollisionHandlerManager = new CollisionHandlerManager(Player, EnemyManager, ItemManager, _blockCollisionBoxes);

            // Add collision objects to the collisionBoxes list
            _EnemyCollisionBoxes = EnemyManager.collisionBoxes;

            collisionBoxes.AddRange(_blockCollisionBoxes); // Add all block collision boxes
            collisionBoxes.AddRange(_itemCollisionBoxes); // Add all item collision boxes
            collisionBoxes.AddRange(_EnemyCollisionBoxes);
        }

        protected override void Update(GameTime gameTime)
        {
            ItemManager.Update();
            ProjectileManager.Update();
            EnemyManager.Update();
            EnvironmentFactory.Update();
            // Update input controls
            keyboardController.Update();
            mouseController.Update();

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
            EnemyManager.Draw();

            base.Draw(gameTime);
        }


        public ContentManager GetContentManager()
        {
            return Content;
        }


        public void ResetGame() { Initialize(); }


        public ProjectileManager GetProjectileManager() { return ProjectileManager; }
    }
}