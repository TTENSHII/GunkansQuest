using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopFunctions : MonoBehaviour
{
    [SerializeField] private int shurikenPrice = 150;
    [SerializeField] private int heartPrice = 200;

    public void BuyShuriKen()
    {
        Inventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        if (playerInventory.gold >= shurikenPrice)
        {
            playerInventory.AddShuriken(1);
            playerInventory.RemoveGold(shurikenPrice);
        }
    }

    public void BuyHealthPotion()
    {
        Inventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        PlayerLife playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();

        if (playerInventory.gold >= heartPrice)
        {
            playerLife.IncreaseLife(1);
            playerInventory.RemoveGold(heartPrice);
        }
    }
}
