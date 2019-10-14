using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    private void Awake()
    {
        instance = this;
    }
}

[System.Serializable]
public class GameObjectEvent : UnityEvent<GameObject>
{

}

[System.Serializable]
public class FloatFloatEvent : UnityEvent<float, float>
{

}
