using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private AudioSource explosionSound = null;
    private Animator animator = null;
    private Rigidbody2D rb = null;

    private void Start()
    {
        explosionSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Explode()
    {
        explosionSound.Play();
        GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("Explode");
    }

    private void OnBombExplosionEnd()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerLife>().TakeDamage(damage);
            Explode();
        }
    }
}
