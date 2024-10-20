using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAppartenance
{
    Player,
    Enemy
}

public class Shuriken : MonoBehaviour
{
    [SerializeField] private AudioClip shurikenSound = null;
    [SerializeField] private WeaponAppartenance weaponAppartenance = WeaponAppartenance.Player;

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
        if (weaponAppartenance == WeaponAppartenance.Player && collision.CompareTag("Enemy"))
        {
            Enemies Enemy = collision.GetComponent<Enemies>();
            Enemy.ReceiveDamage(1);
        } else if (weaponAppartenance == WeaponAppartenance.Enemy && collision.CompareTag("Player"))
        {
            PlayerLife playerLife = collision.GetComponent<PlayerLife>();
            playerLife.TakeDamage(1);
        }
        Destroy(gameObject);
    }
}
