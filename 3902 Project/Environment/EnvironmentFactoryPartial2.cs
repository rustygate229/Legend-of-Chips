using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static _3902_Project.CollisionData;

namespace _3902_Project
{
    public partial class EnvironmentFactory
    {
        Dictionary<int, Dictionary<CollisionType, int>> openDoorAssignments = new Dictionary<int, Dictionary<CollisionType, int>>();

        private void loadDoorAssignments()
        {

            // Level 1
            Dictionary<CollisionType, int> level1 = new Dictionary<CollisionType, int>();
            level1.Add(CollisionType.RIGHT, 2);
            openDoorAssignments.TryAdd(1, level1);

            // Level 2
            Dictionary<CollisionType, int> level2 = new Dictionary<CollisionType, int>();
            level2.Add(CollisionType.LEFT, 1);
            level2.Add(CollisionType.RIGHT, 3);
            openDoorAssignments.TryAdd(2, level2);

            // Level 3
            Dictionary<CollisionType, int> level3 = new Dictionary<CollisionType, int>();
            level3.Add(CollisionType.LEFT, 2);
            level3.Add(CollisionType.TOP, 4);
            level3.Add(CollisionType.BOTTOM, 5);
            openDoorAssignments.TryAdd(3, level3);

            // Level 4
            Dictionary<CollisionType, int> level4 = new Dictionary<CollisionType, int>();
            level4.Add(CollisionType.BOTTOM, 3);
            openDoorAssignments.TryAdd(4, level4);

            // Level 5
            Dictionary<CollisionType, int> level5 = new Dictionary<CollisionType, int>();
            level5.Add(CollisionType.TOP, 3);
            openDoorAssignments.TryAdd(5, level5);
        }

        public void moveToNextRoom(CollisionType name)
        {
            int templevel = openDoorAssignments[_level][name];

            if (templevel < _level) { _display.DecrementLevel(); } else { _display.IncrementLevel(); }
            _level = templevel;
        }
    }
        
}