using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPref;
    [SerializeField] private int _maxEnemyNum;

    private int _curEnemyNum;

    private void Awake()
    {
        InvokeRepeating("Spawn", 3, 2);
        _curEnemyNum = 0;
    }

    private void Spawn()
    {
        Instantiate(_enemyPref, transform.position, transform.rotation);
        _curEnemyNum++;
        if (_curEnemyNum >= _maxEnemyNum)
        {
            CancelInvoke();
        }
    }
}
