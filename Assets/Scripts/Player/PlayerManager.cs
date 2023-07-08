using UnityEngine;

#region RequireComponent
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(PlayerStatsManager))]
[RequireComponent(typeof(PlayerLevelManager))]
[RequireComponent(typeof(PlayerWeaponManager))]
[RequireComponent(typeof(PassiveItem))]
#endregion
public class PlayerManager : MonoBehaviour
{
    public InputHandler inputHandler { get; private set; }
    public CharacterMovement playerLocomotion { get; private set; }
    public PlayerStatsManager playerStatsManager { get; private set; }
    public PlayerLevelManager playerLevelManager { get; private set; }
    public PlayerWeaponManager playerWeaponManager { get; private set; }
    public PassiveItem passiveItem { get; private set; }
    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        playerLocomotion = GetComponent<CharacterMovement>();
        playerStatsManager = GetComponent<PlayerStatsManager>();
        playerLevelManager = GetComponent<PlayerLevelManager>();
        playerWeaponManager = GetComponent<PlayerWeaponManager>();
        passiveItem = GetComponent<PassiveItem>();
    }
    private void Update()
    {
        inputHandler.TickInput();
    }
    private void FixedUpdate()
    {
        playerLocomotion.HandelMovment(inputHandler.moveInput.normalized);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPickUpable pickUp))
        {
            pickUp.PickUpAction(this);
        }
    }
}
