using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
    public Vector2 moveInput { get; private set; }

    [Inject] private Joystick _joystick;
    public void TickInput()
    {
        MoveInputJoystick();
    }
    private void MoveInputJoystick()
    {
        moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }
}
