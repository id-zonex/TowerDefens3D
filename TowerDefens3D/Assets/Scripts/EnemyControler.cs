using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;

    [SerializeField] private float _speed;

    public float Hp { get { return _hp; } }

    private float _trewelledDistance;

    private float _hp = 40f;


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

    public void ApplyDamage(float dmg)
    {
        _hp -= dmg;

        if (_hp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
