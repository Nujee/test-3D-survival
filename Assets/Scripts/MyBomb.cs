using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int _bombDamage = 15;

    private void Awake()
    {
        Invoke("Explode", 3);
    }

    private void Explode()
    {
        var hits = Physics.OverlapSphere(transform.position, 3);
        foreach (var hit in hits)
        {
            Debug.Log(hit.tag);
        }
        Destroy(gameObject);
    }
}
