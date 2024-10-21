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
        internal LinkPlayer Player { get; private set; }  // Player object
        internal BlockManager BlockManager { get; private set; }  // Block manager
        internal ItemManager ItemManager { get; private set; }  // Item manager
        internal ProjectileManager ProjectileManager { get; private set; } //projectile manager FOR LINK'S PROJECTILES ONLY
        internal EnemyManager EnemyManager { get; private set; }
        internal EnvironmentFactory EnvironmentFactory { get; private set; }

        public static BulletManager bulletManager = new BulletManager();

        private List<ICollisionBox> _EnemyCollisionBoxes;



        internal CollisionHandlerManager CollisionHandlerManager;
        internal CollisionDetector CollisionDetector;
        internal List<ICollisionBox> collisionBoxes;
        Texture2D whiteRectangle;
        private List<ICollisionBox> _blockCollisionBoxes;
        private List<ItemCollisionBox> _itemCollisionBoxes;

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
            bulletManager.init(Content, _spriteBatch);
            Player = new LinkPlayer(_spriteBatch, Content, ProjectileManager);

            EnvironmentFactory = new EnvironmentFactory(BlockManager, ItemManager, EnemyManager);



            // Pass the bounds of whiteRectangle to the bulletManager
            bulletManager.init(Content, _spriteBatch, new Rectangle(400, 200, 64, 64)); // Example dimensions


            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput

            // Initialize collision logic
            CollisionDetector = new CollisionDetector();
            _blockCollisionBoxes = new List<ICollisionBox>();

            // Block and Item Texture Loading
            BlockManager.LoadAllTextures();
            ItemManager.LoadAllTextures();
            EnemyManager.LoadAllTextures();

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
            collisionBoxes = new List<ICollisionBox>
            {
                Player.getCollisionBox()
            };
            _EnemyCollisionBoxes = EnemyManager.collisionBoxes;

            collisionBoxes.AddRange(_blockCollisionBoxes); // Add all block collision boxes
            collisionBoxes.AddRange(_itemCollisionBoxes); // Add all item collision boxes
            collisionBoxes.AddRange(_EnemyCollisionBoxes);
        }

        protected override void Update(GameTime gameTime)
        {
            Player.Update();
            ItemManager.Update();
            EnemyManager.Update();
            ProjectileManager.Update();
            bulletManager.Update();
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
            bulletManager.Draw();
            ProjectileManager.Draw();
            Player.Draw();

            _spriteBatch.Begin();
            // Draw item collision boxes for testing purposes
            foreach (var item in _itemCollisionBoxes)
            {
                _spriteBatch.Draw(whiteRectangle, item.Bounds, Color.Yellow);
            }
            foreach (var enemy in _EnemyCollisionBoxes)
            {
                _spriteBatch.Draw(whiteRectangle, enemy.Bounds, Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }



        public void ResetGame()
        {
            Initialize();
        }
    }
}