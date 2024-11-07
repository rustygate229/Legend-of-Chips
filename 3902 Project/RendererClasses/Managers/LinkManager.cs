﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class LinkManager
    {
        // create link names for finding them
        public enum LinkActions { StandardStanding, StandardMoving }
        private LinkActions _currentLinkAction;

        // link dictionary/inventory
        private ISprite _currentLink;

        // create variables for passing
        private LinkSpriteFactory _factory = LinkSpriteFactory.Instance;
        private ProjectileManager _manager;
        private SpriteBatch _spriteBatch;

        // Links global variables
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
            _currentLinkAction = LinkActions.StandardStanding;
            _direction = Renderer.DIRECTION.UP;
            _currentLink = _factory.CreateLink(_currentLinkAction, _direction, _printScale, _manager);
        }


        public void SetLinkState(LinkActions currentAction) { _currentLinkAction = currentAction; ReplaceLink(currentAction); }

        public void SetLinkDirection(Renderer.DIRECTION direction) { _direction = direction;}

        public void SetLinkPosition(Vector2 position) { _position = position; _currentLink.SetPosition(position); }

        public void ReplaceLink(LinkActions name) { _currentLinkAction = name; _currentLink = _factory.CreateLink(name, _direction, _printScale, _manager); }

        public Vector2 GetLinkPosition() { return _position; }

        /// <summary>
        /// Updates the current link
        /// </summary>
        public void Update()
        {
            _currentLink.Update();
        }


        /// <summary>
        /// Draw the current link
        /// </summary>
        public void Draw()
        {
            _currentLink.Draw(_spriteBatch);
        }

    }
}
