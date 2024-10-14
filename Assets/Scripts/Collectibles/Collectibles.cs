using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{
    private AudioSource audioSource = null;
    private SpriteRenderer spriteRenderer = null;

    protected void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void Pickup(Inventory playerInventory)
    {
        audioSource.Play();
        spriteRenderer.enabled = false;
        Invoke("DestroyCollectible", audioSource.clip.length);
    }

    protected void DestroyCollectible()
    {
        Destroy(gameObject);
    }
}
