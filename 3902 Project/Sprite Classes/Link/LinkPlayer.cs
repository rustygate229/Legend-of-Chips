using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project.Link
{
    public class LinkPlayer
    {

        IAnimation _animation;
        ILinkMovement _linkMovement;
        ILinkStateMachine _linkStateMachine;

        double x, y;
        public LinkPlayer(SpriteBatch sb, ContentManager content)
        {
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();

            _animation = new LinkAnimation(sb, content, _linkStateMachine);
        }

        private bool CannotMove()
        {
            return (_linkStateMachine.getAttackState() == (int)LinkStateMachine.ATTACK.THROW
                || _linkStateMachine.getDamage());
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
            return keyboard.IsKeyDown(Keys.Z) || keyboard.IsKeyDown(Keys.C);
        }

        private bool IsDamagedKeysPressed()
        {
            KeyboardState keyboard = Keyboard.GetState();
            return keyboard.IsKeyDown(Keys.E);
        }

        public void MoveUp()
        {
            if (CannotMove()) { return; }
            _linkStateMachine.changeStateMovingUp();
            _linkMovement.moveUp();           
        }

        public void MoveDown()
        {
            if (CannotMove()) { return; }
            _linkStateMachine.changeStateMovingDown();   
            _linkMovement.moveDown();
        }

        public void MoveLeft()
        {
            if (CannotMove()) { return; }
            _linkStateMachine.changeStateMovingLeft();
            _linkMovement.moveLeft();
        }

        public void MoveRight()
        {
            if (CannotMove()) { return; }
            _linkStateMachine.changeStateMovingRight();
            _linkMovement.moveRight();
        }

        public void StayStill()
        {
            switch (_linkStateMachine.getMovementState())
            {
                case (int)LinkStateMachine.MOVEMENT.MUP:
                    _linkStateMachine.changeStateStillUp(); break;
                case (int)LinkStateMachine.MOVEMENT.MLEFT:
                    _linkStateMachine.changeStateStillLeft(); break;
                case (int)LinkStateMachine.MOVEMENT.MRIGHT:
                    _linkStateMachine.changeStateStillRight(); break;
                case (int)LinkStateMachine.MOVEMENT.MDOWN:
                    _linkStateMachine.changeStateStillDown(); break;

                default: break;
            }
        }

        public void Attack() { _linkStateMachine.setMelee(); }

        public void Throw() { _linkStateMachine.setThrow(); }

        public void StopAttack() { _linkStateMachine.stopAttack(); }
        public void StopDamage() { _linkStateMachine.stopDamage(); }
        public void flipDamaged() { _linkStateMachine.setDamage(); }

        public void Update()
        {
            x = _linkMovement.getXPosition();
            y = _linkMovement.getYPosition();

            if (!IsDamagedKeysPressed()) { StopDamage(); }
            if (!IsMovementKeysPressed()) { StayStill(); }
            if (!IsAttackKeysPressed()) { StopAttack(); }
        }

        public void Draw()
        {
            _animation.Update();

            if (_linkStateMachine.getDamage())
            {
                _animation.AnimDamaged(x, y); return;
            }

            switch (_linkStateMachine.getAttackState())
            {
                case (int)LinkStateMachine.ATTACK.MELEE:
                    _animation.AnimAttack(x, y); return;
                case (int)LinkStateMachine.ATTACK.THROW:
                    _animation.AnimItem(x, y); return;

                default: break;
            }

            switch (_linkStateMachine.getMovementState())
            {
                case (int)LinkStateMachine.MOVEMENT.MUP:
                case (int)LinkStateMachine.MOVEMENT.MDOWN:
                case (int)LinkStateMachine.MOVEMENT.MLEFT:
                case (int)LinkStateMachine.MOVEMENT.MRIGHT:
                    _animation.AnimMoving(x, y); break;

                case (int)LinkStateMachine.MOVEMENT.SUP:
                case (int)LinkStateMachine.MOVEMENT.SDOWN:
                case (int)LinkStateMachine.MOVEMENT.SLEFT:
                case (int)LinkStateMachine.MOVEMENT.SRIGHT:
                    _animation.AnimStationary(x, y); break;

                default:
                    break;
            }
        }
    }
}
