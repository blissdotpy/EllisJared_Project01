using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public int maxHealth;
    [SerializeField] protected int health;

    public int Health
    {
        get => health;
        set => health = value;
    }

    public virtual void TakeDamage(int damageAmount)
    {
        Debug.Log($"{name} took {damageAmount} damage.");
        Health -= damageAmount;
        Debug.Log($"New Health: {Health}");
        if (Health <= 0)
        {
            Kill();
        }
    }

    private void Awake()
    {
        health = maxHealth;
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
        Debug.Log($"{name} has died.");
    }
}
