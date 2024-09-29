using System.Collections.Generic;
using _3902_Project;
using Microsoft.Xna.Framework.Input;
using _3902_Project.Content.command;
using System.Diagnostics;
using System.Threading;
using System;

namespace _3902_Project
{
    // Implementing IController interface for keyboard input handling
    public class KeyboardInput : IController
    {
        // Dictionary to map keys to corresponding commands
        private Dictionary<Keys, ICommand> keysToCommands = new Dictionary<Keys, ICommand>();

        // Record last command
        private ICommand previousCommand = null;

        private Game1 _game;


        // Constructor to initialize the game and map keys to commands
        public KeyboardInput(Game1 game)
        {
            this._game = game;

            // Mapping keys to corresponding commands for player movement
            keysToCommands.Add(Keys.W, new CommandMoveUp(game));
            keysToCommands.Add(Keys.S, new CommandMoveDown(game));
            keysToCommands.Add(Keys.A, new CommandMoveLeft(game));
            keysToCommands.Add(Keys.D, new CommandMoveRight(game));
            keysToCommands.Add(Keys.Up, new CommandMoveUp(game));
            keysToCommands.Add(Keys.Down, new CommandMoveDown(game));
            keysToCommands.Add(Keys.Left, new CommandMoveLeft(game));
            keysToCommands.Add(Keys.Right, new CommandMoveRight(game));

            // Mapping keys for damaged state
            keysToCommands.Add(Keys.E, new CommandLinkDamaged(game));

            // Mapping keys for other actions such as attack
            keysToCommands.Add(Keys.Z, new CommandLinkSwordAttack(game));
            keysToCommands.Add(Keys.N, new CommandLinkSwordAttack(game));
            keysToCommands.Add(Keys.C, new CommandLinkThrow(game));

            // Mapping keys for game control actions such as reset and quit
            keysToCommands.Add(Keys.Q, new CommandQuit(game));
            keysToCommands.Add(Keys.R, new CommandReset(game));

            // Mapping keys for cycling through items and blocks
            keysToCommands.Add(Keys.U, new CommandNextItem(game));
            keysToCommands.Add(Keys.I, new CommandPrevItem(game));

            // Mapping keys for cycling through blocks
            keysToCommands.Add(Keys.T, new CommandBlockPrev(game));
            keysToCommands.Add(Keys.Y, new CommandBlockNext(game));

            // Mapping keys for moving through the inventory
            keysToCommands.Add(Keys.D1, new CommandLinkSetInventory1(game));
            keysToCommands.Add(Keys.D2, new CommandLinkSetInventory2(game));
            keysToCommands.Add(Keys.D3, new CommandLinkSetInventory3(game));
        }

        
        private bool IsMoveKey(Keys key)
        {
            return key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D ||
                   key == Keys.Up || key == Keys.Down || key == Keys.Left || key == Keys.Right ||key == Keys.N || key == Keys.Z|| key == Keys.C;
        }

        // Update method to check keyboard input and execute corresponding commands
        public void Update()
        {
            //get the keyboard state
            KeyboardState currentKeyboardState = Keyboard.GetState();
            Keys[] pressedKeys = currentKeyboardState.GetPressedKeys();


            foreach (Keys key in pressedKeys)
            {
                if (keysToCommands.ContainsKey(key))
                {
                    ICommand currentCommand = keysToCommands[key];

                    //lag only of t and y
                    if (IsMoveKey(key))
                    {
                        currentCommand.Execute();
                    }
                    else
                    {
                       
                        if (currentCommand != previousCommand)
                        {
                            currentCommand.Execute();
                            previousCommand = currentCommand;  //update to last command
                        }
                    }
                }
            }

            // if no pressed key, reset previousCommand
            if (pressedKeys.Length == 0)
            {
                previousCommand = null;
            }
        }
    }
}
