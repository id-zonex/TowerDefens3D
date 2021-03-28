using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InfinityRandomSpawner", menuName = "InfinityRandomSpawner")]
public class InfinityRandomSpawner : SpawnerBase
{
    [SerializeField] private GameObject _testEnemyPrefab;

    [SerializeField] private float _spawnOffset = 1f;

    public override IEnumerator Spawn(Transform _parent)
    {
        while(true)
        {
            Instantiate(_testEnemyPrefab, _parent.position, Quaternion.identity, _parent);

            yield return new WaitForSeconds(_spawnOffset);
        }
    }
}
