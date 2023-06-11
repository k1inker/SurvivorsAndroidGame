using UnityEngine;

public class CoinItem : MonoBehaviour, IPickUp
{
    [SerializeField] private ushort _value = 1;
    public void AnimationPickUp(PlayerManager player)
    {
        throw new System.NotImplementedException();
    }

    public void PickUpAction(PlayerManager player)
    {
        //add function coin
    }
}
