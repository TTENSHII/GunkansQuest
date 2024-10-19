using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : Enemies
{
    protected override void Start()
    {
        base.Start();

        maxHealth = 3;
        health = maxHealth;
        speed = 0.5f;
        attackDamage = 1;
        attackRange = 1.8f;
        attackCountdown = 0.5f;
    }
}
