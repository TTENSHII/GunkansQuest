using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnnnemiesType
{
    Crabby
}

public interface Enemies
{
    public int GetAttackDamage();
    public void ReceiveDamage(int damage);
    public void Die();
    public void Move();
    public void Attack();
}
