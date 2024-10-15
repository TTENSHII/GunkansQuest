using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectibles
{
    public override void Pickup(Inventory playerInventory)
    {
        playerInventory.haveLevel1Key = true;
        base.Pickup(playerInventory);
    }
}
