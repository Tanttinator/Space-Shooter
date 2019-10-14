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

    public static Ship playerShip;

    void SpawnPlayer()
    {
        GameObject obj = Instantiate(player, spawnPoint, Quaternion.identity);
        playerShip = obj.GetComponent<Ship>();
        Health h = obj.GetComponent<Health>();
        h.onHealthChanged += OnHealthChanged;
        OnHealthChanged(h.health, h.hull.maxHealth);
        onSpawnPlayer?.Invoke(obj);
    }

    void OnHealthChanged(float health, float maxHealth)
    {
        onPlayerHealthChanged?.Invoke(health, maxHealth);
    }

    private void Start()
    {
        SpawnPlayer();
    }
}
