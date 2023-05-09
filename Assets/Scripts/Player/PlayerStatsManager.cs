using UnityEngine;

public class PlayerStatsManager : CharacterStatsManager
{
    private PlayerManager _player;
    protected override void Awake()
    {
        base.Awake();
        _player = GetComponent<PlayerManager>();
    }
    protected override void Start()
    {
        base.Start();
        _player.uiManager.SetMaxHealthValue(maxHealth);
        _player.uiManager.SetHealthValue(currentHealth);
    }
    public override void TakeDamage(float countDamage)
    {
        base.TakeDamage(countDamage);
        _player.uiManager.SetHealthValue(currentHealth);
    }
    public override void HandlerDeath()
    {
        _player.characterAnimatorManager.PlayAnimation(ConstantName.Animation.Death);
    }
}
