using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public class LinkStateMachine : ILinkStateMachine
{
        public enum Direction { UP, DOWN, LEFT, RIGHT }

        private Direction _direction;

        public LinkStateMachine()
        {
            _direction = Direction.RIGHT;
        }

        public int getDirectionState()
        {
            return (int) _direction;
        }

        public void changeStateUp()
        {
            _direction = Direction.UP;
        }

        public void changeStateDown()
        {
            _direction = Direction.DOWN;
        }

        public void changeStateLeft()
        {
            _direction = Direction.LEFT;
        }

        public void changeStateRight()
        {
            _direction = Direction.RIGHT;
        }
    }
}
