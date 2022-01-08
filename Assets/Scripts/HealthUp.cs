using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] private int _bonusHP = 15;
    [SerializeField] private ParticleSystem _particleSystem;

    private MyHealth _playerHP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            _particleSystem.Play();
            _playerHP = other.gameObject.GetComponent<MyHealth>();
            _playerHP.TakeHeal(_bonusHP);

            foreach (MeshRenderer mesh in gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                mesh.enabled = false;
            }
            GetComponent<Collider>().enabled = false;

            Destroy(gameObject, 2f);
        }
    }
}
