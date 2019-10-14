﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    public GameObject player;
    public Vector2 spawnPoint;
    
    public GameObjectEvent onSpawnPlayer;

    public static Ship playerShip;

    void SpawnPlayer()
    {
        GameObject obj = Instantiate(player, spawnPoint, Quaternion.identity);
        playerShip = obj.GetComponent<Ship>();
        onSpawnPlayer?.Invoke(obj);
    }

    private void Awake()
    {
        Debug.Log("GameHandler::Awake");
        instance = this;
    }

    private void Start()
    {
        SpawnPlayer();
    }
}

[System.Serializable]
public class GameObjectEvent : UnityEvent<GameObject>
{

}
