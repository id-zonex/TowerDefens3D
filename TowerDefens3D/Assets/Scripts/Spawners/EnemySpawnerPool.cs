using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerPool", menuName = "EnemySpawnerPool")]
public class EnemySpawnerPool : InfinityRandomSpawner
{
    public override IEnumerator Spawn(Transform _parent)
    {
        while (true)
        {
            NewPoolManager.GetObject(_testEnemyPrefab.name, Vector3.zero, Quaternion.identity);

            yield return new WaitForSeconds(_spawnOffset);
        }
    }
}
