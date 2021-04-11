using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public PoolObject prefab { get; }
    public bool autoExpand { get; set; }
    public Transform objectParent { get; }

    public List<PoolObject> pool { get; protected set; }

    public Pool(PoolObject prefab, int count, bool autoExpand = false)
    {
        this.prefab = prefab;
        this.objectParent = null;

        CreatePool(count);
    }

    public Pool(PoolObject prefab, int count, Transform parent, bool autoExpand = false)
    {
        this.prefab = prefab;
        this.objectParent = parent;

        this.autoExpand = autoExpand;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        pool = new List<PoolObject>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private PoolObject CreateObject(bool isActiveByDefault = false)
    {
        PoolObject createdObject = Object.Instantiate(prefab, objectParent);
        createdObject.gameObject.SetActive(isActiveByDefault);

        pool.Add(createdObject);

        return createdObject;
    }

    public bool HasFreeElement(out PoolObject element)
    {

        foreach (var item in pool)
        {
            if(item.gameObject.activeInHierarchy == false)
            {
                element = item;
                element.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public PoolObject GetFreeElement()
    {
        if(HasFreeElement(out PoolObject element))
            return element;

        if (autoExpand)
            return CreateObject();

        throw new System.Exception($"There is no free elements in pool of type {typeof(PoolObject)}");
            
    }
}
