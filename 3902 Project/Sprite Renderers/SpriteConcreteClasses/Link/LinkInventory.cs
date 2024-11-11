﻿using System.Collections.Generic;

public class LinkInventory
{

    public enum LINK_PROJECTILES { BLUE_ARROW, BOMB, FIREBALL, BOOMERANG, BLUE_BOOMERANG, FIRE }

    private Dictionary<LINK_PROJECTILES, int> InventoryDict;
    //potentially more variables to be added here
    public LinkInventory()
    {
        InventoryDict = new System.Collections.Generic.Dictionary<LINK_PROJECTILES, int>();
        InventoryDict.Add(LINK_PROJECTILES.BLUE_ARROW, 1000);
        InventoryDict.Add(LINK_PROJECTILES.BOMB, 1000);
        InventoryDict.Add(LINK_PROJECTILES.FIREBALL, 1000);


        //other variables to be instantiated here
    }
    public LinkInventory(Dictionary<LINK_PROJECTILES, int> inventoryDict) { InventoryDict = inventoryDict; }

    public bool canFireProjectiles(int num)
    {
        //num is indexed at 1, want to start at 0 for LINK_PROJECTILES
        num--;
        LINK_PROJECTILES type = (LINK_PROJECTILES)num;

        //dictionary is numbered according to projectile enums
        bool canFire = false;

        if (InventoryDict.TryGetValue(type, out int value))
        {
            if (value > 0)
            {
                canFire = true;
                //assumes it fires so subtracts by 1 
                //Debug.Print("value: " + value);
                InventoryDict[type] = value - 1;
            }

        }
        return canFire;
    }

    public void addProjectiles(LINK_PROJECTILES projectiles, int count)
    {
        if (InventoryDict.ContainsKey(projectiles))
        {
            InventoryDict[projectiles] += count;
        }
        else
        {
            InventoryDict.Add(projectiles, count);
        }
    }


}
