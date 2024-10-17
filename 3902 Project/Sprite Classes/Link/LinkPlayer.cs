using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Content.Projectiles;
using static _3902_Project.ILinkStateMachine;
using System.Drawing;

namespace _3902_Project.Link
{
    public partial class LinkPlayer
    {
        IAnimation _animation;
        ILinkMovement _linkMovement;
        ILinkStateMachine _linkStateMachine;
        ProjectileManager _projectileManager;
        LinkCollisionBox _linkCollisionBox;

        //double x, y;
        public LinkPlayer(SpriteBatch sb, ContentManager content, ProjectileManager projectileManager)
        {
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();
            _animation = new LinkAnimation(sb, content, _linkStateMachine);

            _projectileManager = projectileManager;

            Microsoft.Xna.Framework.Rectangle bounds = new Microsoft.Xna.Framework.Rectangle((int)_linkMovement.getXPosition(), (int)_linkMovement.getYPosition(), 64, 64);

            //temporarily hard coding health and damage values
            _linkCollisionBox = new LinkCollisionBox(bounds, true, 100, 10);


        }

        public double getXPosition() {
            //also updates x and y just to be sure 
            return _linkCollisionBox.Bounds.X;


        }
        public double getYPosition() {
            return _linkCollisionBox.Bounds.Y;

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

        public void changeToItem1() { _linkStateMachine.setInventory1(); }
        public void changeToItem2() { _linkStateMachine.setInventory2(); }
        public void changeToItem3() { _linkStateMachine.setInventory3(); }

        public void Update()
        {
            _animation.Update();

            int x = _linkCollisionBox.Bounds.X;
            int y = _linkCollisionBox.Bounds.Y;
            //updates linkMovement according to any collisions
            _linkMovement.setXPosition((double)x);
            _linkMovement.setYPosition((double)y);

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
