using UnityEngine;
using System.Collections.Generic;


[AddComponentMenu("Pool/ObjectPooling")]
public class ObjectPooling
{
    #region Data
    private List<PoolObject> _poolObjects;
    private Transform _objectParent;
    #endregion

    public void Initialize(int count, PoolObject sample, Transform objectParent)
    {
        _poolObjects = new List<PoolObject>();
        _objectParent = objectParent;

        for (int i = 0; i < count; i++)
        {
            AddObject(sample, objectParent);
        }
    }

    public PoolObject GetObject()
    {
        for (int i = 0; i < _poolObjects.Count; i++)
        {
            PoolObject pool = _poolObjects[i];

            if (pool != null & pool.gameObject.activeInHierarchy == false)
            {
                return pool;
            }
        }

        AddObject(_poolObjects[0], _objectParent);
        return _poolObjects[_poolObjects.Count - 1];
    }

    private void AddObject(PoolObject sample, Transform objectParent)
    {
        GameObject temp = GameObject.Instantiate(sample.gameObject);
        temp.name = sample.name;
        temp.transform.SetParent(objectParent);

        _poolObjects.Add(temp.GetComponent<PoolObject>());

        temp.SetActive(false);
    }
}
