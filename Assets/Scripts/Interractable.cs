using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType
{
    Chest
}

public interface IInteractable
{
    public InteractableType GetType();
    public bool CanInteract();
    public string GetInteractText();
    public void Interact();
}
