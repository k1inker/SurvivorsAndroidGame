using DG.Tweening;
using NTC.Global.Pool;
using UnityEngine;

public class LevelItem : PickUpItem, IPickUp, IPoolItem
{
    public override void AnimationPickUp(PlayerManager player)
    {
        DOTween.Sequence()
            .Append(transform.DOMove(player.transform.position, 0.5f))
            .Join(transform.DOScale(new Vector3(0, 0, 0), 0.5f))
            .AppendCallback(() => NightPool.Despawn(this, 0.5f));
    }

    public void OnDespawn()
    {
        transform.localScale = new Vector3(3, 3, 3);
    }

    public void OnSpawn()
    {
        isPickedUp = false;
    }

    public override void PickUpAction(PlayerManager player)
    {
        if (!isPickedUp)
        {
            isPickedUp = true;
            player.playerLevelManager.IncreaseExperienceValue(value);
            AnimationPickUp(player);
        }
    }
}
