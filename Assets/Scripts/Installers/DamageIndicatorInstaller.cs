using UnityEngine;
using Zenject;

public class DamageIndicatorInstaller : MonoInstaller
{
    [SerializeField] private DamageIndicatorUI _uiUnit;
    public override void InstallBindings()
    {
        Container.Bind<DamageIndicatorUI>().FromInstance(_uiUnit).AsSingle().NonLazy();
    }
}
