using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static _3902_Project.BlockManager;

namespace _3902_Project
{
    public partial class EnvironmentFactory
    {
        Dictionary<int, Dictionary<BlockNames, int>> openDoorAssignments = new Dictionary<int, Dictionary<BlockNames, int>>();

        private void loadDoorAssignments()
        {

            // Level 1
            Dictionary<BlockNames, int> level1 = new Dictionary<BlockNames, int>();
            level1.Add(BlockNames.OpenDoor_LEFT, 2);
            openDoorAssignments.Add(1, level1);

            // Level 2
            Dictionary<BlockNames, int> level2 = new Dictionary<BlockNames, int>();
            level2.Add(BlockNames.OpenDoor_RIGHT, 1);
            level2.Add(BlockNames.OpenDoor_LEFT, 3);
            openDoorAssignments.Add(2, level2);

            // Level 3
            Dictionary<BlockNames, int> level3 = new Dictionary<BlockNames, int>();
            level3.Add(BlockNames.OpenDoor_RIGHT, 2);
            level3.Add(BlockNames.OpenDoor_DOWN, 4);
            level3.Add(BlockNames.OpenDoor_UP, 5);
            openDoorAssignments.Add(3, level3);

            // Level 4
            Dictionary<BlockNames, int> level4 = new Dictionary<BlockNames, int>();
            level4.Add(BlockNames.OpenDoor_UP, 3);
            openDoorAssignments.Add(4, level4);

            // Level 5
            Dictionary<BlockNames, int> level5 = new Dictionary<BlockNames, int>();
            level5.Add(BlockNames.OpenDoor_DOWN, 3);
            openDoorAssignments.Add(5, level5);
        }

        private void moveToNextRoom(BlockNames name)
        {
            _level = openDoorAssignments[_level][name];
        }
    }
        
}