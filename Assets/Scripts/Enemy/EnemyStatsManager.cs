using UnityEngine;

public class EnemyStatsManager : CharacterStatsManager
{
    private void Awake()
    {
        
    }
    public override void TakeDamage(float countDamage)
    {
        base.TakeDamage(countDamage);
    }
    public override void HandlerDeath()
    {
        base.HandlerDeath();
    }
}
