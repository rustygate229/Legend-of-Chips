using Microsoft.Xna.Framework;
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
        internal LinkManager LinkManager = new();
        internal BlockManager BlockManager = new();
        internal ItemManager ItemManager = new();
        internal EnemyManager EnemyManager = new();
        internal ProjectileManager ProjectileManager = new();
        internal CharacterStateManager CharacterStateManager = new();
        internal EnvironmentFactory EnvironmentFactory = new();
        internal BackgroundMusic BackgroundMusic = new();
        internal Menu Menu = new();

        //private List<ICollisionBox> _EnemyCollisionBoxes;


        Texture2D whiteRectangle;
        //private List<ICollisionBox> _blockCollisionBoxes;
        //private List<ICollisionBox> _itemCollisionBoxes;

        // Input controller
        internal IController keyboardController;
        internal IController mouseController;
        

        public Game1()
        {
            _graphics = new(this)
            {
                PreferredBackBufferWidth = 256 * 4,
                PreferredBackBufferHeight = 900  // (1024, 900)
            };
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

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput
            mouseController = new MouseInput(this);

            // Loading all Managers
            BlockManager.LoadAll(_spriteBatch, Content);
            ItemManager.LoadAll(_spriteBatch, Content);
            ProjectileManager.LoadAll(_spriteBatch, Content);
            EnemyManager.LoadAll(_spriteBatch, Content, ProjectileManager);
            LinkManager.LoadAll(_spriteBatch, Content, ProjectileManager);
            BackgroundMusic.LoadAll(Content);
            BackgroundMusic.LoadSongs();
            CharacterStateManager.LoadAll(this, 6);
            Menu.LoadAll(_spriteBatch, Content, CharacterStateManager, ItemManager);

            EnvironmentFactory.LoadAll(LinkManager, EnemyManager, BlockManager, ItemManager, ProjectileManager);
            EnvironmentFactory.loadLevel();

            Menu.addWeaponToA(ItemManager.ItemNames.LongSword);
            Menu.addWeaponToB(ItemManager.ItemNames.Bomb);
        }

        protected override void Update(GameTime gameTime)
        {
            CharacterStateManager.UpdateCooldown(gameTime);

            BlockManager.Update();
            ItemManager.Update();
            ProjectileManager.Update();
            EnemyManager.Update(); 
            LinkManager.Update();
            EnvironmentFactory.Update();

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
            EnemyManager.Draw();
            LinkManager.Draw();
            Menu.Draw();

            // DrawCollidables();

            base.Draw(gameTime);
        }

        public void DrawCollidables()
        {
            List<List<ICollisionBox>> collidables = EnvironmentFactory._collisionBoxes;
            _spriteBatch.Begin();
            Color color = Color.White;

            for (int i = 0; i < collidables.Count; i++)
            {
                //if (i == 1) continue;
                List<ICollisionBox> collisionBoxes = collidables[i];
                foreach (ICollisionBox collisionBox in collisionBoxes)
                {
                    if (i == 0) color = Color.White;
                    if (i == 1) color = Color.Red;
                    if (i == 2) color = Color.Green;
                    if (i == 3) color = Color.Blue;
                    _spriteBatch.Draw(whiteRectangle, collisionBox.Bounds, color);
                }

            }
            _spriteBatch.End();
        }


        public void ResetGame() { Initialize(); }
    }
}