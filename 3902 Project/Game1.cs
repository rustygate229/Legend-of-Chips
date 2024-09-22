using _3902_Project.Content.command.receiver;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace _3902_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game objects and managers
        internal Player Player { get; private set; }  // Player object
        internal BlockManager BlockManager { get; private set; }  // Block manager
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

            // Initialize the player and character state
            Player = new Player();
            CharacterState = new CharacterState();

            // Initialize the block manager
            BlockManager = new BlockManager(Content, _spriteBatch);

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput
            // TODO: use this.Content to load your game content here
            BlockManager.LoadAllTextures();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))

                this.Exit();



            // Update input controls
            keyboardController.Update();

            // TODO: Add your update logic here (e.g., update player, blocks, etc.)

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CadetBlue);

            BlockManager.Draw();

            base.Draw(gameTime);


        }

        // Exiting the game logic
        internal void ExitGame()
        {

            Environment.Exit(0);
        }
    }
}
