﻿// ----------------------------------------------------------------------------
// The MIT License
// NightPool is an object pool for Unity https://github.com/MeeXaSiK/NightPool
// Copyright (c) 2021-2022 Night Train Code
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace NTC.Global.Pool
{
    [DisallowMultipleComponent]
    public class Pool : MonoBehaviour
    {
        public GameObject Prefab { get; private set; }
        public Transform PoolablesParent { get; private set; }
        
        public IReadOnlyList<Poolable> Poolables => pooledGameObjects;

        private readonly List<Poolable> pooledGameObjects = new List<Poolable>(64);
        
        private bool isSetup;
        public void Setup(GameObject prefab, Transform parent)
        {
            if (isSetup) return;

            Prefab = prefab;
            PoolablesParent = parent;
            
            isSetup = true;
        }
        
        public Poolable GetFreeObject(DiContainer container)
        {
            if (pooledGameObjects.Count > 0)
            {
                var poolable = pooledGameObjects[0];

                pooledGameObjects.RemoveAt(0);
                
                return poolable;
            }

            if (container != null)
            {
                return DiInstantiateObjectInThisPool(container);
            }

            return InstantiateObjectInThisPool();
        }

        public void PopulatePool(int count, bool isUseDiContainer, DiContainer container)
        {
            if(isUseDiContainer)
            {
                for (var i = 0; i < count; i++)
                {
                    IncludePoolable(DiInstantiateObjectInThisPool(container));
                }
                return;
            }

            for (var i = 0; i < count; i++)
            {
                IncludePoolable(InstantiateObjectInThisPool());
            }
        }

        public void IncludePoolable(Poolable poolable)
        {
            if (Prefab != poolable.Prefab)
            {
#if DEBUG
                Debug.LogError("You tries to include object from other pool!");
#endif
                return;
            }

            if (pooledGameObjects.Contains(poolable) == false)
            {
                pooledGameObjects.Add(poolable);
            }
        }
        
        public void ExcludePoolable(Poolable poolable)
        {
            if (Prefab != poolable.Prefab)
            {
#if DEBUG
                Debug.LogError("You tries to exclude object from other pool!");
#endif
                return;
            }

            pooledGameObjects.Remove(poolable);
        }
        
        private Poolable InstantiateObjectInThisPool()
        {
            var newPoolable = Instantiate(Prefab, PoolablesParent).AddComponent<Poolable>();
            
            newPoolable.Setup(this, Prefab, false, false);

            return newPoolable;
        }
        private Poolable DiInstantiateObjectInThisPool(DiContainer container)
        {
            var newPoolable = container.InstantiatePrefab(Prefab, PoolablesParent).AddComponent<Poolable>();
            
            newPoolable.Setup(this, Prefab, false, true);

            return newPoolable;
        }
    }
}