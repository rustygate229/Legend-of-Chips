using System.Collections.Generic;
using _3902_Project;
using Microsoft.Xna.Framework.Input;
using _3902_Project.Content.command;

namespace _3902_Project
{
    // Implementing IController interface for keyboard input handling
    public class KeyboardInput : IController
    {
        // Dictionary to map keys to corresponding commands
        private Dictionary<Keys, ICommand> KeysToCommands = new Dictionary<Keys, ICommand>();
   
        private Game1 game;

        // Constructor to initialize the game and map keys to commands
        public KeyboardInput(Game1 game)
        {
            this.game = game;

            // Mapping keys to corresponding commands for player movement
            KeysToCommands.Add(Keys.W, new CommandMoveUp(game));
            KeysToCommands.Add(Keys.S, new CommandMoveDown(game));
            KeysToCommands.Add(Keys.A, new CommandMoveLeft(game));
            KeysToCommands.Add(Keys.D, new CommandMoveRight(game));
            KeysToCommands.Add(Keys.Up, new CommandMoveUp(game));
            KeysToCommands.Add(Keys.Down, new CommandMoveDown(game));
            KeysToCommands.Add(Keys.Left, new CommandMoveLeft(game));
            KeysToCommands.Add(Keys.Right, new CommandMoveRight(game));

            // Mapping keys for other actions such as attack
            KeysToCommands.Add(Keys.Z, new CommandLinkSwordAttack(game));

            // Mapping keys for game control actions such as reset and quit
            KeysToCommands.Add(Keys.R, new CommandReset(game));
            KeysToCommands.Add(Keys.Q, new CommandQuit(game));

            // Mapping keys for cycling through items and blocks
            KeysToCommands.Add(Keys.B, new CommandNextItem(game));
            KeysToCommands.Add(Keys.X, new CommandPrevItem(game));

            // Mapping keys for cycling through blocks
            KeysToCommands.Add(Keys.T, new CommandBlockPrev(game));
            KeysToCommands.Add(Keys.Y, new CommandBlockNext(game));

            // Mapping keys for cycling through enemies or NPCs
            KeysToCommands.Add(Keys.O, new CommandEnemyPrev(game));
            KeysToCommands.Add(Keys.P, new CommandEnemyNext(game));

           
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

