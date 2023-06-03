using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class StageEvent
{
    public float time;
    public GameObject enemyType;
    public int countEnemy;
}
[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvents;

}
