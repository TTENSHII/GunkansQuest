using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int life = 5;

    private UIManager UIManager;
    private Animator anim = null;

    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UiManager").GetComponent<UIManager>();
        anim = GetComponent<Animator>();
        UIManager.UpdateLife(life);
    }

    public void TakeDamage(int damage)
    {
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

    void Die()
    {
        anim.SetFloat("Life", 0);
    }

    public void IncreaseLife(int amount)
    {
        life += amount;
        UIManager.UpdateLife(life);
    }
}
