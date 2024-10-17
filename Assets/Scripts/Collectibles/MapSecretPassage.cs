using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSecretPassage : Collectibles
{
    [SerializeField] Transform destination = null;

    public override void Pickup(Inventory playerInventory)
    {
        base.Pickup(playerInventory);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = destination.position;
    }
}
