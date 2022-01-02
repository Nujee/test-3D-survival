using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyKey : MonoBehaviour
{
    public UnityEvent OnOpen;

    private void OnTriggerEnter(Collider other)
    {
        OnOpen?.Invoke();
    }
}
