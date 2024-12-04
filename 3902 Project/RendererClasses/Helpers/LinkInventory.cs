using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public class LinkInventory
    {
        // our dictionary inventory
        private Dictionary<ProjectileManager.ProjectileNames, int> _projectileInventory = new();

        // links current sword type
        public enum LinkSwordType { WOOD, IRON, MASTER, STAFF, DEBUG }
        private LinkSwordType _linkSwordType;
        public LinkSwordType CurrentLinkSword { get { return _linkSwordType; } set { _linkSwordType = value; } }

        // if link got shield upgrade
        private bool _linkShieldSmall;
        public bool LinkShield { get { return _linkShieldSmall; } set { _linkShieldSmall = value; } }

        private ProjectileManager.ProjectileNames _currentProjectile;
        public ProjectileManager.ProjectileNames CurrentProjectile { get { return _currentProjectile; } set { _currentProjectile = value; } }

        // set all HUD Icon Values
        private int _linkEmeraldAmount = 0;
        private int _linkNormalKeyAmount = 0;
        private int _linkProjectileAmount = 0;
        public int EmeraldAmount { get { return _linkEmeraldAmount; } set { _linkEmeraldAmount = value; if (_linkEmeraldAmount > 999) _linkEmeraldAmount = 999; } }
        public int KeyAmount { get { return _linkNormalKeyAmount; } set { _linkNormalKeyAmount = value; if (_linkNormalKeyAmount > 999) _linkNormalKeyAmount = 999; } }
        public int ProjectileAmount { get { return _projectileInventory.GetValueOrDefault(CurrentProjectile); } set { _linkProjectileAmount = value; if (_linkProjectileAmount > 999) _linkProjectileAmount = 999; } }


        public LinkInventory()
        {
            CurrentLinkSword = LinkSwordType.WOOD;
            // initialize link shield to be small
            LinkShield = false;

            // initializing some amounts for testing
            int amount = 10;
            _projectileInventory.Add(ProjectileManager.ProjectileNames.FireBall, amount);
            _projectileInventory.Add(ProjectileManager.ProjectileNames.BlueArrow, amount);
            _projectileInventory.Add(ProjectileManager.ProjectileNames.Bomb, amount);
            _projectileInventory.Add(ProjectileManager.ProjectileNames.Boomerang, amount);
        }

        public void AddItem(ItemManager.ItemNames name, int amount)
        {
            switch (name)
            {
                case ItemManager.ItemNames.FlashingEmerald:
                    _linkEmeraldAmount += amount; break;
                case ItemManager.ItemNames.NormalKey:
                case ItemManager.ItemNames.BossKey:
                    _linkNormalKeyAmount += amount; break;
                case ItemManager.ItemNames.Bomb:            AddProjectile(ProjectileManager.ProjectileNames.Bomb, amount); break;
                case ItemManager.ItemNames.BlueArrow:       AddProjectile(ProjectileManager.ProjectileNames.BlueArrow, amount); break;
                case ItemManager.ItemNames.FlashingBanana:  AddProjectile(ProjectileManager.ProjectileNames.Boomerang, amount); break;
                default: break;
            }
        }

        public void RemoveItem(ItemManager.ItemNames name, int amount)
        {
            switch (name)
            {
                case ItemManager.ItemNames.FlashingEmerald:
                    _linkEmeraldAmount -= amount; break;
                case ItemManager.ItemNames.NormalKey:
                case ItemManager.ItemNames.BossKey:
                    _linkNormalKeyAmount -= amount; break;
                case ItemManager.ItemNames.Bomb:            RemoveProjectile(ProjectileManager.ProjectileNames.Bomb, amount); break;
                case ItemManager.ItemNames.BlueArrow:       RemoveProjectile(ProjectileManager.ProjectileNames.BlueArrow, amount); break;
                case ItemManager.ItemNames.FlashingBanana:  RemoveProjectile(ProjectileManager.ProjectileNames.Boomerang, amount); break;
                default: break;
            }
        }

        private void AddProjectile(ProjectileManager.ProjectileNames name, int amount)
        {
            int newAmount = _projectileInventory.GetValueOrDefault(name) + amount;
            _projectileInventory.Remove(name);
            _projectileInventory.Add(name, newAmount);
        }

        public void RemoveProjectile(ProjectileManager.ProjectileNames name, int amount)
        {
            int newAmount = _projectileInventory.GetValueOrDefault(name) - amount;
            if (newAmount < 0) { newAmount = 0; }
            _projectileInventory.Remove(name);
            _projectileInventory.Add(name, newAmount);
        }

        public Dictionary<ProjectileManager.ProjectileNames, int> GetProjectileInventory()
        {
            return _projectileInventory;
        }
    }
}
