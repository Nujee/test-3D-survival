using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    [SerializeField] private int _damage;

    public void Init(int damage)
    {
        _damage = damage;
    }

    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<MyHealth>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
