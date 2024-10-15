using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public int gold { get; private set; } = 0;
    [field: SerializeField] public int shurikens { get; private set; } = 0;
    [field: SerializeField] public bool haveLevel1Key { get; set; } = false;

    private UIManager UIManager = null;
    private IInteractable currentInteractable = null;

    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
            currentInteractable = null;
            UIManager.StopToolTip();
        }
    }

    private void UpdateGoldText() 
    {
        UIManager.UpdateGoldText(gold);
    }

    private void UpdateShurikenText()
    {
        UIManager.UpdateShurikenText(shurikens);
    }

    private void UpdateUI()
    {
        UIManager.UpdateGoldText(gold);
        UIManager.UpdateShurikenText(shurikens);
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateGoldText();
    }
    
    public void RemoveGold(int amount)
    {
        gold -= amount;
        UpdateGoldText();
    }

    public void AddShuriken(int amount)
    {
        shurikens += amount;
        UpdateShurikenText();
    }

    public void RemoveShuriken(int amount)
    {
        shurikens -= amount;
        UpdateShurikenText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            IInteractable interactable = collision.GetComponent<IInteractable>();
            if (interactable.CanInteract() == true)
            {
                UIManager.SetToolTipText(interactable.GetInteractText());
                currentInteractable = interactable;
            }
        }
        else if (collision.CompareTag("Collectible"))
        {
            Collectibles collectible = collision.GetComponent<Collectibles>();
            collectible.Pickup(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            UIManager.StopToolTip();
            currentInteractable = null;
        }
    }
}
