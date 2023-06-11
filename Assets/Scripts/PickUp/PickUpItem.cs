using UnityEngine;

public abstract class PickUpItem : MonoBehaviour, IPickUp
{
    [SerializeField] protected bool isPickedUp = false;

    [SerializeField] protected ushort value = 60;

    public abstract void AnimationPickUp(PlayerManager player);
    public abstract void PickUpAction(PlayerManager player);
}
