using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Projectiles;
using static _3902_Project.ILinkStateMachine;

namespace _3902_Project.Link
{
    public partial class LinkPlayer
    {
        IAnimation _animation;
        ILinkMovement _linkMovement;
        ILinkStateMachine _linkStateMachine;
        ProjectileManager _projectileManager;

        double x, y;
        public LinkPlayer(SpriteBatch sb, ContentManager content, ProjectileManager projectileManager)
        {
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();
            _animation = new LinkAnimation(sb, content, _linkStateMachine);

            _projectileManager = projectileManager;

            x = _linkMovement.getXPosition();
            y = _linkMovement.getYPosition();
        }

        public double getXPosition() { return x; }
        public double getYPosition() { return y; }

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

            x = _linkMovement.getXPosition();
            y = _linkMovement.getYPosition();

            if (!IsDamagedKeysPressed()) { StopDamage(); }
            if (!IsMovementKeysPressed()) { StayStill(); }
            if (!IsAttackKeysPressed()) { StopAttack(); }
        }
    }
}
