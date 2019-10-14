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

    public static Ship playerShip;

    void SpawnPlayer()
    {
        GameObject obj = Instantiate(player, spawnPoint, Quaternion.identity);
        playerShip = obj.GetComponent<Ship>();

        playerShip.health.onHealthChanged += OnHealthChanged;
        playerShip.health.onShieldCapacityChanged += OnShieldChanged;

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

    private void Start()
    {
        SpawnPlayer();
    }
}
