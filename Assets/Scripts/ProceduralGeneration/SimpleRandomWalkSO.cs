using UnityEngine;

[CreateAssetMenu(fileName ="RandomWalkParameters_", menuName ="ProceduralGeneration/RandomWalk")]
public class SimpleRandomWalkSO : ScriptableObject
{
    public int iterations = 10, walkLength = 10;
    public bool startRandomlyEachIteration = true;
}
