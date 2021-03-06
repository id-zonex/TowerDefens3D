using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    [SerializeField] private float _dmg = 20;

    public float Damage 
    { 
        get => _dmg;
        set { _dmg = value; } 
    }

    private Rigidbody _rigidbody;

    private Tower _parent;

    void Awake()
    {
        Destroy(gameObject, 3);

        _rigidbody = GetComponent<Rigidbody>();
        _parent = gameObject.GetComponentInParent<Tower>();
    }


    private void FixedUpdate()
    {
        _rigidbody.AddRelativeForce(Vector3.forward * _speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        EnemyControler enemy = other.gameObject.GetComponent<EnemyControler>();


        if (enemy != null)
        {
            if (enemy.ApplyDamage(_dmg))
            {
                _parent?.towerReciplientEnemyes.RemoveEnemy(enemy);
            }
        }

        Destroy(gameObject);
    }
}
