using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMiniBossHealthbar : MonoBehaviour
{
    public TextMeshProUGUI miniBossName;
    public Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        miniBossName = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetHealthBarToInactive();
    }

    public void SetBossName(string name)
    {
        miniBossName.text = name;
    }

    public void SetUIHealthBarToActive()
    {
        slider.gameObject.SetActive(true);
        miniBossName.enabled = true;
    }

    public void SetHealthBarToInactive()
    {
        slider.gameObject.SetActive(false);
        miniBossName.enabled = false;
    }

    public void SetBossMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth * 8;
        slider.value = maxHealth * 8;
    }

    public void SetBossCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth * 8;
    }
}
