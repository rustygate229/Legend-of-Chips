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
        internal MiscManager MiscManager = new();
        internal EnvironmentFactory EnvironmentFactory = new();
        internal BackgroundMusic BackgroundMusic = new();
        internal PlaySoundEffect MySoundEffect = new();
        internal HUD HUD = new();
        internal CollisionManager CollisionManager = new();

        //private List<ICollisionBox> _EnemyCollisionBoxes;


        Texture2D _outline;
        private bool _pauseState = false;
        public bool PauseState { get { return _pauseState; } set { _pauseState = value; } }
        private int _pauseCounter = 0;
        public int PauseCounter { get { return _pauseCounter; } set { _pauseCounter = value; } }
        private bool _startState = true;
        public bool StartState { get { return _startState; } set { _startState = value; } }
        private bool _userPressedEnter;
        public bool UserPressedEnter { get { return _userPressedEnter; } set { _userPressedEnter = value; } }
        private bool _drawCollidables = false;
        public bool DoDrawCollisions
        {
            get { return _drawCollidables; }
            set { _drawCollidables = value; }
        }
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
            base.Initialize();// Game objects and managers
            LinkManager = new();
            BlockManager = new();
            ItemManager = new();
            EnemyManager = new();
            ProjectileManager = new();
            MiscManager = new();
            EnvironmentFactory = new();
            BackgroundMusic = new();
            MySoundEffect = new();
            HUD = new();
            CollisionManager = new();
            LoadContent();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput
            mouseController = new MouseInput(this);

            // Loading all Managers
            MySoundEffect.LoadAll(Content);
            BlockManager.LoadAll(_spriteBatch, Content);
            ItemManager.LoadAll(_spriteBatch, Content);
            ProjectileManager.LoadAll(_spriteBatch, Content);
            EnemyManager.LoadAll(_spriteBatch, Content, ProjectileManager);
            LinkManager.LoadAll(_spriteBatch, Content, MySoundEffect, ProjectileManager);
            MiscManager.LoadAll(_spriteBatch, Content);
            BackgroundMusic.LoadAll(Content);
            HUD.LoadAll(LinkManager, ItemManager, MiscManager);
            MiscManager.StartTransition(MiscManager.Transition_Names.Black_FadeOutTotal);
            MiscManager.StartMenu(MiscManager.StartMenu_Names.StartScreen);

            // for the showing of collisions
            _outline = Content.Load<Texture2D>("SpriteSheets\\Block&Room(Dungeon)_Transparent");

            EnvironmentFactory.LoadAll(LinkManager, EnemyManager, BlockManager, ItemManager, ProjectileManager, MySoundEffect, HUD);
            EnvironmentFactory.loadLevel();

            CollisionManager.LoadAll(LinkManager, EnemyManager, BlockManager, ItemManager, ProjectileManager, MySoundEffect, EnvironmentFactory);
        }

        protected override void Update(GameTime gameTime)
        {
            if (_startState)
            {
                Debug.Write("value of UserPressedEnter: " + UserPressedEnter + " \n");

                if (PauseCounter == 0 && UserPressedEnter)
                {
                    MiscManager.StartMenu(MiscManager.StartMenu_Names.StoryScreen);
                    UserPressedEnter = false;
                    PauseCounter++;
                }
                if (PauseCounter <= 10 && PauseCounter > 0 && UserPressedEnter)
                {
                    //PauseCounter is between 0 and 5 and UserPressedEnter is true (catching potential errors)
                    UserPressedEnter = false;

                }

                if (PauseCounter >= 1)
                {
                    PauseCounter++;
                    if (PauseCounter >= (900 * 7.35) / 3.5 || (UserPressedEnter && PauseCounter >= 30))
                    {
                        _startState = false;
                        MiscManager.UnloadStartMenu();
                        PauseCounter = 1;
                        UserPressedEnter = false;
                    }
                }
            }

            else if (!PauseState && PauseCounter == 0)
            {
                BlockManager.Update();
                ItemManager.Update();
                ProjectileManager.Update();
                EnemyManager.Update();
                LinkManager.Update();
                EnvironmentFactory.Update();
                MiscManager.Update();
                CollisionManager.Update();

                if (LinkManager.CollisionBox.Health <= 0)
                    ResetGame();
            }

            // Update input controls
            keyboardController.Update();
            mouseController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (_startState)
                MiscManager.UpdateAndDrawStartScreen(_spriteBatch);
            else
            {
                BlockManager.Draw();
                ItemManager.Draw();
                ProjectileManager.Draw();
                EnemyManager.Draw();
                LinkManager.Draw();
                HUD.Draw();
                MiscManager.Draw();

                // draw the collisions if the enters "C"
                if (DoDrawCollisions)
                    DrawCollisions();

                if (PauseState)
                    MiscManager.UpdateAndDrawTransition(_spriteBatch);

                if (!PauseState && PauseCounter != 0)
                {
                    MiscManager.UpdateAndDrawTransition(_spriteBatch);
                    PauseCounter++;
                    // sadly. must hard code the same value present in sprite class
                    if (PauseCounter >= 530 / 10)
                        PauseCounter = 0;
                }
            }

            base.Draw(gameTime);
        }

        public void DrawCollisions()
        {
            List<List<ICollisionBox>> collisions = EnvironmentFactory._collisionBoxes;
            Color color = Color.White;
            int lineWidth = 3;

            _spriteBatch.Begin();
            for (int i = 0; i < collisions.Count; i++)
            {
                //if (i == 1) continue;
                List<ICollisionBox> collisionBoxes = collisions[i];
                foreach (ICollisionBox collisionBox in collisionBoxes)
                {
                    Rectangle bounds = collisionBox.Bounds;
                    if (collisionBox.IsCollidable)
                    {
                        if (i == 0) color = Color.White;
                        if (i == 1) color = Color.Red;
                        if (i == 2) color = Color.Green;
                        if (i == 3) color = Color.Blue;
                        if (i == 4) color = Color.Yellow;
                        lineWidth = 3;
                    }
                    else
                        lineWidth = 0;

                    Rectangle outlineTop = new(bounds.X, bounds.Y, bounds.Width, lineWidth);
                    Rectangle outlineLeft = new(bounds.X, bounds.Y, lineWidth, bounds.Height);
                    Rectangle outlineBottom = new(bounds.X, bounds.Y + (bounds.Height - lineWidth), bounds.Width, lineWidth);
                    Rectangle outlineRight = new(bounds.X + (bounds.Width - lineWidth), bounds.Y, lineWidth, bounds.Height);
                    Rectangle rectangleSource = new(235, 1213, 8, 8);
                    _spriteBatch.Draw(_outline, outlineTop, rectangleSource, color);
                    _spriteBatch.Draw(_outline, outlineBottom, rectangleSource, color);
                    _spriteBatch.Draw(_outline, outlineRight, rectangleSource, color);
                    _spriteBatch.Draw(_outline, outlineLeft, rectangleSource, color);
                }
            }
            _spriteBatch.End();
        }


        public void ResetGame()
        {
            // need to have a sequence play out first, but that will need a transition
            MySoundEffect.PlaySound(PlaySoundEffect.Sounds.Enemy_Death);
            _startState = false;
            PauseCounter = 1;
            Initialize();
        }
    }
}