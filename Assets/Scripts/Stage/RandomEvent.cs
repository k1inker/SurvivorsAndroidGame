using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Events/RandomEvents")]
public class RandomEvent : StageEvent
{
    public int likeHood;
    public override void StartEvent(Vector3[] spawnPositions, DiContainer container = null)
    {
        if(Random.Range(0,100) < likeHood)
            base.StartEvent(spawnPositions, container);
    }
}
