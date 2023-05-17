using UnityEngine;
using Zenject;

public class JoystickInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystickUnit;
    public override void InstallBindings()
    {
        Container.Bind<Joystick>().FromInstance(_joystickUnit).AsSingle().NonLazy();
    }
}
