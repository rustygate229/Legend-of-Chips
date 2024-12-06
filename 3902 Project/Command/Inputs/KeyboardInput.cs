using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Microsoft.Xna.Framework.Input;

namespace _3902_Project
{
    // Implementing IController interface for keyboard input handling
    public class KeyboardInput : IController
    {
        // Dictionary to map keys to corresponding commands
        private Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand> keysToCommands = new Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand>();
        private Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand> keysMoveToCommands = new Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand>();
        private Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand> keysPauseToCommands = new Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand>();
        private Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand> keysStartEndToCommands = new Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand>();
        private Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand> keysGameOverToCommands = new Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand>();
        private Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand> keysWonToCommands = new Dictionary<Microsoft.Xna.Framework.Input.Keys, ICommand>();
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
            keysGameOverToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Q, new CommandQuit(game));
            keysGameOverToCommands.Add(Microsoft.Xna.Framework.Input.Keys.R, new CommandReset(game));
            keysWonToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Q, new CommandQuit(game));
            keysWonToCommands.Add(Microsoft.Xna.Framework.Input.Keys.R, new CommandReset(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Q, new CommandQuit(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.R, new CommandReset(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.P, new CommandPauseGame(game));

            // Mapping keys for moving through the inventory
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D1, new CommandLinkSetInventory(game, 1));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D2, new CommandLinkSetInventory(game, 2));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D3, new CommandLinkSetInventory(game, 3));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D4, new CommandLinkSetInventory(game, 4));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D5, new CommandLinkSetInventory(game, 5));

            // DEBUG TOOLS
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.C, new CommandDrawCollidables(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.H, new CommandSpawnAllHearts(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.K, new CommandSpawnDebugSword(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.J, new CommandSpawnLinkInBounds(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.U, new CommandSpawn50Arrows(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.I, new CommandSpawn50Boomerangs(game));
            keysToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Y, new CommandSpawn50Bombs(game));

            // Mapping keys to corresponding commands for player interacting with pause screen
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.W, new CommandSelectUp(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.S, new CommandSelectDown(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.A, new CommandSelectLeft(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.D, new CommandSelectRight(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Up, new CommandSelectUp(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Down, new CommandSelectDown(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Left, new CommandSelectLeft(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Right, new CommandSelectRight(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.P, new CommandPauseGame(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Q, new CommandQuit(game));
            keysPauseToCommands.Add(Microsoft.Xna.Framework.Input.Keys.R, new CommandReset(game));

            keysStartEndToCommands.Add(Microsoft.Xna.Framework.Input.Keys.Enter, new CommandStartEndGame(game));
        }

       

        // Update method to check keyboard input and execute corresponding commands
        public void Update()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            Microsoft.Xna.Framework.Input.Keys[] currentKeyboardPressed = currentKeyboardState.GetPressedKeys();
            HashSet<Microsoft.Xna.Framework.Input.Keys> newPreviousKeys = new HashSet<Microsoft.Xna.Framework.Input.Keys>();

            if (_game.StartState)
                newPreviousKeys = EnterKeyCheck(currentKeyboardPressed, newPreviousKeys);
            else if (_game.IsGameOver) // If Game Over state
                newPreviousKeys = GameOverKeyCheck(currentKeyboardPressed, newPreviousKeys);
            else if (_game.IsWonState) 
                newPreviousKeys = WonStateKeyCheck(currentKeyboardPressed, newPreviousKeys);
            else if (_game.PauseState)
                newPreviousKeys = PauseKeyCheck(currentKeyboardPressed, newPreviousKeys);
            else
            {
                newPreviousKeys = NormalKeyCheck(currentKeyboardPressed, newPreviousKeys);
                newPreviousKeys = MovementCheck(currentKeyboardPressed, newPreviousKeys);
            }

            _previousKeys = newPreviousKeys;
        }

        private HashSet<Microsoft.Xna.Framework.Input.Keys> NormalKeyCheck(Microsoft.Xna.Framework.Input.Keys[] currentKeyboardPressed, HashSet<Microsoft.Xna.Framework.Input.Keys> newPreviousKeys)
        {
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
            return newPreviousKeys;
        }

        private HashSet<Microsoft.Xna.Framework.Input.Keys> MovementCheck(Microsoft.Xna.Framework.Input.Keys[] currentKeyboardPressed, HashSet<Microsoft.Xna.Framework.Input.Keys> newPreviousKeys)
        {
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
            return newPreviousKeys;
        }

        private HashSet<Microsoft.Xna.Framework.Input.Keys> PauseKeyCheck(Microsoft.Xna.Framework.Input.Keys[] currentKeyboardPressed, HashSet<Microsoft.Xna.Framework.Input.Keys> newPreviousKeys)
        {
            // for each key, find if it is either previously pressed or a movement key
            foreach (Microsoft.Xna.Framework.Input.Keys key in currentKeyboardPressed)
            {
                // if key passes check, then execute
                if (keysPauseToCommands.ContainsKey(key))
                {
                    if (!_previousKeys.Contains(key))
                    {
                        ICommand setKeyboardCommand = keysPauseToCommands[key];
                        setKeyboardCommand.Execute();
                    }
                    // add keys to a new previous
                    newPreviousKeys.Add(key);
                }
            }
            return newPreviousKeys;
        }

        private HashSet<Microsoft.Xna.Framework.Input.Keys> EnterKeyCheck(Microsoft.Xna.Framework.Input.Keys[] currentKeyboardPressed, HashSet<Microsoft.Xna.Framework.Input.Keys> newPreviousKeys)
        {
            if (currentKeyboardPressed.Contains(Microsoft.Xna.Framework.Input.Keys.Enter))
            {
                ICommand setKeyboardCommand = keysStartEndToCommands[Microsoft.Xna.Framework.Input.Keys.Enter];
                setKeyboardCommand.Execute();
            }
            return newPreviousKeys;
        }
        // Add a method to handle Game Over key commands
        private HashSet<Microsoft.Xna.Framework.Input.Keys> GameOverKeyCheck(Microsoft.Xna.Framework.Input.Keys[] currentKeyboardPressed, HashSet<Microsoft.Xna.Framework.Input.Keys> newPreviousKeys)
        {
            foreach (Microsoft.Xna.Framework.Input.Keys key in currentKeyboardPressed)
            {
                if (keysGameOverToCommands.ContainsKey(key))
                {
                    if (!_previousKeys.Contains(key))
                    {
                        ICommand setKeyboardCommand = keysGameOverToCommands[key];
                        setKeyboardCommand.Execute();
                    }
                    newPreviousKeys.Add(key);
                }
            }
            return newPreviousKeys;
        }

        private HashSet<Microsoft.Xna.Framework.Input.Keys> WonStateKeyCheck(Microsoft.Xna.Framework.Input.Keys[] currentKeyboardPressed, HashSet<Microsoft.Xna.Framework.Input.Keys> newPreviousKeys)
        {
            foreach (Microsoft.Xna.Framework.Input.Keys key in currentKeyboardPressed)
            {
                if (keysWonToCommands.ContainsKey(key))
                {
                    if (!_previousKeys.Contains(key))
                    {
                        ICommand setKeyboardCommand = keysWonToCommands[key];
                        setKeyboardCommand.Execute();
                    }
                    newPreviousKeys.Add(key);
                }
            }
            return newPreviousKeys;
        }

    }
}
