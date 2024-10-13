using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    [SerializeField] private AudioClip shurikenSound = null;

    private Rigidbody2D rb = null;
    private Animator animator = null;
    private AudioSource audioSource = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(shurikenSound);
    }

    private void FixedUpdate()
    {
        float speed = rb.velocity.x;
        animator.SetFloat("Speed", speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemies Enemy = collision.GetComponent<Enemies>();
            Enemy.ReceiveDamage(1);
        }
        Destroy(gameObject);
    }
}
