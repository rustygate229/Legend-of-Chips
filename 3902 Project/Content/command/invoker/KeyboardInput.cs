using System.Collections.Generic;
using _3902_Project;
using Microsoft.Xna.Framework.Input;
using _3902_Project.Content.command;
using System.Diagnostics;
using System.Threading;

namespace _3902_Project
{
    // Implementing IController interface for keyboard input handling
    public class KeyboardInput : IController
    {
        // Dictionary to map keys to corresponding commands
        private Dictionary<Keys, ICommand> KeysToCommands = new Dictionary<Keys, ICommand>();
   
        private Game1 _game;

        // Constructor to initialize the game and map keys to commands
        public KeyboardInput(Game1 Game)
        {
            _game = Game;

            // Mapping keys to corresponding commands for player movement
            KeysToCommands.Add(Keys.W, new CommandMoveUp(Game));
            KeysToCommands.Add(Keys.S, new CommandMoveDown(Game));
            KeysToCommands.Add(Keys.A, new CommandMoveLeft(Game));
            KeysToCommands.Add(Keys.D, new CommandMoveRight(Game));
            KeysToCommands.Add(Keys.Up, new CommandMoveUp(Game));
            KeysToCommands.Add(Keys.Down, new CommandMoveDown(Game));
            KeysToCommands.Add(Keys.Left, new CommandMoveLeft(Game));
            KeysToCommands.Add(Keys.Right, new CommandMoveRight(Game));

            // Mapping keys for other actions such as attack
            KeysToCommands.Add(Keys.Z, new CommandLinkSwordAttack(Game));
            KeysToCommands.Add(Keys.N, new CommandLinkSwordAttack(Game));
            // gets replaced when we add switching between items
            KeysToCommands.Add(Keys.C, new CommandLinkThrow(Game));

            // Mapping keys for game control actions such as reset and quit
            // * NOT IMPLEMENTED
            // KeysToCommands.Add(Keys.R, new CommandReset(game));
            KeysToCommands.Add(Keys.Q, new CommandQuit(Game));

            // Mapping keys for cycling through items and blocks
            KeysToCommands.Add(Keys.U, new CommandNextItem(Game));
            KeysToCommands.Add(Keys.I, new CommandPrevItem(Game));

            // Mapping keys for cycling through blocks
            KeysToCommands.Add(Keys.T, new CommandBlockPrev(Game));
            KeysToCommands.Add(Keys.Y, new CommandBlockNext(Game));

            // * NOT IMPLEMENTED/CAUSES CRASHING
            // Mapping keys for cycling through enemies or NPCs
            // KeysToCommands.Add(Keys.O, new CommandEnemyPrev(Game));
            // KeysToCommands.Add(Keys.P, new CommandEnemyNext(Game));
        }

        // Update method to check keyboard input and execute corresponding commands
        public void Update()
        {
            // Get the current state of the keyboard
            KeyboardState currentKeyboardState = Keyboard.GetState();
            Keys[] pressedKeys = currentKeyboardState.GetPressedKeys();

            // Loop through each pressed key
            foreach (Keys key in pressedKeys)
            {
                // Check if the key is mapped to a command
                if (KeysToCommands.ContainsKey(key))
                {
                    // Execute the corresponding command
                    KeysToCommands[key].Execute();
                }
            }
        }    
    }
}

