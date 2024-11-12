using System.Collections.Generic;
using System.Diagnostics;

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
    //public LinkInventory(Dictionary<LINK_PROJECTILES, int> inventoryDict) { InventoryDict = inventoryDict; }
    public LINK_PROJECTILES translateNumbers(int number)
    {
        //numbers run from 1 to 5
        //logic for figuring out which numbers represent which values - hard coded for now
        LINK_PROJECTILES temp = LINK_PROJECTILES.ARROW;
        if (number == 1)
        {
            temp = LINK_PROJECTILES.ARROW;
        }
        else if (number == 2)
        {
            temp = LINK_PROJECTILES.BOMB;
        }
        else if (number == 3)
        {
            temp = LINK_PROJECTILES.BLUE_ARROW;
        }
        else if (number == 4)
        {
            temp = LINK_PROJECTILES.BOOMERANG;
        }
        else if (number == 5)
        {
            temp = LINK_PROJECTILES.FIRE;
        }
        return temp;
    }

    public bool canFireProjectiles(int num)
    {
        //dictionary is numbered according to projectile enums
        bool canFire = false;

        LINK_PROJECTILES type = translateNumbers(num);

        if (InventoryDict.TryGetValue(type, out int value))
        {
            if (value > 0)
            {
                //Debug.Print("firing " + type.ToString());
                canFire = true;
                //assumes it fires so subtracts by 1 
                InventoryDict[type] = value - 1;
            }

        }
        return canFire;
    }

    public void addProjectiles(LINK_PROJECTILES projectiles, int count)
    {
        if (InventoryDict.ContainsKey(projectiles))
        {
            Debug.Print(projectiles.ToString() + " added to inventory");
            InventoryDict[projectiles] += count;
        }
        else
        {
            InventoryDict.Add(projectiles, count);
        }
    }


}
