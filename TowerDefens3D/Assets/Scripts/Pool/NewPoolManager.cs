using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPoolManager : MonoBehaviour
{
    [SerializeField] private List<PoolPart> poolObjects;
    private static List<PoolPart> _poolObjects;

    [System.Serializable]
    class PoolPart
    {
        public bool autoExpand;

        public PoolObject prefab;
        public int count;
        public Pool pool;
        public string name;
    }

    private void Awake()
    {
        _poolObjects = poolObjects;

        GameObject parent = new GameObject("Pool");

        for (int i = 0; i < _poolObjects.Count; i++)
        {
            _poolObjects[i].pool = new Pool(_poolObjects[i].prefab, _poolObjects[i].count, parent.transform, true);
            _poolObjects[i].name = _poolObjects[i].prefab.name;
        }
    }

    public static PoolObject GetObject(string name, Vector3 position, Quaternion rotation)
    {
        PoolObject result = null;
        Pool pool = GetPool(name);

        result = pool.GetFreeElement();
        result.transform.position = position;
        result.transform.rotation = rotation;

        return result;
    }

    private static Pool GetPool(string name)
    {
        foreach (PoolPart item in _poolObjects)
        {
            if(string.Compare(item.prefab.name, name) == 0)
            {
                return item.pool;
            }
        }

        return null;
    }
}
