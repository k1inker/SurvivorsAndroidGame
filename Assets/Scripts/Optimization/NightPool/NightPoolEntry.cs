// ----------------------------------------------------------------------------
// The MIT License
// NightPool is an object pool for Unity https://github.com/MeeXaSiK/NightPool
// Copyright (c) 2021-2022 Night Train Code
// ----------------------------------------------------------------------------

using UnityEngine;
using Zenject;

namespace NTC.Global.Pool
{
    public class NightPoolEntry : MonoBehaviour
    {
        [SerializeField] private PoolPreset poolPreset;
        [Inject] private DiContainer _diContainer;
        private void Awake()
        {
            NightPool.InstallPoolItems(poolPreset, _diContainer);
        }

        private void OnDestroy()
        {
            NightPool.Reset();
        }
    }
}