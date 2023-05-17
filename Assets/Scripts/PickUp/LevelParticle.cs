using UnityEngine;

public class LevelParticle : MonoBehaviour, IPickUp
{
    [SerializeField] private ushort value;

    public void PickUpAction(PlayerManager player)
    {
        player.playerLevelManager.IncreaseExperienceValue(value);
    }
}
