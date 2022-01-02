using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    void Update()
    {
        //var pos = target.position - transform.position;
        //Quaternion rot = Quaternion.LookRotation(pos);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);

        //var pos = target.position - transform.position;
        //var dir = Vector3.RotateTowards(transform.forward, pos, speed * Time.deltaTime, 0);
        //transform.rotation = Quaternion.LookRotation(dir);

        transform.LookAt(target);
    }
}
