using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    protected int maxHealth = 3;
    protected int health = 3;
    protected int attackDamage = 1;
    protected float speed = 5.0f;
    protected float attackRange = 1.8f;
    protected float attackCountdown = 0.5f;

    protected bool isStunned = false;
    protected bool canAttack = true;

    protected Animator animator = null;
    protected Rigidbody2D rb = null;
    protected PlayerMovements player = null;
    protected PlayerLife playerLife = null;
    protected FloatingHealthBar healthBar = null;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovements>();
        playerLife = FindObjectOfType<PlayerLife>();
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

    protected void Attack()
    {
        if (isStunned) return;
        if (!canAttack) return;
        animator.SetBool("IsAttacking", true);
        canAttack = false;
        Invoke("ResetAttackPossibility", attackCountdown);
    }

    protected void FixedUpdate()
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
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        isStunned = true;
        rb.velocity = Vector2.zero;
        healthBar.UpdateHealthBar(health, maxHealth);
        animator.SetBool("IsTakingDamage", true);
        if (health <= 0)
        {
            animator.SetBool("IsDead", true);
            rb.velocity = Vector2.zero;
        }
    }

    protected void OnDieAnimationEnd()
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
