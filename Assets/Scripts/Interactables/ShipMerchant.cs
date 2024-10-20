using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMerchant : MonoBehaviour , IInteractable
{
    [SerializeField] private GameObject itemShopUI = null;

    public bool CanInteract()
    {
        return true;
    }

    public string GetInteractText()
    {
        return "Press E to buy items";
    }

    public void Interact()
    {
        itemShopUI.SetActive(true);
    }
}
