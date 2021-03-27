using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _testEnemyPrefab;

    [SerializeField] private float _spawnOffset = 1f;

    [SerializeField] private int _enemyCount = 10;
    private void Start()
    {
        StartCoroutine(SpawnEnemyes());
    }

    private IEnumerator SpawnEnemyes()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            Instantiate(_testEnemyPrefab, transform.position, Quaternion.identity, transform);

            yield return new WaitForSeconds(_spawnOffset);
        }
    }
}
