using UnityEngine;

[CreateAssetMenu(menuName = "Wave")]
public class WaveItem : ScriptableObject
{
    public int countEnemyPerWave;
    public float timeOneWave;
    public GameObject typeEnemy;
}
