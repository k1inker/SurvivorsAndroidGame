using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class StageEvent : ScriptableObject
{
    public float time;
    public GameObject enemyType;
    public int countEnemy;

    public bool isRepeatedEvent;
    public float reapeatEverySeconds;
    public int countRepeat;

    public StageEvent(float time, GameObject enemyType, int countEnemy, bool isRepeatedEvent, float reapeatEverySeconds, int countRepeat)
    {
        this.time = time;
        this.enemyType = enemyType;
        this.countEnemy = countEnemy;
        this.isRepeatedEvent = isRepeatedEvent;
        this.reapeatEverySeconds = reapeatEverySeconds;
        this.countRepeat = countRepeat;
    }
}
