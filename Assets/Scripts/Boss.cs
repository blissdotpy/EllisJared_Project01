using System;
using UnityEngine;


public class Boss : Enemy, IDamageable
{
    private ExplodeController explodeController;

    private void Awake()
    {
        explodeController = GetComponent<ExplodeController>();
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log($"{name} took {damageAmount} damage.");
        Health -= damageAmount;
        Debug.Log($"New Health: {Health}");
        if (Health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        explodeController.Explode();
        gameObject.SetActive(false);
        Debug.Log($"{name} has died.");
    }
}
