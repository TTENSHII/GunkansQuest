using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Enemies
{
    [SerializeField] private Transform[] shurikenSpawnPoints = null;
    [SerializeField] private Transform[] bombSpawnPoints = null;

    [SerializeField] private GameObject ShurikenPrefab = null;
    [SerializeField] private GameObject bombPrefab = null;

    [SerializeField] private float bombThrowForce = 1f;
    [SerializeField] private float shurikenThrowForce = 1f;

    protected enum AttackType
    {
        Shuriken,
        Bomb
    }

    protected override void OnDieAnimationEnd()
    {
        base.OnDieAnimationEnd();
        GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>().LoadEndGame();
    }

    protected void ThrowBombs()
    {
        for (int i = 0; i < bombSpawnPoints.Length; i++)
        {
            GameObject bomb = Instantiate(bombPrefab, bombSpawnPoints[i].position, Quaternion.identity);
            bomb.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bombThrowForce);
        }
    }

    protected void ThrowShuriken()
    {
        for (int i = 0; i < shurikenSpawnPoints.Length; i++)
        {
            GameObject shuriken = Instantiate(ShurikenPrefab, shurikenSpawnPoints[i].position, Quaternion.identity);
            shuriken.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -shurikenThrowForce);
        }
    }

    protected AttackType GetRandomAttackType()
    {
        return (AttackType)Random.Range(0, 2);
    }

    protected override void Attack()
    {
        if (isStunned) return;
        if (!canAttack) return;
        if (player == null) return;
        if (transform.position.x < player.transform.position.x && transform.localScale.x < 0) return;

        AttackType attackType = GetRandomAttackType();
        if (attackType == AttackType.Bomb)
        {
            ThrowBombs();
        }
        else
        {
            ThrowShuriken();
        }

        animator.SetBool("IsAttacking", true);
        canAttack = false;
        Invoke("ResetAttackPossibility", attackCountdown);
    }
}
