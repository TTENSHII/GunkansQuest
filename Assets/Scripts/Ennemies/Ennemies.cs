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
    public void Move();
    public void Attack();
}
