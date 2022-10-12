using UnityEngine;

public class EnemyMiniBossManager : MonoBehaviour
{
    public UIMiniBossHealthbar miniBossHealthbar;
    public string miniBossName;
    public MiniBoss miniBoss;

    private void Awake()
    {
        miniBossHealthbar = FindObjectOfType<UIMiniBossHealthbar>();
        miniBoss = GetComponent<MiniBoss>();
    }

    private void Start()
    {
        miniBossHealthbar.SetUIHealthBarToActive();
        miniBossHealthbar.SetBossName(miniBossName);
        miniBossHealthbar.SetBossMaxHealth(miniBoss.MaxHealth);
    }
}
