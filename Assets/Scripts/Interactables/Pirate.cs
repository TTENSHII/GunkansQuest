using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour , IInteractable
{
    public bool CanInteract()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<Inventory>().haveLevelKey)
        {
            return true;
        }
        return false;
    }

    public string GetInteractText()
    {
        return "Press E to follow captain";
    }

    public void Interact()
    {
        GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>().LoadLevel(2);
    }
}
