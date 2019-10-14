using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Faction", menuName = "Faction")]
public class Faction : ScriptableObject
{

    new public string name = "Faction";
    [SerializeField] List<Faction> enemies;
    [SerializeField] List<Faction> allies;

    public void AddEnemy(Faction other)
    {
        allies.Remove(other);
        enemies.Add(other);
    }

    public void AddAlly(Faction other)
    {
        enemies.Remove(other);
        allies.Add(other);
    }

    public bool IsEnemy(Faction other)
    {
        return enemies.Contains(other);
    }

    public bool IsAlly(Faction other)
    {
        return allies.Contains(other);
    }
}
