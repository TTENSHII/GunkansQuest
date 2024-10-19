using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : Enemies
{
    protected override void Start()
    {
        base.Start();

        maxHealth = 5;
        health = maxHealth;
        speed = 1.5f;
        attackDamage = 1;
        attackRange = 1.8f;
        attackCountdown = 0.6f;
    }
}
