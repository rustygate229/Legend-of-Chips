﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class LinkManager
    {
        // create link names for finding them
        public enum LinkSprite { Standing, Moving, Throwing, Won }
        public enum LinkActions { SwordAttack, SwordThrow, None }

        private LinkSprite _currentLinkSprite;
        public LinkSprite CurrentLinkSprite { get { return _currentLinkSprite; } set { _currentLinkSprite = value; } }
        private LinkActions _currentLinkAction;
        public LinkActions CurrentLinkAction { get { return _currentLinkAction; } set { _currentLinkAction = value; } }
        private int _linkThrowingDecrement = 5;

        // link dictionary/inventory
        private ISprite CurrentLink;
        private DamageHelper _damageHelper = new();
        private LinkInventory _inventory = new();

        // create variables for passing
        private LinkSpriteFactory _factory = LinkSpriteFactory.Instance;
        private ProjectileManager _manager;
        private SpriteBatch _spriteBatch;
        private PlaySoundEffect _soundEffect;

        // Links global variables
        private ICollisionBox _collisionBox;
        public ICollisionBox LinkCollisionBox { get { return _collisionBox; } set { _collisionBox = value; } }

        private Renderer.DIRECTION _direction;
        public Renderer.DIRECTION LinkDirection { get { return _direction; } set { _direction = value; } }

        public Vector2 LinkPositionOnWindow { get { return CurrentLink.PositionOnWindow; } set { CurrentLink.PositionOnWindow = value; } }
        public Rectangle LinkDestinationRectangle { get { return CurrentLink.DestinationRectangle; } set { CurrentLink.DestinationRectangle = value; } }

        private float _printScale = 4f;


        // constructor
        public LinkManager() { }

        // Load all link textures
        public void LoadAll(SpriteBatch spriteBatch, ContentManager content, PlaySoundEffect sounds, ProjectileManager manager) {
            // initialize inventory
            _inventory = new();
            _spriteBatch = spriteBatch;
            _manager = manager;
            _soundEffect = sounds;
            _factory.LoadAllTextures(content);

            // all initial stuff
            
            CurrentLinkSprite = LinkSprite.Standing;
            CurrentLinkAction = LinkActions.None;
            LinkDirection = Renderer.DIRECTION.RIGHT;
            IsLinkDamaged = false;

            CurrentLink = _factory.CreateLink(CurrentLinkSprite, _inventory.LinkShield, _direction, _printScale, _manager);
            LinkPositionOnWindow = new(128, 196 + (128 + (64 * 3)));
            CollisionBox = new LinkCollisionBox(CurrentLink);
            SetCollision(CollisionBox);
            // IMPORTANT: look at this methods comment for health transfering
            SetHealthDamage(CollisionBox, _maxHealth);
        }

        public void ReplaceLinkSprite(LinkSprite name) {
            CurrentLinkSprite = name;
            Vector2 oldPosition = CurrentLink.PositionOnWindow;
            CurrentLink = _factory.CreateLink(name, _inventory.LinkShield, _direction, _printScale, _manager);
            CurrentLink.PositionOnWindow = oldPosition;
            CollisionBox.Bounds = CurrentLink.DestinationRectangle;
        }

        public LinkInventory GetLinkInventory() { return _inventory; }

        /// <summary>
        /// Updates the current link
        /// </summary>
        public void Update()
        {
            CurrentLink.Update();
            CollisionBox.Bounds = CurrentLink.DestinationRectangle;

            if (IsLinkDamaged)
            {
                _damageHelper.CurrentSprite = CurrentLink;
                _damageHelper.UpdateDamagedState();
                // Console.WriteLine("Current Link Health: " + CollisionBox.Health);
            }

            if (CurrentLinkSprite is LinkSprite.Moving)
            {
                float positionSpeed = 3F;
                switch (LinkDirection)
                {
                    case Renderer.DIRECTION.DOWN:   _manager.SetNewSwordPosition(new Vector2(0, Math.Abs(positionSpeed))); break;
                    case Renderer.DIRECTION.UP: _manager.SetNewSwordPosition(new Vector2(0, -(Math.Abs(positionSpeed)))); break;
                    case Renderer.DIRECTION.RIGHT: _manager.SetNewSwordPosition(new Vector2(Math.Abs(positionSpeed), 0)); break;
                    case Renderer.DIRECTION.LEFT: _manager.SetNewSwordPosition(new Vector2(-(Math.Abs(positionSpeed)), 0)); break;
                    default: throw new ArgumentException("Invalid direction type for updatePosition");
                }
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
