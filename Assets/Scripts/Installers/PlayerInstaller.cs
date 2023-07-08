using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerManager _playerUnit;
    public override void InstallBindings()
    {
        Container.Bind<PlayerManager>().FromInstance(_playerUnit).AsSingle().NonLazy();
        Container.QueueForInject(_playerUnit);
    }
}
