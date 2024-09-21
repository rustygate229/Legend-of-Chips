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

        public LinkPlayer()
        {
            _animation = new LinkAnimation();
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();
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
            _linkStateMachine.changeToMoving();
            _linkStateMachine.changeStateUp();

            _linkMovement.moveUp();
            
        }

        public void MoveDown()
        {
            _linkStateMachine.changeToMoving();
            _linkStateMachine.changeStateDown();
            
            _linkMovement.moveDown();
        }

        public void MoveLeft()
        {
            _linkStateMachine.changeToMoving();
            _linkStateMachine.changeStateLeft();

            _linkMovement.moveLeft();
        }

        public void MoveRight()
        {
            _linkStateMachine.changeToMoving();
            _linkStateMachine.changeStateRight();

            _linkMovement.moveRight();
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

    }
}
