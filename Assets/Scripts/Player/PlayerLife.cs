using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [field: SerializeField] public int life { get; private set; } = 5;

    private UIManager UIManager = null;
    private Animator anim = null;

    private void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
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

    private void Die()
    {
        anim.SetFloat("Life", 0);
        Destroy(GetComponent<PlayerMovements>());
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void IncreaseLife(int amount)
    {
        life += amount;
        UIManager.UpdateLife(life);
    }
}
