using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 moveInput { get; private set; }

    private Joystick _joystick;
    private void Awake()
    {
        _joystick = GetComponentInChildren<Joystick>();
    }
    public void TickInput()
    {
        MoveInputJoystick();
    }
    private void MoveInputJoystick()
    {
        moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }
}
