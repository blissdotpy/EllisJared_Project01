using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;

    [SerializeField] public int PlayerHealth = 100;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    public int Health
    {
        get => PlayerHealth;
        set => PlayerHealth = value;
    }

    public void TakeDamage(int damageAmount)
    {
        if (PlayerHealth <= 0)
        {
            Kill();
        }
        PlayerHealth -= damageAmount;
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
