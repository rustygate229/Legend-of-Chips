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

        private Dictionary<int, Action<double, double>> commandMap;

        public LinkPlayer()
        {
            _animation = new LinkAnimation();
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();

            commandMap = new Dictionary<int, Action<double, double>>();
        }

        private void loadCommands()
        {
            commandMap.Add((int)LinkStateMachine.MOVEMENT.MDOWN, _animation.AnimDownMoving);
            commandMap.Add((int)LinkStateMachine.MOVEMENT.MUP, _animation.AnimUpMoving);
            commandMap.Add((int)LinkStateMachine.MOVEMENT.MLEFT, _animation.AnimLeftMoving);
            commandMap.Add((int)LinkStateMachine.MOVEMENT.MRIGHT, _animation.AnimRightMoving);
            commandMap.Add((int)LinkStateMachine.MOVEMENT.SDOWN, _animation.AnimDownStationary);
            commandMap.Add((int)LinkStateMachine.MOVEMENT.SUP, _animation.AnimUpStationary);
            commandMap.Add((int)LinkStateMachine.MOVEMENT.SLEFT, _animation.AnimLeftStationary);
            commandMap.Add((int)LinkStateMachine.MOVEMENT.SRIGHT, _animation.AnimRightStationary);
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
      
        }

        public void Draw()
        {
            commandMap.TryGetValue((int)_linkStateMachine.getMovementState(), out Action<double, double> command);
            command.Invoke(_linkMovement.getXPosition(), _linkMovement.getYPosition());
        }

    }
}
