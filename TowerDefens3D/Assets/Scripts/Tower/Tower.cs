using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerData))]
public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _trunk;

    [SerializeField] private GameObject _hitZonePrafab;
    [SerializeField] private GameObject _hitZone;

    private TowerData _towerData;

    private List<EnemyControler> _enemies = new List<EnemyControler>();

    private void Awake()
    {
        _towerData = GetComponent<TowerData>();

        SetHitZone();
    }


    private void FixedUpdate()
    {
        EnemyControler target;

        if (_enemies.Count > 0)
        {
            switch (_towerData.TargetingMode)
            {
                case TargetingMode.First:
                    target = TryGetCurrentEnemy();
                    break;
                case TargetingMode.Last:
                    target = _enemies[_enemies.Count - 1];
                    break;

                default:
                    target = target = TryGetCurrentEnemy();
                    break;
            }

            if(target != null)
            {
                float Ypos = Mathf.Clamp(target.transform.position.y, 0.2f, 3);

                _head.LookAt(new Vector3(target.transform.position.x, _head.position.y, target.transform.position.z));
                _trunk.LookAt(new Vector3(target.transform.position.x, Ypos, target.transform.position.z));

                _towerData.Gun.Shot(_trunk, transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyControler enemy = ParseEnemy(other.gameObject);

        if (enemy != null)
            _enemies.Add(ParseEnemy(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyControler enemy = ParseEnemy(other.gameObject);

        if(enemy != null)
            _enemies.Remove(ParseEnemy(other.gameObject));
    }

    public void EnableZone()
    {
        _hitZone.SetActive(true);
    }

    public void DesableZone()
    {
        _hitZone.SetActive(false);
    }

    public void RemoveEnemy(EnemyControler enemy)
    {
        _enemies.Remove(enemy);
    }

    private void SetHitZone()
    {
        float radius = _towerData.Radius;

        _hitZone = Instantiate(_hitZonePrafab);
        _hitZone.transform.position = transform.position;

        _hitZone.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);

        _hitZone.transform.parent = transform;

        _hitZone.SetActive(false);
    }

    private EnemyControler ParseEnemy(GameObject gameObject)
    {
        return gameObject.GetComponent<EnemyControler>();
    }

    private EnemyControler TryGetCurrentEnemy()
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
