using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuys : Enemies
{
    [SerializeField] private GameObject bombPrefab = null;
    [SerializeField] private GameObject keyPrefab = null;
    [SerializeField] private float guysScale = 1.617497f;
    [SerializeField] private float bombThrowForce = 10.0f;

    protected void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        direction = new Vector2(direction.x, direction.y + 0.2f);
        bomb.GetComponent<Rigidbody2D>().velocity = direction * bombThrowForce;
    }

    protected override void OnDieAnimationEnd()
    {
        GameObject key = Instantiate(keyPrefab, transform.position, Quaternion.identity);
        base.OnDieAnimationEnd();
    }

    protected override void Attack()
    {
        if (isStunned) return;
        if (!canAttack) return;
        if (player == null) return;
        if (transform.position.x < player.transform.position.x && transform.localScale.x < 0) return;
        animator.SetBool("IsAttacking", true);
        canAttack = false;
        ThrowBomb();
        Invoke("ResetAttackPossibility", attackCountdown);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-guysScale, guysScale, guysScale);
        } else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(guysScale, guysScale, guysScale);
        }
    }
}
