using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class CharacterStateManager
    {
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public bool IsDead => Health <= 0;

        private Dictionary<string, int> inventory;

        public CharacterStateManager(int maxHealth)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
            inventory = new Dictionary<string, int>();
        }

        public void DecreaseHealth(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;

            if (IsDead)
            {
                HandleDeath();
            }
        }

        public void IncreaseHealth(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
        }

        public void AddItem(string itemName)
        {
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName]++;
            }
            else
            {
                inventory[itemName] = 1;
            }
        }

        public void UseItem(string itemName)
        {
            if (inventory.ContainsKey(itemName) && inventory[itemName] > 0)
            {
                if (itemName == "HealthPotion")
                {
                    IncreaseHealth(2);
                }
                inventory[itemName]--;

                if (inventory[itemName] == 0)
                {
                    inventory.Remove(itemName);
                }
            }
        }

        public int GetFullHearts()
        {
            return Health / 2; // Each heart represents 2 HP
        }

        public bool HasHalfHeart()
        {
            return Health % 2 != 0; // If the remainder is not 0, it means there is half a heart
        }

        private void HandleDeath()
        {
            Console.WriteLine("Character is dead.");
        }
    }
}