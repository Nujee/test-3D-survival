using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] private int _bonusHP = 15;
    private MyHealth _playerHP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerHP = other.gameObject.GetComponent<MyHealth>();
            _playerHP.TakeHeal(_bonusHP);
            Destroy(gameObject);
        }
    }
}
