using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
    private static PoolPart[] _pools;
    private static GameObject _objectParent;

    [System.Serializable]
    public struct PoolPart
    {
        public string name;
        public PoolObject prefab;
        public int count;
        public ObjectPooling ferula;
    }


    public static void Initialize(PoolPart[] newPools)
    {
        _pools = newPools;

        _objectParent = new GameObject("Pool");

        for (int i = 0; i < _pools.Length; i++)
        {
            ref PoolPart pool = ref _pools[i];

            if(_pools[i].prefab != null)
            {
                pool.ferula = new ObjectPooling();
                pool.ferula.Initialize(pool.count, pool.prefab, _objectParent.transform);
            }
        }
    }

    public static GameObject GetObject(string name, Vector3 position, Quaternion rotation)
    {
        GameObject result = null;

        if (_pools != null)
        {
            for (int i = 0; i < _pools.Length; i++)
            {
                ref PoolPart pool = ref _pools[i];
                if(string.Compare(pool.prefab.name, name) == 0)
                {
                    result = pool.ferula.GetObject().gameObject;
                    result.transform.position = position;
                    result.transform.rotation = rotation;

                    result.transform.SetParent(_objectParent.transform);

                    result.SetActive(true);
                    return result;
                }
            }
        }

        return result;
    }
}
