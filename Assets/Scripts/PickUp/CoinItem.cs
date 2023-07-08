using UnityEngine;

public class CoinItem : MonoBehaviour, IPickUpable
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
