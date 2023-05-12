using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected int damage;
    protected bool isThrough;
    protected bool isPushBack;
    protected float pushBackForce;
    public void SettingsProjectile(int damage,bool isThrough, bool isPushBack, float pushBackForce, float timeAlive)
    {
        this.damage = damage;
        this.isThrough = isThrough;
        this.isPushBack = isPushBack;
        this.pushBackForce = pushBackForce;
        DestoyTimer(timeAlive);
    }
    private void DestoyTimer(float time)
    {
        Invoke(nameof(DestoyProjectile), time);
    }
    protected void DestoyProjectile()
    {
        Destroy(gameObject);
    }
}
