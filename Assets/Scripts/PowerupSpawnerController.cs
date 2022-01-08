using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] _powerUpTypes;
    [SerializeField] private Transform[] _powerUpSpawners;
    private int _maxEnemyNum = 100;
    private int _curEnemyNum = 0;

    private void Awake()
    {
        InvokeRepeating("Spawn", 1, 5);
    }

    private void Spawn()
    {
        var randomType = _powerUpTypes[Random.Range(0, _powerUpTypes.Length)];
        var randomSpawner = _powerUpSpawners[Random.Range(0, _powerUpSpawners.Length)].position;
        Instantiate(randomType, randomSpawner, transform.rotation);
        _curEnemyNum++;

        if (_curEnemyNum >= _maxEnemyNum)
        {
            CancelInvoke();
        }
    }
}
