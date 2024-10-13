using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private AudioSource audioSource = null;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerLife>().TakeDamage(damage);
            audioSource.Play();
        }
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemies>().ReceiveDamage(10);
            audioSource.Play();
        }
    }
}
