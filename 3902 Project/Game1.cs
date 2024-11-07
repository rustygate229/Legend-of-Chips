using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game objects and managers
        internal LinkManager _Link { get; private set; }  // Player object
        internal BlockManager _BlockManager { get; private set; }  // Block manager
        internal ItemManager _ItemManager { get; private set; }  // Item manager
        internal EnemyManager _EnemyManager { get; private set; }
        public ProjectileManager _ProjectileManager { get;  set; }
        internal EnvironmentFactory _EnvironmentFactory { get; private set; }

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

            // Initialize collision logic
            CollisionDetector = new CollisionDetector();
            _blockCollisionBoxes = new List<ICollisionBox>();

            // Block and Item Texture Loading
            _BlockManager = new BlockManager();
            _BlockManager.LoadAll(_spriteBatch, Content);

            _ItemManager = new ItemManager();
            _ItemManager.LoadAll(_spriteBatch, Content);

            _ProjectileManager = new ProjectileManager();
            _ProjectileManager.LoadAll(_spriteBatch, Content);

            _EnemyManager = new EnemyManager();
            _EnemyManager.LoadAll(_spriteBatch, Content, _ProjectileManager);

            _Link = new LinkManager();
            _Link.LoadAll(_spriteBatch, Content, _ProjectileManager);

            _EnvironmentFactory = new EnvironmentFactory(this, _blockCollisionBoxes);

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput
            mouseController = new MouseInput(this);

            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });

            _EnvironmentFactory.loadLevel();

            Dictionary<BlockManager.BlockNames, List<ICollisionBox>> BlockCollisionDict = _EnvironmentFactory.getCollidables(); // Load collision boxes from ENVIRONMENT
            List<ICollisionBox> CollisionList = new List<ICollisionBox>();
            if (BlockCollisionDict.TryGetValue(BlockManager.BlockNames.Square, out CollisionList))
            {
                _blockCollisionBoxes.AddRange(CollisionList);
            }
       
            CollisionHandlerManager = new CollisionHandlerManager(this, _blockCollisionBoxes);

            // Add collision objects to the collisionBoxes list
            _EnemyCollisionBoxes = _EnemyManager.collisionBoxes;

            collisionBoxes.AddRange(_blockCollisionBoxes); // Add all block collision boxes
            //collisionBoxes.AddRange(_itemCollisionBoxes); // Add all item collision boxes
            collisionBoxes.AddRange(_EnemyCollisionBoxes);
        }

        protected override void Update(GameTime gameTime)
        {
            _ItemManager.Update();
            _ProjectileManager.Update();
            _EnemyManager.Update();
            _Link.Update();
            _EnvironmentFactory.Update(_Link);
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

            _BlockManager.Draw();
            _ItemManager.Draw();
            _ProjectileManager.Draw();
            _Link.Draw();
            _EnemyManager.Draw();

            base.Draw(gameTime);
        }

        public void ResetGame() { Initialize(); }
    }
}