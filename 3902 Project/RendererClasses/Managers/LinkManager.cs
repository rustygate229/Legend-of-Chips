﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using System.Diagnostics.CodeAnalysis;

namespace _3902_Project
{
    public class LinkManager
    {
        // create link names for finding them
        public enum LinkSprite { Standing, Moving, Throwing }
        public enum LinkActions { SwordAttack, SwordThrow, None }

        private LinkSprite _currentLinkSprite;
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
            _currentLinkSprite = LinkSprite.Standing;
            _currentLinkAction = LinkActions.None;
            _direction = Renderer.DIRECTION.UP;
            _currentLink = _factory.CreateLink(_currentLinkSprite, _direction, _printScale, _manager);
        }


        public void SetLinkSpriteState(LinkSprite currentSprite) { _currentLinkSprite = currentSprite; ReplaceLinkSprite(currentSprite); }
        public void SetLinkActionState(LinkActions currentAction) { _currentLinkAction = currentAction; }

        public void SetLinkDirection(Renderer.DIRECTION direction) { _direction = direction;}
        public Renderer.DIRECTION GetLinkDirection() { return _direction ;}

        public void SetLinkPosition(Vector2 position) { _position = position; _currentLink.SetPosition(position); }

        public void ReplaceLinkSprite(LinkSprite name) { 
            _currentLinkSprite = name; 
            _currentLink = _factory.CreateLink(name, _direction, _printScale, _manager);
            _currentLink.SetPosition(_position);
        }

        public Vector2 GetLinkPosition() { return _position; }
        
        public LinkActions GetLinkActions() { return _currentLinkAction; }

        /// <summary>
        /// Updates the current link
        /// </summary>
        public void Update()
        {
            //Console.WriteLine("direction: " + _direction.ToString());
            
            _currentLink.Update();
            _position = _currentLink.GetVectorPosition();
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
