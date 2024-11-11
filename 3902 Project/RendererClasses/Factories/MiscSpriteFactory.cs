using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using static _3902_Project.MiscManager;

namespace _3902_Project
{
    public class MiscSpriteFactory
    {
        // block spritesheet
        private Texture2D _miscSpritesheet;

        // create a new instance of BlockSpriteFactory
        private static MiscSpriteFactory instance = new MiscSpriteFactory();

        public static MiscSpriteFactory Instance { get { return instance; } }


        // constructor to call the new instance method and initialize the sprite factory
        public MiscSpriteFactory() { instance = this; }


        // load all textures/spritesheet
        public void LoadAllTextures(ContentManager content)
        {
            _miscSpritesheet = content.Load<Texture2D>("Dungeon_Block_and_Room_Spritesheet_transparent");
        }


        /// <summary>
        /// CreateBlock for sprites that are plain sprites
        /// </summary>
        /// <param name="blockName"></param>
        /// <param name="printScale"></param>
        /// <returns>the sprite it creates, used fro unloading</returns>
        public ISprite CreateBlock(ThingNames thingName, float printScale)
        {
            switch (thingName)
            {
                case ThingNames.Number0White:
                    return new Number0White(_miscSpritesheet, printScale);
                default: throw new ArgumentException("Invalid block name");
            }
        }

        /// <summary>
        /// CreateBlock that has speed also, mainly needed for MoveableBlocks
        /// </summary>
        /// <param name="blockName"></param>
        /// <param name="direction"></param>
        /// <param name="printScale"></param>
        /// <param name="speed"></param>
        /// <returns>the sprite it creates, used fro unloading</returns>
        public ISprite CreateBlock(MiscManager.ThingNames thingName, Renderer.DIRECTION direction, float printScale, float speed)
        {
            switch (thingName)
            {
                default: throw new ArgumentException("invalid block name");
            }

            // More public IBlock returning methods follow
            // ...
        }
    }
}

/*
// Client code in main game class' LoadContent method:
EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/