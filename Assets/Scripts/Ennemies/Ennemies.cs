using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnnnemiesType
{
    Crabby
}

public interface Ennemies
{
    public int GetAttackDamage();
    public void ReceiveDamage(int damage);
    public void Die();
    protected void Move();
    protected void Attack();
}
