using _3902_Project.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private LinkPlayer player;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);

            player = new LinkPlayer(_spriteBatch, Content);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboardState = Keyboard.GetState();

            player.Update();

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                player.Attack();
            }
            else if (keyboardState.IsKeyDown(Keys.X))
            {
                player.Throw();
            }
            else
            {
                player.StopAttack();
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                player.MoveLeft();
            }

            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                player.MoveRight();
            }

            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                player.MoveUp();
            }

            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                player.MoveDown();
            }

            else
            {
                player.StayStill();
            }

            
            
            // TODO: Add your update logic here
            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            player.Draw();

            base.Draw(gameTime);
        }
    }
}
