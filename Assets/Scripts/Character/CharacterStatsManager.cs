using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float maxHealth;

    public virtual void TakeDamage(float countDamage)
    {
        if (currentHealth - countDamage > 0)
        {
            currentHealth -= countDamage;
        }
        else
        {
            currentHealth = 0;
            HandlerDeath();
        }
    }
    public virtual void HandlerDeath()
    {
        Invoke(nameof(gameObject.Destroy), 2f);
    }
}
