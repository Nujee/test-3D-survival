using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// двигается по траектории "подковы", думаю, все из-за
// _trackingObjectTransform.y в лэйтапдейте, это ж кватрнион, а беру как эйлера
public class MyCamera : MonoBehaviour
{
    [SerializeField] private Transform _trackingObjectTransform;
    [SerializeField] private float _cameraOffset = 3f;
    [SerializeField] private float _cameraHeight = 1.5f;

    private Vector3 _targetPosition;
    private float _targetRotationAngle;

    private void FixedUpdate()
    {
        transform.LookAt(_trackingObjectTransform);
    }

    private void LateUpdate()
    {
        float cameraX = _targetPosition.x + _cameraOffset * Mathf.Sin(Mathf.PI * _trackingObjectTransform.rotation.y);
        float cameraY = _cameraHeight;
        float cameraZ = _targetPosition.z + _cameraOffset * Mathf.Cos(Mathf.PI * _trackingObjectTransform.rotation.y);

        transform.position = new Vector3(cameraX, cameraY, cameraZ);
    }
}
