using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902_Project.ILinkStateMachine;

namespace _3902_Project.Link
{
    public partial class LinkPlayer
    {

        double x, y;
        public LinkPlayer(SpriteBatch sb, ContentManager content)
        {
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();

            _animation = new LinkAnimation(sb, content, _linkStateMachine);
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
                _animation.AnimDamaged(x, y);
            }

            switch (_linkStateMachine.getAttackState())
            {
                case ATTACK.MELEE:
                    _animation.AnimAttack(x, y); return;
                case ATTACK.THROW:
                    _animation.AnimItem(x, y); return;

                default: break;
            }

            switch (_linkStateMachine.getMovementState())
            {
                case MOVEMENT.MUP:
                case MOVEMENT.MDOWN:
                case MOVEMENT.MLEFT:
                case MOVEMENT.MRIGHT:
                    _animation.AnimMoving(x, y); break;

                case MOVEMENT.SUP:
                case MOVEMENT.SDOWN:
                case MOVEMENT.SLEFT:
                case MOVEMENT.SRIGHT:
                    _animation.AnimStationary(x, y); break;

                default:
                    break;
            }
        }
    }
}
