using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InputHandler inputHandler { get; private set; }
    public PlayerLocomotion playerLocomotion { get; private set; }
    public PlayerAnimatorManager playerAnimatorManager { get; private set; }
    public PlayerStatsManager playerStatsManager { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; } 
    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerStatsManager = GetComponent<PlayerStatsManager>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        inputHandler.TickInput();
    }
    private void FixedUpdate()
    {
        playerLocomotion.HandelMovment(inputHandler.moveInput.normalized);
    }
}
