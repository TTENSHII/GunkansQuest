using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold = 0;

    private IInteractable CurentInteractable = null;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CurentInteractable != null)
        {
            Debug.Log("Interacting with " + CurentInteractable.GetType());
            CurentInteractable.Interact();
            CurentInteractable = null;
        }
    }

    public void AddGold(int amount)
    {
        Debug.Log("Adding " + amount + " gold");
        gold += amount;
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            IInteractable Interactable = collision.GetComponent<IInteractable>();
            if (Interactable.CanInteract())
            {
                Debug.Log(Interactable.GetInteractText());
                CurentInteractable = Interactable;
            }
        }
    }
}
