using System;
using UnityEngine;


public class Boss : Enemy
{
    private ExplodeController explodeController;
    private EnemyBossManager enemyBossManager;

    private void Awake()
    {
        explodeController = GetComponent<ExplodeController>();
        enemyBossManager = GetComponent<EnemyBossManager>();
    }

    public override void Kill()
    {
        explodeController.Explode();
        enemyBossManager.bossHealthBar.SetHealthBarToInactive();
        Debug.Log($"{name} has died.");
    }
    
    public override void TakeDamage(int damageAmount)
    {
        Debug.Log($"{name} took {damageAmount} damage.");
        Health -= damageAmount;
        enemyBossManager.bossHealthBar.SetBossCurrentHealth(Health);
        Debug.Log($"New Health: {Health}");
        if (Health <= 0)
        {
            Kill();
        }
    }
}
