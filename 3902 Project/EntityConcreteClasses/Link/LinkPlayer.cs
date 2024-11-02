using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static _3902_Project.ILinkStateMachine;

namespace _3902_Project
{
    public partial class LinkPlayer
    {
        IAnimation _animation;
        ILinkMovement _linkMovement;
        ILinkStateMachine _linkStateMachine;
        ProjectileManager _projectileManager;
        LinkInventory _linkInventory;


        //double x, y;
        public LinkPlayer(Game1 game, SpriteBatch sb)
        {
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();
            _animation = new LinkAnimation(sb, game.Content, _linkStateMachine);
            _linkInventory = new LinkInventory();

            _projectileManager = game.ProjectileManager;



        }

        public ICollisionBox getCollisionBox()
        {
            return ((LinkMovement)_linkMovement).getCollisionBox();
        }

        public double getXPosition() {
            //also updates x and y just to be sure 
            return _linkMovement.getXPosition();


        }
        public double getYPosition() {
            return _linkMovement.getYPosition();

        }

        private bool CannotMove()
        {
            return (_linkStateMachine.getAttackState() == ATTACK.THROW);
        }

        private bool IsMovementKeysPressed()
        {
            KeyboardState keyboard = Keyboard.GetState();

            return keyboard.IsKeyDown(Keys.W) ||
                keyboard.IsKeyDown(Keys.A) ||
                keyboard.IsKeyDown(Keys.S) ||
                keyboard.IsKeyDown(Keys.D) ||
                keyboard.IsKeyDown(Keys.Up) ||
                keyboard.IsKeyDown(Keys.Left) ||
                keyboard.IsKeyDown(Keys.Down) ||
                keyboard.IsKeyDown(Keys.Right);
        }

        private bool IsAttackKeysPressed()
        {
            KeyboardState keyboard = Keyboard.GetState();
            return keyboard.IsKeyDown(Keys.Z) || keyboard.IsKeyDown(Keys.N) || keyboard.IsKeyDown(Keys.C);
        }

        private bool IsDamagedKeysPressed()
        {
            KeyboardState keyboard = Keyboard.GetState();
            return keyboard.IsKeyDown(Keys.E);
        }

        public void Attack() { _linkStateMachine.setMelee(); }
        public void Throw() {
            _linkStateMachine.setThrow();
            FireProjectile();
        }


        public void StopAttack() { _linkStateMachine.stopAttack(); }
        public void StopDamage() { _linkStateMachine.stopDamage(); }
        public void flipDamaged() { _linkStateMachine.setDamage(); }

        public void changeToItem1() { _linkStateMachine.setInventory(1); }
        public void changeToItem2() { _linkStateMachine.setInventory(2); }
        public void changeToItem3() { _linkStateMachine.setInventory(3); }
        public void changeToItem4() { _linkStateMachine.setInventory(4); }

        public void changeToItem5() { _linkStateMachine.setInventory(5); }

        public void Update()
        {
            _animation.Update();

            int x = (int)_linkMovement.getXPosition();
            int y = (int)_linkMovement.getYPosition();
            //updates linkMovement according to any collisions
            ((LinkMovement)_linkMovement).getCollisionBox().Bounds = new Rectangle(x, y, ((LinkMovement)_linkMovement).getCollisionBox().Bounds.Width, ((LinkMovement)_linkMovement).getCollisionBox().Bounds.Height);

            if (!IsDamagedKeysPressed()) { StopDamage(); }
            if (!IsMovementKeysPressed()) { StayStill(); }
            if (!IsAttackKeysPressed()) { StopAttack(); }
        }

        public ILinkStateMachine.MOVEMENT getState()
        {
            return _linkStateMachine.getMovementState();
        }

        public ILinkStateMachine.ATTACK getAttack()
        {
            return _linkStateMachine.getAttackState();
        }

    }
}
