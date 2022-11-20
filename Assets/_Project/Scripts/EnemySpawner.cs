using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    [AssetsOnly]
    private Enemy _enemyPrefab;
    [SerializeField]
    [ReadOnly]
    private float _delay = 3f;

    void Update()
    {
        _delay -= Time.deltaTime;
        if (_delay <= 0)
        {
            _delay += Random.Range(6f, 12f);
            float x = Random.Range(-1, 1f);
            float y = _enemyPrefab.transform.position.y;
            float z = Random.Range(0, 1f);
            GameObject enemy= Instantiate(_enemyPrefab.gameObject, transform);
            enemy.transform.forward = -new Vector3(x, 0, z);
            enemy.transform.position = (new Vector3(x, 0, z).normalized * 40f) + new Vector3(0, y, 0);
        }
    }
}
