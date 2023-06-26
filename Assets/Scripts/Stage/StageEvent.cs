using NTC.Global.Pool;
using UnityEngine;
using Zenject;

public abstract class StageEvent : ScriptableObject
{
    [Header("General Settings")]
    public GameObject spawnObject;
    public int countObject;
    public virtual void StartEvent(Vector3[] spawnPositions, DiContainer container = null)
    {
        foreach (var position in spawnPositions)
        {
            NightPool.Spawn(spawnObject, container, position, Quaternion.identity);
        }
    }
}
