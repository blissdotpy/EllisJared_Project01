using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIPlayerHealthbar : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        playerName = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetBossName(string name)
    {
        playerName.text = name;
    }

    public void SetUIHealthBarToActive()
    {
        slider.gameObject.SetActive(true);
        playerName.enabled = true;
    }

    public void SetHealthBarToInactive()
    {
        slider.gameObject.SetActive(false);
        playerName.enabled = false;
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
