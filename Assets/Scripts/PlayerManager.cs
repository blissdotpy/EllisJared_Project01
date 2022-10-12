using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    public CameraShake cameraShake;
    public PlayerManager playerManager;

    public UIPlayerHealthbar playerHealthbar;
    public string playerName;
    public Player player;

    [SerializeField] public int PlayerHealth = 100;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerHealthbar = FindObjectOfType<UIPlayerHealthbar>();
        player = GetComponent<Player>();
    }

    private void Start()
    {
        playerHealthbar.SetUIHealthBarToActive();
        playerHealthbar.SetBossName(playerName);
        playerHealthbar.SetBossMaxHealth(player.PlayerHealth);
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
        Debug.Log($"{name} took {damageAmount} damage.");
        Health -= damageAmount;
        //StartCoroutine(cameraShake.Shake(.15f, .14f));

        playerHealthbar.SetBossCurrentHealth(Health);
        Debug.Log($"New Health: {Health}");
        if (Health <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        player.EnemyDamage += OnEnemyDamage;
    }

    private void OnDisable()
    {
        player.EnemyDamage -= OnEnemyDamage;
    }

    private void OnEnemyDamage(int damage)
    {
        TakeDamage(damage);
    }
}
