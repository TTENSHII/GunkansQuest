using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour , IInteractable
{
    [SerializeField] private Sprite openSprite = null;
    [SerializeField] private Sprite closedSprite = null;
    [SerializeField] private AudioClip openSound = null;

    [field: SerializeField] public int gold { get; private set; } = 100;
    [field: SerializeField] public int shurikens { get; private set; } = 2;

    private AudioSource audioSource = null;
    private SpriteRenderer spriteRenderer = null;

    private bool isOpen = false;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = closedSprite;
        audioSource = GetComponent<AudioSource>();
    }

    public bool CanInteract()
    {
        if (isOpen)
        {
            return false;
        }
        return true;
    }

    public string GetInteractText()
    {
        return "Press E to open";
    }

    public void Interact()
    {
        spriteRenderer.sprite = openSprite;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Inventory>().AddGold(gold);
        player.GetComponent<Inventory>().AddShuriken(shurikens);
        isOpen = true;
        audioSource.PlayOneShot(openSound);
    }
}
