using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class StageEvent
{
    public float time;
    public GameObject enemyType;
    public int countEnemy;

    public bool isRepeatedEvent;
    public float reapeatEverySeconds;
    public int countRepeat;
}
