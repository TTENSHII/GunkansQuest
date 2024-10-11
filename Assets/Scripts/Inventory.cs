using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold = 0;

    private UIManager UIManager;
    private IInteractable CurentInteractable = null;

    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UiManager").GetComponent<UIManager>();
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

    public void AddGold(int amount)
    {
        gold += amount;
        UIManager.UpdateGoldText(gold);
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
