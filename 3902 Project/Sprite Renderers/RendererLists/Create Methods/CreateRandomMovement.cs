using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        public Vector2 CreateRandomMovement(int positionSpeed, Vector2 updatePosition)
        {
            switch(_rendListType)
            {
                case _rendOrder.Size2:
                    return CreateRandomMovementSize2(positionSpeed, updatePosition);
                case _rendOrder.Size3DownUp:
                    return CreateRandomMovementSize3DownUp(positionSpeed, updatePosition);
                case _rendOrder.Size3RightLeft:
                    return CreateRandomMovementSize3RightLeft(positionSpeed, updatePosition);
                case _rendOrder.Size4:
                    return CreateRandomMovementSize4(positionSpeed, updatePosition);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateRandomMovementSize2(int positionSpeed, Vector2 updatePosition)
        {
            // Randomly choose a direction:
            switch(_random.Next(4))
            {
                case 0: // Move DOWN
                    SetDirection(Renderer.DIRECTION.DOWN);
                    _rendDownUp.SetDirection(_direction);
                    return updatePosition = _rendDownUp.GetUpdatePosition(positionSpeed);
                case 1: // Move UP
                    SetDirection(Renderer.DIRECTION.UP);
                    _rendDownUp.SetDirection(_direction);
                    return updatePosition = _rendDownUp.GetUpdatePosition(positionSpeed);
                case 2: // Move RIGHT
                    SetDirection(Renderer.DIRECTION.RIGHT);
                    _rendRightLeft.SetDirection(_direction);
                    return updatePosition = _rendRightLeft.GetUpdatePosition(positionSpeed);
                case 3: // Move LEFT
                    SetDirection(Renderer.DIRECTION.LEFT);
                    _rendRightLeft.SetDirection(_direction);
                    return updatePosition = _rendRightLeft.GetUpdatePosition(positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateRandomMovementSize3DownUp(int positionSpeed, Vector2 updatePosition)
        {
            // Randomly choose a direction:
            switch (_random.Next(4))
            {
                case 0: // Move DOWN
                    SetDirection(Renderer.DIRECTION.DOWN);
                    _rendDownUp.SetDirection(_direction);
                    return updatePosition = _rendDownUp.GetUpdatePosition(positionSpeed);
                case 1: // Move UP
                    SetDirection(Renderer.DIRECTION.UP);
                    _rendDownUp.SetDirection(_direction);
                    return updatePosition = _rendDownUp.GetUpdatePosition(positionSpeed);
                case 2: // Move RIGHT
                    SetDirection(Renderer.DIRECTION.RIGHT);
                    _rendRight.SetDirection(_direction);
                    return updatePosition = _rendRight.GetUpdatePosition(positionSpeed);
                case 3: // Move LEFT
                    SetDirection(Renderer.DIRECTION.LEFT);
                    _rendLeft.SetDirection(_direction);
                    return updatePosition = _rendLeft.GetUpdatePosition(positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateRandomMovementSize3RightLeft(int positionSpeed, Vector2 updatePosition)
        {
            // Randomly choose a direction:
            switch (_random.Next(4))
            {
                case 0: // Move DOWN
                    SetDirection(Renderer.DIRECTION.DOWN);
                    _rendDown.SetDirection(_direction);
                    return updatePosition = _rendDown.GetUpdatePosition(positionSpeed);
                case 1: // Move UP
                    SetDirection(Renderer.DIRECTION.UP);
                    _rendUp.SetDirection(_direction);
                    return updatePosition = _rendUp.GetUpdatePosition(positionSpeed);
                case 2: // Move RIGHT
                    SetDirection(Renderer.DIRECTION.RIGHT);
                    _rendRightLeft.SetDirection(_direction);
                    return updatePosition = _rendRightLeft.GetUpdatePosition(positionSpeed);
                case 3: // Move LEFT
                    SetDirection(Renderer.DIRECTION.LEFT);
                    _rendRightLeft.SetDirection(_direction);
                    return updatePosition = _rendRightLeft.GetUpdatePosition(positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateRandomMovementSize4(int positionSpeed, Vector2 updatePosition)
        {
            // Randomly choose a direction:
            switch (_random.Next(4))
            {
                case 0: // Move DOWN
                    SetDirection(Renderer.DIRECTION.DOWN);
                    _rendDown.SetDirection(_direction);
                    return updatePosition = _rendDown.GetUpdatePosition(positionSpeed);
                case 1: // Move UP
                    SetDirection(Renderer.DIRECTION.UP);
                    _rendUp.SetDirection(_direction);
                    return updatePosition = _rendUp.GetUpdatePosition(positionSpeed);
                case 2: // Move RIGHT
                    SetDirection(Renderer.DIRECTION.RIGHT);
                    _rendRight.SetDirection(_direction);
                    return updatePosition = _rendRight.GetUpdatePosition(positionSpeed);
                case 3: // Move LEFT
                    SetDirection(Renderer.DIRECTION.LEFT);
                    _rendLeft.SetDirection(_direction);
                    return updatePosition = _rendLeft.GetUpdatePosition(positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }
    }
}