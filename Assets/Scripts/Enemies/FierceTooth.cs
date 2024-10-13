using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FierceeTooth : Enemies
{
    protected override void Start()
    {
        base.Start();

        maxHealth = 4;
        health = maxHealth;
        speed = 2;
        attackDamage = 1;
        attackRange = 2;
        attackCountdown = 0.5f;
    }
}
