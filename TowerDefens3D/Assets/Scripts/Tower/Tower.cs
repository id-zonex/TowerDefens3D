using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _trunk;

    [SerializeField] private Gun _gun;

    [SerializeField] private TargetingMode _targetingMode = TargetingMode.First;

    private List<EnemyControler> _enemies = new List<EnemyControler>();

    private enum TargetingMode
    {
        First,
        Last
    }

    private void Awake()
    {
        _gun = Instantiate(_gun);
    }


    private void FixedUpdate()
    {
        EnemyControler target;

        if (_enemies.Count > 0)
        {
            switch (_targetingMode)
            {
                case TargetingMode.First:
                    target = TryGetEnemy();
                    break;
                case TargetingMode.Last:
                    target = _enemies[_enemies.Count - 1];
                    break;

                default:
                    target = target = TryGetEnemy();
                    break;
            }

            if(target != null)
            {
                float Ypos = Mathf.Clamp(target.transform.position.y, 0.2f, 3);

                _head.LookAt(new Vector3(target.transform.position.x, _head.position.y, target.transform.position.z));
                _trunk.LookAt(new Vector3(target.transform.position.x, Ypos, target.transform.position.z));

                _gun.Shot(_trunk, transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}: Enter");

        EnemyControler enemy = ParseEnemy(other.gameObject);

        if (enemy != null)
            _enemies.Add(ParseEnemy(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name}: Exit");

        EnemyControler enemy = ParseEnemy(other.gameObject);

        if(enemy != null)
            _enemies.Remove(ParseEnemy(other.gameObject));
    }

    public void RemoveEnemy(EnemyControler enemy)
    {
        _enemies.Remove(enemy);
    }

    private EnemyControler ParseEnemy(GameObject gameObject)
    {
        return gameObject.GetComponent<EnemyControler>();
    }

    private EnemyControler TryGetEnemy()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            EnemyControler enemy = _enemies[i];

            if (enemy != null)
            {
                return enemy; 
            }
        }

        return null;
    }


}
