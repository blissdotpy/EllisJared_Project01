using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossManager : MonoBehaviour
{
    public UIBossHealthbar bossHealthBar;
    public string bossName;
    public Enemy enemy;

    private void Awake()
    {
        bossHealthBar = FindObjectOfType<UIBossHealthbar>();
        enemy = GetComponent<EnemyAI>();
    }

    private void Start()
    {
        bossHealthBar.SetUIHealthBarToActive();
        bossHealthBar.SetBossName(bossName);
        bossHealthBar.SetBossMaxHealth(enemy.maxHealth);
    }
}
