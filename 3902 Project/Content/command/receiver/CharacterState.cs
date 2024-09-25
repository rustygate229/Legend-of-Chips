using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project.Content.command.receiver
{
    public class CharacterState
    {
        //inventory to keep track of items and their counts
        private static Dictionary<string, int> _inventoryItems = new Dictionary<string, int>();

        public static Dictionary<string, int> InventoryItems
        {
            get { return _inventoryItems; }
            set { _inventoryItems = value; }
        }

        //facing direction
        private static Vector2 direction = new Vector2(0, -1);
        public static Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        //character position
        private static int xPos = 100;
        public static int XPos
        {
            get { return xPos; }
            set { xPos = value; }
        }

        private static int yPos = 100;
        public static int YPos
        {
            get { return yPos; }
            set { yPos = value; }
        }

        // Character's weapon/item 
        private static string currentItem = "Sword";  // Example default item
        public static string CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value; }
        }

        //character's HP
        private static int health = 100;  //starting health
        public static int Health
        {
            get { return health; }
            set { health = value; }
        }

        //reset state
        public static void ResetState()
        {
            // Reset inventory to default items
            _inventoryItems = new Dictionary<string, int>
            {
                { "Sword", 1 }, 
            };

            // Reset position, health, and other states
            xPos = 100;  
            yPos = 100;  
            currentItem = "Sword";  
            direction = new Vector2(0, -1); 
        }

        //switch item state

        public static void NextItem()
        {
            if (currentItem == "Sword")
                currentItem = "Bow";
            else if (currentItem == "Bow")
                currentItem = "Bomb";
            else
                currentItem = "Sword";  
        }

        public static void PrevItem()
        {
            if (currentItem == "Sword")
                currentItem = "Bomb";
            else if (currentItem == "Bomb")
                currentItem = "Bow";
            else
                currentItem = "Sword";  
        }
    }
}
