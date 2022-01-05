using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform _camera;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("Camera").transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
    }
}
