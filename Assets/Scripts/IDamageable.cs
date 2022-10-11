using Unity;
using UnityEngine;

public interface IDamageable
{
    int Health { get; set; }
    public void TakeDamage(int damageAmount);
}
