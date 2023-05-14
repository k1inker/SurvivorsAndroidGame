using UnityEngine;
using Zenject;

public class DamageIndicatorInstaller : MonoInstaller
{
    [SerializeField] private UIDamageIndicator _uiUnit;
    public override void InstallBindings()
    {
        Container.Bind<UIDamageIndicator>().FromInstance(_uiUnit).AsSingle().NonLazy();
    }
}
