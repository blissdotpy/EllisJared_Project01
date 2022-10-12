using System;
using System.Threading;
using UnityEngine;


public class Player : PlayerManager
{
    public event Action<int> EnemyDamage;

    public void OnEnemyDamage()
    {
        EnemyDamage?.Invoke(10);
    }
}
