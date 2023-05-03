using UnityEngine;

public class PlayerStatsManager : CharacterStatsManager
{
    private PlayerManager _player;
    private void Awake()
    {
        _player = GetComponent<PlayerManager>();
    }
    public override void TakeDamage(float countDamage)
    {
        base.TakeDamage(countDamage);
    }
    public override void HandlerDeath()
    {

    }
}
