using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerBase _spawner;

    [SerializeField] private List<SpawnerBase> _spawners;

    [SerializeField] private float _timeStep = 5f;

    private void Start()
    {
        if (_spawners.Count == 0)
        {
            Debug.Log("Start one spawner");
            _spawner = Instantiate(_spawner);
            StartSpawner(_spawner);
        }
        else
        {
            Debug.Log("Start spawners");
            InstantiateSpawners();
            StartCoroutine(StartSpawners());
        }
    }

    private void StartSpawner(ISpawner spawner)
    {
        StartCoroutine(spawner.Spawn(transform));
    }

    private IEnumerator StartSpawners()
    {
        foreach (var spawner in _spawners)
        {
            yield return StartCoroutine(spawner.Spawn(transform));
            yield return new WaitForSeconds(_timeStep);
        }
    }

    private void InstantiateSpawners()
    {
        for (int i = 0; i < _spawners.Count; i++)
        {
            _spawners[i] = Instantiate(_spawners[i]);
        }
    }
}
