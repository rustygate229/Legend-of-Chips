using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class LinkManager
    {
        // create link names for finding them
        public enum LinkSprite { Standing, Moving, Throwing }
        public enum LinkActions { SwordAttack, SwordThrow, None }

        private LinkSprite _currentLinkSprite;
        private LinkSprite CurrentLinkSprite { get { return _currentLinkSprite; } set { _currentLinkSprite = value; } }
        private LinkActions _currentLinkAction;
        private LinkActions CurrentLinkAction { get { return _currentLinkAction; } set { _currentLinkAction = value; } };
        private int _linkThrowingDecrement = 5;

        // link dictionary/inventory
        private ISprite CurrentLink;
        private DamageHelper _damageHelper = new();
        private LinkInventory _inventory = new();

        // create variables for passing
        private LinkSpriteFactory _factory = LinkSpriteFactory.Instance;
        private ProjectileManager _manager;
        private SpriteBatch _spriteBatch;

        // Links global variables
        public ICollisionBox _collisionBox;
        public ICollisionBox LinkCollisionBox { get { return _collisionBox; } set { _collisionBox = value; } }

        private Renderer.DIRECTION _direction;
        public Renderer.DIRECTION LinkDirection { get { return _direction; } set { _direction = value; } }

        public Vector2 LinkPosition { get { return CurrentLink.GetVectorPosition() } set { CurrentLink.SetPosition(value); } }
        public Rectangle LinkPosition { get { return CurrentLink.GetRectanglePosition() } set { CurrentLink.SetPosition(value); } }

        private float _printScale = 4f;


        // constructor
        public LinkManager() { }

        // Load all link textures
        public void LoadAll(SpriteBatch spriteBatch, ContentManager content, ProjectileManager manager) {
            // initialize inventory
            _inventory = new();
            _spriteBatch = spriteBatch;
            _manager = manager;
            _factory.LoadAllTextures(content);

            // all initial stuff
            CurrentLinkSprite = LinkSprite.Standing;
            CurrentLinkAction = LinkActions.None;
            LinkDirection = Renderer.DIRECTION.DOWN;
            IsLinkDamaged = false;
            _inventory.CurrentLinkSword = LinkInventory.LinkSwordType.WOOD;

            CurrentLink = _factory.CreateLink(CurrentLinkSprite, _inventory.LinkShield, _direction, _printScale, _manager);
            CollisionBox = new LinkCollisionBox(CurrentLink);
            SetCollision(CollisionBox);
            // IMPORTANT: look at this methods comment for health transfering
            SetHealthDamage(CollisionBox, _maxHealth);
        }

        public Rectangle GetLinkRectanglePosition() { return CurrentLink.GetRectanglePosition(); }


        public void ReplaceLinkSprite(LinkSprite name) {
            CurrentLinkSprite = name;
            CurrentLink = _factory.CreateLink(name, _inventory.LinkShield, _direction, _printScale, _manager);
            CurrentLink.SetPosition(_position);
            _collisionBox.Bounds = CurrentLink.GetRectanglePosition();
        }

        /// <summary>
        /// Updates the current link
        /// </summary>
        public void Update()
        {
            CurrentLink.Update();
            _position = CurrentLink.GetVectorPosition();
            _collisionBox.Bounds = CurrentLink.GetRectanglePosition();

            if (IsLinkDamaged)
            {
                _damageHelper.Sprite = (IFlashing)CurrentLink;
                _damageHelper.Position = CurrentLink.GetVectorPosition;
                _damageHelper.UpdateDamagedState();
                SetLinkPosition(_damageHelper.Position);
            }

            if ((_swordDamageDecrementTotal >= 0) && (_swordDamageDecrementTotal < 10))
                _swordDamageDecrementTotal--;
            else if (_swordDamageDecrementTotal != 10)
                _swordDamageDecrementTotal = 10;

            if (CurrentLinkSprite == LinkSprite.Throwing)
            {
                _linkThrowingDecrement--;
                if (_linkThrowingDecrement < 0)
                {
                    _linkThrowingDecrement = 5;
                    CurrentLinkSprite = LinkSprite.Standing;
                }
            }

        }


        /// <summary>
        /// Draw the current link
        /// </summary>
        public void Draw()
        {
            if (!IsLinkDamaged)
                CurrentLink.Draw(_spriteBatch);
            else
                _damageHelper.Draw(_spriteBatch);
        }
    }
}
