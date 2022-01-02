using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] private float _bonusSpeedForce = 500f;
    [SerializeField] private float _bonusDuration = 5f;
    private Player _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpeedUpWearOff(_bonusDuration));
        }
    }

    IEnumerator SpeedUpWearOff(float bonusDuration)
    {
        foreach (MeshRenderer mesh in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            mesh.enabled = false;
        }
        GetComponent<Collider>().enabled = false;

        _player.SpeedForce += _bonusSpeedForce;
        yield return new WaitForSeconds(bonusDuration);
        _player.SpeedForce -= _bonusSpeedForce;

        Destroy(gameObject);
    }
}
