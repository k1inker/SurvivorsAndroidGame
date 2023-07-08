using NTC.Global.Pool;
using System.Collections;
using UnityEngine;
using Zenject;

public class DamageableCollider : MonoBehaviour, IPoolItem
{
    [Inject] private PlayerManager _playerManager;

    [Header("Damage parametrs")]
    [SerializeField, Range(.1f,1f)] private float _rateDamage = 0.5f;
    [SerializeField] private int _damage = 1;

    private Coroutine _dealingDamageCoroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _playerManager.gameObject)
        {
            if (_dealingDamageCoroutine == null && gameObject.activeSelf)
            {
                _dealingDamageCoroutine = StartCoroutine(DealingDamage());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _playerManager.gameObject)
        {
            if (_dealingDamageCoroutine != null)
            {
                StopCoroutine(_dealingDamageCoroutine);
                _dealingDamageCoroutine = null;
            }
        }
    }
    private IEnumerator DealingDamage()
    {
        while (true)
        {
            _playerManager.playerStatsManager.TakeDamage(_damage);
            yield return new WaitForSeconds(_rateDamage);
        }
    }
    public void OnSpawn()
    {
        _dealingDamageCoroutine = null;
    }

    public void OnDespawn()
    {
        if (_dealingDamageCoroutine != null)
            StopCoroutine(_dealingDamageCoroutine);
    }
}
