using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private AudioSource audioSource = null;
    private Animator anim = null;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Explode(Collision2D collision)
    {
        anim.SetTrigger("Explode");

        audioSource.Play();
        Destroy(gameObject, 0.5f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();
            playerLife.TakeDamage(2);
            Explode(collision);
        }
        else if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Walls"))
        {
            Explode(collision);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemies enemy = collision.gameObject.GetComponent<Enemies>();
            enemy.ReceiveDamage(2);
            Explode(collision);
        }
    }
}
