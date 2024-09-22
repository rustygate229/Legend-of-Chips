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

        private Dictionary<int, Action<double, double>> commandMap;

        public LinkPlayer(SpriteBatch sb, ContentManager content)
        {
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();
            _linkStateMachine.changeStateMovingLeft();

            _animation = new LinkAnimation(sb, content, _linkStateMachine);

            commandMap = new Dictionary<int, Action<double, double>>();
        }

        private void loadCommands()
        {
        }

        private bool IsMovementKeyPressed()
        {
            KeyboardState state = Keyboard.GetState();

            // Check for WASD or arrow keys
            return state.IsKeyDown(Keys.W) ||
                   state.IsKeyDown(Keys.A) ||
                   state.IsKeyDown(Keys.S) ||
                   state.IsKeyDown(Keys.D) ||
                   state.IsKeyDown(Keys.Up) ||
                   state.IsKeyDown(Keys.Down) ||
                   state.IsKeyDown(Keys.Left) ||
                   state.IsKeyDown(Keys.Right);
        }

        public void MoveUp()
        {
            _linkStateMachine.changeStateMovingUp();

            _linkMovement.moveUp();
            
        }

        public void MoveDown()
        {
            _linkStateMachine.changeStateMovingDown();
            
            _linkMovement.moveDown();
        }

        public void MoveLeft()
        {
            _linkStateMachine.changeStateMovingLeft();

            _linkMovement.moveLeft();
        }

        public void MoveRight()
        {
            _linkStateMachine.changeStateMovingRight();

            _linkMovement.moveRight();
        }

        public void Update()
        {
            x = _linkMovement.getXPosition();
            y = _linkMovement.getYPosition();
        }

        public void Draw()
        {

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

            _animation.Update();
        }

    }
}
