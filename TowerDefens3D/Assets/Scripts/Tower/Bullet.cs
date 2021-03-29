using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    [SerializeField] private float _dmg = 20;

    private Rigidbody _rigidbody;

    private Tower _parent;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 10);
        _parent = gameObject.GetComponentInParent<Tower>();
    }

    void FixedUpdate()
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
                _parent.RemoveEnemy(enemy);
            }
        }

        Destroy(gameObject);
      
    }
}
