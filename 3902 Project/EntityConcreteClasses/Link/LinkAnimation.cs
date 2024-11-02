using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
	public class LinkAnimation : IAnimation
    {

        private ILinkSprite stationaryLink;
        private ILinkSprite walkingLink;
        private ILinkSprite itemLink;
        private ILinkSprite attackingLink;

        private ILinkSprite currentLink;

        private ILinkStateMachine _stateMachine;
        private SpriteBatch _spriteBatch;

        private int currentFrame;
        private int totalFrames;
        public LinkAnimation(SpriteBatch sb, ContentManager content, ILinkStateMachine state)
		{
            _spriteBatch = sb;
            LinkSpriteFactory.Instance.LoadAllTextures(content, state);
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

            ((AttackingLinkSprite)attackingLink).x = x;
            ((AttackingLinkSprite)attackingLink).y = y;


            attackingLink.Draw(_spriteBatch);
            currentLink = attackingLink;

        }

        public void AnimItem(double x, double y)
        {
            ((LinkSprite)itemLink).x = x;
            ((LinkSprite)itemLink).y = y;

            itemLink.Draw(_spriteBatch);
            currentLink = itemLink;
        }

        public void AnimMoving(double x, double y)
        {
            ((LinkSprite)walkingLink).x = x;
            ((LinkSprite)walkingLink).y = y;

            walkingLink.Draw(_spriteBatch);
            currentLink = walkingLink;
        }

        public void AnimStationary(double x, double y)
        {
            ((LinkSprite)stationaryLink).x = x;
            ((LinkSprite)stationaryLink).y = y;

            stationaryLink.Draw(_spriteBatch);
            currentLink = stationaryLink;
        }

        public void AnimDamaged(double x, double y)
        {
            if (currentLink.GetType() == typeof(LinkSprite))
            {
                ((LinkSprite)currentLink).x = x;
                ((LinkSprite)currentLink).y = y;
            }
            else if(currentLink.GetType() == typeof(AttackingLinkSprite)) {
                ((AttackingLinkSprite)currentLink).x = x;
                ((AttackingLinkSprite)currentLink).x = y;
            }

            currentLink.Draw(_spriteBatch);
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
