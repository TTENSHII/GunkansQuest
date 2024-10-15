using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuys : Enemies
{
    [SerializeField] private GameObject bombPrefab = null;
    [SerializeField] private float guysScale = 1.617497f;
    [SerializeField] private float bombThrowForce = 25.0f;

    protected void ThrowBomb()
    {
        if (player == null) return;
        GameObject shuriken = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        shuriken.GetComponent<Rigidbody2D>().velocity = direction * bombThrowForce;
    }

    protected override void Attack()
    {
        Debug.Log("BigGuys Attack");
        if (isStunned) return;
        if (!canAttack) return;
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
