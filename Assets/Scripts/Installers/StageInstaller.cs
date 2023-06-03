using UnityEngine;
using Zenject;

public class StageInstaller : MonoInstaller
{
    [SerializeField] private StageEventManager _stageManager;
    public override void InstallBindings()
    {
        Container.Bind<StageEventManager>().FromInstance(_stageManager).AsSingle().NonLazy();
    }
}
