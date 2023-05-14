using System;

public class PlayerStatsManager : CharacterStatsManager
{
    private PlayerManager _player;

    public Action<int> OnTakeDamagePlayer;
    protected void Awake()
    {
        _player = GetComponent<PlayerManager>();
    }
    protected override void Start()
    {
        base.Start();
        _player.uiManager.SetMaxHealthValue(maxHealth);
        _player.uiManager.SetHealthValue(currentHealth);
    }
    public override void TakeDamage(int countDamage)
    {
        base.TakeDamage(countDamage);

        OnTakeDamagePlayer?.Invoke(currentHealth);
    }
}
