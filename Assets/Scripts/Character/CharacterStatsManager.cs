using System;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int maxHealth;

    public Action<string> OnTakeDamageCharacter;
    public Action<string> OnDeathCharacter;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    public virtual void TakeDamage(int countDamage)
    {
        if (currentHealth - countDamage > 0)
        {
            currentHealth -= countDamage;
            OnTakeDamageCharacter?.Invoke(ConstantName.Animation.Damage);
            return;
        }

        currentHealth = 0;
        HandlerDeath();
    }
    public virtual void HealHealth(int countHeal)
    {
        if(currentHealth + countHeal >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += countHeal;
        }
    }
    public virtual void HandlerDeath()
    {
        OnDeathCharacter?.Invoke(ConstantName.Animation.Death);
    }
}
