using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemysSpawner", menuName = "EnemysSpawner")]
public class EnemysSpawner : SpawnerBase
{
    [SerializeField] private GameObject[] _enemyPrefabs;

    [SerializeField] private float _timeStep = 1f;

    public override IEnumerator Spawn(Transform _parent)
    {
        for (int i = 0; i < _enemyPrefabs.Length; i++)
        {
            Instantiate(_enemyPrefabs[i], _parent.position, Quaternion.identity, _parent);

            yield return new WaitForSeconds(_timeStep);
        }
    }
}
