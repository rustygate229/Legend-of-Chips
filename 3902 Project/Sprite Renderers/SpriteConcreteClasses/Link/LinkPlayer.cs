using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using static _3902_Project.ILinkStateMachine;

namespace _3902_Project
{
    public partial class LinkPlayer
    {
        IAnimation _animation;
        LinkMovement _linkMovement;
        ILinkStateMachine _linkStateMachine;
        ProjectileManager _projectileManager;
        LinkInventory _linkInventory;
        CharacterStateManager _characterState;


        //double x, y;
        public LinkPlayer(SpriteBatch sb, ContentManager content, ProjectileManager projectileManager, CharacterStateManager characterState)
        {
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();
            _animation = new LinkAnimation(sb, content, _linkStateMachine);
            _linkInventory = new LinkInventory();
            _characterState = characterState;

            _projectileManager = projectileManager;
        }

        public ICollisionBox getCollisionBox()
        {
            return _linkMovement.getCollisionBox();
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

        private Rectangle playAreaBoundary = new Rectangle(125, 320, 780, 450);

        public void Attack() { _linkStateMachine.setMelee(); }
        public void Throw() {
            _linkStateMachine.setThrow();
            FireProjectile();
        }

        //Character State Logic
        public void TakeDamage(int damageAmount)
        {
            _characterState.DecreaseHealth(damageAmount);
        }

        public void PickUpItem(string itemName)
        {
            _characterState.AddItem(itemName);
        }

        public void UseItem(string itemName)
        {
            _characterState.UseItem(itemName);
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
            ICollisionBox playerCollisionBox = ((LinkMovement)_linkMovement).getCollisionBox();
            playerCollisionBox.Bounds = new Rectangle(x, y, playerCollisionBox.Bounds.Width, playerCollisionBox.Bounds.Height);

            CollisionBoxHelper.KeepInBounds(playerCollisionBox, playAreaBoundary);

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
