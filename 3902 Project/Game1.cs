using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ISprite stationaryLink;
        private ISprite walkingLink;
        private ISprite itemLink;
        private ISprite attackingLink;
        private LinkStateMachine _stateMachine;


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

            stationaryLink = LinkSpriteFactory.Instance.StationaryLinkSprite();
            walkingLink = LinkSpriteFactory.Instance.CreateWalkingLinkSprite();

            itemLink = LinkSpriteFactory.Instance.CreateItemUseLinkSprite();
            attackingLink = LinkSpriteFactory.Instance.CreateAttackingLinkSprite();

            //default left
            _stateMachine = new LinkStateMachine();
            _stateMachine.changeStateMovingRight();




            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            stationaryLink.Update();
            base.Update(gameTime);

            stationaryLink.Update();
            walkingLink.Update();
            itemLink.Update();
            attackingLink.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            stationaryLink.Draw(_spriteBatch, _stateMachine, 200, 150);
            walkingLink.Draw(_spriteBatch, _stateMachine, 300, 150);
            itemLink.Draw(_spriteBatch, _stateMachine, 400, 150);
            attackingLink.Draw(_spriteBatch, _stateMachine, 450, 150);


            base.Draw(gameTime);
        }
    }
}
