using UnityEngine;

public class EnemyStatsManager : CharacterStatsManager
{
    protected override void Awake()
    {
        base.Awake();
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
