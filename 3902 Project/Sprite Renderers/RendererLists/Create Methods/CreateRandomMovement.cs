using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        public Vector2 CreateRandomMovement(int positionSpeed)
        {
            switch(_rendListType)
            {
                case RendOrder.Size2:
                    return CreateRandomMovementSize2(positionSpeed);
                case RendOrder.Size3DownUp:
                    return CreateRandomMovementSize3DownUp(positionSpeed);
                case RendOrder.Size3RightLeft:
                    return CreateRandomMovementSize3RightLeft(positionSpeed);
                case RendOrder.Size4:
                    return CreateRandomMovementSize4(positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateRandomMovementSize2(int positionSpeed)
        {
            int randomValue = _random.Next(4);
            // Randomly choose a direction:
            switch(randomValue)
            {
                case 0: // Move DOWN
                    SetDirection((int)Renderer.DIRECTION.DOWN);
                    _rendDownUp.SetDirection(_direction);
                    return _rendDownUp.GetUpdatePosition(randomValue, positionSpeed);
                case 1: // Move UP
                    SetDirection((int)Renderer.DIRECTION.UP);
                    _rendDownUp.SetDirection(_direction);
                    return _rendDownUp.GetUpdatePosition(randomValue, positionSpeed);
                case 2: // Move RIGHT
                    SetDirection((int)Renderer.DIRECTION.RIGHT);
                    _rendRightLeft.SetDirection(_direction);
                    return _rendRightLeft.GetUpdatePosition(randomValue, positionSpeed);
                case 3: // Move LEFT
                    SetDirection((int)Renderer.DIRECTION.LEFT);
                    _rendRightLeft.SetDirection(_direction);
                    return _rendRightLeft.GetUpdatePosition(randomValue, positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateRandomMovementSize3DownUp(int positionSpeed)
        {
            int randomValue = _random.Next(4);
            // Randomly choose a direction:
            switch (randomValue)
            {
                case 0: // Move DOWN
                    SetDirection((int)Renderer.DIRECTION.DOWN);
                    _rendDownUp.SetDirection(_direction);
                    return _rendDownUp.GetUpdatePosition(randomValue, positionSpeed);
                case 1: // Move UP
                    SetDirection((int)Renderer.DIRECTION.UP);
                    _rendDownUp.SetDirection(_direction);
                    return _rendDownUp.GetUpdatePosition(randomValue, positionSpeed);
                case 2: // Move RIGHT
                    SetDirection((int)Renderer.DIRECTION.RIGHT);
                    _rendRight.SetDirection(_direction);
                    return _rendRight.GetUpdatePosition(randomValue, positionSpeed);
                case 3: // Move LEFT
                    SetDirection((int)Renderer.DIRECTION.LEFT);
                    _rendLeft.SetDirection(_direction);
                    return _rendLeft.GetUpdatePosition(randomValue, positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateRandomMovementSize3RightLeft(int positionSpeed)
        {
            int randomValue = _random.Next(4);
            // Randomly choose a direction:
            switch (randomValue)
            {
                case 0: // Move DOWN
                    SetDirection((int)(int)Renderer.DIRECTION.DOWN);
                    _rendDown.SetDirection(_direction);
                    return  _rendDown.GetUpdatePosition(randomValue, positionSpeed);
                case 1: // Move UP
                    SetDirection((int)Renderer.DIRECTION.UP);
                    _rendUp.SetDirection(_direction);
                    return  _rendUp.GetUpdatePosition(randomValue, positionSpeed);
                case 2: // Move RIGHT
                    SetDirection((int)Renderer.DIRECTION.RIGHT);
                    _rendRightLeft.SetDirection(_direction);
                    return  _rendRightLeft.GetUpdatePosition(randomValue, positionSpeed);
                case 3: // Move LEFT
                    SetDirection((int)Renderer.DIRECTION.LEFT);
                    _rendRightLeft.SetDirection(_direction);
                    return _rendRightLeft.GetUpdatePosition(randomValue, positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateRandomMovementSize4(int positionSpeed)
        {
            int randomValue = _random.Next(4);
            // Randomly choose a direction:
            switch (randomValue)
            {
                case 0: // Move DOWN
                    SetDirection((int)Renderer.DIRECTION.DOWN);
                    _rendDown.SetDirection(_direction);
                    return _rendDown.GetUpdatePosition(randomValue, positionSpeed);
                case 1: // Move UP
                    SetDirection((int)Renderer.DIRECTION.UP);
                    _rendUp.SetDirection(_direction);
                    return _rendUp.GetUpdatePosition(randomValue, positionSpeed);
                case 2: // Move RIGHT
                    SetDirection((int)Renderer.DIRECTION.RIGHT);
                    _rendRight.SetDirection(_direction);
                    return _rendRight.GetUpdatePosition(randomValue, positionSpeed);
                case 3: // Move LEFT
                    SetDirection((int)Renderer.DIRECTION.LEFT);
                    _rendLeft.SetDirection(_direction);
                    return _rendLeft.GetUpdatePosition(randomValue, positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }
    }
}