using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPref;
    [SerializeField] private Transform[] _enemySpawners;
    private int _maxEnemyNum = 100;
    private int _curEnemyNum = 0;

    public int _currentFragsNumber;

    private void Awake()
    {
        InvokeRepeating("Spawn", 3, 2);
    }

    private void Spawn()
    {
        var randomSpawner = _enemySpawners[Random.Range(0, _enemySpawners.Length)].position;
        Instantiate(_enemyPref, randomSpawner, transform.rotation);
        _curEnemyNum++;

        if (_curEnemyNum >= _maxEnemyNum)
        {
            CancelInvoke();
        }
    }
}
