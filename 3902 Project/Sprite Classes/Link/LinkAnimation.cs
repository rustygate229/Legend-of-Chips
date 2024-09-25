using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;


namespace _3902_Project
{
	public class LinkAnimation : IAnimation
    {

        private ISprite stationaryLink;
        private ISprite walkingLink;
        private ISprite itemLink;
        private ISprite attackingLink;

        private ISprite currentLink;

        private ILinkStateMachine _stateMachine;
        private SpriteBatch _spriteBatch;

        private int currentFrame;
        private int totalFrames;
        public LinkAnimation(SpriteBatch sb, ContentManager content, ILinkStateMachine state)
		{
            _spriteBatch = sb;
            LinkSpriteFactory.Instance.LoadAllTextures(content);
            _stateMachine = state;

            stationaryLink = LinkSpriteFactory.Instance.StationaryLinkSprite();
            walkingLink = LinkSpriteFactory.Instance.CreateWalkingLinkSprite();

            itemLink = LinkSpriteFactory.Instance.CreateItemUseLinkSprite();
            attackingLink = LinkSpriteFactory.Instance.CreateAttackingLinkSprite();

            currentLink = stationaryLink;

            currentFrame = 0;

            //THIS IS HARDCODED TUNE LATER IF NEED BE
            totalFrames = 5;

        }

        public void AnimAttack(double x, double y)
        {
            attackingLink.Draw(_spriteBatch, _stateMachine, x, y);
            currentLink = attackingLink;

        }

        public void AnimItem(double x, double y)
        {
            itemLink.Draw(_spriteBatch, _stateMachine, x, y);
            currentLink = itemLink;
        }

        public void AnimMoving(double x, double y)
        {
            walkingLink.Draw(_spriteBatch, _stateMachine, x, y);
            currentLink = walkingLink;
        }

        public void AnimStationary(double x, double y)
        {
            stationaryLink.Draw(_spriteBatch, _stateMachine, x, y);
            currentLink = stationaryLink;
        }

        public void AnimDamaged(double x, double y)
        {
            currentLink.Draw(_spriteBatch, _stateMachine, x, y);
        }

        public void Update()
        {
            currentFrame++;
            if(currentFrame >= totalFrames)
            {
                currentFrame = 0;
                currentLink.Update();

            }

        }
    }
}
