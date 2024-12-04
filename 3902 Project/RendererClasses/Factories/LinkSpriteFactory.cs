using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class LinkSpriteFactory
    {
        // Link spritesheet
        private Texture2D _linkSpritesheet;

        // Create a singleton instance of LinkSpriteFactory
        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance { get { return instance; } }

        // Constructor to initialize the factory instance
        private LinkSpriteFactory() { LinkSpriteFactory.instance = this; }

        public void LoadAllTextures(ContentManager content) { _linkSpritesheet = content.Load<Texture2D>("SpriteSheets\\Link_Transparent"); }

        public void UnloadAllTextures(ContentManager content) { _linkSpritesheet.Dispose(); }

        // create every type of link
        public ISprite CreateLink(LinkManager.LinkSprite linkAction, bool shieldStatus, Renderer.DIRECTION direction, float printScale, ProjectileManager manager)
        {
            switch (linkAction)
            {
                case LinkManager.LinkSprite.Standing:
                    return new LinkStanding(_linkSpritesheet, shieldStatus, direction, printScale);
                case LinkManager.LinkSprite.Throwing:
                    return new LinkAction(_linkSpritesheet, direction, printScale);
                case LinkManager.LinkSprite.Moving:
                    return new LinkMoving(_linkSpritesheet, shieldStatus, direction, printScale, manager);
                case LinkManager.LinkSprite.Won:
                    return new LinkWon(_linkSpritesheet, printScale);
                default: throw new ArgumentException("invalid link name");
            }
        }

        // Add more link types as necessary by specifying their source rectangles and positions
        // public ISprite OtherLink() { ... }
    }
}
