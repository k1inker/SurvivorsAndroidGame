using UnityEngine;

public class EnemyStatsManager : CharacterStatsManager
{
    public delegate void OnDamageEnemy(int damageCount);
    public event OnDamageEnemy onDamageEnemy;
    protected override void Awake()
    {
        base.Awake();
    }
    public override void TakeDamage(int countDamage)
    {
        base.TakeDamage(countDamage);
        onDamageEnemy?.Invoke(countDamage);
    }
    public override void HandlerDeath()
    {
        base.HandlerDeath();
    }
}
