using NTC.Global.Pool;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName ="Events/RegularEvent")]
public class RegularEvent : StageEvent
{
    public float time;

    [Header("Repeated settings")]
    public bool isRepeatedEvent;
    public float reapeatEverySeconds;
    public int countRepeat;
    public RegularEvent(float time, GameObject spawnObject, int countObject, bool isRepeatedEvent, float reapeatEverySeconds, int countRepeat)
    {
        this.time = time;
        this.spawnObject = spawnObject;
        this.countObject = countObject;
        this.isRepeatedEvent = isRepeatedEvent;
        this.reapeatEverySeconds = reapeatEverySeconds;
        this.countRepeat = countRepeat;
    }
    public RegularEvent CreateNewStage(float timeNextEvent)
    {
        int newCountRepeat = countRepeat - 1;
        RegularEvent newStage = new RegularEvent(timeNextEvent, spawnObject,
            countObject, isRepeatedEvent,
            reapeatEverySeconds, newCountRepeat);
        return newStage;
    }
}
