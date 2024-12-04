using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace _3902_Project
{
    // Implementing IController interface for keyboard input handling
    public class KeyboardInput : IController
    {
        // Dictionary to map keys to corresponding commands
        private Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand> keysToCommands = new Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand>();
        private Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand> keysMoveToCommands = new Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand>();

        // Create a set of previous keys for previous 
        private HashSet<Microsoft.Xna.Framework.Input.Keys> _previousKeys = new HashSet<Microsoft.Xna.Framework.Input.Keys>();

        // use game for inputs
        private Game1 _game;


        // Constructor to initialize the game and map keys to commands
        public KeyboardInput(Game1 game)
        {
            this._game = game;

            // Mapping keys to corresponding commands for player movement
            keysMoveToCommands.Add(Microsoft.Xna.Framework.Input.Keys.W, new CommandMoveUp(game));
            keysMoveToCommands.Add(Microsoft.Xna.Framework.Input.Keys.S, new CommandMoveDown(game));
            keysMoveToCommands.Add(Microsoft.Xna.Framework.Input.Keys.A, new CommandMoveLeft(game));
            keysMoveToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D, new CommandMoveRight(game));
            keysMoveToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Up, new CommandMoveUp(game));
            keysMoveToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Down, new CommandMoveDown(game));
            keysMoveToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Left, new CommandMoveLeft(game));
            keysMoveToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Right, new CommandMoveRight(game));

            // Mapping keys for damaged state
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.E, new CommandLinkDamaged(game));

            // Mapping keys for other actions such as attack
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Z, new CommandLinkSwordAttack(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.N, new CommandLinkThrow(game));

            // Mapping keys for game control actions such as reset and quit
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Q, new CommandQuit(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.R, new CommandReset(game));

            // Mapping keys for moving through the inventory
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D1, new CommandLinkSetInventory(game, 1));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D2, new CommandLinkSetInventory(game, 2));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D3, new CommandLinkSetInventory(game, 3));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D4, new CommandLinkSetInventory(game, 4));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D5, new CommandLinkSetInventory(game, 5));

            // DEBUG TOOLS
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.C, new CommandDrawCollidables(game));

        }

        // Update method to check keyboard input and execute corresponding commands
        public void Update()
        {
            //get the keyboard state
            KeyboardState currentKeyboardState = Keyboard.GetState();
            Microsoft.Xna.Framework.Input.Keys[] currentKeyboardPressed = currentKeyboardState.GetPressedKeys();
            HashSet<Microsoft.Xna.Framework.Input.Keys> newPreviousKeys = new HashSet<Microsoft.Xna.Framework.Input.Keys>();

            // for each key, find if it is either previously pressed or a movement key
            foreach (Microsoft.Xna.Framework.Input.Keys key in currentKeyboardPressed)
            {
                // if key passes check, then execute
                if (keysToCommands.ContainsKey(key)) 
                {
                    if (!_previousKeys.Contains(key))
                    {
                        ICommand setKeyboardCommand = keysToCommands[key];
                        setKeyboardCommand.Execute();
                    }
                    // add keys to a new previous
                    newPreviousKeys.Add(key);
                }
            }
            // if conditions for movement keys
            if (currentKeyboardPressed.Length == 0 && _previousKeys.Count != 0) { new CommandLinkStill(_game).Execute(); }
            else if (currentKeyboardPressed.Length > 0)
            {
                Microsoft.Xna.Framework.Input.Keys key = currentKeyboardPressed[currentKeyboardPressed.Length - 1];
                if (keysMoveToCommands.ContainsKey(key))
                {
                    if (!_previousKeys.Contains(key))
                    {
                        ICommand setKeyboardCommand = keysMoveToCommands[key];
                        setKeyboardCommand.Execute();
                    }
                    newPreviousKeys.Add(key);
                }
            }

            // set old previous keys = new previous keys
            _previousKeys = newPreviousKeys;
        }
    }
}
