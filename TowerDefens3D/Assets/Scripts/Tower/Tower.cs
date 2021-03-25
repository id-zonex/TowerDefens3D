using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _trunk;

    private List<EnemyControler> _enemies = new List<EnemyControler>();

    private void FixedUpdate()
    {
        if (_enemies.Count > 0)
        {
            EnemyControler target = _enemies[0];

            float Ypos = Mathf.Clamp(target.transform.position.y, 1, 3);

            _head.LookAt(new Vector3(target.transform.position.x, _head.position.y, target.transform.position.z));
            _trunk.LookAt(new Vector3(target.transform.position.x, Ypos, target.transform.position.z));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}: Enter");

        EnemyControler enemy = GetEnemy(other.gameObject);

        if (enemy != null)
            _enemies.Add(GetEnemy(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name}: Exit");

        EnemyControler enemy = GetEnemy(other.gameObject);

        if(enemy != null)
            _enemies.Remove(GetEnemy(other.gameObject));
    }

    private EnemyControler GetEnemy(GameObject gameObject)
    {
        return gameObject.GetComponent<EnemyControler>();
    }
}
