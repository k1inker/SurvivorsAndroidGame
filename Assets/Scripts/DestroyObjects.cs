using NTC.Global.Pool;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [SerializeField] private bool _isDestroyByTime;
    [SerializeField] private float _timeAlive;
    [SerializeField] private bool _isPoolObject;
    private void Awake()
    {
        _timeAlive = Time.time + _timeAlive;
    }
    private void OnEnable()
    {
        _timeAlive = Time.time + _timeAlive;
    }
    private void FixedUpdate()
    {
        if(Time.time > _timeAlive && _isDestroyByTime)
        {
            DestroyObject();
        }
    }
    public void DestroyObject()
    {
        if (_isPoolObject)
        {
            NightPool.Despawn(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
