// ItemCollisionBox.cs
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class BombItemCollisionBox : ItemCollisionBox

    {

        BombItemCollisionBox(Rectangle bounds) : base(bounds, ItemManager.ItemNames.Bomb, 1) { }

    }
        
}