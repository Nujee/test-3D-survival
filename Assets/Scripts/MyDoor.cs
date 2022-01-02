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

        //for (int i = 0; i < _smoothness; i++)
        //{
        //    _gridTransform.position -= (transform.up * (_gridhHeight / _smoothness));
        //}

        //_gridTransform.position = Vector3.Lerp(_gridTransform.position, _gridTransform.position - (5 * Vector3.up), _smoothness);
    }
}
