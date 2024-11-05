using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                // 假设药瓶可以恢复一定的血量
                if (itemName == "HealthPotion")
                {
                    IncreaseHealth(20); // 假设药瓶恢复 20 HP
                }
                inventory[itemName]--;

                if (inventory[itemName] == 0)
                {
                    inventory.Remove(itemName);
                }
            }
        }

        private void HandleDeath()
        {
            //Test
            Console.WriteLine("Character is dead.");
        }
    }
}

