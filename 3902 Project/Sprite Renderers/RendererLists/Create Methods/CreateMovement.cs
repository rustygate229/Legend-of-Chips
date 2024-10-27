using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        public Vector2 CreateMovement(int selectedDirection, float positionSpeed)
        {
            switch(_rendListType)
            {
                case RendOrder.Size2:
                    return CreateMovementSize2(selectedDirection, positionSpeed);
                case RendOrder.Size3DownUp:
                    return CreateMovementSize3DownUp(selectedDirection, positionSpeed);
                case RendOrder.Size3RightLeft:
                    return CreateMovementSize3RightLeft(selectedDirection, positionSpeed);
                case RendOrder.Size4:
                    return CreateMovementSize4(selectedDirection, positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateMovementSize2(int selectedDirection, float positionSpeed)
        {
            SetDirection(selectedDirection);
            // get direction, then assign values
            switch ((int)_direction)
            {
                case 0: // Move DOWN
                    _rendDownUp.SetDirection(_direction);
                    return _rendDownUp.GetUpdatePosition(selectedDirection, positionSpeed);
                case 1: // Move UP
                    _rendDownUp.SetDirection(_direction);
                    return _rendDownUp.GetUpdatePosition(selectedDirection, positionSpeed);
                case 2: // Move RIGHT
                    _rendRightLeft.SetDirection(_direction);
                    return _rendRightLeft.GetUpdatePosition(selectedDirection, positionSpeed);
                case 3: // Move LEFT
                    _rendRightLeft.SetDirection(_direction);
                    return _rendRightLeft.GetUpdatePosition(selectedDirection, positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateMovementSize3DownUp(int selectedDirection, float positionSpeed)
        {
            SetDirection(selectedDirection);
            // get direction, then assign values
            switch ((int)_direction)
            {
                case 0: // Move DOWN
                    _rendDownUp.SetDirection(_direction);
                    return _rendDownUp.GetUpdatePosition(selectedDirection, positionSpeed);
                case 1: // Move UP
                    _rendDownUp.SetDirection(_direction);
                    return _rendDownUp.GetUpdatePosition(selectedDirection, positionSpeed);
                case 2: // Move RIGHT
                    _rendRight.SetDirection(_direction);
                    return _rendRight.GetUpdatePosition(selectedDirection, positionSpeed);
                case 3: // Move LEFT
                    _rendLeft.SetDirection(_direction);
                    return _rendLeft.GetUpdatePosition(selectedDirection, positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateMovementSize3RightLeft(int selectedDirection, float positionSpeed)
        {
            SetDirection(selectedDirection);
            // get direction, then assign values
            switch ((int)_direction)
            {
                case 0: // Move DOWN
                    _rendDown.SetDirection(_direction);
                    return  _rendDown.GetUpdatePosition(selectedDirection, positionSpeed);
                case 1: // Move UP
                    _rendUp.SetDirection(_direction);
                    return  _rendUp.GetUpdatePosition(selectedDirection, positionSpeed);
                case 2: // Move RIGHT
                    _rendRightLeft.SetDirection(_direction);
                    return  _rendRightLeft.GetUpdatePosition(selectedDirection, positionSpeed);
                case 3: // Move LEFT
                    _rendRightLeft.SetDirection(_direction);
                    return _rendRightLeft.GetUpdatePosition(selectedDirection, positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }

        private Vector2 CreateMovementSize4(int selectedDirection, float positionSpeed)
        {
            SetDirection(selectedDirection);
            // get direction, then assign values
            switch ((int)_direction)
            {
                case 0: // Move DOWN
                    _rendDown.SetDirection(_direction);
                    return _rendDown.GetUpdatePosition(selectedDirection, positionSpeed);
                case 1: // Move UP
                    _rendUp.SetDirection(_direction);
                    return _rendUp.GetUpdatePosition(selectedDirection, positionSpeed);
                case 2: // Move RIGHT
                    _rendRight.SetDirection(_direction);
                    return _rendRight.GetUpdatePosition(selectedDirection, positionSpeed);
                case 3: // Move LEFT
                    _rendLeft.SetDirection(_direction);
                    return _rendLeft.GetUpdatePosition(selectedDirection, positionSpeed);
                default: throw new ArgumentException("out of bounds direction in createRandomMovement");
            }
        }
    }
}