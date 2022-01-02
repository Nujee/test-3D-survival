using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyMine : MonoBehaviour
{
    public UnityEvent OnTakeDamage;
    private Collider[] _hits;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            OnTakeDamage?.Invoke();
            Destroy(gameObject);
        }

    }
}
