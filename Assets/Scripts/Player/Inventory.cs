using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public int gold { get; private set; } = 0;
    [field: SerializeField] public int shurikens { get; private set; } = 0;
    [field: SerializeField] public bool haveLevelKey { get; set; } = false;

    private UIManager UIManager = null;
    private IInteractable currentInteractable = null;

    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        LoadInventory();
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

    private void SaveInventory()
    {
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("Shurikens", shurikens);
        PlayerPrefs.Save();
    }

    private void LoadInventory()
    {
        gold = PlayerPrefs.GetInt("Gold", 0);
        shurikens = PlayerPrefs.GetInt("Shurikens", 5);
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
        SaveInventory();
    }
    
    public void RemoveGold(int amount)
    {
        gold -= amount;
        UpdateGoldText();
        SaveInventory();
    }

    public void AddShuriken(int amount)
    {
        shurikens += amount;
        UpdateShurikenText();
        SaveInventory();
    }

    public void RemoveShuriken(int amount)
    {
        shurikens -= amount;
        UpdateShurikenText();
        SaveInventory();
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
