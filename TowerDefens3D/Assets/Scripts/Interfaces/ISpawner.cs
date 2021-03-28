using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
    IEnumerator Spawn(Transform _parent);
}
