using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CountedSpawner", menuName = "CountedSpawner")]
public class CountedSpawner : SpawnerBase
{
    [SerializeField] private GameObject _testEnemyPrefab;

    [SerializeField] private float _timeStep = 1f;
    [SerializeField] private int _enemyCount = 10;

    public override IEnumerator Spawn(Transform _parent)
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            Instantiate(_testEnemyPrefab, _parent.position, Quaternion.identity, _parent);

            yield return new WaitForSeconds(_timeStep);
        }
    }
}
