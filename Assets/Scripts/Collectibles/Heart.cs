using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Collectibles
{
    public override void Pickup(Inventory playerInventory)
    {
        base.Pickup(playerInventory);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerLife>().IncreaseLife(1);
    }
}
