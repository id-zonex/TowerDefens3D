using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerBase _spawner;

    public float TimeStep = 5f;

    public List<SpawnerBase> Spawners;

    private void Start()
    {
        if (Spawners.Count == 0)
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
        foreach (var spawner in Spawners)
        {
            yield return StartCoroutine(spawner.Spawn(transform));
            yield return new WaitForSeconds(TimeStep);
        }
    }

    private void InstantiateSpawners()
    {
        for (int i = 0; i < Spawners.Count; i++)
        {
            Spawners[i] = Instantiate(Spawners[i]);
        }
    }
}
