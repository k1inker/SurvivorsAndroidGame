using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;
    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(_camera).AsSingle().NonLazy();
    }
}
