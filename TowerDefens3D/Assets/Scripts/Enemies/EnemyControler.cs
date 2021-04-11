using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.Events;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;

    [SerializeField] private float _speed;

    [SerializeField] private float _maxHp = 40f;

    [SerializeField] private int _price = 37;

    public UnityAction<float, float> DamagedEvent;

    public float Hp { get { return _hp; } }

    private float _hp;

    private float _trewelledDistance;

    private void Start()
    {
        _hp = _maxHp;

        _pathCreator = GameObject.Find("Path").GetComponent<PathCreator>();

        transform.rotation = Quaternion.identity;
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

    public bool ApplyDamage(float dmg)
    {
        _hp -= dmg;

        if (_hp <= 0)
        {
            Death();
            return true;
        }

        DamagedEvent.Invoke(_hp, _maxHp);

        return false;
    }

    private void Death()
    {
        Destroy(gameObject);
        Money.AddMoney(_price);
    }
}
