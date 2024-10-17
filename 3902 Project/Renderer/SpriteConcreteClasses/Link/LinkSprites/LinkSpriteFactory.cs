using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace _3902_Project
{
    public class LinkSpriteFactory
    {
        private Texture2D linkSpriteSheet;

        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        private ILinkStateMachine linkStateMachine;

        private int spriteSize = 64;

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content, ILinkStateMachine state)
        {
            linkSpriteSheet = content.Load<Texture2D>("Link Spritesheet transparent");
            linkStateMachine = state;
        }

        public ILinkSprite StationaryLinkSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(1, 11, 16, 16));
            source.Add(new Rectangle(35, 11, 16, 16));
            source.Add(new Rectangle(69, 11, 16, 16));

            return new LinkSprite(linkSpriteSheet, source, 1, spriteSize, spriteSize, linkStateMachine);
        }

        public ILinkSprite CreateWalkingLinkSprite()
        {
            //opted to initialize the list of textures here
            //instead of in LinkSprite

            List<Rectangle> source = new List<Rectangle>();
            //down sourceRects (initialization is x, y, width, height)
            source.Add(new Rectangle(1, 11, 16, 16));
            source.Add(new Rectangle(18, 11, 16, 16));
            //right sourceRects
            source.Add(new Rectangle(35, 11, 16, 16));
            source.Add(new Rectangle(52, 11, 16, 16));
            //up sourceRects
            source.Add(new Rectangle(69, 11, 16, 16));
            source.Add(new Rectangle(86, 11, 16, 16));

            return new LinkSprite(linkSpriteSheet, source, 2, spriteSize, spriteSize, linkStateMachine);
        }

        public ILinkSprite CreateItemUseLinkSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Rectangle(107, 11, 16, 16));
            source.Add(new Rectangle(124, 11, 16, 16));
            source.Add(new Rectangle(141, 11, 16, 16));
            return new LinkSprite(linkSpriteSheet, source, 1, spriteSize, spriteSize, linkStateMachine);
        }

        public ILinkSprite CreateAttackingLinkSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            //down
            source.Add(new Rectangle(1, 47, 16, 16));
            source.Add(new Rectangle(18, 47, 16, 27));
            source.Add(new Rectangle(35, 47, 16, 23));
            source.Add(new Rectangle(53, 47, 16, 19));

            //right
            source.Add(new Rectangle(1, 77, 16, 16));
            source.Add(new Rectangle(18, 77, 27, 16));
            source.Add(new Rectangle(46, 77, 23, 16));
            source.Add(new Rectangle(70, 77, 19, 16));

            //up
            source.Add(new Rectangle(1, 109, 16, 16));
            source.Add(new Rectangle(18, 97, 16, 28));
            source.Add(new Rectangle(35, 98, 16, 27));
            source.Add(new Rectangle(52, 106, 16, 19));
            return new AttackingLinkSprite(linkSpriteSheet, source, 4, spriteSize / 16.0f, linkStateMachine);
        }

    }
}

/*
// Client code in main game class' LoadContent method:
LinkSpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Link class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/