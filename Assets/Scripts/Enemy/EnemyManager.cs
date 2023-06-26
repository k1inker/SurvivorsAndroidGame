using System.Collections;
using UnityEngine;
using Zenject;

public class EnemyManager : CharacterManager
{
    public EnemyStatsManager enemyStats { get; private set; }
    public EnemyLocomotionManager enemyLocomotion { get; private set; }

    [Header("Information Target")]
    [SerializeField] [Inject] private PlayerManager _currentTarget;
    [SerializeField] private Vector2 _targetVector;

    protected override void Awake()
    {
        base.Awake();
        enemyStats = GetComponent<EnemyStatsManager>();
        enemyLocomotion = GetComponent<EnemyLocomotionManager>();
    }
    private void Start()
    {
        enemyStats.OnEnemyDeath += DeathingHandler;
    }
    private void FixedUpdate()
    {
        enemyLocomotion.HandelMovment(_targetVector);
    }
    private void LateUpdate()
    {
        UpdateInfoTarget();
    }
    private void UpdateInfoTarget()
    {
        if(_currentTarget != null)
        {
            _targetVector = _currentTarget.transform.position - transform.position;
            _targetVector.Normalize();
        }
    }
    public void DeathingHandler()
    {
        _targetVector = Vector2.zero;
    }
}
