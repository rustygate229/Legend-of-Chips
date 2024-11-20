using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public class LinkInventory
    {
        private Dictionary<ProjectileManager.ProjectileNames, int> _projectileInventory = new Dictionary<ProjectileManager.ProjectileNames, int>();

        // links current sword type
        public enum LinkSwordType { WOOD, IRON, MASTER, STAFF }
        private LinkSwordType _linkSwordType;
        public LinkSwordType CurrentLinkSword { get { return _linkSwordType; } set { _linkSwordType = value; } }

        // if link got shield upgrade
        private bool _linkShieldSmall;
        public bool LinkShield { get { return _linkShieldSmall; } set { _linkShieldSmall = value; } }

        public LinkInventory()
        {
            CurrentLinkSword = LinkSwordType.WOOD;
            // initialize link shield to be small
            LinkShield = true;

            // initializing some amounts for testing
            int amount = 10;
            _projectileInventory.Add(ProjectileManager.ProjectileNames.FireBall, amount);
            _projectileInventory.Add(ProjectileManager.ProjectileNames.BlueArrow, amount);
            _projectileInventory.Add(ProjectileManager.ProjectileNames.Bomb, amount);
        }

        public void AddItem(ProjectileManager.ProjectileNames name, int amount)
        {
            int newAmount = _projectileInventory.GetValueOrDefault(name) + amount;
            _projectileInventory.Add(name, newAmount);
        }

        public void RemoveItem(ProjectileManager.ProjectileNames name, int amount)
        {
            int newAmount = _projectileInventory.GetValueOrDefault(name) - amount;
            if (newAmount < 0) { newAmount = 0; }
            _projectileInventory.Add(name, newAmount);
        }

        public Dictionary<ProjectileManager.ProjectileNames, int> GetProjectileInventory()
        {
            return _projectileInventory;
        }
    }
}
