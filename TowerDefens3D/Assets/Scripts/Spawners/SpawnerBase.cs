using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class SpawnerBase : ScriptableObject, ISpawner
{
    public virtual IEnumerator Spawn(Transform _parent)
    {
        yield return null;
    }
}
