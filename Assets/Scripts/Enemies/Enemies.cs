using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 3;
    [SerializeField] protected int health = 3;
    [SerializeField] protected int attackDamage = 1;
    [SerializeField] protected float speed = 5.0f;
    [SerializeField] protected float attackRange = 1.8f;
    [SerializeField] protected float attackCountdown = 0.5f;

    protected bool isStunned = false;
    protected bool canAttack = true;

    protected Animator animator = null;
    protected Rigidbody2D rb = null;
    protected PlayerMovements player = null;
    protected PlayerLife playerLife = null;
    protected FloatingHealthBar healthBar = null;
    protected AudioSource audioSource = null;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerLife = FindObjectOfType<PlayerLife>();
        player = FindObjectOfType<PlayerMovements>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    protected bool IsPlayerInRange()
    {
        if (player == null) return false;

        float distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);
        float distanceY = Mathf.Abs(player.transform.position.y - transform.position.y);

        if (distanceX <= attackRange && distanceY <= 1.0f)
        {
            return true;
        }

        return false;
    }

    protected void Update()
    {
        if (IsPlayerInRange())
        {
            Attack();
        }
    }

    private void ResetAttackPossibility()
    {
        canAttack = true;
    }

    protected virtual void Attack()
    {
        if (isStunned) return;
        if (!canAttack) return;
        animator.SetBool("IsAttacking", true);
        canAttack = false;
        Invoke("ResetAttackPossibility", attackCountdown);
    }

    protected virtual void FixedUpdate()
    {
        if (health <= 0)
        {
            animator.SetFloat("Speed", 0);
            return;
        }
        Move();
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    protected void Move()
    {
        if (isStunned || player == null) return;

        float distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (distanceX > 8)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        if (player.transform.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    protected void OnAttackAnimationEnd()
    {
        animator.SetBool("IsAttacking", false);
    }

    protected void OnHitAnimationEnd()
    {
        isStunned = false;
        animator.SetBool("IsTakingDamage", false);
        animator.SetBool("IsAttacking", false);
    }

    public void ReceiveDamage(int damage)
    {
        if (health <= 0) return;
        health -= damage;
        isStunned = true;
        rb.velocity = Vector2.zero;
        healthBar.UpdateHealthBar(health, maxHealth);
        animator.SetBool("IsTakingDamage", true);
        if (health <= 0)
        {
            animator.SetBool("IsDead", true);
            rb.velocity = Vector2.zero;
            audioSource.Play();
        }
    }

    protected virtual void OnDieAnimationEnd()
    {
       Destroy(gameObject);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife.TakeDamage(attackDamage);
        }
    }
}
