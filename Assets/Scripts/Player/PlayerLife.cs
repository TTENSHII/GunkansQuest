using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life = 5;
    [SerializeField] private int maxLife = 5;
    [SerializeField] private AudioClip takeDamageSound = null;

    private AudioSource audioSource = null;
    private UIManager UIManager = null;
    private Animator anim = null;

    private void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        UIManager.UpdateLife(life);
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        audioSource.PlayOneShot(takeDamageSound);
        life -= damage;
        anim.SetTrigger("TakeDamage");
        UIManager.UpdateLife(life);
        if (life <= 0)
        {
            Die();
        }
    }

    public void OnPlayerDeadEnd()
    {
        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.LoadGameOver();
    }

    private void Die()
    {
        anim.SetFloat("Life", 0);
        Destroy(GetComponent<PlayerMovements>());
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void IncreaseLife(int amount)
    {
        life += amount;
        if (life > maxLife)
        {
            life = maxLife;
        }
        UIManager.UpdateLife(life);
    }
}
