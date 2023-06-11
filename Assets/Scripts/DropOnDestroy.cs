using NTC.Global.Pool;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour, IPoolItem
{
    [SerializeField] private GameObject[] _dropItems;
    [SerializeField][Range(0f, 1f)] private float _chance = 1f;

    private bool _isQuitting = false;
    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }
    private void CheckDrop()
    {
        if (_isQuitting)
            return;

        if(Random.value < _chance)
        {
            GameObject toDrop = _dropItems[Random.Range(0, _dropItems.Length - 1)];
            NightPool.Spawn(toDrop, null, transform.position, Quaternion.identity);
        }
    }

    public void OnSpawn() { }
    public void OnDespawn()
    {
        CheckDrop();
    }
}
