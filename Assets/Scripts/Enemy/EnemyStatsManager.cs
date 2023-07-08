using NTC.Global.Pool;
using System;
using UnityEngine;
using Zenject;
public class EnemyStatsManager : CharacterStatsManager, IDamageable, IPoolItem
{
    [Inject] private DamageIndicatorUI _indicator;
    [Inject] private StageEventManager _stageEvent;

    [SerializeField] private float progressTimeRate = 30f;
    [SerializeField] private float progressPerSplit = .2f;
    private float _progress
    {
        get
        {
            return _time / progressTimeRate * progressPerSplit;
        }
    }
    private float _time;

    public Action OnEnemyDeath;
    private void Awake()
    {
        _stageEvent.OnTimeChange += (time) => _time = time;
    }
    public void ApplyProgress()
    {
        maxHealth = maxHealth + (int)(maxHealth * _progress);
    }
    public override void TakeDamage(int countDamage)
    {
        if (currentHealth <= 0)
            return;

        _indicator.SpawnIndicator(transform.position, countDamage);
        base.TakeDamage(countDamage);
    }
    protected override void HandlerDeath()
    {
        base.HandlerDeath();
        OnEnemyDeath?.Invoke();
        NightPool.Despawn(this);
    }
    public void OnSpawn()
    {
        ApplyProgress();
        currentHealth = maxHealth;
    }
    public void OnDespawn()
    {

    }
}
