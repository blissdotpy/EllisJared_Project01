using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBossHealthbar : MonoBehaviour
{
    public TextMeshProUGUI bossName;
    public Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        bossName = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetBossName(string name)
    {
        bossName.text = name;
    }

    public void SetUIHealthBarToActive()
    {
        slider.gameObject.SetActive(true);
        bossName.enabled = true;
    }

    public void SetHealthBarToInactive()
    {
        slider.gameObject.SetActive(false);
        bossName.enabled = false;
    }

    public void SetBossMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetBossCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
