using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBomb : MonoBehaviour
{
    public int _bombDamage = 100;

    private void Awake()
    {
        Invoke("Explode", 3);
    }

    private void Explode()
    {
        var hits = Physics.OverlapSphere(transform.position, 3);
        foreach (var hit in hits)
        {
            if (hit.gameObject.GetComponent<MyHealth>())
            {
                hit.gameObject.GetComponent<MyHealth>().TakeDamage(_bombDamage);
            }
        }
        Destroy(gameObject);
    }
}
