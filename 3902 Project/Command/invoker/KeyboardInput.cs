using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace _3902_Project
{
    // Implementing IController interface for keyboard input handling
    public class KeyboardInput : IController
    {
        // Dictionary to map keys to corresponding commands
        private Dictionary<Keys, ICommand> keysToCommands = new Dictionary<Keys, ICommand>();

        // Create a set of previous keys for previous 
        private HashSet<Keys> _previousKeys = new HashSet<Keys>();

        // use game for inputs
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
            keysToCommands.Add(Keys.N, new CommandLinkThrow(game));

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

            // Mapping keys for cycling through enemy
            keysToCommands.Add(Keys.O, new CommandEnemyPrev(game));
            keysToCommands.Add(Keys.P, new CommandEnemyNext(game));
        }


        private bool IsMoveKey(Keys key)
        {
            return key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D ||
                   key == Keys.Up || key == Keys.Down || key == Keys.Left || key == Keys.Right;
        }

        // Update method to check keyboard input and execute corresponding commands
        public void Update()
        {
            //get the keyboard state
            KeyboardState currentKeyboardState = Keyboard.GetState();
            Keys[] currentKeyboardPressed = currentKeyboardState.GetPressedKeys();
            HashSet<Keys> newPreviousKeys = new HashSet<Keys>();

            // for each key, find if it is either previously pressed or a movement key
            foreach (Keys key in currentKeyboardPressed)
            {
                // if key passes check, then execute
                if (keysToCommands.ContainsKey(key) && (!_previousKeys.Contains(key) || IsMoveKey(key)))
                {
                    ICommand setKeyboardCommand = keysToCommands[key];
                    setKeyboardCommand.Execute();
                }
                // add keys to a new previous
                newPreviousKeys.Add(key);
            }

            // set old previous keys = new previous keys
            _previousKeys = newPreviousKeys;
        }
    }
}
