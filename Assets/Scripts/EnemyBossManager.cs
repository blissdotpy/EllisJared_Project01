using UnityEngine;

public class EnemyBossManager : MonoBehaviour
{
    public UIBossHealthbar bossHealthBar;
    public string bossName;
    public Boss boss;

    private void Awake()
    {
        bossHealthBar = FindObjectOfType<UIBossHealthbar>();
        boss = GetComponent<Boss>();
    }

    private void Start()
    {
        bossHealthBar.SetUIHealthBarToActive();
        bossHealthBar.SetBossName(bossName);
        bossHealthBar.SetBossMaxHealth(boss.MaxHealth);
    }
}
