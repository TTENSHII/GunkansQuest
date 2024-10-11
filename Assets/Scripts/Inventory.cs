using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold = 0;
    public int shurikens = 5;

    private UIManager UIManager;
    private IInteractable CurentInteractable = null;

    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UiManager").GetComponent<UIManager>();
        UIManager.UpdateGoldText(gold);
        UIManager.UpdateShurikenText(shurikens);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CurentInteractable != null)
        {
            CurentInteractable.Interact();
            CurentInteractable = null;
            UIManager.StopToolTip();
        }
    }

    public int GetGold()
    {
        return gold;
    }

    public int GetShuriken()
    {
        return shurikens;
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UIManager.UpdateGoldText(gold);
    }

    public void AddShuriken(int amount)
    {
        shurikens += amount;
        UIManager.UpdateShurikenText(shurikens);
    }

    public void RemoveShuriken(int amount)
    {
        shurikens -= amount;
        UIManager.UpdateShurikenText(shurikens);
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
        UIManager.UpdateGoldText(gold);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            IInteractable Interactable = collision.GetComponent<IInteractable>();
            if (Interactable.CanInteract())
            {
                UIManager.SetToolTipText(Interactable.GetInteractText());
                CurentInteractable = Interactable;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            UIManager.StopToolTip();
            CurentInteractable = null;
        }
    }
}
