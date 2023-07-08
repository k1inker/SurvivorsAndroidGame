using System;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int maxHealth;

    public int armor;

    public Action<string> OnTakeDamageCharacter;
    public Action<string> OnDeathCharacter;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    public virtual void TakeDamage(int countDamage)
    {
        ApplyArmor(ref countDamage);

        currentHealth -= countDamage;

        if (currentHealth > 0)
        {
            OnTakeDamageCharacter?.Invoke(ConstantName.Animation.Damage);
            return;
        }

        currentHealth = 0;
        HandlerDeath();
    }
    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if(damage < 0) { damage = 0;}
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
    protected virtual void HandlerDeath()
    {
        OnDeathCharacter?.Invoke(ConstantName.Animation.Death);
    }
}
