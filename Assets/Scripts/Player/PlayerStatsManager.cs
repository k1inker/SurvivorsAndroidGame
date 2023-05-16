using System;

public class PlayerStatsManager : CharacterStatsManager
{
    public Action<int> OnHealthChange;
    public Action<int> OnMaxHealthChange;
    protected override void Start()
    {
        base.Start();
        OnMaxHealthChange?.Invoke(maxHealth);
        OnHealthChange?.Invoke(currentHealth);
    }
    public override void TakeDamage(int countDamage)
    {
        base.TakeDamage(countDamage);

        OnHealthChange?.Invoke(currentHealth);
    }
}
