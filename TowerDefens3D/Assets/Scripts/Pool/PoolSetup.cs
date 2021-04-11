using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Pool/PoolSetup")]
public class PoolSetup : MonoBehaviour
{
    [SerializeField] private PoolManager.PoolPart[] _pools;

    private void OnValidate()
    {
        for (int i = 0; i < _pools.Length; i++)
        {
            _pools[i].name = _pools[i].prefab.name;
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        PoolManager.Initialize(_pools);
    }

}
