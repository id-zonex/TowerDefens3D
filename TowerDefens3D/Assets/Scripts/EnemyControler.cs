using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;

    [SerializeField] private float _speed;

    private float _trewelledDistance;


    private void Start()
    {
        _pathCreator = GameObject.Find("Path").GetComponent<PathCreator>();
    }

    private void Update()
    {
        _trewelledDistance += _speed * Time.deltaTime;

        transform.position = _pathCreator.path.GetPointAtDistance(_trewelledDistance);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_trewelledDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "finish":
                Destroy(gameObject);
                break;

        }

    }

    public void ApplyDamage(int dmg)
    {
        Debug.Log($"{gameObject.name}, Ayyy");
    }
}
