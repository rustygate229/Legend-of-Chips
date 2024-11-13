using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class LinkManager
    {
        // create link names for finding them
        public enum LinkSprite { Standing, Moving, Throwing }
        public enum LinkActions { SwordAttack, SwordThrow, None }

        private LinkSprite _currentLinkSprite;
        private LinkActions _currentLinkAction;

        private bool _linkDamagedState { get; set; }
        private bool _linkColorFlip = false;
        public bool IsLinkDamaged
        {
            get { return _linkDamagedState; }
            set { _linkDamagedState = value; }
        }
        private int _linkDamagedStateCounter = 0;
        private int _linkDamagedStateCounterTotal = 50;

        // link dictionary/inventory
        private ILink _currentLink;

        // create variables for passing
        private LinkSpriteFactory _factory = LinkSpriteFactory.Instance;
        private ProjectileManager _manager;
        private SpriteBatch _spriteBatch;

        // Links global variables
        public LinkCollisionBox _collisionBox;
        private Vector2 _position;
        private Renderer.DIRECTION _direction;
        private float _printScale = 4f;


        // constructor
        public LinkManager() { }

        // Load all link textures
        public void LoadAll(SpriteBatch spriteBatch, ContentManager content, ProjectileManager manager) {
            _spriteBatch = spriteBatch;
            _factory.LoadAllTextures(content);
            _manager = manager;
            _currentLinkSprite = LinkSprite.Standing;
            _currentLinkAction = LinkActions.None;
            _direction = Renderer.DIRECTION.DOWN;
            _linkDamagedState = false;
            _currentLink = _factory.CreateLink(_currentLinkSprite, _direction, _printScale, _manager);
            _collisionBox = new LinkCollisionBox(_currentLink, true, 10);
        }


        public void SetLinkSpriteState(LinkSprite currentSprite) { _currentLinkSprite = currentSprite; ReplaceLinkSprite(currentSprite); }
        public void SetLinkActionState(LinkActions currentAction) { _currentLinkAction = currentAction; }
        public void SetLinkDirection(Renderer.DIRECTION direction) { _direction = direction; }
        public Renderer.DIRECTION GetLinkDirection() { return _direction; }
        public void SetLinkPosition(Vector2 position) { 
            _position = position; 
            _currentLink.SetPosition(position);
        }

        public void ReplaceLinkSprite(LinkSprite name) {
            _currentLinkSprite = name;
            _currentLink = _factory.CreateLink(name, _direction, _printScale, _manager);
            _currentLink.SetPosition(_position);
        }

        public Rectangle GetLinkRectanglePosition() { return _currentLink.GetRectanglePosition(); }
        public Vector2 GetLinkPosition() { return _currentLink.GetVectorPosition();  }
        public LinkActions GetLinkActions() { return _currentLinkAction; }
        public void flipDamaged() { _linkDamagedState = !_linkDamagedState; }

        /// <summary>
        /// Updates the current link
        /// </summary>
        public void Update()
        {
            _currentLink.Update();
            _position = _currentLink.GetVectorPosition();
            _collisionBox.Bounds = _currentLink.GetRectanglePosition();
            if (_linkDamagedState)
                _linkDamagedStateCounter++;
        }


        /// <summary>
        /// Draw the current link
        /// </summary>
        public void Draw()
        {
            if (!_linkDamagedState)
                _currentLink.Draw(_spriteBatch);
            else
            {
                if (_linkColorFlip)
                    _currentLink.Draw(_spriteBatch, Color.Red);
                else
                    _currentLink.Draw(_spriteBatch, Color.AntiqueWhite);
            }
        }

        public void CheckDamagedState()
        {
            if (_linkDamagedStateCounter == _linkDamagedStateCounterTotal)
                IsLinkDamaged = false;
            else
            {
                _linkColorFlip = !_linkColorFlip;
                // send link backwards for 10 frames once damaged
                if (_linkDamagedStateCounter < 10)
                {
                    float positionSpeed = 10;
                    Vector2 updatePosition = new (0, 0);
                    switch (_direction)
                    {
                        case Renderer.DIRECTION.DOWN:    updatePosition = new (0, Math.Abs(positionSpeed)); break;
                        case Renderer.DIRECTION.UP:      updatePosition = new (0, -(Math.Abs(positionSpeed))); break;
                        case Renderer.DIRECTION.RIGHT:   updatePosition = new (Math.Abs(positionSpeed), 0); break;
                        case Renderer.DIRECTION.LEFT:    updatePosition = new (-(Math.Abs(positionSpeed)), 0); break;
                        default: break;
                    }
                    SetLinkPosition(_position + updatePosition);
                }

            }
        }

    }
}
