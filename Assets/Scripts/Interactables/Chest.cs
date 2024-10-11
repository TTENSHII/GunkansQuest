using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour , IInteractable
{
    public Sprite openSprite;
    public Sprite closedSprite;

    public AudioClip openSound;
    private AudioSource audioSource;
    
    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;

    public int gold = 100;
    public int shuriken = 2;
    
    public new InteractableType GetType()
    {
        return InteractableType.Chest;
    }

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
        player.GetComponent<Inventory>().AddShuriken(shuriken);
        isOpen = true;
        audioSource.PlayOneShot(openSound);
    }

    //when colliding with the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Player"))
        // {
            
        // }
    }
}
