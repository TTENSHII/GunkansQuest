using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby : MonoBehaviour
{
    public int health = 3;
    public float speed = 5.0f;
    public int attackDamage = 1;
    public float attackRange = 1.8f;
    public float attackCountdown = 4.0f; // 2s

    private bool isStunned = false;
    private bool canAttack = true;

    private Animator animator = null;
    private Rigidbody2D rb = null;
    private PlayerMovements player = null;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        player = FindObjectOfType<PlayerMovements>();
    }

    private bool IsPlayerInRange()
    {
        if (player == null) return false;
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        float crabbyX = transform.position.x;
        float crabbyY = transform.position.y;
        float distanceX = Mathf.Abs(playerX - crabbyX);
        float distanceY = Mathf.Abs(playerY - crabbyY);
        if (distanceX <= attackRange && distanceY <= 1.0f)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        if (IsPlayerInRange())
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        Move();
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    public int GetAttackDamage()
    {
        return attackDamage;
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        isStunned = true;
        rb.velocity = Vector2.zero;
        if (health <= 0)
        {
            animator.SetBool("IsDead", true);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnDieAnimationEnd()
    {
       Die();
    }

    private void OnAttackAnimationEnd()
    {
        animator.SetBool("IsAttacking", false);
    }

    private void OnHitAnimationEnd()
    {
        isStunned = false;
        Move();
    }

    protected void Move()
    {
        if (isStunned) return;
        if (player == null) return;
        float playerX = player.transform.position.x;
        float crabbyX = transform.position.x;
        if (playerX > crabbyX)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
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
}
