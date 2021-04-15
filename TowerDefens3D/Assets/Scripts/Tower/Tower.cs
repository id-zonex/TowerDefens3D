using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(TowerData), typeof(SphereCollider))]
public class Tower : MonoBehaviour
{
    public static event UnityAction<Tower> OpenEvent;
    public static event UnityAction CloseEvent;

    [SerializeField] private Transform _head;
    [SerializeField] private Transform _trunk;

    [SerializeField] private GameObject _hitZonePrafab;
    [SerializeField] private GameObject _hitZone;

    public TowerData TowerData;

    private List<EnemyControler> _enemies = new List<EnemyControler>();

    #region Unity 
    private void Start()
    {
        TowerData = GetComponent<TowerData>();
        SetHitZone();
    }

    private void FixedUpdate()
    {
        EnemyControler target;

        if (_enemies.Count > 0)
        {
            target = GetCurrentEnemy();

            if(target != null)
            {
                Rotate(target);

                TowerData.Gun.Shot(_trunk, transform);
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

    public void OnMouseDown()
    {
        OpenEvent.Invoke(this);
    }


    #endregion


    #region Move
    private void Rotate(EnemyControler target)
    {
        float Ypos = Mathf.Clamp(target.transform.position.y, 0.2f, 3);

        _head.LookAt(new Vector3(target.transform.position.x, _head.position.y, target.transform.position.z));
        _trunk.LookAt(new Vector3(target.transform.position.x, Ypos, target.transform.position.z));
    }

    #endregion


    #region Hit zone
    public void EnableZone()
    {
        _hitZone.SetActive(true);
    }

    public void DesableZone()
    {
        _hitZone.SetActive(false);
    }

    private void SetHitZone()
    {
        float radius = TowerData.Radius;

        _hitZone = Instantiate(_hitZonePrafab);
        _hitZone.transform.position = transform.position;

        _hitZone.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);

        _hitZone.transform.parent = transform;

        _hitZone.SetActive(false);
    }

    #endregion

    #region Ways to get enemies
    public void RemoveEnemy(EnemyControler enemy)
    {
        _enemies.Remove(enemy);
    }

    protected EnemyControler ParseEnemy(GameObject gameObject)
    {
        return gameObject.GetComponent<EnemyControler>();
    }

    protected EnemyControler GetCurrentEnemy()
    {
        switch (TowerData.TargetingMode)
        {
            case TargetingMode.First:
                return TryGetFirstEnemy();
            case TargetingMode.Last:
                return _enemies[_enemies.Count - 1];
            default:
                return TryGetFirstEnemy();
        }
    }

    protected EnemyControler TryGetFirstEnemy()
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
    #endregion

}
