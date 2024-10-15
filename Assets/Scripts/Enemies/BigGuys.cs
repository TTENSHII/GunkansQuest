using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuys : Enemies
{
    protected override void Start()
    {
        base.Start();

        maxHealth = 6;
        health = maxHealth;
        speed = 0.4f;
        attackDamage = 1;
        attackRange = 1.8f;
        attackCountdown = 0.5f;
    }

    protected override void Attack()
    {
        if (isStunned) return;
        if (!canAttack) return;
        animator.SetBool("IsAttacking", true);
        canAttack = false;
        Invoke("ResetAttackPossibility", attackCountdown);
    }
}
