using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoor : MonoBehaviour
{
    [SerializeField] private Transform _gridTransform;
    private float _gridhHeight = 5;

    public void Push()
    {
        GetComponent<Animator>().SetBool("Push", true);
    }
}
