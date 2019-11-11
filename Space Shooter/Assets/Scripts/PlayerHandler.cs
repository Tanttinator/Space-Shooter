using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler instance;

    public GameObject player;
    public Vector2 spawnPoint;

    public GameObjectEvent onSpawnPlayer;
    public FloatFloatEvent onPlayerHealthChanged;
    public FloatFloatEvent onPlayerShieldChanged;
    public FloatFloatEvent onPlayerEnergyChanged;

    public static Ship playerShip;

    void SpawnPlayer()
    {
        GameObject obj = Instantiate(player, spawnPoint, Quaternion.identity);
        playerShip = obj.GetComponent<Ship>();

        playerShip.health.onHealthChanged += OnHealthChanged;
        playerShip.health.onShieldCapacityChanged += OnShieldChanged;
        playerShip.onEnergyChanged += OnEnergyChanged;

        onSpawnPlayer?.Invoke(obj);
    }

    void OnHealthChanged(float health, float maxHealth)
    {
        onPlayerHealthChanged?.Invoke(health, maxHealth);
    }

    void OnShieldChanged(float capacity, float maxCapacity)
    {
        onPlayerShieldChanged?.Invoke(capacity, maxCapacity);
    }

    void OnEnergyChanged(float capacity, float maxCapacity)
    {
        onPlayerEnergyChanged?.Invoke(capacity, maxCapacity);
    }

    private void Start()
    {
        SpawnPlayer();
    }
}
