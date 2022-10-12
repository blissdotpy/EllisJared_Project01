using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.AssetImporters;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] public int maxHealth;
    [SerializeField] protected int health;
    [SerializeField] public CameraShake cameraShake;


    public int Health
    {
        get => health;
        set => health = value;
    }

    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public virtual void TakeDamage(int damageAmount)
    {
        Debug.Log($"{name} took {damageAmount} damage.");
        Health -= damageAmount;
        StartCoroutine(cameraShake.Shake(.15f, .14f));
        Debug.Log($"New Health: {Health}");
        if (Health <= 0)
        {
            Kill();
        }
    }

    protected virtual void Kill()
    {
        Destroy(gameObject);
        Debug.Log($"{name} has died.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        if (player != null)
        {
            player.OnEnemyDamage();
        }
    }
}
