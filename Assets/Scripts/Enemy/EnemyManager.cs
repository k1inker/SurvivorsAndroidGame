using UnityEngine;
using Zenject;

[RequireComponent(typeof(EnemyStatsManager))]
[RequireComponent(typeof(CharacterMovement))]
public class EnemyManager : MonoBehaviour
{
    public EnemyStatsManager enemyStats { get; private set; }
    public CharacterMovement enemyLocomotion { get; private set; }

    [Header("Information Target")]
    [SerializeField] [Inject] private PlayerManager _currentTarget;
    [SerializeField] private Vector2 _targetVector;

    private void Awake()
    {
        enemyStats = GetComponent<EnemyStatsManager>();
        enemyLocomotion = GetComponent<CharacterMovement>();
    }
    private void OnEnable()
    {
        enemyStats.OnEnemyDeath += DeathingHandler;
    }
    private void OnDisable()
    {
        enemyStats.OnEnemyDeath -= DeathingHandler;
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
