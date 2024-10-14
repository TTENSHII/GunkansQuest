using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectibles
{
    [SerializeField] private int goldAmount = 10;

    public override void Pickup(Inventory playerInventory)
    {
        base.Pickup(playerInventory);
        playerInventory.AddGold(goldAmount);
    }
}
