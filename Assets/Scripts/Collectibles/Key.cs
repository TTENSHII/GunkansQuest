using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectibles
{
    public override void Pickup(Inventory playerInventory)
    {
        playerInventory.haveLevelKey = true;
        base.Pickup(playerInventory);
    }
}
