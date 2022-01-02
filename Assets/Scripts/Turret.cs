using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _delay = 50;

    private void OnTriggerStay(Collider other)
    {
        TurnToTarget();
        if (other.CompareTag("Player"))
        {
            Fire();
        }
    }

    private void TurnToTarget()
    {
        transform.LookAt(_target);
    }

    private void Fire()
    {
        _delay--;

        if (_delay <= 0)
        {
            var bul = Instantiate(_bullet, _bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
            bul.Init(_damage);
            _delay = 50;
        }
    }
}
