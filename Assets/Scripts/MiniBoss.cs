using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : Enemy
{
    private EnemyMiniBossManager miniBossManager;

    private void Awake()
    {
        miniBossManager = GetComponent<EnemyMiniBossManager>();
    }

    protected override void Kill()
    {
        miniBossManager.miniBossHealthbar.SetHealthBarToInactive();
        Debug.Log($"{name} has died.");
        Destroy(gameObject);
    }
    
    public override void TakeDamage(int damageAmount)
    {
        Debug.Log($"{name} took {damageAmount} damage.");
        Health -= damageAmount;
        miniBossManager.miniBossHealthbar.SetBossCurrentHealth(Health);
        Debug.Log($"New Health: {Health}");
        if (Health <= 0)
        {
            Kill();
        }
    }
}
